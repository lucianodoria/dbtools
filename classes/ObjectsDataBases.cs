using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace DBTools.classes
{
    public class ObjectsDataBases : MySqlConnectionClass 
    {
        public class DataBase
        {
            public int Id;
            public string Name;
            public DateTime CreateDate;
            public string Owner;
            public bool IsAccessible;
            public bool IsSystemObject;
            public int TablesCount;
            public int ViewsCount;
            public int StoredProceduresCount;
        }
        public class DataBases : CollectionBase
        {
            public DataBase this[int index]
            {
                get
                {
                    return (DataBase)this.List[index];
                }
                set
                {
                    this.List[index] = value;
                }
            }
            public int Add(DataBase dataBase)
            {
                return base.List.Add(dataBase);
            }
            public bool Contains(DataBase dataBase)
            {
                return base.List.Contains(dataBase);
            }
            public void Insert(int index, DataBase dataBase)
            {
                base.List.Insert(index, dataBase);
            }
            public void Remove(DataBase dataBase)
            {
                base.List.Remove(dataBase);
            }
        }
    
        private DataBases m_dataBases;

        public ObjectsDataBases()
        {
            m_dataBases = new DataBases(); 
        }

        public DataBases GetDataBases()
        {
            DataBases dataBases = new DataBases();

            try
            {
                m_dataBases.Clear();

                this.Conect(); 

                string query = "SHOW DATABASES";

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataBase dataBase = new DataBase();

                    dataBase.Id						= 0;
                    dataBase.Name					= dt.Rows[i]["Database"].ToString();
                    dataBase.CreateDate				= DateTime.Now;//Convert.ToDateTime(dt.Rows[i]["crdate"]);
                    dataBase.Owner					= string.Empty;
                    dataBase.TablesCount			= getTablesCount(dataBase.Name);
                    dataBase.ViewsCount				= getViewsCount(dataBase.Name);
                    dataBase.StoredProceduresCount	= getStoredProceduresCount(dataBase.Name);
                    dataBase.IsAccessible           = true;
                    dataBase.IsSystemObject         = false;

                    dataBases.Add(dataBase);
                }

                m_dataBases = dataBases;

                return dataBases;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private int getTablesCount(string dataBase)
        {
            try
            {
                string query = string.Format("SHOW TABLES FROM {0}", dataBase);

                DataTable dt = this.Query(query);

                return dt.Rows.Count;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private int getViewsCount(string dataBase)
        {
            try
            {
                string query = string.Format("SHOW TABLES FROM {0}", dataBase);

                DataTable dt = this.Query(query);

                return dt.Rows.Count;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private int getStoredProceduresCount(string dataBase)
        {
            try
            {
                string query = string.Format("SHOW TABLES FROM {0}", dataBase);

                DataTable dt = this.Query(query);

                return dt.Rows.Count;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
    }
}
