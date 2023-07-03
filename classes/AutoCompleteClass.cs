using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBTools.classes
{
    public class AutoCompleteClass
    {
        private struct ColumnsAutoComplete
		{
			public const int ObjectType	= 0;
			public const int ObjectName	= 1;
			public const int List		= 2;
		}
        public enum ObjectType
        {
            Table			= 1,
            View			= 2,
            StoredProcedure	= 3
        }

        private DataSet m_ds;

        public AutoCompleteClass()
        {
            m_ds = new DataSet("dsAutoComplete"); 
        }

        public void Clear(string dataBase)
        {
            if(!dataBaseExist(dataBase)){return;}

            m_ds.Tables[dataBase].Rows.Clear();  
        }
        public void AddDataTable(DataTable dt)
        {
            if(!dataBaseExist(dt.TableName))
            {
                m_ds.Tables.Add(dt);
            }
        }

        public List<string> GetList(string dataBase, string objectName)
        {
            List<string> textList = new List<string>(); 
 
            if(!dataBaseExist(dataBase)){return textList;}

            DataRow[] dr = m_ds.Tables[dataBase].Select(string.Format("ObjectName='{0}'", objectName));   

            if(dr.Length > 0)
            {
	            string[] parts = dr[0]["List"].ToString().Split(',');
	            textList = new List<string>(parts);
            }

            return textList; 
        }
        public List<string> GetListObjectsTypes(string dataBase, List<ObjectType> objectTypes)
        {
            List<string>	textList			= new List<string>();
            string			objectTypesValues	= "";
            bool			virgula				= false;

            if(!dataBaseExist(dataBase)){return textList;}

            foreach (var item in objectTypes)
            {
                if(virgula){objectTypesValues += ",";}
 
                objectTypesValues += "'" + ((int)item).ToString() + "'"; 

                virgula = true;
            }

            DataRow[] drs = m_ds.Tables[dataBase].Select(string.Format("ObjectType IN ({0})", objectTypesValues));   

            foreach (DataRow dr in drs)
            {
                textList.Add(dr["ObjectNameImg"].ToString());
            }

            return textList; 
        }
        public List<string> GetObjectsDB(string dataBase)
        {
            List<string> textList = new List<string>(); 

            if(!dataBaseExist(dataBase)){return textList;}

            foreach (DataRow dr in m_ds.Tables[dataBase].Rows)
            {
                textList.Add(dr["ObjectNameImg"].ToString());
            }

            return textList; 
        }
        public void SetKeywords(ScintillaNet.Scintilla scintilla, string dataBase)
        {
            List<ObjectType> objectTypes = new List<ObjectType>();
 
            objectTypes.Add(ObjectType.Table);
            objectTypes.Add(ObjectType.View);  
            objectTypes.Add(ObjectType.StoredProcedure);  

            List<string> listArray = GetListObjectsTypes(dataBase, objectTypes);

            scintilla.Lexing.SetKeywords(2, string.Join(" ", listArray)); 
        }

        private bool dataBaseExist(string dataBase)
        {
            try
            {
                return m_ds.Tables.Contains(dataBase);
            }
            catch
            {
                return false;
            }
        }
    }
}