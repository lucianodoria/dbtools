using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBTools.classes;
using System.Reflection;
using System.Xml;
using System.Threading;

namespace DBTools.forms
{
    public partial class frmGerenciadorWebService : Form
    {
        private WebServiceInvokerClass m_ws = new WebServiceInvokerClass();

        public frmGerenciadorWebService()
        {
            InitializeComponent();
        }

#region EVENTOS

        private void btnResgatar_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread(new ThreadStart(ResgatarMetodos));

                t.IsBackground = true;
                t.Start();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnGerarCodigoCSharp_Click(object sender, EventArgs e)
        {
            StringBuilder   sb          = new StringBuilder();
            string          objectName  = string.Empty; 

            try
            {
                objectName = "m_" + cboServicos.Text.ToLower();     

                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                List<string>  listMetodos       = new List<string>(); 

                Dictionary<string, MethodInfo> listMethodInfo = m_ws.ListMethodInfo;

                if(chkCriarCodigoTodosWebMetodos.Checked)
                {
                   listMetodos = m_ws.EnumerateServiceMethods(cboServicos.Text);  
                }
                else
                {
                    listMetodos.Add(cboMetodos.Text); 
                }

                pgbMetodos.Minimum  = 0;
                pgbMetodos.Maximum  = listMetodos.Count-1;
                pgbMetodos.Value    = 0;

                for (int m = 0; m < listMetodos.Count; m++)
                {
                    StringBuilder   sbParams                = new StringBuilder();
                    StringBuilder   sbParamsWithoutType     = new StringBuilder();
                    StringBuilder   sbParamsDocument        = new StringBuilder();
                    string          methodName              = string.Empty; 
                    string          returnType              = string.Empty;
                    string          paramsMethod            = string.Empty; 
                    string          paramsWithoutType       = string.Empty; 
                    int             tabsCountParamsMethod   = 0;
                    bool            isReturnType            = false;

                    MethodInfo methodInfo = listMethodInfo[listMetodos[m]];
                    ParameterInfo[] listParams = methodInfo.GetParameters();

                    methodName =  methodInfo.Name; 

                    bool isInserirVirgula = false;
                    bool isXmlElement = false;

                    #region Lista parâmetros do método

                    for (int i = 0; i < listParams.Length; i++)
                    {       
                        if(chkRemoverParametroUser.Checked)
                        {
                            if(listParams[i].ParameterType.Name == "User")
                            {
                                continue;
                            }
                        }

                        if(isInserirVirgula)
                        {
                            sbParams.Append("," + Environment.NewLine);
                            //sbParams.Append("\t\t\t\t\t");
                            sbParams.Append("{TABS}");
                        }

                        sbParams.Append(Funcoes.ConvertDataTypeDBToCSharp(listParams[i].ParameterType.Name) + " " + listParams[i].Name);
                        sbParamsDocument.Append("\t\t///<param name=\"" + listParams[i].Name + "\"></param>" + Environment.NewLine);

                        isInserirVirgula = true;
                    }

                    #endregion

                    #region Lista parâmetros do webservice

                    isInserirVirgula = false;

                    for (int i = 0; i < listParams.Length; i++)
                    {       
                        if(isInserirVirgula)
                        {
                            sbParamsWithoutType.Append("," + Environment.NewLine);
                            //sbParamsWithoutType.Append("\t\t\t\t\t");
                            sbParamsWithoutType.Append("{TABS}");
                        }

                        if(chkRemoverParametroUser.Checked)
                        {
                            if(listParams[i].ParameterType.Name == "User")
                            {
                                sbParamsWithoutType.Append("m_" + listParams[i].Name.ToLower());
                            }
                            else
                            {
                                sbParamsWithoutType.Append(listParams[i].Name);
                            }
                        }
                        else
                        {
                            sbParamsWithoutType.Append(listParams[i].Name);
                        }

                        isInserirVirgula = true;
                    }

                    #endregion

                    returnType = Funcoes.ConvertDataTypeDBToCSharp(methodInfo.ReturnParameter.ParameterType.Name); 

                    if(returnType.ToLower() != "void")
                    {
                        isReturnType = true; 
                    }

                    if(chkConverterXMLParaDataTable.Checked)
                    {
                        if(returnType.ToLower() == "xmlelement")
                        {
                            isXmlElement = true;
                            returnType = "DataTable";
                        }
                    }

                    sb.Append("\t\t/**************************************************************" + Environment.NewLine);
                    sb.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
                    sb.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
                    sb.Append("\t\t* Data de modificação	=" + Environment.NewLine);
                    sb.Append("\t\t**************************************************************/" + Environment.NewLine);
                    sb.Append("\t\t///<summary>" + Environment.NewLine);
                    sb.Append("\t\t///" + Environment.NewLine);
                    sb.Append("\t\t///</summary>" + Environment.NewLine);
                    sb.Append(sbParamsDocument.ToString());
 
                    if(isReturnType)
                    {
                        sb.Append("\t\t///<returns>Objeto " + returnType + ".</returns>" + Environment.NewLine);

                        if(chkAlterarSelectParaGet.Checked)
                        {
                            if(methodName.Length >= 6)
                            {
                                if(methodName.Substring(0, 6) == "Select")
                                {
                                    methodName = methodName.Replace("Select", "Get"); 
                                }
                            }
                        }
                    }

                    #region Calculando tabulação dos parâmetros do método

                    tabsCountParamsMethod = ("public " + returnType + " " + methodName  + "(").Length/4;
                    tabsCountParamsMethod += 2;
                               
                    paramsMethod =  sbParams.ToString().Replace("{TABS}", Funcoes.RepeatString("\t", tabsCountParamsMethod));
                    
                    #endregion

                    sb.Append("\t\tpublic " + returnType + " " + methodName  + "(" + paramsMethod + ")" + Environment.NewLine);
                    sb.Append("\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\ttry" + Environment.NewLine);
                    sb.Append("\t\t\t{" + Environment.NewLine);

                    #region Calculando tabulação padrão dos parâmetros do webservice

                    tabsCountParamsMethod = (objectName + "." + methodInfo.Name + "(").Length/4;
                    tabsCountParamsMethod += 4;
                                
                    paramsWithoutType =  sbParamsWithoutType.ToString().Replace("{TABS}", Funcoes.RepeatString("\t", tabsCountParamsMethod));

                    #endregion

                    if (isReturnType)
                    {
                        if(chkConverterXMLParaDataTable.Checked)
                        {
                            if(isXmlElement)
                            {
                                #region Calculando tabulação dos parâmetros do webservice

                                tabsCountParamsMethod = ("XmlElement xmle = " + objectName + "." + methodInfo.Name + "(").Length/4;
                                tabsCountParamsMethod += 4;
                                
                                paramsWithoutType =  sbParamsWithoutType.ToString().Replace("{TABS}", Funcoes.RepeatString("\t", tabsCountParamsMethod));

                                #endregion

                                sb.Append("\t\t\t\tXmlElement xmle = " + objectName + "." + methodInfo.Name + "(" + paramsWithoutType + ");" + Environment.NewLine + Environment.NewLine);
                                sb.Append("\t\t\t\treturn LDConverter.XMLElementToDataTable(xmle);" + Environment.NewLine);
                            }
                            else
                            {
                                sb.Append("\t\t\t\treturn " + objectName + "." + methodInfo.Name + "(" + paramsWithoutType + ");" + Environment.NewLine);
                            }
                        }
                        else
                        {
                            sb.Append("\t\t\t\treturn " + objectName + "." + methodInfo.Name + "(" + paramsWithoutType + ");" + Environment.NewLine);
                        }
                    }
                    else
                    {
                        sb.Append("\t\t\t\t" + objectName + "." + methodInfo.Name + "(" + paramsWithoutType + ");" + Environment.NewLine);
                    }

                    sb.Append("\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
                    sb.Append("\t\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
                    sb.Append("\t\t\t}" + Environment.NewLine);
                    sb.Append("\t\t}" + Environment.NewLine);

                    pgbMetodos.Value = m;
                }

                forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
                                                                                                 sb.ToString());

                formVisualizar.Text = "Visualizar - Método de utilização de WebService em C#";

                formVisualizar.ShowDialog();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ShowCursor(this, CursorType.Default);
            }
        }
        private void chkCriarCodigoTodosWebMetodos_CheckedChanged(object sender, EventArgs e)
        {
            cboMetodos.Enabled = !chkCriarCodigoTodosWebMetodos.Checked;
        }
        private void btnExportarExcelListaMetodos_Click(object sender, EventArgs e)
        {
            try
            {
                lvwMetodos.ExportToExcel();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

#endregion

#region FUNCOES

        private void ResgatarMetodos()
        {
            try
            {
                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                m_ws.OpenUri(new Uri(txtURL.Text.Trim())); 

                cboServicos.DataSource = m_ws.AvailableServices;

                if(cboServicos.Items.Count > 0)
                {
                    cboServicos.SelectedIndex = 0;

                    cboMetodos.DataSource = m_ws.EnumerateServiceMethods(cboServicos.Text);

                    PreencherListView();
                }
                //string service = "MyService";
                //string method = "MyMethod";

                //string[] args = new string[] { "arg1", "arg2" };

                //string result = invoker.InvokeMethod<string>(service, method, args);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                btnGerarCodigoCSharp.Enabled = true;
            }
        }
        private void PreencherListView()
        {
            List<string>  listMetodos = new List<string>(); 

            try
            {
                lvwMetodos.Items.Clear();
  
                Dictionary<string, MethodInfo> listMethodInfo = m_ws.ListMethodInfo;
            
                listMetodos = m_ws.EnumerateServiceMethods(cboServicos.Text);

                for (int i = 0; i < listMetodos.Count; i++)
                {
                    List<string> aDados = new List<string>();
 
                    MethodInfo methodInfo = listMethodInfo[listMetodos[i]];
                    
                    aDados.Add(methodInfo.Name);
                    aDados.Add(methodInfo.ReturnType.Name);
                    aDados.Add(methodInfo.GetParameters().Length.ToString());

                    lvwMetodos.Add(aDados, 0);   
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        #region Tools for SuperVisorWeb

        ///<summary>
        /// Converte o objeto XMLElement para um objeto DataTable.
        ///</summary>
        ///<param name="xmle">Objeto XMLElement a ser convertido.</param>
        ///<returns>Objeto DataTable.</returns>
        private DataTable ConvertXMLElementToDataTable(XmlElement xmle)
        {
            DataTable dt = new DataTable("SupervisorWeb");

            try
            {
                List<string>  listColumnNames = new List<string>(); 

                if (xmle.HasChildNodes)
                {
                    //Criamos um objeto da classe XmlNodeList que contém o XPath
                    XmlNodeList No = xmle.ChildNodes[0].ChildNodes; 

                    #region Adiciona nomes das colunas

                    for (int c = 0; c < No[0].ChildNodes.Count; c++)
                    {
                        listColumnNames.Add(No[0].ChildNodes[c].Name);
                    }

                    #endregion

                    dt = CreateDataTable(listColumnNames);

                    #region Adiciona valores nos campos
                    //Percorre todos os elementos contidos no objeto No e exibe o valor dos elementos-filhos
                    for (int i = 0; i < No.Count; i++)
                    {
                        List<string>  aDados = new List<string>(); 

                        for (int c = 0; c < No[i].ChildNodes.Count; c++)
                        {
                            aDados.Add(No[i].ChildNodes[c].InnerText);
                        }

                        #region Adiciona dados na tabela
                        string[] strDados = new string[aDados.Count];

                        for (int y = 0; y < aDados.Count; y++)
                        {
                            strDados[y] = aDados[y].ToString();
                        }

                        dt.Rows.Add(strDados);
                        #endregion
                    }
                    #endregion
                }

                return dt;
            }
            catch
            {
                return dt;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCollumName"></param>
        /// <returns></returns>
        private DataTable CreateDataTable(List<string> collumnsName)
        {
            DataTable dtTemp = new DataTable();

            try
            {
                for (int i = 0; i < collumnsName.Count; i++)
                {
                    dtTemp.Columns.Add(collumnsName[i], typeof(string));
                }

                return dtTemp;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }

        #endregion   

#endregion
    }
}
