using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBTools.classes.ObjectsClass;
using System.Data;

namespace DBTools.classes
{
    public class SqlObjectsClass
    {
        public IDataBaseObjects _iDataBaseObjects;

        /// <summary>
        /// Resgata as Tabelas em cache. 
        /// </summary>
        public Tables TablesCache
        {
            get { return _iDataBaseObjects.GetTablesCache(); }
        }
        /// <summary>
        /// Resgata as Views em cache. 
        /// </summary>
        public Views ViewsCache
        {
            get { return _iDataBaseObjects.GetViewsCache(); }
        }
        /// <summary>
        /// Resgata as StoredProcedures Views em cache. 
        /// </summary>
        public StoredProcedures StoredProceduresCache
        {
            get { return _iDataBaseObjects.GetStoredProceduresCache(); }
        }  


        public SqlObjectsClass(ServerType serverType)
        {
            if(serverType == ServerType.SQLServer)
            {
                this._iDataBaseObjects = new SqlServerObjectsClass();
            }
            else
            {
                this._iDataBaseObjects = new MySqlObjectsClass();
            }
        }
                
        public void Conect()
        {
            _iDataBaseObjects.Conect();  
        }
		public void Open()
        {
            _iDataBaseObjects.Open(); 
        }
		public void Close()
        {
            _iDataBaseObjects.Close(); 
        }

		public System.Data.DataTable Query(string query)
        {
            return _iDataBaseObjects.Query(query); 
        }
		public void QueryCommand(string queryCommand)
        {
            _iDataBaseObjects.QueryCommand(queryCommand); 
        }

        public void InitConfig(ConnectionStringBuilder connBuilder)
        {
            _iDataBaseObjects.InitConfig(connBuilder);  
        }

        public Table GetTableByID(int id)
        {
            return _iDataBaseObjects.GetTableByID(id);
        }
        public Table GetTableByName(string name)
        {
            return _iDataBaseObjects.GetTableByName(name);    
        }
        public Tables GetTables()
        {
            return _iDataBaseObjects.GetTables(); 
        }
        public Tables GetTables(bool showSystemObject)
        {
            return _iDataBaseObjects.GetTables(); 
        }

        public Views GetViews()
        {
            return _iDataBaseObjects.GetViews(); 
        }
        public Views GetViews(bool showSystemObject)
        {
            return _iDataBaseObjects.GetViews(showSystemObject);
        }

        public StoredProcedures GetStoredProcedures()
        {
            return _iDataBaseObjects.GetStoredProcedures(); 
        }
        public StoredProcedures GetStoredProcedures(bool showSystemObject)
        {
            return _iDataBaseObjects.GetStoredProcedures(showSystemObject); 
        }

        public Columns GetColumns(Table table)
        {
            return _iDataBaseObjects.GetColumns(table); 
        }
        public Columns GetColumns(View view)
        {
            return _iDataBaseObjects.GetColumns(view); 
        }
        public Columns GetColumns(object objectItem)
        {
            return _iDataBaseObjects.GetColumns(objectItem); 
        }
  
        public StoredProcedureParameters GetStoredProcedureParameters(StoredProcedure sp)
        {
            return _iDataBaseObjects.GetStoredProcedureParameters(sp); 
        }

        public DataTable GetAutoCompleteList()
        {
            return _iDataBaseObjects.GetAutoCompleteList(); 
        }

        public string GetText(View view)
        {
            return _iDataBaseObjects.GetText(view); 
        }
        public string GetText(StoredProcedure sp)
        {
            return _iDataBaseObjects.GetText(sp); 
        }
        public void SetRowCount(ref Table table)
        {
            _iDataBaseObjects.SetRowCount(ref table); 
        }
        public int GetRowCount(Table table)
        {
            return _iDataBaseObjects.GetRowCount(table); 
        }
    }
}
