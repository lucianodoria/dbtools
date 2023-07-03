using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTools.classes
{
    public class Field
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        /// 
        /// </summary>
        public string Type {get; set;}
        /// <summary>
        /// 
        /// </summary>
        public string Label {get; set;} 
        /// <summary>
        /// 
        /// </summary>
        public string Description {get; set;}
        public bool Required {get; set;}
        
        /*public string Default_ {get; set;}
        public string Readonly_ {get; set;}
        public string Class_ {get; set;} */
        
        public Field() {}
    }

    public class TextField : Field
    {
        public string Default_ {get; set;}
        public bool Readonly_ {get; set;}
        public string Class_ {get; set;}
        public int Size  {get; set;}
        public int Maxlength  {get; set;}
        public bool Disabled  {get; set;}
        public string Filter  {get; set;}
        
        public TextField() {}

        public string GetXMLField()
        {
            return "";
        }
    }
}
