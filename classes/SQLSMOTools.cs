using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DBTools.classes
{
    public class SQLSmoTools
    {
        private Microsoft.SqlServer.Management.Smo.Server   m_sqlServer;
        private SqlConnectionStringBuilder m_connBuilder;
        private string m_dataBase;
        public Microsoft.SqlServer.Management.Smo.Server Server
        {
            get { return m_sqlServer; }
            set { m_sqlServer = value; }
        }
        public Microsoft.SqlServer.Management.Smo.DatabaseCollection Databases
        {
            get { return m_sqlServer.Databases; }
        }
        public string ServerName
        {
            get { return m_connBuilder.DataSource; }
            set { m_connBuilder.DataSource = value; }
        }
        public string UserName
        {
            get { return m_connBuilder.UserID; }
            set { m_connBuilder.UserID = value; }
        }
        public string Password
        {
            get { return m_connBuilder.Password; }
            set { m_connBuilder.Password = value; }
        }
        public bool IntegratedSecurity
        {
            get { return m_connBuilder.IntegratedSecurity; }
            set { m_connBuilder.IntegratedSecurity = value; }
        }

        public string DataBaseQuery
        {
            get {return m_dataBase;}
            set { m_dataBase = value; }
        }

        public SQLSmoTools()
        {
            m_connBuilder = new SqlConnectionStringBuilder();
        }

        /// <summary>
        /// Conecta no servidor
        /// </summary>
        public bool Connect()
        {
            try
            {
                SqlConnection conn = new SqlConnection(m_connBuilder.ConnectionString);  

                Microsoft.SqlServer.Management.Common.ServerConnection serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(conn);
 
                m_sqlServer = new Microsoft.SqlServer.Management.Smo.Server(serverConnection); 

                return true;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// DisConnects this.Connection
        /// </summary>
        public bool DisConnect()
        {
            try
            {
                if(m_sqlServer != null)
                {
                    m_sqlServer.ConnectionContext.Disconnect(); 
                }

                return true;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata uma Tabela pelo id.
        /// </summary>
        /// <param name="name">Id da tabela</param>
        /// <returns></returns>
        public Microsoft.SqlServer.Management.Smo.Table GetTableById(int id)
        {
            try
            {
                m_sqlServer.Databases[m_dataBase].Tables.Refresh(true);  
                return m_sqlServer.Databases[m_dataBase].Tables.ItemById(id); 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata lista de Tabelas.
        /// </summary>
        /// <param name="dataBaseName">Nome do Banco de Dados</param>
        /// <returns>Retorna tabelas do Banco de Dados</returns>
        public Microsoft.SqlServer.Management.Smo.TableCollection GetTables()
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].Tables; 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata lista de Views.
        /// </summary>
        /// <param name="dataBaseName">Nome do Banco de Dados</param>
        /// <returns>Retorna tabelas do Banco de Dados</returns>
        public Microsoft.SqlServer.Management.Smo.ViewCollection GetViews()
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].Views; 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata uma View pelo id.
        /// </summary>
        /// <param name="name">Id da View</param>
        /// <returns></returns>
        public Microsoft.SqlServer.Management.Smo.View GetViewById(int id)
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].Views.ItemById(id); 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata lista de Stored Procedures.
        /// </summary>
        /// <returns>Retorna todas as StoredProcedures</returns>
        public Microsoft.SqlServer.Management.Smo.StoredProcedureCollection GetStoredProcedures()
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].StoredProcedures; 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata uma Stored Procedures pelo id.
        /// </summary>
        /// <param name="name">Id da StoredProcedure</param>
        /// <returns></returns>
        public Microsoft.SqlServer.Management.Smo.StoredProcedure GetStoredProcedureById(int id)
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].StoredProcedures.ItemById(id); 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Resgata uma Stored Procedures pelo nome.
        /// </summary>
        /// <param name="name">Nome da StoredProcedure</param>
        /// <returns></returns>
        public Microsoft.SqlServer.Management.Smo.StoredProcedure GetStoredProcedureByName(string name)
        {
            try
            {
                return m_sqlServer.Databases[m_dataBase].StoredProcedures[name]; 
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="sqlCommand">Informe uma consulta SQL ou uma View.</param>
		/// <returns>Retorna um DataTable</returns>
		public System.Data.DataTable Query(string sqlCommand)
		{
			try
			{
                return m_sqlServer.Databases[m_dataBase].ExecuteWithResults(sqlCommand).Tables[0];
			}
			catch (Exception e)
			{
				throw e;
			}
		}
        /// <summary>
        /// Executa uma instrução SQL de Update. Delete e SP.
        /// </summary>
        /// <param name="sqlCommand">Informe uma SQL command ou uma SP</param>
        public void ExecuteNonQuery(string sqlCommand)
		{
			try
			{
                m_sqlServer.Databases[m_dataBase].ExecuteNonQuery(sqlCommand);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
        /// <summary>
        /// Executa uma instrução SQL de Update. Delete e SP.
        /// </summary>
        /// <param name="sqlCommand">Informe uma SQL command ou uma SP</param>
        /// <param name="executionTypes"></param>
        public void ExecuteNonQuery(string sqlCommand, Microsoft.SqlServer.Management.Common.ExecutionTypes executionTypes)
        {
            try
            {
                m_sqlServer.Databases[m_dataBase].ExecuteNonQuery(sqlCommand, executionTypes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Atualiza as Views.
        /// </summary>
        public void RefreshViews()
        {
            try
            {
                m_sqlServer.Databases[m_dataBase].Views.Refresh(true);  
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        /// <summary>
        /// Atualiza as StoredProcedures.
        /// </summary>
        public void RefreshStoredProcedures()
        {
            try
            {
                m_sqlServer.Databases[m_dataBase].StoredProcedures.Refresh(true);  
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}
