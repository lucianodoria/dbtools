using System;
using MySql.Data;
using MySql.Data.MySqlClient;

public class MySqlConnectionClass
{
    private MySqlConnection m_conn;
    private string _serverName;
    private string _dataBase;
    private string _userName;
    private string _password;
    private int _connectTimeout;

    /// <summary>
    /// Informe o nome do Servidor a ser conectado.
    /// </summary>
    public string ServerName
    {
        get { return _serverName; }
        set { _serverName = value; }
    }
    /// <summary>
    /// Informe o nome do Banco a ser acessado.
    /// </summary>
    public string DataBaseName
    {
        get { return _dataBase; }
        set { _dataBase = value; }
    }
    /// <summary>
    /// Informe o usuário a se conectar no Servidor.
    /// </summary>
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }
    /// <summary>
    /// Informe a senha a se conectar no Servidor.
    /// </summary>
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    /// <summary>
    /// Informe o tempo para expirar ao tentar fazer uma conexão.
    /// </summary>
    public int ConnectTimeout
    {
        get { return _connectTimeout; }
        set { _connectTimeout = value; }
    }
    /// <summary>
    /// ConnectionString da conexão.
    /// </summary>
    public string ConnectionString
    {
        get { return m_conn.ConnectionString; }
    }
    public MySqlConnectionClass() { }

    /// <summary>
    /// Função para conectar no banco.
    /// </summary>
    public void Conect()
    {
        try
        {
            m_conn = new MySqlConnection();
            //m_conn.ConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4};", ServerName, DataBaseName, UserName, Password, 3306);
            m_conn.ConnectionString = string.Format("Server={0};User Id={2};Password={3};Port={4};Database={1};Convert Zero Datetime=True;Allow Zero Datetime=True", ServerName, DataBaseName.IsNullOrEmpty() ? "mysql" : DataBaseName, UserName, Password, 3306);
        }
        catch (Exception e)
        {
            m_conn = null;
            throw e;
        }
    }
    ///// <summary>
    ///// Função para conectar no banco.
    ///// </summary>
    ///// <param name="ConnectionString">String de conexão</param>
    //public void Conect(string connectionString)
    //{
    //    try
    //    {
    //        m_connBuilder.ConnectionString = connectionString;

    //        this.Conect(); 
    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }
    //}
    ///// <summary>
    ///// Função para conectar no banco.
    ///// </summary>
    ///// <param name="connBuilder">String de conexão</param>
    //public void Conect(SqlConnectionStringBuilder connBuilder)
    //{
    //    try
    //    {
    //        m_connBuilder = connBuilder;

    //        this.Conect(); 
    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }
    //}

    /// <summary>
    /// Função para conectar no banco.
    /// </summary>
    public void Open()
    {
        try
        {
            this.Close();
            m_conn.Open();
        }
        catch (Exception e)
        {
            m_conn = null;
            throw e;
        }
    }
    /// <summary>
    /// Fecha conexão com o Banco.
    /// </summary>
    public void Close()
    {
        try
        {
            if (m_conn != null)
            {
                m_conn.Close();
            }
        }
        catch (Exception e)
        {
            m_conn = null;
            throw e;
        }
    }

    ///// <summary>
    ///// Função para gerar uma consulta.
    ///// </summary>
    ///// <param name="query">Informe uma consulta SQL.</param>
    ///// <returns>Retorna um SqlDataReader</returns>
    //public SqlDataReader Query(string query, CommandBehavior cb)
    //{
    //    try
    //    {
    //        this.Open();

    //        SqlCommand sqlCommand = new SqlCommand(query, m_conn);

    //        SqlDataReader dr = sqlCommand.ExecuteReader(cb);  

    //        this.Close(); 

    //        return dr;
    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }
    //}

    /// <summary>
    /// Função para gerar uma consulta.
    /// </summary>
    /// <param name="query">Informe uma consulta SQL.</param>
    /// <returns>Retorna um DataTable</returns>
    public System.Data.DataTable Query(string query)
    {
        try
        {
            this.Open();

            MySqlCommand sqlCommand = new MySqlCommand(query, m_conn);

            sqlCommand.CommandTimeout = 360;

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);

            System.Data.DataTable dt = new System.Data.DataTable();

            sqlDataAdapter.Fill(dt);

            this.Close();

            return dt;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    /// <summary>
    /// Insere, edita ou exclui dados do banco
    /// </summary>
    /// <param name="sComandoSQL">Instrução SQL (Ex.: INSERT, UPDATE ou DELETE)</param>
    public void QueryCommand(string queryCommand)
    {
        try
        {
            this.Open();

            MySqlCommand sqlCommand = new MySqlCommand(queryCommand, m_conn);

            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            this.Close();
        }
    }
    /// <summary>
    /// Insere registro no do banco e retorna o ID
    /// </summary>
    /// <param name="sComandoSQL">Instrução SQL (Ex.: INSERT, UPDATE ou DELETE)</param>
    public long QueryCommandInsert(string queryCommand)
    {
        try
        {
            this.Open();

            MySqlCommand sqlCommand = new MySqlCommand(queryCommand, m_conn);

            sqlCommand.ExecuteNonQuery();

            return sqlCommand.LastInsertedId;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            this.Close();
        }
    }
}
