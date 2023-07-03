﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml;

namespace DBTools.classes
{
    public class WebServiceInvokerClass
    {
        private Assembly m_webServiceAssembly;
        private List<string> m_services;
        private Dictionary<string, MethodInfo> m_listMethodInfo;
        private Dictionary<string, Type> m_availableTypes;
 
        /// <summary>
        /// Text description of the available services within this web service.
        /// </summary>
        public List<string> AvailableServices
        {
            get{ return this.m_services; }
        }
        /// <summary>
        /// Retorna a lista de métodos do webservice.
        /// </summary>
        public Dictionary<string, MethodInfo> ListMethodInfo
        {
            get { return m_listMethodInfo; }
            set { m_listMethodInfo = value; }
        }

        /// <summary>
        /// Creates the service invoker using the specified web service.
        /// </summary>
        /// <param name="webServiceUri"></param>
        public WebServiceInvokerClass()
        {
        }

        public void OpenUri(Uri webServiceUri)
        {
            this.m_services         = new List<string>(); // available services
            this.m_availableTypes   = new Dictionary<string, Type>(); // available types
            this.m_listMethodInfo   = new Dictionary<string,MethodInfo>(); 
            // create an assembly from the web service description
            this.m_webServiceAssembly = BuildAssemblyFromWSDL(webServiceUri);
 
            // see what service types are available
            Type[] types = this.m_webServiceAssembly.GetExportedTypes();
 
            // and save them
            foreach (Type type in types)
            {
                m_services.Add(type.FullName);
                m_availableTypes.Add(type.FullName, type);
            }
        }
 
        /// <summary>
        /// Gets a list of all methods available for the specified service.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public List<string> EnumerateServiceMethods(string serviceName)
        {
            this.m_listMethodInfo.Clear();
 
            List<string> methods = new List<string>();
 
            if (!this.m_availableTypes.ContainsKey(serviceName))
                throw new Exception("Service Not Available");
            else
            {
                Type type = this.m_availableTypes[serviceName];
 
                // only find methods of this object type (the one we generated)
                // we don't want inherited members (this type inherited from SoapHttpClientProtocol)
                foreach (MethodInfo minfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {
                    methods.Add(minfo.Name);

                    this.m_listMethodInfo.Add(minfo.Name, minfo); 
                }
 
                return methods;
            }
        }
 
        /// <summary>
        /// Invokes the specified method of the named service.
        /// </summary>
        /// <typeparam name="T">The expected return type.</typeparam>
        /// <param name="serviceName">The name of the service to use.</param>
        /// <param name="methodName">The name of the method to call.</param>
        /// <param name="args">The arguments to the method.</param>
        /// <returns>The return value from the web service method.</returns>
        public T InvokeMethod<T>( string serviceName, string methodName, params object[] args )
        {
            // create an instance of the specified service
            // and invoke the method
            object obj = this.m_webServiceAssembly.CreateInstance(serviceName);
 
            Type type = obj.GetType();
 
            return (T)type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, args);
        }
 
        /// <summary>
        /// Builds the web service description importer, which allows us to generate a proxy class based on the 
        /// content of the WSDL described by the XmlTextReader.
        /// </summary>
        /// <param name="xmlreader">The WSDL content, described by XML.</param>
        /// <returns>A ServiceDescriptionImporter that can be used to create a proxy class.</returns>
        private ServiceDescriptionImporter BuildServiceDescriptionImporter( XmlTextReader xmlreader )
        {
            // make sure xml describes a valid wsdl
            if (!ServiceDescription.CanRead(xmlreader))
                throw new Exception("Invalid Web Service Description");
 
            // parse wsdl
            ServiceDescription serviceDescription = ServiceDescription.Read(xmlreader);
 
            // build an importer, that assumes the SOAP protocol, client binding, and generates properties
            ServiceDescriptionImporter descriptionImporter = new ServiceDescriptionImporter();
            descriptionImporter.ProtocolName = "Soap12";
            descriptionImporter.AddServiceDescription(serviceDescription, null, null);
            descriptionImporter.Style = ServiceDescriptionImportStyle.Client;
            descriptionImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
 
            return descriptionImporter;
        }
 
        /// <summary>
        /// Compiles an assembly from the proxy class provided by the ServiceDescriptionImporter.
        /// </summary>
        /// <param name="descriptionImporter"></param>
        /// <returns>An assembly that can be used to execute the web service methods.</returns>
        private Assembly CompileAssembly(ServiceDescriptionImporter descriptionImporter)
        {
            // a namespace and compile unit are needed by importer
            CodeNamespace codeNamespace = new CodeNamespace();
            CodeCompileUnit codeUnit = new CodeCompileUnit();
 
            codeUnit.Namespaces.Add(codeNamespace);
 
            ServiceDescriptionImportWarnings importWarnings = descriptionImporter.Import(codeNamespace, codeUnit);
 
            if (importWarnings == 0) // no warnings
            {
                // create a c# compiler
                CodeDomProvider compiler = CodeDomProvider.CreateProvider("CSharp");
 
                // include the assembly references needed to compile
                string[] references = new string[3] { "System.Web.Services.dll", "System.Xml.dll", "System.Data.dll" };
 
                CompilerParameters parameters = new CompilerParameters(references);
 
                // compile into assembly
                CompilerResults results = compiler.CompileAssemblyFromDom(parameters, codeUnit);
 
                foreach (CompilerError oops in results.Errors)
                {
                    // trap these errors and make them available to exception object
                    throw new Exception("Compilation Error Creating Assembly");
                }
 
                // all done....
                return results.CompiledAssembly;
            }
            else
            {
                // warnings issued from importers, something wrong with WSDL
                throw new Exception("Invalid WSDL");
            }
        }
 
        /// <summary>
        /// Builds an assembly from a web service description.
        /// The assembly can be used to execute the web service methods.
        /// </summary>
        /// <param name="webServiceUri">Location of WSDL.</param>
        /// <returns>A web service assembly.</returns>
        private Assembly BuildAssemblyFromWSDL(Uri webServiceUri)
        {
            if (String.IsNullOrEmpty(webServiceUri.ToString()))
                throw new Exception("Web Service Not Found");
 
            XmlTextReader xmlreader = new XmlTextReader(webServiceUri.ToString() + "?wsdl");
 
            ServiceDescriptionImporter descriptionImporter = BuildServiceDescriptionImporter(xmlreader);
 
            return CompileAssembly(descriptionImporter);
        }

    }
}
