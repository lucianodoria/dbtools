using System;
using System.Data;
using System.Data.SqlClient;

	public class clsConexao
	{
		public static SqlConnection Conn;

		public clsConexao(){}
		
		#region VARIAVEIS DE CONEXAO
		private string _Senha			= string.Empty;
		private string _Usuario			= string.Empty;
		private string _Servidor		= string.Empty;
		private string _Banco			= string.Empty;
		private string _ConnectTimeout	= string.Empty;
		#endregion

		#region PROPRIEDADES DE CONEXOES

		/// <summary>
		/// Informe o usuário a se conectar no Servidor.
		/// </summary>
		public string Usuario
		{
			set
			{
				_Usuario = value;
			}
		}

		/// <summary>
		/// Informe a senha a se conectar no Servidor.
		/// </summary>
		public string Senha
		{
			set
			{
				_Senha = value;
			}
		}
		
		/// <summary>
		/// Informe o nome do Servidor a ser conectado.
		/// </summary>
		public string Servidor
		{
			set
			{
				_Servidor = value;
			}
		}

		/// <summary>
		/// Informe o nome do Banco a ser acessado.
		/// </summary>
		public string Banco
		{
			set
			{
				_Banco = value;
			}
		}

		/// <summary>
		/// Informe o tempo para expirar ao tentar fazer uma conexão.
		/// </summary>
		public int ConnectTimeout
		{
			set
			{
				_ConnectTimeout = ";Connect Timeout=" + value.ToString();
			}
		}

		
		#endregion

		/// <summary>
		/// Função para conectar no banco.
		/// </summary>
		public void Conectar()
		{
			try
			{
				Conn = new SqlConnection();
				Conn.ConnectionString = String.Concat(new string[]{"Data Source=", _Servidor, ";Initial Catalog=", _Banco, ";uid=", _Usuario, ";pwd=", _Senha,
																   ";Enlist=false", ";Pooling=true", _ConnectTimeout});			
				Conn.Open(); 				 
			}
			catch (Exception e)
			{
				Conn = null;
				throw e;
			}
		
		}

		/// <summary>
		/// Função para conectar no banco.
		/// </summary>
		/// <param name="ConnectionString">String de conexão</param>
		public void Conectar(string ConnectionString)
		{
			try
			{
				Conn = new SqlConnection();
				Conn.ConnectionString = ConnectionString;
								
				Conn.Open(); 	 
			}
			catch (Exception e)
			{
				Conn = null;
				throw e;
			}
		
		}

		/// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="sViewSQL">Informe uma consulta SQL ou uma View.</param>
		/// <returns>Retorna um SqlDataReader</returns>
		public SqlDataReader Consultar(string sViewSQL, CommandBehavior cb)
		{
			SqlCommand sqlCommand = new SqlCommand(sViewSQL, Conn);
			SqlDataReader dr = sqlCommand.ExecuteReader(cb);  
					
			return dr;
		}

		/// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="sViewSQL">Informe uma consulta SQL ou uma View.</param>
		/// <returns>Retorna um DateSet com o nome da tebela de: TB_LIGACAO</returns>
		public DataSet Consultar(string sSQL)
		{
			try
			{
				SqlCommand sqlCommand = new SqlCommand(sSQL, Conn);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				
				DataSet dst = new DataSet(); 

				sqlDataAdapter.Fill(dst, "TABELA");
				
				return dst;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="sViewSQL">Informe uma consulta SQL ou uma View.</param>
		/// <returns>Retorna um DataTable</returns>
		public DataTable Consultar_DataTable(string sSQL)
		{
			try
			{
				SqlCommand sqlCommand = new SqlCommand(sSQL, Conn);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				
				DataTable dt = new DataTable(); 

				sqlDataAdapter.Fill(dt);
				
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
		public void InstrucaoSQL(string sComandoSQL)
		{
			SqlCommand CMD = new SqlCommand(sComandoSQL, Conn);
			CMD.ExecuteNonQuery();
		}
		
		public SqlDataReader BPMI_Consultar_AC(int MCT)
		{			
			SqlCommand Comando = new SqlCommand("SP_PJCAM_VEICULO", Conn);
			Comando.CommandType = CommandType.StoredProcedure;

            Comando.Parameters.AddWithValue("@NR_MCT", MCT);

			SqlDataReader dr  = Comando.ExecuteReader();  

			return dr;
		}

		/// <summary>
		/// Fecha conexão com o Banco.
		/// </summary>
		public void Fechar()
		{
			if(Conn != null)
			{
				Conn.Close();
			}
		}

	}
