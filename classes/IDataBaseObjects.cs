using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DBTools.classes.ObjectsClass;

namespace DBTools.classes
{
    public class ConnectionStringBuilder
    {
        public string ServerName;
        public string DataBase;
        public string UserName;
        public string Password;
        public int    ConnectTimeout;
        public bool IntegratedSecurity;
    }

    public interface IDataBaseObjects
    { 
        Tables GetTablesCache();
        Views GetViewsCache();
        StoredProcedures GetStoredProceduresCache();

		void Conect();
		void Open();
		void Close();
		System.Data.DataTable Query(string query);
		void QueryCommand(string queryCommand);
        void InitConfig(ConnectionStringBuilder connBuilder);

        Table GetTableByID(int id);
        Table GetTableByName(string name);
        Tables GetTables();
        Tables GetTables(bool showSystemObject);

        Views GetViews();
        Views GetViews(bool showSystemObject);

        StoredProcedures GetStoredProcedures();
        StoredProcedures GetStoredProcedures(bool showSystemObject);

        Columns GetColumns(Table table);
        Columns GetColumns(View view);
        Columns GetColumns(object objectItem);
  
        StoredProcedureParameters GetStoredProcedureParameters(StoredProcedure sp);

        DataTable GetAutoCompleteList();

        string GetText(View view);
        string GetText(StoredProcedure sp);
        void SetRowCount(ref Table table);
        int GetRowCount(Table table);
    }
}
