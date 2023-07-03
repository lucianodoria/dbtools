using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBTools.classes;
using System.Threading;
using DBTools.forms.graficos;
using System.Collections.Specialized;
using System.Data.SqlClient;
using DBTools.classes.ObjectsClass;
using Microsoft.SqlServer.Management.Sdk.Sfc;

public struct NodeTag
{
	public bool         Expand;
	public object       Tag;
	public object       Object;
	public ConnectionClass   Connection;
	public string       DataBase;

	public Table GetTable()
	{
		try
		{
		return (Table)this.Tag;
		}
		catch(Exception exc)
		{
			throw(exc); 
		}
	}
	public DBTools.classes.ObjectsClass.View GetView()
	{
		try
		{
			return (DBTools.classes.ObjectsClass.View)this.Tag;
		}
		catch(Exception exc)
		{
			throw(exc); 
		}
	}
	public StoredProcedure GetStoredProcedure()
	{
		try
		{
			return (StoredProcedure)this.Tag;
		}
		catch(Exception exc)
		{
			throw(exc); 
		}
	}
	public Column GetColumn()
	{
		try
		{
			return (Column)this.Tag;
		}
		catch(Exception exc)
		{
			throw(exc); 
		}
	}
	public StoredProcedureParameter GetStoredProcedureParameter()
	{
		try
		{
		return (StoredProcedureParameter)this.Tag;
		}
		catch(Exception exc)
		{
			throw(exc); 
		}
	}
}

namespace DBTools.forms
{
	public partial class frmServerExplorer : Crom.Controls.DockableToolWindow
	{
		private     int         m_mouse_X   = 0;
		private     int         m_mouse_Y   = 0;
		private     ArrayList   m_aItem     = new ArrayList();
		internal    ConnectionClass  Conn        = null;
		internal SqlObjectsClass m_so { get; set; }
        private Dictionary<string, SqlObjectsClass> m_dicSO = new Dictionary<string,SqlObjectsClass>(); 
		internal AutoCompleteClass m_autoComplete = new AutoCompleteClass(); 
		
		private enum DataType
		{
			TABELA  = 5,
			VIEW    = 6,
			SP      = 7,
			VAZIO   = 0
		}
		private struct IconType
		{
			public const int    Server		= 0;
			public const int	DataBase	= 1;
			public const int	FolderTable	= 2;
			public const int	Table		= 3;
			public const int	TableRow	= 4;
			public const int	View		= 5;
			public const int	SP			= 6;
			public const int	SPRow		= 7;
			public const int	TableRowPK	= 8;
			public const int	TableRowFK	= 9;
			public const int	TableFK		= 10;
			public const int	SPRowOutput	= 11;
			public const int	ViewRow		= 12;
			public const int	FolderView	= 13;
			public const int	FolderSP	= 14;
		}

		public frmServerExplorer()
		{
			InitializeComponent();
		}
	
#region FORM

		private void frmServerExplorer_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;

			Funcoes.FormServerExplorer = this;
		}
		private void frmServerExplorer_FormClosing(object sender, FormClosingEventArgs e)
		{
			Funcoes.FormMain.mnuExibirServerExplorer.Enabled = true;   
		}

#endregion

#region FUNÇÕES ESPECIAIS

		private NodeTag getNodeTag(object nodeTag)
		{
			try
			{
				return (NodeTag)nodeTag;
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
				throw(exc);
			}
		}
		private NodeTag getNodeTagFromSelectNode()
		{
			try
			{
				tvwDados.SelectedNode = tvwDados.GetNodeAt(m_mouse_X, m_mouse_Y);

				return (NodeTag)tvwDados.SelectedNode.Tag;
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
				throw(exc);
			}
		}

		internal void Atualizar(ServerType serverType)
		{
			try
			{
				Funcoes.ShowCursor(this, CursorType.WaitCursor);      

				Application.DoEvents();
		 
				m_so = new SqlObjectsClass(serverType); 

				string server   = Funcoes.FormMain.SqlSmoTools.ServerName;
				
				tvwDados.Nodes.Clear();
				m_aItem.Clear();

				TreeNode nodeSQLServer = new TreeNode(server, IconType.Server, IconType.Server);
				nodeSQLServer.Tag = 0;
				
				tvwDados.Nodes.Add(nodeSQLServer);

				ObjectsDataBases.DataBases listDatabases = new ObjectsDataBases.DataBases();

				if( Funcoes.FormMain._serverType == ServerType.SQLServer)
				{
					Microsoft.SqlServer.Management.Smo.DatabaseCollection sqlServerDataBases = Funcoes.FormMain.SqlSmoTools.Databases;

					foreach (Microsoft.SqlServer.Management.Smo.Database sqlServerDataBase in sqlServerDataBases)
					{
						ObjectsDataBases.DataBase dataBase = new ObjectsDataBases.DataBase();
 
						dataBase.Id						= sqlServerDataBase.ID;
						dataBase.Name					= sqlServerDataBase.Name;
						dataBase.Owner					= sqlServerDataBase.Owner;
						dataBase.TablesCount			= 1;
						dataBase.ViewsCount				= 1;
						dataBase.StoredProceduresCount	= 1;
						dataBase.IsAccessible			= sqlServerDataBase.IsAccessible;
						dataBase.IsSystemObject			= sqlServerDataBase.IsSystemObject;

						listDatabases.Add(dataBase); 
					}
				}
				else
				{
					ObjectsDataBases dataDB = new ObjectsDataBases(); 

					dataDB.ServerName   = Funcoes.FormMain.SqlSmoTools.ServerName;
					dataDB.DataBaseName = Funcoes.FormMain.SqlSmoTools.DataBaseQuery;
					dataDB.UserName     = Funcoes.FormMain.SqlSmoTools.UserName;
					dataDB.Password     = Funcoes.FormMain.SqlSmoTools.Password;

					listDatabases = dataDB.GetDataBases(); 
				}

				Funcoes.FormMain.pgbMain.Value      = 0;
				Funcoes.FormMain.pgbMain.Minimum    = 0;
				Funcoes.FormMain.pgbMain.Maximum    = listDatabases.Count;

				for (int i = 0; i < listDatabases.Count; i++)
				{
					if(Funcoes.FormMain._dataBaseShowDenyReader == false)
					{
						if(listDatabases[i].IsAccessible == false)
						{
							Funcoes.FormMain.pgbMain.Value = i+1;
							continue;
						} 
					}
					if(Funcoes.FormMain._dataBaseShowSystemObject == false)
					{
						if(listDatabases[i].IsSystemObject)
						{
							Funcoes.FormMain.pgbMain.Value = i+1;
							continue;
						} 
					}
 
					NodeTag nodeTag = new NodeTag(); 
					nodeTag.Expand  = false;
					nodeTag.Tag     = listDatabases[i];

					TreeNode nodeDB = new TreeNode(listDatabases[i].Name, IconType.DataBase, IconType.DataBase);
					nodeDB.Tag      = nodeTag;

					#region Lista tabelas

					nodeTag             = new NodeTag(); 
					nodeTag.Expand      = false;
					nodeTag.Tag         = listDatabases[i].Name;
					nodeTag.DataBase    = listDatabases[i].Name;

					TreeNode nodeTables = new TreeNode("TABLES", IconType.FolderTable, IconType.FolderTable);
					nodeTables.Tag      = nodeTag;

					try
					{
						if (listDatabases[i].TablesCount > 0)
						{
							TreeNode nodeColumn = new TreeNode("Refresh", IconType.Table, IconType.Table);
							
							// adiciona uma coluna
							nodeTables.Nodes.Add(nodeColumn);
						}
					}
					catch
					{
						nodeDB.Text         = listDatabases[i].Name + "(Sem permissão)";
						nodeDB.ForeColor    = Color.Red;

						//Funcoes.LogError(this.Name, exc, exc.Message);
					}

					nodeDB.Nodes.Add(nodeTables);

					#endregion

					#region Lista Views

					nodeTag             = new NodeTag(); 
					nodeTag.Expand      = false;
					nodeTag.Tag         = listDatabases[i].Name;
					nodeTag.DataBase    = listDatabases[i].Name;

					TreeNode nodeViews  = new TreeNode("VIEWS", IconType.FolderView, IconType.FolderView);
					nodeViews.Tag       = nodeTag;

					try
					{
						if (listDatabases[i].ViewsCount > 0)
						{
							TreeNode nodeColumn = new TreeNode("Refresh", IconType.View, IconType.View);
							// adiciona uma coluna
							nodeViews.Nodes.Add(nodeColumn);
						}
					}
					catch{}

					nodeDB.Nodes.Add(nodeViews);

					#endregion

					#region Lista SPs

					nodeTag             = new NodeTag(); 
					nodeTag.Expand      = false;
					nodeTag.Tag         = listDatabases[i].Name;
					nodeTag.DataBase    = listDatabases[i].Name;

					TreeNode nodeSPs    = new TreeNode("SP", IconType.FolderSP, IconType.FolderSP);
					nodeSPs.Tag         = nodeTag;

					try
					{
						if (listDatabases[i].StoredProceduresCount > 0)
						{
							TreeNode nodeColumn = new TreeNode("Refresh", IconType.SP, IconType.SP);
							// adiciona uma coluna
							nodeSPs.Nodes.Add(nodeColumn);
						}
					}
					catch{}

					nodeDB.Nodes.Add(nodeSPs);

					#endregion

					nodeSQLServer.Nodes.Add(nodeDB);

					Funcoes.FormMain.pgbMain.Value = i+1;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
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
		/**************************************************************
		* Função criada por		= Luciano da Silva Dória
		* Data de criação		= 03/05/2007 08:40
		* Data de modificação	= 
		**************************************************************/
		private void ListColumns(string name, string dataType, long dataLength, bool lastColumn)
		{
			try
			{
				if (mnuMinuscula.Checked)
				{
					name = name.ToLower();
				}

				if (mnuTipoDados.Checked == false)
				{
					#region Somente lista de campos
					Funcoes.FormMain.FormFunction.txtOrigem.AppendText(name);

					if (mnuComVirgula.Checked && !lastColumn)
					{
						Funcoes.FormMain.FormFunction.txtOrigem.AppendText(",");
					}

					#endregion
				}
				else
				{
					#region Lista de campos com tipo de dados
					if (mnuTipoDadosCSharp.Checked)
					{
						#region Com tipo de Dados C#

						Funcoes.FormMain.FormFunction.txtOrigem.AppendText(GetCSharpDataType(dataType));
						Funcoes.FormMain.FormFunction.txtOrigem.AppendText(" " + name);

						if (mnuComVirgula.Checked)
						{
							Funcoes.FormMain.FormFunction.txtOrigem.AppendText(" = " + GetCSharpDataTypeValue(dataType) + ";");
						}

						#endregion
					}
					else
					{
						#region Com tipo de Dados SQL Server
						Funcoes.FormMain.FormFunction.txtOrigem.AppendText(name);

						switch (dataType)
						{
							case "char":
							case "nchar":
							case "nvarchar":
							case "varbinary":
							case "varchar":
								{
									Funcoes.FormMain.FormFunction.txtOrigem.AppendText(" " + dataType + "(" + dataLength.ToString() + ")");
									break;
								}
							case "numeric":
								{
									Funcoes.FormMain.FormFunction.txtOrigem.AppendText(" " + dataType + "(" + dataLength.ToString() + ", 0)");
									break;
								}
							default:
								{
									Funcoes.FormMain.FormFunction.txtOrigem.AppendText(" " + dataType);
									break;
								}
						}

						if (mnuComVirgula.Checked && !lastColumn)
						{
							Funcoes.FormMain.FormFunction.txtOrigem.AppendText(",");
						}
						#endregion
					}

					#endregion
				}

				if (!lastColumn)
				{
					Funcoes.FormMain.FormFunction.txtOrigem.AppendText(Environment.NewLine);
				}
			}
			catch (Exception exc)
			{
				throw (exc);
			}
		}
		private void ListarTable(TreeNode nodePai, string strQuery, int IconIndex, int IconIndexFilho, int IconIndexSubFilho, string strTitulo, string strCod)
		{
			try
			{
				DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(strQuery + " ORDER BY name");

				TreeNode nodeMain = new TreeNode(strTitulo, IconIndex, IconIndex);
				nodeMain.Tag = 100;

				nodePai.Nodes.Add(nodeMain);

				for (int i = 0; i < dt.Rows.Count; i++)
				{
					long id = Convert.ToInt64(dt.Rows[i]["id"]);

					PreencherNoFilho(ref nodeMain, dt.Rows[i][0].ToString(), strCod, IconIndexFilho, IconIndexSubFilho, id);
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void PreencherNoFilho(ref TreeNode noPai, string sTitulo, Object tag, int IconIndex, int IconIndexSubFilho, long id)
		{
			try
			{
				TreeNode no = new TreeNode(sTitulo, IconIndex, IconIndex);
				no.Tag = tag + ";" + id.ToString();

				noPai.Nodes.Add(no);

				//if(IconIndex == 5 || IconIndex == 6)
				//{
				//    Funcoes.FormMain.FormSQLEditor.txtQuery.HighlightDescriptors.Add(new HighlightDescriptor(sTitulo, Color.Maroon, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
				//}

				string query = "select name,typestat,colstat, isForeignKey=(select fkey from sysforeignkeys where sysforeignkeys.fkeyid=syscolumns.id and sysforeignkeys.fkey=syscolumns.colid)" +
							   ",nametable=(select name from sysobjects where sysobjects.id=(select rkeyid from sysforeignkeys where sysforeignkeys.fkeyid=syscolumns.id and sysforeignkeys.fkey=syscolumns.colid)) from syscolumns where id=" + id.ToString();

				DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query);

				bool blnExiste = false;

				for (int i = 0; i < dt.Rows.Count; i++)
				{
					int     icon        = IconIndexSubFilho;
					string  strCollum   = dt.Rows[i]["name"].ToString();
					int     typestat    = Convert.ToInt16(dt.Rows[i]["typestat"]);
					int     colstat     = Convert.ToInt16(dt.Rows[i]["colstat"]);

					if (IconIndex == IconType.Table)
					{
						if (colstat == 1)
						{
							icon = IconType.TableRowPK;

							TreeNode nodeColum = new TreeNode(strCollum, icon, icon);
							nodeColum.Tag = IconIndexSubFilho;

							no.Nodes.Add(nodeColum);
						}
						else
						{
							if (dt.Rows[i]["isForeignKey"] != DBNull.Value)
							{
								icon = IconType.TableRowFK;
								string nametable = dt.Rows[i]["nametable"].ToString();

								TreeNode nodeColum = new TreeNode(strCollum, icon, icon);
								nodeColum.Tag = IconIndexSubFilho;

								no.Nodes.Add(nodeColum);

								// insere a tabela proprietária do FK
								TreeNode nodeTableFK = new TreeNode(nametable, IconType.TableFK, IconType.TableFK);
								nodeTableFK.Tag = IconIndexSubFilho;

								nodeColum.Nodes.Add(nodeTableFK);
							}
							else
							{
								TreeNode nodeColum = new TreeNode(strCollum, icon, icon);
								nodeColum.Tag = IconIndexSubFilho;

								no.Nodes.Add(nodeColum);
							}
						}
					}
					else if (IconIndex == IconType.SP)
					{
						if (colstat == 4)
						{
							icon = IconType.SPRowOutput;
						}

						TreeNode nodeColum = new TreeNode(strCollum, icon, icon);
						nodeColum.Tag = IconIndexSubFilho;

						no.Nodes.Add(nodeColum);
					}
					else
					{
						TreeNode nodeColum = new TreeNode(strCollum, icon, icon);
						nodeColum.Tag = IconIndexSubFilho;

						no.Nodes.Add(nodeColum);
					}

					blnExiste = false;

					for (int p = 0; p < m_aItem.Count; p++)
					{
						if (string.CompareOrdinal(m_aItem[p].ToString(), strCollum) == 0)
						{
							blnExiste = true;
							continue;
						}
					}

					if (IconIndex == 5 && blnExiste == false)
					{
						//Funcoes.FormMain.FormSQLEditor.txtQuery.HighlightDescriptors.Add(new HighlightDescriptor(strCollum, Color.Green, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
						m_aItem.Add(strCollum);
					}
				}
			}
			catch//(Exception exc)
			{
				//MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
			}
		}
	   /**************************************************************
	   * Função criada por		= Luciano da Silva Dória
	   * Data de criação		= 21/12/2006 10:01
	   * Data de modificação	= 
	   **************************************************************/
		private string PegaTipoDadosCSharpValor(int cod)
		{
			try
			{
				string tipoDado = string.Empty;

				switch (cod)
				{
					case 34:// image
						{
							tipoDado = "?";
							break;
						}
					case 35:// text
					case 99:// ntext
					case 167:// varchar
					case 175:// char
					case 231:// nvarchar
					case 239:// nchar
						{
							tipoDado = "string.Empty";

							break;
						}
					case 36:// uniqueidentifier
						{
							tipoDado = "?";
							break;
						}
					case 48:// tinyint
						{
							tipoDado = "0";
							break;
						}
					case 52:// smallint
						{
							tipoDado = "0";
							break;
						}
					case 56:// int
						{
							tipoDado = "0";
							break;
						}
					case 61:// datetime
					case 58:// smalldatetime
						{
							tipoDado = "DateTime.Now";

							break;
						}
					case 59:// real
					case 60:// money
					case 106:// decimal
					case 122:// smallmoney
						{
							tipoDado = "0";
							break;
						}
					case 62:// float
						{
							tipoDado = "0";
							break;
						}
					case 98:// sql_variant
						{
							tipoDado = "?";
							break;
						}
					case 104:// bit
						{
							tipoDado = "false";
							break;
						}
					case 108:// numeric
					case 127:// bigint
						{
							tipoDado = "0";
							break;
						}
					case 165:// varbinary
					case 173:// binary
						{
							tipoDado = "0";
							break;
						}
					case 189:// timestamp
						{
							tipoDado = "?";
							break;
						}
				}

				return tipoDado;
			}
			catch
			{
				return "Erro!";
			}
		}
		private string GetCSharpDataType(string dataTypeSQL)
		{
			try
			{
				string dataType = string.Empty;

				switch (dataTypeSQL.ToLower())
				{
					case "image":
						{
							dataType = "byte[]";
							break;
						}
					case "text":
					case "ntext":
					case "varchar":
					case "char":
					case "nvarchar":
					case "nchar":
						{
							dataType = "string";

							break;
						}
					case "uniqueidentifier":
						{
							dataType = "?";
							break;
						}
					case "smallint":
					case "tinyint":
						{
							dataType = "short";
							break;
						}
					case "int":
						{
							dataType = "int";
							break;
						}
					case "datetime":
					case "smalldatetime":
						{
							dataType = "DateTime";
							break;
						}
					case "real":
					case "money":
					case "decimal":
					case "smallmoney":
						{
							dataType = "decimal";
							break;
						}
					case "float":
						{
							dataType = "float";
							break;
						}
					case "sql_variant":
						{
							dataType = "?";
							break;
						}
					case "bit":
						{
							dataType = "bool";
							break;
						}
					case "numeric":
					case "bigint":
						{
							dataType = "long";
							break;
						}
					case "varbinary":
					case "binary":
						{
							dataType = "byte[]";
							break;
						}
					case "timestamp":
						{
							dataType = "?";
							break;
						}
				}

				return dataType;
			}
			catch
			{
				return "Erro!";
			}
		}
		private string GetCSharpDataTypeValue(string dataTypeSQL)
		{
			try
			{
				string dataType = string.Empty;

				switch (dataTypeSQL.ToLower())
				{
					case "image":
						{
							dataType = "?";
							break;
						}
					case "text":
					case "ntext":
					case "varchar":
					case "char":
					case "nvarchar":
					case "nchar":
						{
							dataType = "string.Empty";

							break;
						}
					case "uniqueidentifier":
						{
							dataType = "?";
							break;
						}
					case "tinyint":
						{
							dataType = "0";
							break;
						}
					case "smallint":
						{
							dataType = "0";
							break;
						}
					case "int":
						{
							dataType = "0";
							break;
						}
					case "datetime":
					case "smalldatetime":
						{
							dataType = "DateTime.Now";

							break;
						}
					case "real":
					case "money":
					case "decimal":
					case "smallmoney":
						{
							dataType = "0";
							break;
						}
					case "float":
						{
							dataType = "0";
							break;
						}
					case "sql_variant":
						{
							dataType = "?";
							break;
						}
					case "bit":
						{
							dataType = "false";
							break;
						}
					case "numeric":
					case "bigint":
						{
							dataType = "0";
							break;
						}
					case "varbinary":
					case "binary":
						{
							dataType = "0";
							break;
						}
					case "timestamp":
						{
							dataType = "?";
							break;
						}
				}

				return dataType;
			}
			catch
			{
				return "Erro!";
			}
		}
		internal bool VerificaSeTreeViewEstaSelecionada()
		{
			try
			{
				bool bSelecionado = false;

				if (tvwDados.SelectedNode.IsSelected == true)
				{
					bSelecionado = true;
				}

				//if(tvwDados.SelectedNode != null)
				//{
				//    bSelecionado = true;
				//}

				return bSelecionado;
			}
			catch
			{
				MessageBox.Show("Selecione algum item primeiro!", "Pausa não selecionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
		}
		private string PegaNomeDoMetodo()
		{
			string sMethod = string.Empty;

			try
			{
				if (VerificaSeTreeViewEstaSelecionada())
				{
					sMethod = tvwDados.SelectedNode.Text;
				}

				return sMethod;
			}
			catch
			{
				return sMethod;
			}
		}
		
		private frmComandoSQL setFormComando(frmComandoSQL formComando, TreeNode treeNode)
		{
			ArrayList aDadosIni = new ArrayList();

			aDadosIni.Add("0");
			aDadosIni.Add("*");
			aDadosIni.Add("int");

			formComando.lvwCampos.Add(aDadosIni);

			NodeTag nodeTag = getNodeTag(treeNode.Tag);

			Columns columns = m_so.GetColumns(nodeTag.Tag);

			foreach (Column column in columns)
			{
				string NomeDoCampo = string.Empty;
				string dataType = string.Empty;

				ArrayList aDados = new ArrayList();

				int? length = column.DataType.MaximumLength;

				if (length.HasValue == false)
				{
					length = 0;
				}

				aDados.Add(length.ToString());
				aDados.Add(column.Name);
				aDados.Add(column.DataType.Name);

				formComando.lvwCampos.Add(aDados);
			}

			return formComando;
		}
		private string getWhere(List<string> camposWhere, bool newLine)
		{
			string query = string.Empty;

			if (camposWhere.Count > 0)
			{
				query = " WHERE ";

				bool bAND = false;

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (bAND) { query += " AND "; }

					query += camposWhere[i].ToLower();

					if (newLine) { query += Environment.NewLine; }

					bAND = true;
				}
			}

			return query;
		}
		private string getOrderBy(List<string> camposOrderBy)
		{
			string query = string.Empty;

			if (camposOrderBy.Count > 0)
			{
				query = " ORDER BY ";

				bool bAND = false;

				for (int i = 0; i < camposOrderBy.Count; i++)
				{
					if (bAND) { query += ", "; }

					query += camposOrderBy[i].ToLower();

					bAND = true;
				}
			}

			return query;
		}

		private void ListTables(TreeNode nodeTables)
		{
			try
			{
				nodeTables.Nodes.Clear();  

				Tables tbc = m_so.GetTables(Funcoes.FormMain._tableShowSystemObject); 

				Funcoes.FormMain.pgbMain.Minimum    = 0;
				Funcoes.FormMain.pgbMain.Maximum    = tbc.Count;
				Funcoes.FormMain.pgbMain.Value      = 0;

				for (int i = 0; i < tbc.Count; i++)
				{
					int id      = tbc[i].Id;
					string name = tbc[i].Name;

					NodeTag nodeTag = new NodeTag(); 

					nodeTag.Expand		= false;
					nodeTag.Tag			= tbc[i];
					nodeTag.DataBase	= tbc[i].DataBase;
					
					TreeNode nodeTable = new TreeNode(name, IconType.Table, IconType.Table);
					nodeTable.Tag = nodeTag;


					TreeNode nodeColumn = new TreeNode("Refresh", IconType.TableRow, IconType.TableRow);
					// adiciona uma coluna
					nodeTable.Nodes.Add(nodeColumn);

					// adiciona uma tabela
					nodeTables.Nodes.Add(nodeTable);

					Funcoes.FormMain.pgbMain.Value +=1;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void ListViews(TreeNode nodeViews)
		{
			try
			{
				nodeViews.Nodes.Clear(); 

				Views vwc = m_so.GetViews(Funcoes.FormMain._viewShowSystemObject); 

				Funcoes.FormMain.pgbMain.Minimum    = 0;
				Funcoes.FormMain.pgbMain.Maximum    = vwc.Count;
				Funcoes.FormMain.pgbMain.Value      = 0;

				for (int i = 0; i < vwc.Count; i++)
				{
					int     id      = vwc[i].Id;
					string  name    = vwc[i].Name; 

					NodeTag nodeTag = new NodeTag();

					nodeTag.Expand      = false;
					nodeTag.Tag         = vwc[i];
					nodeTag.DataBase	= vwc[i].DataBase;

					TreeNode nodeView = new TreeNode(name, IconType.View, IconType.View);
					nodeView.Tag = nodeTag;

					// adiciona uma tabela
					nodeViews.Nodes.Add(nodeView);

					TreeNode nodeColumn = new TreeNode("Refresh", IconType.ViewRow, IconType.ViewRow);
					// adiciona uma coluna
					nodeView.Nodes.Add(nodeColumn);

					Funcoes.FormMain.pgbMain.Value +=1;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void ListStoredProcedures(TreeNode nodeSPs)
		{
			try
			{
				nodeSPs.Nodes.Clear(); 

				StoredProcedures spc = m_so.GetStoredProcedures(Funcoes.FormMain._spShowSystemObject);    

				Funcoes.FormMain.pgbMain.Minimum    = 0;
				Funcoes.FormMain.pgbMain.Maximum    = spc.Count;
				Funcoes.FormMain.pgbMain.Value      = 0;

				for (int i = 0; i < spc.Count; i++)
				{
					int     id      = spc[i].Id; 
					string  name    = spc[i].Name; 

					NodeTag nodeTag = new NodeTag();

					nodeTag.Expand      = false;
					nodeTag.Tag         = spc[i];
					nodeTag.DataBase	= spc[i].DataBase;

					TreeNode nodeSP = new TreeNode(name, IconType.SP, IconType.SP);
					nodeSP.Tag      = nodeTag;

					nodeSPs.Nodes.Add(nodeSP);

					TreeNode nodeColumn = new TreeNode("Refresh", IconType.ViewRow, IconType.ViewRow);
					nodeSP.Nodes.Add(nodeColumn);

					Funcoes.FormMain.pgbMain.Value +=1;
					Application.DoEvents();  
				}   
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + "\n\n" +
					exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void ListTableColumns(TreeNode nodeTable)
		{
			int iconType = 0;
			NodeTag nodeTag = new NodeTag();

			try
			{
				nodeTag = getNodeTag(nodeTable.Tag);

				nodeTable.Nodes.Clear();
  
				Funcoes.FormMain.SqlSmoTools.DataBaseQuery = nodeTag.DataBase;
				Funcoes.FormMain.SetTextDataBase(nodeTag.DataBase);

				Table table = nodeTag.GetTable(); 

				Columns cc = m_so.GetColumns(table);    

				foreach (Column column in cc)
				{
					iconType = IconType.TableRow;

					string columnName = column.Name;

					if (Funcoes.FormMain._tableShowColumnsDataType)
					{
						string datatype     = column.DataType.Name;
						string allowNulls   = column.Nullable ? "null" : "not null";

						columnName += " (" + Funcoes.GetDataType(column) + ", " + allowNulls + ")";
					}

					if (column.IsPrimaryKey)
					{
						iconType = IconType.TableRowPK;

						#region Insere normalmente

						TreeNode nodeColumn = new TreeNode(columnName, iconType, iconType);
						nodeColumn.Tag = column;

						// adiciona uma coluna
						nodeTable.Nodes.Add(nodeColumn);
										
						continue;
 
						#endregion
					}

					#region Adiciona a coluna

					if (Funcoes.FormMain._tableShowFK && !column.IsPrimaryKey)
					{
						string datatype = column.DataType.Name.ToLower();

						if (column.IsForeignKey)
						{
							#region É FK(ForeignKey)

							TreeNode nodeColumn = new TreeNode(columnName, IconType.TableRowFK, IconType.TableRowFK);
							nodeColumn.Tag = column;

							// adiciona uma coluna
							nodeTable.Nodes.Add(nodeColumn);

							NodeTag nodeTagFK = new NodeTag(); 

							nodeTagFK.Expand	= false;
							nodeTagFK.Tag		= column.TableForeignKey;
							nodeTagFK.DataBase	= nodeTag.DataBase;

							// insere a tabela proprietária do FK
							TreeNode nodeTableFK = new TreeNode(column.TableForeignKey.Name, IconType.TableFK, IconType.TableFK);
							nodeTableFK.Tag = nodeTagFK;

							nodeColumn.Nodes.Add(nodeTableFK);

							#endregion
						}
						else
						{
							#region Insere normalmente

							TreeNode nodeColumn = new TreeNode(columnName, iconType, iconType);
							nodeColumn.Tag = column;

							// adiciona uma coluna
							nodeTable.Nodes.Add(nodeColumn);

							#endregion
						}
					}
					#endregion
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.ShowCursor(this, CursorType.Default);
				Cursor.Show();

				Funcoes.LogError(this.Name, exc);
			}
		}
		private void ListViewColumns(TreeNode nodeView)
		{
			int iconType = 0;
			NodeTag nodeTag = new NodeTag();

			try
			{
				nodeTag = getNodeTag(nodeView.Tag); 

				nodeView.Nodes.Clear();
  
				Funcoes.FormMain.SqlSmoTools.DataBaseQuery = nodeTag.DataBase;
				Funcoes.FormMain.SetTextDataBase(nodeTag.DataBase);

				DBTools.classes.ObjectsClass.View view = nodeTag.GetView(); 

				Columns cc = m_so.GetColumns(view);    

				foreach (Column column in cc)
				{
					iconType = IconType.TableRow;

					string columnName = column.Name;

					if (Funcoes.FormMain._tableShowColumnsDataType)
					{
						string datatype     = column.DataType.Name;
						string allowNulls   = column.Nullable ? "null" : "not null";

						columnName += " (" + Funcoes.GetDataType(column) + ", " + allowNulls + ")";
					}

					if (column.IsPrimaryKey)
					{
						iconType = IconType.TableRowPK;

						#region Insere normalmente

						TreeNode nodeColumn = new TreeNode(columnName, iconType, iconType);
						nodeColumn.Tag = column;

						// adiciona uma coluna
						nodeView.Nodes.Add(nodeColumn);
										
						continue;
 
						#endregion
					}

					#region Adiciona a coluna

					if (Funcoes.FormMain._tableShowFK && !column.IsPrimaryKey)
					{
						string datatype = column.DataType.Name.ToLower();

						if (column.IsForeignKey)
						{
							#region É FK(ForeignKey)

							TreeNode nodeColumn = new TreeNode(columnName, IconType.TableRowFK, IconType.TableRowFK);
							nodeColumn.Tag = column;

							// adiciona uma coluna
							nodeView.Nodes.Add(nodeColumn);

							// insere a tabela proprietária do FK
							TreeNode nodeTableFK = new TreeNode(column.TableForeignKey.Name, IconType.TableFK, IconType.TableFK);
							nodeTableFK.Tag = IconType.TableFK;

							nodeColumn.Nodes.Add(nodeTableFK);

							#endregion
						}
						else
						{
							#region Insere normalmente

							TreeNode nodeColumn = new TreeNode(columnName, iconType, iconType);
							nodeColumn.Tag = column;

							// adiciona uma coluna
							nodeView.Nodes.Add(nodeColumn);

							#endregion
						}
					}
					#endregion
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.ShowCursor(this, CursorType.Default);
				Cursor.Show();

				Funcoes.LogError(this.Name, exc);
			}
		}
		private void ListStoredProcedureParams(TreeNode nodeSP)
		{
			int iconType = 0;
			NodeTag nodeTag = new NodeTag();

			try
			{
				nodeTag = getNodeTag(nodeSP.Tag);

				nodeSP.Nodes.Clear();

				Funcoes.FormMain.SqlSmoTools.DataBaseQuery = nodeTag.DataBase;
				Funcoes.FormMain.SetTextDataBase(nodeTag.DataBase);

				StoredProcedure storedProcedure = nodeTag.GetStoredProcedure(); 

				StoredProcedureParameters sppc = m_so.GetStoredProcedureParameters(storedProcedure); 

				foreach (StoredProcedureParameter parameter in sppc)
				{
					string paramName    = string.Empty;
					iconType            = IconType.SPRow;

					if (parameter.IsOutputParameter) { iconType = IconType.SPRowOutput; }

					if (Funcoes.FormMain._spShowColumnsDataType)
					{
						paramName = parameter.Name + " (" + parameter.TypeWithLength + ")";
					}
					else
					{
						paramName = parameter.Name;
					}

					TreeNode nodeField = new TreeNode(paramName, iconType, iconType);
					nodeField.Tag = parameter;

					// adiciona o parâmetro
					nodeSP.Nodes.Add(nodeField);
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.ShowCursor(this, CursorType.Default);
				Cursor.Show();

				Funcoes.LogError(this.Name, exc);
			}
		}

		/**************************************************************
		* Função criada por		= Luciano da Silva Dória
		* Data de criação		= 26/03/2009 14:06
		* Data de modificação	= 
		**************************************************************/
		private void TimeSpanDuration(DateTime dtmInicio)
		{
			try
			{
				TimeSpan ts = dtmInicio - DateTime.Now;  

				Funcoes.FormMain.lblTempoDecorrido.Text = ts.Duration().ToString();
			}
			catch
			{
				
			}
		}
		private void TimeSpanDurationClear()
		{
			Funcoes.FormMain.lblTempoDecorrido.Text = "0";
		}

		private void ScriptTableAsInsertWithValuesToClipboard()
		{
			bool newLine = false;

			try
			{
				Funcoes.ShowCursor(this, CursorType.WaitCursor);
	
				List<string> columns = new List<string>();
				List<SqlDataType> sqlDataTypeList = new List<SqlDataType>();
 
				StringBuilder sbInsert = new StringBuilder();
				
				NodeTag nodeTag = getNodeTagFromSelectNode();

				Table table = nodeTag.GetTable();
 
				DataTable dt = Funcoes.FormMain.SqlSmoTools.Query("SELECT TOP 500 * FROM " + table.Name);

				Columns tableColumns = m_so.GetColumns(table);   

				foreach (Column column in tableColumns)
				{
					if (column.IsPrimaryKey && column.Identity){continue;}

					columns.Add(column.Name.ToLower());
					sqlDataTypeList.Add(column.DataType.SqlDataType); 
				}

				for (int i = 0; i < dt.Rows.Count; i++)
				{
					bool virgula = false;

					if(newLine){sbInsert.Append(Environment.NewLine);}
					
					sbInsert.Append("insert into " + table.Owner + "." + table.Name.ToLower() + " values (");

					for (int c = 0; c < columns.Count; c++) 
					{
						if(virgula){sbInsert.Append(",");}

						sbInsert.Append(Funcoes.RetornaValorComTipo(dt.Rows[i][columns[c]].ToString(),
																	sqlDataTypeList[c]));

						virgula = true;
					}

					sbInsert.Append(")");

					newLine = true;
				}

				Clipboard.SetText(sbInsert.ToString());  

				Funcoes.ShowCursor(this, CursorType.Default);

				MessageBox.Show("Copiado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
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

#endregion

#region EVENTOS DE OBJETOS
		//
		// TreeView tvwDados
		//
		private void tvwDados_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				tvwDados.SelectedNode = tvwDados.GetNodeAt(m_mouse_X, m_mouse_Y);

				if(tvwDados.SelectedNode == null){return;}

				if (VerificaSeTreeViewEstaSelecionada() == false){return;}

				Clipboard.SetText(tvwDados.SelectedNode.Text);  
				
				Application.DoEvents();
  
				Funcoes.FormMain.FormSQLEditor.txtQuery.NativeInterface.Paste();  
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void tvwDados_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			try
			{
				string strItem = ((TreeNode)e.Item).Text; 

				// Start the Drag Operation
				DoDragDrop(strItem, DragDropEffects.Copy | DragDropEffects.Move);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void tvwDados_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			mnuComandoSQL.Visible                           = false;
			mnuComandoSQLDelete.Visible                     = false;
			mnuComandoSQLInsert.Visible                     = false;
			mnuComandoSQLSelect.Visible                     = false;
			mnuComandoSQLUpdate.Visible                     = false;

			mnuExecuteSP.Visible                            = false;
			mnuSelectFrom.Visible                           = false;
			mnuListarNodes.Visible                          = false;
			mnuVisualizar.Visible                           = false;
			mnuProcurarEmSPs.Visible                        = false;
			mnuProcurarEmSPsPopUp.Visible                   = false; 
			mnuAtualizar.Visible                            = false;
			mnuCriarSP.Visible                              = false;
			mnuProcurarTabela.Visible                       = false;
			mnuVisualizaPropriedadesTodasTabelas.Visible    = false;
			mnuPropriedades.Visible                         = false;
			mnuGerarMetodo.Visible                          = false;
			mnuGerarMetodoVB6.Visible                       = false;
			
			mnuCriarEnumDaTabela.Visible                    = false;
			mnuStruct.Visible                               = false;
			mnuGraficos.Visible                             = false; 
			mnuTabelaVirtualGerar.Visible                   = false; 
			mnuListGroupQuery.Visible                       = false;
			mnuAlterarOwnerdbo.Visible                      = false;
			mnuImportExcel.Visible                          = false;
			mnuScriptTableAs.Visible                        = false;
			mnuDeletarRegistrosDuplicados.Visible           = false;
			mnuJoomla.Visible                               = false;
            mnuListarDescricao.Visible                      = false;
            mnuGerarClasseFileHelper.Visible                = false;

			try
			{
				tvwDados.SelectedNode = tvwDados.GetNodeAt(m_mouse_X, m_mouse_Y);

				if(tvwDados.SelectedNode == null){return;}

				int iconType = tvwDados.SelectedNode.ImageIndex;

				switch (iconType)
				{
					case IconType.Table:
						{
							mnuSelectFrom.Visible                   = true;
							mnuComandoSQL.Visible                   = true;
							mnuComandoSQLDelete.Visible             = true;
							mnuComandoSQLInsert.Visible             = true;
							mnuComandoSQLSelect.Visible             = true;
							mnuComandoSQLUpdate.Visible             = true;
							mnuListarNodes.Visible                  = true;
							mnuProcurarEmSPs.Visible                = true;
							mnuCriarSP.Visible                      = true;
							mnuStruct.Visible                       = true;
							mnuCriarEnumDaTabela.Visible            = true;
							mnuGraficos.Visible                     = true;
							mnuAtualizar.Visible                    = true;
							mnuPropriedades.Visible                 = true;
							mnuListGroupQuery.Visible               = true;
							mnuAlterarOwnerdbo.Visible              = true;
							mnuScriptTableAs.Visible                = true;
							mnuDeletarRegistrosDuplicados.Visible   = true;
							mnuJoomla.Visible                       = true;
                            mnuListarDescricao.Visible              = true;
                            mnuGerarClasseFileHelper.Visible        = true;
                            break;
						}
					case IconType.TableRow:
						{
							mnuProcurarEmSPs.Visible                = true;
							break;
						}
					case IconType.View:
						{
							mnuSelectFrom.Visible                   = true;
							mnuComandoSQL.Visible                   = true;
							mnuComandoSQLSelect.Visible             = true;
							mnuListarNodes.Visible                  = true;
							mnuVisualizar.Visible                   = true;
							mnuProcurarEmSPs.Visible                = true;
							mnuGraficos.Visible                     = true; 
							mnuAtualizar.Visible                    = true;
							mnuTabelaVirtualGerar.Visible           = true;
							mnuListGroupQuery.Visible               = true;
							mnuAlterarOwnerdbo.Visible              = true;
							mnuStruct.Visible                       = true;
							mnuCriarEnumDaTabela.Visible            = true;
                            mnuGerarClasseFileHelper.Visible        = true;
							break;
						}
					case IconType.SP:
						{
							mnuExecuteSP.Visible                    = true;
							mnuVisualizar.Visible                   = true;
							mnuProcurarEmSPs.Visible                = true;
							mnuGerarMetodo.Visible                  = true;
							mnuAtualizar.Visible                    = true;
							mnuAlterarOwnerdbo.Visible              = true;
							mnuImportExcel.Visible                  = true;
							break;
						}
					case IconType.FolderTable:
					case IconType.FolderView:
					case IconType.FolderSP:
						{
							mnuListarNodes.Visible                  = true;
							mnuAtualizar.Visible                    = true;

							if(iconType == IconType.FolderTable)
							{
								mnuVisualizaPropriedadesTodasTabelas.Visible = true; 
							}
							if(iconType == IconType.FolderSP)
							{
								mnuProcurarEmSPsPopUp.Visible   = true;  
							}
						
							break;
						}
					case IconType.TableFK:
						{
							mnuSelectFrom.Visible                   = true;
							mnuProcurarTabela.Visible               = true;
							break;
						}
					case IconType.TableRowPK:
						{
							mnuProcurarEmSPs.Visible                = true;
							break;
						}
				}
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void tvwDados_MouseMove(object sender, MouseEventArgs e)
		{
			m_mouse_X = e.X;
			m_mouse_Y = e.Y;
		}
		private void tvwDados_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			NodeTag nodeTag = new NodeTag();
			DateTime dtmInicio = new DateTime();

			try
			{
				Funcoes.ShowCursor(this, CursorType.WaitCursor);
				Cursor.Show(); 

				TimeSpanDurationClear();

				tvwDados.SelectedNode = tvwDados.GetNodeAt(m_mouse_X, m_mouse_Y);

				if(tvwDados.SelectedNode == null){return;}

				int iconType = tvwDados.SelectedNode.ImageIndex;

				if (tvwDados.SelectedNode.Tag is NodeTag)
				{
					nodeTag = getNodeTagFromSelectNode();

					if (nodeTag.Expand)
					{
						return;
					}
					else
					{
						if(nodeTag.Tag is DBTools.classes.ObjectsDataBases.DataBase)
						{
							Funcoes.FormMain.SetTextDataBase(tvwDados.SelectedNode.Text); 
						}
						else
						{
							tvwDados.SelectedNode.Nodes.Clear();
						}
					}
				}
				else
				{
					return;
				}

				dtmInicio = DateTime.Now;  

				switch (iconType)
				{
				   case IconType.DataBase:
						{
							#region DataBase 
							Funcoes.FormMain.SqlSmoTools.DataBaseQuery = tvwDados.SelectedNode.Text;

							if(Funcoes.FormMain._serverType == ServerType.SQLServer)
							{

							}

							ConnectionStringBuilder connBuilder = new classes.ConnectionStringBuilder(); 

							connBuilder.ServerName         = Funcoes.FormMain.SqlSmoTools.ServerName;
							connBuilder.DataBase           = Funcoes.FormMain.SqlSmoTools.DataBaseQuery;
							connBuilder.UserName           = Funcoes.FormMain.SqlSmoTools.UserName;
							connBuilder.Password           = Funcoes.FormMain.SqlSmoTools.Password;
							connBuilder.IntegratedSecurity = Funcoes.FormMain.SqlSmoTools.IntegratedSecurity;
 
							tvwDados.SelectedNode.Tag = nodeTag;
 
							if(m_dicSO.ContainsKey(connBuilder.DataBase) == false)
							{
								SqlObjectsClass so = new SqlObjectsClass(Funcoes.FormMain._serverType);

								so.InitConfig(connBuilder);

								m_dicSO.Add(connBuilder.DataBase, so); 
 
								m_so = m_dicSO[connBuilder.DataBase];

								m_autoComplete.AddDataTable(m_so.GetAutoCompleteList()); 

								Funcoes.FormMain.FormSQLEditor.txtQuery.AutoComplete.List = m_autoComplete.GetObjectsDB(connBuilder.DataBase); 
							}

							#endregion
							break;
						}
					case IconType.FolderTable:
						{
							tvwDados.SelectedNode.Text += " (Expandindo...)";
							Application.DoEvents();  

							ListTables(tvwDados.SelectedNode);
							break;
						}
				   case IconType.FolderView:
						{
							tvwDados.SelectedNode.Text += " (Expandindo...)";
							Application.DoEvents();

							ListViews(tvwDados.SelectedNode);
							break;
						}
				   case IconType.FolderSP:
						{
							tvwDados.SelectedNode.Text += " (Expandindo...)";
							Application.DoEvents();

							ListStoredProcedures(tvwDados.SelectedNode);
							break;
						}
					case IconType.Table:
						{
							ListTableColumns(tvwDados.SelectedNode);                            
							break;
						}
					case IconType.View:
						{
							ListViewColumns(tvwDados.SelectedNode); 
							break;
						}
					case IconType.SP:
						{
							ListStoredProcedureParams(tvwDados.SelectedNode); 
							break;
						}
				}

				TimeSpanDuration(dtmInicio); 
				tvwDados.SelectedNode.Text = tvwDados.SelectedNode.Text.Replace(" (Expandindo...)", "");
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.ShowCursor(this, CursorType.Default);
				Cursor.Show();

				Funcoes.LogError(this.Name, exc);
			}
			finally
			{
				if(tvwDados.SelectedNode.Tag is NodeTag)
				{
					nodeTag.Expand              = true;
					tvwDados.SelectedNode.Tag   = nodeTag;
				}

				TimeSpanDuration(dtmInicio); 
				tvwDados.SelectedNode.Text = tvwDados.SelectedNode.Text.Replace(" (Expandindo...)", "");

				Funcoes.ShowCursor(this, CursorType.Default);
				Cursor.Show();
			}
		}
		private void tvwDados_MouseClick(object sender, MouseEventArgs e)
		{
			string dataBase = string.Empty;
  
			try
			{
				tvwDados.SelectedNode = tvwDados.GetNodeAt(m_mouse_X, m_mouse_Y);

				if(tvwDados.SelectedNode == null){return;}

				if (VerificaSeTreeViewEstaSelecionada() == false){return;}

				int iconType = tvwDados.SelectedNode.ImageIndex;

				switch (iconType)
				{
				   case IconType.DataBase:
						{
							dataBase = tvwDados.SelectedNode.Text;
							break;
						}
					case IconType.FolderTable:
					case IconType.FolderView:
					case IconType.FolderSP:
					case IconType.Table:
					case IconType.View:
					case IconType.SP:
						{
							NodeTag nodeTag = getNodeTagFromSelectNode();

							dataBase = nodeTag.DataBase;
							break;
						}
					case IconType.TableRowPK:
					case IconType.TableRowFK:
					case IconType.TableRow:
						 {
							Column column =  (Column)tvwDados.SelectedNode.Tag;

							dataBase = column.DataBase;
							break;
						}
					case IconType.TableFK:
						{
							Table table = getNodeTagFromSelectNode().GetTable(); 

							dataBase = table.DataBase;
							break;
						}

					case IconType.ViewRow:
						{
							Column column = (Column)tvwDados.SelectedNode.Tag;

							dataBase = column.DataBase;
							break;
						}
					case IconType.SPRow:
					case IconType.SPRowOutput:
						{
							StoredProcedureParameter spr = (StoredProcedureParameter)tvwDados.SelectedNode.Tag;

							dataBase = spr.DataBase; 
							break;
						}
						
				}

				if(string.IsNullOrEmpty(dataBase) == false)
				{
					Funcoes.FormMain.SqlSmoTools.DataBaseQuery = dataBase;
					Funcoes.FormMain.SetTextDataBase(dataBase); 
					
					if(m_dicSO.ContainsKey(dataBase))
					{
						m_so = m_dicSO[dataBase];
					}
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		//
		// Button
		//
		private void btnListarCampos_Click(object sender, System.EventArgs e)
		{
			try
			{
				Funcoes.FormMain.FormFunction.txtOrigem.Clear();

				if (VerificaSeTreeViewEstaSelecionada())
				{
					string sMethod  = tvwDados.SelectedNode.Text;
					//string[] strCod = tvwDados.SelectedNode.Tag.ToString().Split(';');

					bool    objExist    = false;
					object  tag         = null;

					NodeTag nodeTag = getNodeTagFromSelectNode();

					tag = Funcoes.FormMain.SqlSmoTools.GetTableById((int)nodeTag.Tag);

					if(tag != null)
					{
						objExist = true;
					}

					if(objExist == false)
					{
						tag = Funcoes.FormMain.SqlSmoTools.GetViewById((int)nodeTag.Tag);

						if(tag != null)
						{
							objExist = true;
						}
					}

					if(objExist == false)
					{
						tag = Funcoes.FormMain.SqlSmoTools.GetStoredProcedureById((int)nodeTag.Tag);
					}

					if (tag is Table)
					{
						#region Table

						Columns columns = m_so.GetColumns(nodeTag.Tag);   

						int i = 0;

						foreach (Column column in columns)
						{
							ListColumns(column.Name, column.DataType.Name, column.DataType.MaximumLength , (i == (columns.Count - 1) ? true : false));
							i++;
						}

						#endregion
					}
					else if (tag is DBTools.classes.ObjectsClass.View)
					{
						#region View
						Columns columns = m_so.GetColumns(nodeTag.Tag);

						int i = 0;

						foreach (Column column in columns)
						{
							ListColumns(column.Name, column.DataType.Name, column.DataType.MaximumLength, (i == (columns.Count - 1) ? true : false));
							i++;
						}

						#endregion
					}
					else if (tag is StoredProcedure)
					{
						#region StoredProcedure

						StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(nodeTag.GetStoredProcedure());   

						int i = 0;

						foreach (StoredProcedureParameter spr in spp)
						{
							ListColumns(spr.Name, spr.DataType.Name, spr.DataType.MaximumLength, (i == (spp.Count - 1) ? true : false));
						}

						#endregion
					}
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		//
		// Menus
		//
		private void mnuSelectFrom_Click(object sender, System.EventArgs e)
		{
			try
			{
				Funcoes.FormMain.FormSQLEditor.txtQuery.Text += "SELECT * FROM " + PegaNomeDoMetodo().ToLower() + Environment.NewLine;
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuExecuteSP_Click(object sender, System.EventArgs e)
		{
			try
			{
				string spName = tvwDados.SelectedNode.Text;

				if (Funcoes.FormMain.FormSQLEditor.txtQuery.Text.Trim().Length > 0)
				{
					Funcoes.FormMain.FormSQLEditor.txtQuery.Text += Environment.NewLine;
				}

				Funcoes.FormMain.FormSQLEditor.txtQuery.Text += "exec " + spName + Environment.NewLine;

				NodeTag nodeTag = getNodeTagFromSelectNode();
				
				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(getNodeTagFromSelectNode().GetStoredProcedure());  
 
				for (int i = 0; i < spp.Count; i++)
				{
					if (i != (spp.Count - 1))
					{
						Funcoes.FormMain.FormSQLEditor.txtQuery.Text += ", -- " + spp[i].Name + " (" + spp[i].TypeWithLength + ")" + Environment.NewLine;
					}
					else
					{
						Funcoes.FormMain.FormSQLEditor.txtQuery.Text += " -- " + spp[i].Name + " (" + spp[i].TypeWithLength + ")" + Environment.NewLine;
					}
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuComandoSQL_Select_Click(object sender, EventArgs e)
		{
			try
			{
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.SELECT);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.OK)
				{
					string NomeMetodo = tvwDados.SelectedNode.Text;

					List<string> camposSelect   = FormComando.CamposSelect;
					List<string> camposWhere    = FormComando.CamposWhere;
					List<string> camposOrderBy  = FormComando.CamposOrderBy;

					string query = "SELECT ";

					if (FormComando.TopQuery > 0)
					{
						query += " TOP " + FormComando.TopQuery.ToString() + " ";
					}

					bool virgula = false;

					for (int i = 0; i < camposSelect.Count; i++)
					{
						if (virgula) { query += ", "; }

						query += camposSelect[i].ToLower();

						virgula = true;
					}

					query += " FROM " + NomeMetodo.ToLower() + Environment.NewLine;
					query += getWhere(camposWhere, false);
					query += getOrderBy(camposOrderBy);

					Funcoes.FormMain.FormSQLEditor.txtQuery.Text += query;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuComandoSQL_Insert_Click(object sender, EventArgs e)
		{
			try
			{
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.INSERT);

				setFormComando(FormComando, tvwDados.SelectedNode);

				FormComando.gpbWhere.Enabled = false;

				if (FormComando.ShowDialog() == DialogResult.OK)
				{
					string NomeMetodo = tvwDados.SelectedNode.Text;

					List<string> campos_select = FormComando.CamposSelect;
					List<string> campos_where = FormComando.CamposWhere;

					string query = "INSERT INTO " + NomeMetodo.ToLower() + " (";

					bool virgula = false;

					for (int i = 0; i < campos_select.Count; i++)
					{
						if (virgula) { query += ", "; }

						query += campos_select[i].ToLower();

						virgula = true;
					}

					query += ")" + Environment.NewLine + " VALUES " + Environment.NewLine + "(";

					virgula = false;

					for (int i = 0; i < campos_select.Count; i++)
					{
						query += "'" + campos_select[i].ToLower() + "'";// + Environment.NewLine;

						if (campos_select.Count > 0 && i < (campos_select.Count - 1)) { query += ", "; }

						query += Environment.NewLine;

						virgula = true;
					}

					query += ") ";

					Funcoes.FormMain.FormSQLEditor.txtQuery.Text += query;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuComandoSQL_Update_Click(object sender, EventArgs e)
		{
			try
			{
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.UPDATE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.OK)
				{
					string NomeMetodo = tvwDados.SelectedNode.Text;

					List<string> campos_select = FormComando.CamposSelect;
					List<string> campos_where = FormComando.CamposWhere;

					string query = "UPDATE " + NomeMetodo.ToLower() + " SET ";

					bool virgula = false;

					for (int i = 0; i < campos_select.Count; i++)
					{
						if (virgula) { query += ", "; }

						query += campos_select[i].ToLower() + "=";

						virgula = true;
					}

					query += Environment.NewLine;

					query += getWhere(campos_where, false);

					Funcoes.FormMain.FormSQLEditor.txtQuery.Text += query;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuComandoSQL_Delete_Click(object sender, EventArgs e)
		{
			try
			{
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.DELETE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				FormComando.gpbSelect.Enabled = false;

				if (FormComando.ShowDialog() == DialogResult.OK)
				{
					string NomeMetodo = tvwDados.SelectedNode.Text;

					List<string> campos_select = FormComando.CamposSelect;
					List<string> campos_where = FormComando.CamposWhere;

					string query = "DELETE " + NomeMetodo.ToLower() + " ";

					query += Environment.NewLine;

					query += getWhere(campos_where, true);

					Funcoes.FormMain.FormSQLEditor.txtQuery.Text += query;
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuListarNodes_Click(object sender, EventArgs e)
		{
			try
			{
				Funcoes.FormMain.FormFunction.txtOrigem.Clear();

				if (VerificaSeTreeViewEstaSelecionada())
				{
					string sMethod = tvwDados.SelectedNode.Text;

					tvwDados.SelectedNode.Expand(); 

					for (int i = 0; i < tvwDados.SelectedNode.Nodes.Count; i++)
					{
						Funcoes.FormMain.FormFunction.txtOrigem.AppendText(tvwDados.SelectedNode.Nodes[i].Text.Trim() + Environment.NewLine);
					}
				}
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuVisualizar_Click(object sender, EventArgs e)
		{
			try
			{
				int iconType = tvwDados.SelectedNode.ImageIndex;

				NodeTag nodeTag = getNodeTagFromSelectNode();

				forms.frmVisualizarSPView formVisualizar;

				if(nodeTag.Tag is DBTools.classes.ObjectsClass.View)  
				{
					DBTools.classes.ObjectsClass.View view = nodeTag.GetView();

					string text = m_so.GetText(view);  

					formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,
																		   text);

					formVisualizar.Text = "Visualizar View: " + view.Name;

					formVisualizar.ShowDialog();
				}
				else if(nodeTag.Tag is StoredProcedure) 
				{
					StoredProcedure sp = nodeTag.GetStoredProcedure();

					string text = m_so.GetText(sp);  

					formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,
																		   text,
																		   FormType.StoredProcedureEdit);
							
					formVisualizar.Text = "Visualizar SP: " + sp.Name;

					formVisualizar.ShowDialog();
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + "\n\n" +
								exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void mnuProcurarEmSPs_Click(object sender, EventArgs e)
		{
			try
			{
				forms.frmPesquisa formPesquisa = new DBTools.forms.frmPesquisa(m_so);

				formPesquisa.TextFind   = tvwDados.SelectedNode.Text;
				formPesquisa.Text       += " - " + tvwDados.SelectedNode.Text;

				formPesquisa.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + "\n" + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void mnuAtualizar_Click(object sender, EventArgs e)
		{
			try
			{
				Funcoes.ShowCursor(this, CursorType.WaitCursorArrow);   

				TreeNode treeNodeSelected = tvwDados.SelectedNode;
  
				int iconType = treeNodeSelected.ImageIndex;

				DateTime dtmInicio = DateTime.Now;

				switch (iconType)
				{
					case IconType.FolderTable:
						{
							ListTables(treeNodeSelected);   
							break;
						}
				   case IconType.FolderView:
						{
							ListViews(treeNodeSelected);  
							break;
						}
				   case IconType.FolderSP:
						{
							ListStoredProcedures(treeNodeSelected);  
							break;
						}
					case IconType.Table:
						{
							treeNodeSelected.Text += " (Expandindo...)";
							Application.DoEvents();

							ListTableColumns(treeNodeSelected);
							break;
						}
					case IconType.View:
						{
							treeNodeSelected.Text += " (Expandindo...)";
							Application.DoEvents();

							ListViewColumns(treeNodeSelected);
							break;
						}
					case IconType.SP:
						{
							treeNodeSelected.Text += " (Expandindo...)";
							Application.DoEvents();

							ListStoredProcedureParams(treeNodeSelected);
							break;
						}
				}

				TimeSpanDuration(dtmInicio); 
				treeNodeSelected.Text = treeNodeSelected.Text.Replace(" (Expandindo...)", "");
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
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
		private void mnuCriarSPInsert_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb        = new StringBuilder();
				StringBuilder sbInsert  = new StringBuilder();
				
				Funcoes.FormMain.FormFunction.txtDestino.Clear();

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				Table table = nodeTag.GetTable();
				Column  columnPrimaryKey = new Column();
				bool    primaryKey          = false;

				sb.Append(Funcoes.GetSPDocument());
				sb.Append("CREATE PROCEDURE [dbo].[SPR_" + table.Name + "_INSERIR]" + Environment.NewLine);

				bool virgula = false;

				Columns columns = m_so.GetColumns(table);

				foreach (Column column in columns)
				{
					if (column.IsPrimaryKey && column.Identity)
					{
						columnPrimaryKey    = column;
						primaryKey          = true;
						continue;
					}

					if (virgula)
					{
						sb.Append("," + Environment.NewLine);
						sbInsert.Append("," + Environment.NewLine);
					}

					sb.Append("\t@" + column.Name.ToLower() + " " + Funcoes.GetDataType(column));
					sbInsert.Append("\t@" + column.Name.ToLower());

					virgula = true;
				}

				if (virgula && primaryKey)
				{
					sb.Append(",");
				}

				sb.Append(Environment.NewLine);
				sbInsert.Append(Environment.NewLine);

				if (primaryKey)
				{
					sb.Append("\t@" + columnPrimaryKey.Name.ToLower() + " " + Funcoes.GetDataType(columnPrimaryKey) + " output" + Environment.NewLine);
				}

				sb.Append("AS" + Environment.NewLine);
				sb.Append("SET NOCOUNT ON" + Environment.NewLine);
				sb.Append("BEGIN" + Environment.NewLine);
				sb.Append("\tinsert into " + table.Owner + "." + table.Name.ToLower() + " values" + Environment.NewLine);
				sb.Append("\t(" + Environment.NewLine);

				sb.Append(sbInsert.ToString());

				sb.Append("\t)" + Environment.NewLine + Environment.NewLine);

				if (primaryKey)
				{
					sb.Append("\tset @" + columnPrimaryKey.Name.ToLower() + " = @@identity" + Environment.NewLine);
				}

				sb.Append("END");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,sb.ToString(), FormType.StoredProcedureCreate);

				formVisualizar.Text     = "Visualizar";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuCriarSPUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				StringBuilder sbUpdate = new StringBuilder();

				Funcoes.FormMain.FormFunction.txtDestino.Clear();

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				Table table = nodeTag.GetTable();

				sb.Append(Funcoes.GetSPDocument());

				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.CREATE_SP_UPDATE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.Cancel) { return; }

				string NomeMetodo = tvwDados.SelectedNode.Text;

				List<string> camposSelect           = FormComando.CamposSelect;
				List<string> camposSelectDataType   = FormComando.CamposSelectDataType;
				List<string> camposWhere            = FormComando.CamposWhere;
				List<string> camposWhereDataType    = FormComando.CamposWhereDataType;

				sb.Append("CREATE PROCEDURE [dbo].[SPR_" + table.Name + "_ALTERAR]" + Environment.NewLine);

				bool virgula = false;

				#region insere os parâmetros de entrada

				for (int i = 0; i < camposSelect.Count; i++)
				{
					if (virgula)
					{
						sb.Append("," + Environment.NewLine);
						sbUpdate.Append("," + Environment.NewLine);
					}

					sb.Append("\t@" + camposSelect[i].ToLower() + " " + camposSelectDataType[i].ToLower());
					sbUpdate.Append("\t" + camposSelect[i].ToLower() + "=@" + camposSelect[i].ToLower());

					virgula = true;
				}

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (virgula)
					{
						sb.Append("," + Environment.NewLine);
					}

					sb.Append("\t@" + camposWhere[i].ToLower() + " " + camposWhereDataType[i]);

					virgula = true;
				}

				#endregion

				sb.Append(Environment.NewLine);
				sbUpdate.Append(Environment.NewLine);

				sb.Append("AS" + Environment.NewLine);
				sb.Append("SET NOCOUNT ON" + Environment.NewLine);
				sb.Append("BEGIN" + Environment.NewLine);
				sb.Append("\tupdate " + table.Owner + "." + table.Name.ToLower() + " set" + Environment.NewLine);

				sb.Append(sbUpdate.ToString());

				#region where
				sb.Append("\twhere ");

				bool bAnd = false;

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (bAnd)
					{
						sb.Append(" and ");
					}

					sb.Append(camposWhere[i].ToLower() + "=@" + camposWhere[i].ToLower());

					bAnd = true;
				}

				#endregion

				sb.Append(Environment.NewLine);
				sb.Append("END");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5, 
																								 sb.ToString(),
																								 FormType.StoredProcedureCreate);

				formVisualizar.Text = "Visualizar";

				formVisualizar.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Err: " + exc.Message + "\n\n" +
								"StackTrace: " + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void mnuCriarSPDelete_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();

				Funcoes.FormMain.FormFunction.txtDestino.Clear();

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				Table table = nodeTag.GetTable();

				sb.Append(Funcoes.GetSPDocument());
				
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.CREATE_SP_DELETE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.Cancel) { return; }

				string NomeMetodo = tvwDados.SelectedNode.Text;

				List<string> camposWhere            = FormComando.CamposWhere;
				List<string> camposWhereDataType    = FormComando.CamposWhereDataType;

				sb.Append("CREATE PROCEDURE [dbo].[SPR_" + table.Name + "_EXCLUIR]" + Environment.NewLine);

				bool virgula = false;

				#region insere os parâmetros de entrada

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (virgula)
					{
						sb.Append("," + Environment.NewLine);
					}

					sb.Append("\t@" + camposWhere[i].ToLower() + " " + camposWhereDataType[i]);

					virgula = true;
				}

				#endregion

				sb.Append(Environment.NewLine);

				sb.Append("AS" + Environment.NewLine);
				sb.Append("SET NOCOUNT ON" + Environment.NewLine);
				sb.Append("BEGIN" + Environment.NewLine);
				sb.Append("\tdelete " + table.Owner + "." + table.Name.ToLower() + Environment.NewLine);

				#region where
				sb.Append("\twhere ");

				bool bAnd = false;

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (bAnd)
					{
						sb.Append(" and ");
					}

					sb.Append(camposWhere[i].ToLower() + "=@" + camposWhere[i].ToLower());

					bAnd = true;
				}

				#endregion

				sb.Append(Environment.NewLine);
				sb.Append("END");

				forms.frmVisualizarSPView formVisualizar = new frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,
																				   sb.ToString(),
																				   FormType.StoredProcedureCreate);

				formVisualizar.Text = "Visualizar";

				formVisualizar.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Err: " + exc.Message + "\n\n" +
								"StackTrace: " + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void mnuProcurarTabela_Click(object sender, EventArgs e)
		{
			try
			{
				string tableName = string.Empty;

				try
				{
					int iconTableFK = tvwDados.SelectedNode.ImageIndex; 

					if (iconTableFK != IconType.TableFK)
					{
						MessageBox.Show("Não é tabela da coluna FK!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					tableName = tvwDados.SelectedNode.Text;
				}
				catch
				{
					MessageBox.Show("Não é tabela da coluna FK!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				foreach (TreeNode node in tvwDados.Nodes[0].Nodes[0].Nodes[0].Nodes)
				{
					if (node.Text == tableName)
					{
						tvwDados.TopNode        = node;
						tvwDados.SelectedNode   = node;
						return;
					}
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuVisualizaPropriedadesTodasTabelas_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada())
				{
					frmTablesRowsCount formRowsCount = new frmTablesRowsCount(tvwDados.SelectedNode.Nodes, m_so); 

					formRowsCount.Show(); 
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuPropriedades_Click(object sender, EventArgs e)
		{
			frmTablesRowsCount formRowsCount;

			try
			{
				if (VerificaSeTreeViewEstaSelecionada())
				{
					NodeTag nodeTag = getNodeTagFromSelectNode();

					Table table = nodeTag.GetTable();

					formRowsCount = new frmTablesRowsCount(table, m_so); 

					formRowsCount.Show(); 
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuJoomlaCriarComponente_Click(object sender, EventArgs e)
		{
			frmJoomla formJoomla;

			try
			{
				if (VerificaSeTreeViewEstaSelecionada())
				{
					NodeTag nodeTag = getNodeTagFromSelectNode();

					Table table = nodeTag.GetTable();

					formJoomla = new frmJoomla(table, m_so);

					formJoomla.ShowDialog(); 
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
        private void mnuJoomlaCriarPaginaKnockout_Click(object sender, EventArgs e)
        {
            frmJoomlaKnockout formJoomla;

            try
            {
                if (VerificaSeTreeViewEstaSelecionada())
                {
                    NodeTag nodeTag = getNodeTagFromSelectNode();

                    Table table = nodeTag.GetTable();

                    formJoomla = new frmJoomlaKnockout(table, m_so);

                    formJoomla.ShowDialog();
                }
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
		private void mnuJoomlaGerarSelectControl_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada())
				{
					NodeTag nodeTag = getNodeTagFromSelectNode();

					Table table = nodeTag.GetTable();

                    frmJoomlaCriarSelect frm = new frmJoomlaCriarSelect(table, m_so);

                    frm.ShowDialog(); 
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
            catch (FormatException exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuCriarSPSelect_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				Table table = nodeTag.GetTable();

				StringBuilder sb        = new StringBuilder();
				StringBuilder sbUpdate  = new StringBuilder();
				StringBuilder sbSelect  = new StringBuilder();

				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.CREATE_SP_SELECT);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.Cancel) { return; }

				sb.Append(Funcoes.GetSPDocument());
				sb.Append("CREATE PROCEDURE [dbo].[spr_Get" + table.Name + "]" + Environment.NewLine);

				List<string> camposSelect           = FormComando.CamposSelect;
				List<string> camposSelectDataType   = FormComando.CamposSelectDataType;
				List<string> camposWhere            = FormComando.CamposWhere;
				List<string> camposWhereDataType    = FormComando.CamposWhereDataType;
				List<string> camposOrderBy          = FormComando.CamposOrderBy;

				bool virgula = false;

				#region Where

				for (int i = 0; i < camposWhere.Count; i++)
				{
					if (virgula)
					{
						sb.Append("," + Environment.NewLine);
					}

					sb.Append("\t@" + camposWhere[i].ToLower() + " " + camposWhereDataType[i]);

					virgula = true;
				}

				#endregion

				sb.Append("\nAS");
				sb.Append("\nSET NOCOUNT ON");
				sb.Append("\nBEGIN");
				sbSelect.Append("\n\tselect ");

				if (FormComando.TopQuery > 0)
				{
					sbSelect.Append(" top " + FormComando.TopQuery.ToString() + " ");
				}

				virgula = false;

				for (int i = 0; i < camposSelect.Count; i++)
				{
					if (virgula) {sbSelect.Append(", ");}

					sbSelect.Append(camposSelect[i].ToLower());

					virgula = true;
				}

				sbSelect.Append(" from " + table.Owner + "." + table.Name.ToLower());

				if(camposWhere.Count > 0)
				{
					#region where
					
					sbSelect.Append("\n\twhere ");

					bool bAnd = false;

					for (int i = 0; i < camposWhere.Count; i++)
					{
						if (bAnd)
						{
							sbSelect.Append(" and ");
						}

						sbSelect.Append(camposWhere[i].ToLower() + "=@" + camposWhere[i].ToLower());

						bAnd = true;
					}

					#endregion
				}

				if(camposOrderBy.Count > 0)
				{
					sbSelect.Append("\n\t" + getOrderBy(camposOrderBy).Trim().ToLower());
				}
				
				sb.Append(sbSelect.ToString());
				sb.Append("\nEND");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,
																								 sb.ToString(),
																								 FormType.StoredProcedureCreate);

				formVisualizar.Text = "Visualizar - Select";

				formVisualizar.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show("Err: " + exc.Message + "\n\n" +
								"StackTrace: " + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void mnuTabelaVirtualGerar_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				StringBuilder sbSQL = new StringBuilder();
 
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.SELECT);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog()  == DialogResult.OK)
				{
					string NomeMetodo       = tvwDados.SelectedNode.Text;
					string valueMember      = "";
					string displayMember    = "";

					List<string> camposSelect   = FormComando.CamposSelect;
					List<string> camposWhere    = FormComando.CamposWhere;
					List<string> camposOrderBy  = FormComando.CamposOrderBy;
				   
					sb.Append("internal static DataTable " + NomeMetodo.ToLower() + " = new DataTable();\n\n");

					sbSQL.Append("SELECT ");

					if (FormComando.TopQuery > 0)
					{
						sbSQL.Append(" TOP " + FormComando.TopQuery.ToString() + " ");
					}

					bool virgula = false;

					for (int i = 0; i < camposSelect.Count; i++)
					{
						if (virgula) { sbSQL.Append(", ");}

						if(i == 0){valueMember      = camposSelect[i].ToLower();}
						if(i == 1){displayMember    = camposSelect[i].ToLower();}

						sbSQL.Append(camposSelect[i].ToLower());

						virgula = true;
					}

					sbSQL.Append(" FROM " + NomeMetodo.ToLower());

					sbSQL.Append(getWhere(camposWhere, true));
					sbSQL.Append(getOrderBy(camposOrderBy));

					string NomeMetodo2  =  NomeMetodo.ToLower().Replace("vw_", " ");
					NomeMetodo2         = NomeMetodo2.Replace("_"," "); 
 
					sb.Append("#region " + NomeMetodo2 + " - "+ NomeMetodo.ToLower() + "\n\n");
					sb.Append("query = \"" + sbSQL.ToString() + "\";\n\n");
					sb.Append("TabelasVirtuais." + NomeMetodo.ToLower() + "  = null;\n");
					sb.Append("TabelasVirtuais." + NomeMetodo.ToLower() + "  = m_daoHelpDesk.Query(query);\n\n");
					sb.Append("#endregion\n\n");

					sb.Append("case TableVirtualType." + NomeMetodo.ToLower().Replace("vw_", "") + ":\n");
					sb.Append("\t{\n");
					sb.Append("\t\t#region " + NomeMetodo.ToLower() + "\n");
					sb.Append("\t\tdt \t\t\t\t= TabelasVirtuais." + NomeMetodo.ToLower() + ".Copy();\n");
					sb.Append("\t\tdisplayMember\t= \"" + displayMember + "\";\n");
					sb.Append("\t\tvalueMember\t\t= \"" + valueMember + "\";\n");
					sb.Append("\t\tbreak;\n");
					sb.Append("\t\t#endregion\n");
					sb.Append("\t}\n");

					string text = sb.ToString().Replace("\n", Environment.NewLine);   

					Clipboard.SetText(text);  

					Funcoes.FileWrite(Application.StartupPath + @"\temp.txt", text, true, true);  
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuProcurarEmSPsPopUp_Click(object sender, EventArgs e)
		{
			try
			{
				frmFindInSPs formFindInSPs = new frmFindInSPs();
 
				if(formFindInSPs.ShowDialog() != DialogResult.OK){return;}   

				forms.frmPesquisa formPesquisa = new DBTools.forms.frmPesquisa(m_so);

				formPesquisa.TextFind   = formFindInSPs.TextValue;
				formPesquisa.Text       += " - " + formFindInSPs.TextValue;

				formPesquisa.ShowDialog();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message + "\n" + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void mnuGerarMetodoCSharp_Click(object sender, EventArgs e)
		{
			string          methodName          = string.Empty;
			string          spNameWithOwner     = "";
			List<StoredProcedureParameter>  listParams          = new List<StoredProcedureParameter>();
			List<StoredProcedureParameter>  listOutput          = new List<StoredProcedureParameter>();
			StringBuilder   sb           = new StringBuilder(); 
			StringBuilder   sbParams            = new StringBuilder();
			StringBuilder   sqlCommandParameters= new StringBuilder(); 

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StoredProcedure sp = nodeTag.GetStoredProcedure();

				// monta o nome da SP com o seu Owner
				spNameWithOwner = sp.Owner.ToLower() + "." + sp.Name; 
				
				// resgata o nome da SP
				methodName      = sp.Name.ToLower().Replace("sp_", "");
				methodName      = methodName.Replace("spr_", "");

				#region varre todos os parâmeteros da SP e os separa por tipo

				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(sp);

				foreach (StoredProcedureParameter spr in spp)
				{
					if (spr.IsOutputParameter == false)
					{
						listParams.Add(spr);
					}
					else
					{
						listOutput.Add(spr);
					}
				}
				#endregion

				#region lista todos os parâmetros de entrada
				for (int i = 0; i < listParams.Count; i++)
				{               
					sbParams.Append(GetCSharpDataType(listParams[i].DataType.Name) + " " + listParams[i].Name.Replace("@", ""));

					if(i < listParams.Count-1)
					{
						sbParams.Append( "," + Environment.NewLine);
					}

					sqlCommandParameters.Append("\t\t\t\tsqlCommand.Parameters.AddWithValue(\"" + listParams[i].Name.ToLower() + "\", " + listParams[i].Name.ToLower().Replace("@", "") + ");" + Environment.NewLine);
				}
				#endregion

				#region lista todos os parâmetros de saída
				for (int i = 0; i < listOutput.Count; i++)
				{               
					if(listOutput[i].DataType.SqlDataType == SqlDataType.VarChar ||
					   listOutput[i].DataType.SqlDataType == SqlDataType.NVarChar)
					{
						sqlCommandParameters.Append(Environment.NewLine + "\t\t\t\tsqlCommand.Parameters.Add(\"" + listOutput[i].Name.ToLower() + "\", SqlDbType." + Funcoes.getSQLDataTypeConvert(listOutput[i].DataType.Name) + "," + listOutput[i].DataType.MaximumLength.ToString() + ");" + Environment.NewLine);
					}
					else
					{
						sqlCommandParameters.Append(Environment.NewLine + "\t\t\t\tsqlCommand.Parameters.Add(\"" + listOutput[i].Name.ToLower() + "\", SqlDbType." + Funcoes.getSQLDataTypeConvert(listOutput[i].DataType.Name) + ");" + Environment.NewLine);
					}
					
					sqlCommandParameters.Append("\t\t\t\tsqlCommand.Parameters[\"" + listOutput[i].Name.ToLower() + "\"].Direction = ParameterDirection.Output;" + Environment.NewLine);
				}
				#endregion

				sb.Append("\t\t/**************************************************************" + Environment.NewLine);
				sb.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
				sb.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
				sb.Append("\t\t* Data de modificação	=" + Environment.NewLine);
				sb.Append("\t\t**************************************************************/" + Environment.NewLine);
				sb.Append("\t\tinternal {@IDT@} " + methodName  + "(" + sbParams.ToString() + ")" + Environment.NewLine);
				sb.Append("\t\t{" + Environment.NewLine);
				sb.Append("\t\t\ttry" + Environment.NewLine);
				sb.Append("\t\t\t{" + Environment.NewLine);
				sb.Append("\t\t\t\tSqlCommand sqlCommand = new SqlCommand(\"" + spNameWithOwner + "\", m_conn);" + Environment.NewLine);
				sb.Append("\t\t\t\tsqlCommand.CommandType = CommandType.StoredProcedure;" + Environment.NewLine + Environment.NewLine);
				
				sb.Append(sqlCommandParameters.ToString()); 

				sb.Append(Environment.NewLine + "\t\t\t\tExecuteSP(ref sqlCommand);" + Environment.NewLine);

				for (int r = 0; r < listOutput.Count; r++)
				{
					sb.Append(Environment.NewLine + "\t\t\t\treturn Convert." + Funcoes.GetDataTypeConvert(listOutput[r].DataType.Name) + "(sqlCommand.Parameters[\"" + listOutput[r].Name.ToLower() + "\"].Value);" + Environment.NewLine);
				}

				if (listOutput.Count <= 0)
				{
					sb = sb.Replace("{@IDT@}", "void");
				}
				else
				{
					sb = sb.Replace("{@IDT@}", GetCSharpDataType(listOutput[0].DataType.Name));
				}

				sb.Append("\t\t\t}" + Environment.NewLine);
				sb.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
				sb.Append("\t\t\t{" + Environment.NewLine);
				sb.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
				sb.Append("\t\t\t}" + Environment.NewLine);
				sb.Append("\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sb.ToString());

				formVisualizar.Text = "Visualizar - Método de utilização de SP em C#";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}        
		private void mnuGerarMetodoConsultaCSharp_Click(object sender, EventArgs e)
		{
			string          methodName          = string.Empty;
			string          spNameWithOwner     = "";
			List<StoredProcedureParameter>  listParams          = new List<StoredProcedureParameter>();
			List<StoredProcedureParameter>  listOutput          = new List<StoredProcedureParameter>();
			StringBuilder   sbDestino           = new StringBuilder(); 
			StringBuilder   sbParams            = new StringBuilder();
			StringBuilder   sqlCommandParameters= new StringBuilder(); 

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StoredProcedure sp = nodeTag.GetStoredProcedure();

				// monta o nome da SP com o seu Owner
				spNameWithOwner = sp.Owner.ToLower() + "." + sp.Name; 
				
				// resgata o nome da SP
				methodName      = sp.Name.ToLower().Replace("sp_", "");
				methodName      = methodName.Replace("spr_", "");

				#region varre todos os parâmeteros da SP e os separa por tipo

				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(sp);

				foreach (StoredProcedureParameter spr in spp)
				{
					if (spr.IsOutputParameter == false)
					{
						listParams.Add(spr);
					}
					else
					{
						listOutput.Add(spr);
					}
				}
				#endregion

				#region lista todos os parâmetros de entrada
				for (int i = 0; i < listParams.Count; i++)
				{               
					sbParams.Append(GetCSharpDataType(listParams[i].DataType.Name) + " " + listParams[i].Name.Replace("@", ""));

					if(i < listParams.Count-1)
					{
						sbParams.Append( "," + Environment.NewLine);
					}

					sqlCommandParameters.Append("\t\t\t\tsqlCommand.Parameters.AddWithValue(\"" + listParams[i].Name.ToLower() + "\", " + listParams[i].Name.ToLower().Replace("@", "") + ");" + Environment.NewLine);
				}
				#endregion

				#region lista todos os parâmetros de saída
				for (int i = 0; i < listOutput.Count; i++)
				{               
					sqlCommandParameters.Append(Environment.NewLine + "\t\t\t\tsqlCommand.Parameters.AddWithValue(\"" + listOutput[i].Name.ToLower() + "\", SqlDbType." + Funcoes.getSQLDataTypeConvert(listOutput[i].DataType.Name) + ");" + Environment.NewLine);
					sqlCommandParameters.Append("\t\t\t\tsqlCommand.Parameters[\"" + listOutput[i].Name.ToLower() + "\"].Direction = ParameterDirection.Output;" + Environment.NewLine);
				}
				#endregion

				sbDestino.Append("\t\t/**************************************************************" + Environment.NewLine);
				sbDestino.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
				sbDestino.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
				sbDestino.Append("\t\t* Data de modificação	=" + Environment.NewLine);
				sbDestino.Append("\t\t**************************************************************/" + Environment.NewLine);
				sbDestino.Append("\t\tinternal DataTable " + methodName  + "(" + sbParams.ToString() + ")" + Environment.NewLine);
				sbDestino.Append("\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\ttry" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tSqlCommand sqlCommand = new SqlCommand(\"" + spNameWithOwner + "\", m_conn);" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tsqlCommand.CommandType = CommandType.StoredProcedure;" + Environment.NewLine + Environment.NewLine);
				
				sbDestino.Append(sqlCommandParameters.ToString()); 

				sbDestino.Append("\t\t\t\tSqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tDataTable dt = new DataTable();" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append("\t\t\t\tm_conn.Close();" + Environment.NewLine); 
				sbDestino.Append("\t\t\t\tm_conn.Open();" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append("\t\t\t\tsqlDataAdapter.Fill(dt);" + Environment.NewLine + Environment.NewLine);
				sbDestino.Append("\t\t\t\treturn dt;" + Environment.NewLine);

				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t\tfinally" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tm_conn.Close();" + Environment.NewLine); 
				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sbDestino.ToString());

				formVisualizar.Text     = "Visualizar - Método de utilização de SP em C#";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuCriarEnumDaTabela_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StringBuilder sbEnum        = new StringBuilder();
				StringBuilder sqlCommand    = new StringBuilder();
 
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.UPDATE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog()  == DialogResult.OK)
				{
					string methodName       = tvwDados.SelectedNode.Text.ToLower();
					string valueMember      = "";
					string displayMember    = "";

					List<string> camposSelect   = FormComando.CamposSelect;
				   
					sbEnum.Append("\tprivate enum HD_" + methodName  + Environment.NewLine);
					sbEnum.Append("\t{");

					sqlCommand.Append("SELECT TOP 50 ");

					bool virgula = false;

					for (int i = 0; i < camposSelect.Count; i++)
					{
						if (virgula) { sqlCommand.Append(", ");}

						sqlCommand.Append(camposSelect[i].ToLower());

						if(i == 0){valueMember      = camposSelect[i].ToLower();}
						if(i == 1){displayMember    = camposSelect[i].ToLower();}

						virgula = true;
					}

					sqlCommand.Append(" FROM " + methodName.ToLower());

					DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(sqlCommand.ToString());

					List<string> listLinesLabel = new List<string>(); 
					List<string> listLinesValue = new List<string>();
 
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						string enumName     = "";
						string enumNameTemp = Funcoes.ReplaceCharactersForEnum(dt.Rows[i][displayMember].ToString());

						string[] enumNameArray = enumNameTemp.Split(' '); 

						for (int r = 0; r < enumNameArray.Length; r++)
						{
							if(enumNameArray[r].Length > 1)
							{
								enumName += enumNameArray[r].Substring(0, 1).ToUpper() + enumNameArray[r].Substring(1, enumNameArray[r].Length-1).ToLower();
							}
							if(enumNameArray[r].Length == 1)
							{
								enumName += enumNameArray[r].Substring(0, 1).ToUpper();
							}
							else
							{
								enumName += "";
							}
						}

						listLinesLabel.Add(enumName.Trim());
						listLinesValue.Add(dt.Rows[i][valueMember].ToString());
					}

					List<string> lines = Funcoes.NormalizeWithTab(listLinesLabel, listLinesValue, "= ");   

					for (int i = 0; i < lines.Count; i++)
					{
   
						sbEnum.Append("\n\t\t" + lines[i]);
						
						if(i < dt.Rows.Count-1){sbEnum.Append(",");}
					}

					sbEnum.Append("\n\t}");

					forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																									 sbEnum.ToString());
					formVisualizar.Text = "Visualizar - Enum gerada do Objeto " + methodName;

					formVisualizar.ShowDialog();
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}        
		private void mnuStructGerarComTiposDeDados_Click(object sender, EventArgs e)
		{
			Table    table   = new Table();
			DBTools.classes.ObjectsClass.View     view    = new DBTools.classes.ObjectsClass.View(); 
			Columns columns = new Columns();
 
			bool isTable = false;

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Tag is Table)
				{
					table   = nodeTag.GetTable();
					columns = m_so.GetColumns(table); 
					isTable = true;
				}
				else if(nodeTag.Tag is DBTools.classes.ObjectsClass.View)
				{
					view    = nodeTag.GetView();
					columns = m_so.GetColumns(view); 
					isTable = true;
				}

				StringBuilder sbStruct = new StringBuilder();

				string methodName = tvwDados.SelectedNode.Text.ToLower();
			 
				sbStruct.Append("\t\tpublic struct HD_" + methodName);
				sbStruct.Append("\n\t\t{");

				List<string> listLinesLabel = new List<string>(); 
				List<string> listLinesValue = new List<string>();

				for (int i = 0; i < columns.Count; i++)
				{
					string dataType = Funcoes.ConvertDataTypeDBToCSharp(columns[i].DataType.SqlDataType.ToString());

					listLinesLabel.Add("public " + dataType);
					listLinesValue.Add(columns[i].Name.ToLower());
				}

				List<string> lines = Funcoes.NormalizeWithTab(listLinesLabel, listLinesValue, "");   

				for (int i = 0; i < lines.Count; i++)
				{
					sbStruct.Append("\n\t\t\t" + lines[i] + ";");
				}

				sbStruct.Append("\n\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sbStruct.ToString());

				if(isTable)
				{
					formVisualizar.Text = string.Format("Visualizar - Struct com Tipo de Dados da Tabela {0}", table.Name);
				}
				else
				{
					formVisualizar.Text = string.Format("Visualizar - Struct com Tipo de Dados da View {0}", view.Name);
				}

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuStructGerarSomenteLista_Click(object sender, EventArgs e)
		{
			//SystemObjectsClass.Table table = new SystemObjectsClass.Table();
			//SystemObjectsClass.View view = new SystemObjectsClass.View();
			bool isTable = false;

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				string objectName = tvwDados.SelectedNode.Text; 

				StringBuilder sbStruct = new StringBuilder();
 
				frmComandoSQL FormComando = new frmComandoSQL(frmComandoSQL.CommandType.UPDATE);

				setFormComando(FormComando, tvwDados.SelectedNode);

				if (FormComando.ShowDialog() == DialogResult.OK)
				{
					List<string> camposSelect   = FormComando.CamposSelect;
				   
					sbStruct.Append("\t\tpublic struct Columns__");
					sbStruct.Append("\n\t\t{");

					List<string> listLinesLabel = new List<string>(); 
					List<string> listLinesValue = new List<string>();
 
					for (int i = 0; i < camposSelect.Count; i++)
					{
						listLinesLabel.Add("public const int " + camposSelect[i].ToLower());
						listLinesValue.Add(i.ToString());
					}

					List<string> lines = Funcoes.NormalizeWithTab(listLinesLabel, listLinesValue, "= ");   

					for (int i = 0; i < lines.Count; i++)
					{
						sbStruct.Append("\n\t\t\t" + lines[i] + ";");
					}

					sbStruct.Append("\n\t\t}");

					forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																									 sbStruct.ToString());

					if(isTable)
					{
						formVisualizar.Text = string.Format("Visualizar - Struct Const da Tabela {0}", objectName);
					}
					else
					{
						formVisualizar.Text = string.Format("Visualizar - Struct Const da View {0}", objectName);
					}

					formVisualizar.ShowDialog();
				}
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuGraficosPizza_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				frmGraficoPizza  formPizza = new frmGraficoPizza(nodeTag.Tag, m_so);  

				formPizza.Show();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuGraficoPlot_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				frmGraficoPlot  formPlot = new frmGraficoPlot(nodeTag.Tag, m_so);  

				formPlot.Show();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuListGroupQuery_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				frmListGroupQuery  formList = new frmListGroupQuery(nodeTag.Tag, m_so);  

				formList.Show(); 
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuAlterarOwnerdbo_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				string objctName    = tvwDados.SelectedNode.Text.Trim();

				// verifica se o objeto já está com o Owner como [dbo]
				StringBuilder query = new StringBuilder();
 
				query.Append("SELECT dbo.sysobjects.name, dbo.sysobjects.xtype, dbo.sysusers.name AS owner, ");
				query.Append(" dbo.sysobjects.uid, dbo.sysobjects.crdate, dbo.sysobjects.id ");
				query.Append(" FROM dbo.sysobjects LEFT OUTER JOIN ");
				query.Append(" dbo.sysusers ON dbo.sysobjects.uid = dbo.sysusers.uid ");
				query.Append(" WHERE dbo.sysobjects.name LIKE '" + objctName + "'");

				DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query.ToString());

				if(dt.Rows.Count > 0)
				{
					if(dt.Rows[0]["owner"].ToString().ToLower() == "dbo")
					{
						MessageBox.Show("O objeto [" + objctName + "] já está com o Owner [dbo]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}

				if (MessageBox.Show("Deseja alterar o Owner do objeto [" + objctName + "] para [dbo]?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return;
				}

				Funcoes.FormMain.SqlSmoTools.ExecuteNonQuery("exec sp_changeobjectowner '" + objctName + "', 'dbo'");

				MessageBox.Show("Alterado o Owner do objeto [" + objctName + "] para [dbo] com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuImportExcel_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;}

				NodeTag nodeTag = getNodeTagFromSelectNode();

				StoredProcedure storedProcedure  = nodeTag.GetStoredProcedure();//Funcoes.FormMain.SqlSmoTools.GetStoredProcedureById((int)nodeTag.GetStoredProcedure().Id);
				
				frmImportExcel formImportExcel = new frmImportExcel(storedProcedure);

				formImportExcel.Show(); 
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
			Funcoes.LogError(this.Name, exc);
			}        
		}
		private void mnuStructGerarComTiposDeDadosPreenchimento_Click(object sender, EventArgs e)
		{
		}
		private void mnuScriptTableAsInsertWithValuesToClipboard_Click(object sender, EventArgs e)
		{
			try
			{
				Thread t = new Thread(new ThreadStart(ScriptTableAsInsertWithValuesToClipboard));
				
				t.SetApartmentState(ApartmentState.STA); 
				t.IsBackground = true;
				t.Start();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuScriptTableAsCreateTable_Click(object sender, EventArgs e)
		{
			try
			{
				Funcoes.ShowCursor(this, CursorType.WaitCursorArrow);   
				TimeSpanDurationClear();

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				DateTime dtmInicio = DateTime.Now; 

				Table table = nodeTag.GetTable();

				Microsoft.SqlServer.Management.Smo.Table sysTable = Funcoes.FormMain.SqlSmoTools.GetTableById(table.Id);     

				List<Urn> list = new List<Urn>();
				
				list.Add(sysTable.Urn);

				Microsoft.SqlServer.Management.Smo.Scripter scripter = new Microsoft.SqlServer.Management.Smo.Scripter();

				scripter.Server										= Funcoes.FormMain.SqlSmoTools.Server;
				scripter.Options.IncludeHeaders						= true;
				scripter.Options.SchemaQualify						= true;
				scripter.Options.SchemaQualifyForeignKeysReferences	= true;
				scripter.Options.NoCollation						= true;
				scripter.Options.DriAllConstraints					= true;
				scripter.Options.DriAll								= true;
				scripter.Options.DriAllKeys							= true;
				scripter.Options.DriIndexes							= true;
				scripter.Options.ClusteredIndexes					= true;
				scripter.Options.NonClusteredIndexes				= true;
				scripter.Options.ToFileOnly							= false;
				//scripter.Options.FileName							= @"C:\tables.sql";

				StringCollection sqlCreateTable = scripter.Script(list.ToArray());

				TimeSpanDuration(dtmInicio); 

				StringBuilder sb = new StringBuilder();  

				foreach (string line in sqlCreateTable)
				{
					sb.Append(line + "\n"); 
				}

				Clipboard.SetText(sb.ToString());
				
				MessageBox.Show("Copiado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
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
		private void mnuGerarMetodoCSharpDAAB_Click(object sender, EventArgs e)
		{
			string          methodName          = string.Empty;
			string          spNameWithOwner     = "";
			List<StoredProcedureParameter>  listParams          = new List<StoredProcedureParameter>();
			List<StoredProcedureParameter>  listOutput          = new List<StoredProcedureParameter>();
			StringBuilder   sbDestino           = new StringBuilder(); 
			StringBuilder   sbParams            = new StringBuilder();
			StringBuilder   sqlCommandParameters= new StringBuilder(); 

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StoredProcedure sp = nodeTag.GetStoredProcedure();

				// monta o nome da SP com o seu Owner
				spNameWithOwner = sp.Owner.ToLower() + "." + sp.Name; 
				
				// resgata o nome da SP
				methodName      = sp.Name.ToLower().Replace("sp_", "");
				methodName      = methodName.Replace("spr_", "");

				#region varre todos os parâmeteros da SP e os separa por tipo

				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(sp);

				foreach (StoredProcedureParameter spr in spp)
				{                   
					if (spr.IsOutputParameter == false)
					{
						listParams.Add(spr);
					}
					else
					{
						listOutput.Add(spr);
					}
				}
				#endregion

				#region Lista todos os parâmetros de entrada
				for (int i = 0; i < listParams.Count; i++)
				{               
					sbParams.Append(GetCSharpDataType(listParams[i].DataType.Name) + " " + listParams[i].Name.Replace("@", ""));

					if(i < listParams.Count-1)
					{
						sbParams.Append( "," + Environment.NewLine);
					}

					//db.AddInParameter(dbCommand, "@numerosmallint", DbType.Int16, 1);
					sqlCommandParameters.Append("\t\t\t\t\tdb.AddInParameter(dbCommand,\"" + listParams[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listParams[i].DataType.Name) + ", " + listParams[i].Name.ToLower().Replace("@", "") + ");" + Environment.NewLine);
				}
				#endregion

				#region Lista todos os parâmetros de saída
				for (int i = 0; i < listOutput.Count; i++)
				{         
					//db.AddOutParameter(dbCommand, "@outputbigint", DbType.Int64, 64);
					if(listOutput[i].DataType.SqlDataType == SqlDataType.VarChar ||
					   listOutput[i].DataType.SqlDataType == SqlDataType.NVarChar)
					{
						sqlCommandParameters.Append("\t\t\t\t\tdb.AddOutParameter(dbCommand, \"" + listOutput[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listOutput[i].DataType.Name) + ", " + listOutput[i].DataType.MaximumLength.ToString() + ");" + Environment.NewLine);
					}
					else
					{
						sqlCommandParameters.Append("\t\t\t\t\tdb.AddOutParameter(dbCommand, \"" + listOutput[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listOutput[i].DataType.Name) + ", " + listOutput[i].DataType.MaximumLength.ToString() + ");" + Environment.NewLine);
					}
				}
				#endregion

				sbDestino.Append("\t\t/**************************************************************" + Environment.NewLine);
				sbDestino.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
				sbDestino.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
				sbDestino.Append("\t\t* Data de modificação	=" + Environment.NewLine);
				sbDestino.Append("\t\t**************************************************************/" + Environment.NewLine);
				sbDestino.Append("\t\tinternal {@IDT@} " + methodName  + "(" + sbParams.ToString() + ")" + Environment.NewLine);
				sbDestino.Append("\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\ttry" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);

				sbDestino.Append("\t\t\t\tDatabase db = DatabaseFactory.CreateDatabase();" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append("\t\t\t\tusing (DbCommand dbCommand = db.GetStoredProcCommand(\"" + spNameWithOwner + "\"))" + Environment.NewLine);
				sbDestino.Append("\t\t\t\t{" + Environment.NewLine);

				sbDestino.Append(sqlCommandParameters.ToString()); 

				sbDestino.Append(Environment.NewLine + "\t\t\t\t\tdb.ExecuteNonQuery(dbCommand);" + Environment.NewLine + Environment.NewLine);

				for (int r = 0; r < listOutput.Count; r++)
				{
					//db.GetParameterValue(dbCommand, "@outputbigint")
					sbDestino.Append("\t\t\t\t\treturn Convert." + Funcoes.GetDataTypeConvert(listOutput[r].DataType.Name) + "(db.GetParameterValue(dbCommand, \"" + listOutput[r].Name.ToLower() + "\"));" + Environment.NewLine);
				}

				if (listOutput.Count <= 0)
				{
					sbDestino = sbDestino.Replace("{@IDT@}", "void");
				}
				else
				{
					sbDestino = sbDestino.Replace("{@IDT@}", GetCSharpDataType(listOutput[0].DataType.Name));
				}

				sbDestino.Append("\t\t\t\t}" + Environment.NewLine);

				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sbDestino.ToString());

				formVisualizar.Text = "Visualizar - Método de utilização de SP em C#";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuGerarMetodoConsultaCSharpDAAB_Click(object sender, EventArgs e)
		{
			string          methodName          = string.Empty;
			string          spNameWithOwner     = "";
			List<StoredProcedureParameter>  listParams          = new List<StoredProcedureParameter>();
			StringBuilder   sbDestino           = new StringBuilder(); 
			StringBuilder   sbParams            = new StringBuilder();
			StringBuilder   sqlCommandParameters= new StringBuilder(); 

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if(nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StoredProcedure sp = nodeTag.GetStoredProcedure();

				// monta o nome da SP com o seu Owner
				spNameWithOwner = sp.Owner.ToLower() + "." + sp.Name; 
				
				// resgata o nome da SP
				methodName      = sp.Name.ToLower().Replace("sp_", "");
				methodName      = methodName.Replace("spr_", "");

				#region varre todos os parâmeteros da SP e os separa por tipo

				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(sp);

				foreach (StoredProcedureParameter spr in spp)
				{
					listParams.Add(spr);
				}
				#endregion

				#region Lista todos os parâmetros de entrada
				for (int i = 0; i < listParams.Count; i++)
				{               
					sbParams.Append(GetCSharpDataType(listParams[i].DataType.Name) + " " + listParams[i].Name.Replace("@", ""));

					if(i < listParams.Count-1)
					{
						sbParams.Append( "," + Environment.NewLine);
					}

					//db.AddInParameter(dbCommand, "@numerosmallint", DbType.Int16, 1);
					sqlCommandParameters.Append("\t\t\t\tdb.AddInParameter(dbCommand,\"" + listParams[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listParams[i].DataType.Name) + ", " + listParams[i].Name.ToLower().Replace("@", "") + ");" + Environment.NewLine);
				}
				#endregion

				sbDestino.Append("\t\t/**************************************************************" + Environment.NewLine);
				sbDestino.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
				sbDestino.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
				sbDestino.Append("\t\t* Data de modificação	=" + Environment.NewLine);
				sbDestino.Append("\t\t**************************************************************/" + Environment.NewLine);
				sbDestino.Append("\t\tinternal DataTable " + methodName  + "(" + sbParams.ToString() + ")" + Environment.NewLine);
				sbDestino.Append("\t\t{" + Environment.NewLine);
				
				sbDestino.Append("\t\t\tDataTable dt = new DataTable();" + Environment.NewLine + Environment.NewLine);
				
				sbDestino.Append("\t\t\ttry" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);

				sbDestino.Append("\t\t\t\tDatabase db = DatabaseFactory.CreateDatabase();" + Environment.NewLine + Environment.NewLine);

				//DbCommand dbCommand = db.GetStoredProcCommand("dbo.SPR_GetProjetos");

				sbDestino.Append("\t\t\t\tDbCommand dbCommand = db.GetStoredProcCommand(\"" + spNameWithOwner + "\");" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append(sqlCommandParameters.ToString()  + Environment.NewLine); 

				sbDestino.Append("\t\t\t\tusing (IDataReader dr = db.ExecuteReader(dbCommand))" + Environment.NewLine);
				sbDestino.Append("\t\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\t\tdt.Load(dr);" + Environment.NewLine);
				sbDestino.Append("\t\t\t\t}" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append("\t\t\t\treturn dt;" + Environment.NewLine);

				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sbDestino.ToString());

				formVisualizar.Text = "Visualizar - Método de utilização de SP em C#";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuGerarMetodoVB6_Click(object sender, EventArgs e)
		{
			string methodName = string.Empty;
			string spNameWithOwner = "";
			List<StoredProcedureParameter> listParams = new List<StoredProcedureParameter>();
			List<StoredProcedureParameter> listOutput = new List<StoredProcedureParameter>();
			StringBuilder sbDestino = new StringBuilder();
			StringBuilder sbParams = new StringBuilder();
			StringBuilder sqlCommandParameters = new StringBuilder();

			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false) { return; }

				NodeTag nodeTag = getNodeTagFromSelectNode();

				if (nodeTag.Expand == false)
				{
					MessageBox.Show("Expanda a Tabela primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				StoredProcedure sp = nodeTag.GetStoredProcedure();

				// monta o nome da SP com o seu Owner
				spNameWithOwner = sp.Owner.ToLower() + "." + sp.Name;

				// resgata o nome da SP
				methodName = sp.Name.ToLower().Replace("sp_", "");
				methodName = methodName.Replace("spr_", "");

				#region varre todos os parâmeteros da SP e os separa por tipo

				StoredProcedureParameters spp = m_so.GetStoredProcedureParameters(sp);

				foreach (StoredProcedureParameter spr in spp)
				{
					if (spr.IsOutputParameter == false)
					{
						listParams.Add(spr);
					}
					else
					{
						listOutput.Add(spr);
					}
				}
				#endregion

				#region Lista todos os parâmetros de entrada
				for (int i = 0; i < listParams.Count; i++)
				{
					sbParams.Append(GetCSharpDataType(listParams[i].DataType.Name) + " " + listParams[i].Name.Replace("@", ""));

					if (i < listParams.Count - 1)
					{
						sbParams.Append("," + Environment.NewLine);
					}

					//db.AddInParameter(dbCommand, "@numerosmallint", DbType.Int16, 1);
					sqlCommandParameters.Append("\t\t\t\t\tdb.AddInParameter(dbCommand,\"" + listParams[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listParams[i].DataType.Name) + ", " + listParams[i].Name.ToLower().Replace("@", "") + ");" + Environment.NewLine);
				}
				#endregion

				#region Lista todos os parâmetros de saída
				for (int i = 0; i < listOutput.Count; i++)
				{
					//db.AddOutParameter(dbCommand, "@outputbigint", DbType.Int64, 64);
					if (listOutput[i].DataType.SqlDataType == SqlDataType.VarChar ||
						listOutput[i].DataType.SqlDataType == SqlDataType.NVarChar)
					{
						sqlCommandParameters.Append("\t\t\t\t\tdb.AddOutParameter(dbCommand, \"" + listOutput[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listOutput[i].DataType.Name) + ", " + listOutput[i].DataType.MaximumLength.ToString() + ");" + Environment.NewLine);
					}
					else
					{
						sqlCommandParameters.Append("\t\t\t\t\tdb.AddOutParameter(dbCommand, \"" + listOutput[i].Name.ToLower() + "\", DbType." + Funcoes.GetDataTypeSQLToCSharp(listOutput[i].DataType.Name) + ", " + listOutput[i].DataType.MaximumLength.ToString() + ");" + Environment.NewLine);
					}
				}
				#endregion

				sbDestino.Append("\t\t'**************************************************************" + Environment.NewLine);
				sbDestino.Append("\t\t' Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
				sbDestino.Append("\t\t' Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
				sbDestino.Append("\t\t' Data de modificação	=" + Environment.NewLine);
				sbDestino.Append("\t\t'**************************************************************" + Environment.NewLine);
				sbDestino.Append("\t\tinternal {@IDT@} " + methodName + "(" + sbParams.ToString() + ")" + Environment.NewLine);
				sbDestino.Append("\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\ttry" + Environment.NewLine);

				sbDestino.Append("\t\t\t\tDatabase db = DatabaseFactory.CreateDatabase();" + Environment.NewLine + Environment.NewLine);

				sbDestino.Append("\t\t\t\tusing (DbCommand dbCommand = db.GetStoredProcCommand(\"" + spNameWithOwner + "\"))" + Environment.NewLine);
				sbDestino.Append("\t\t\t\t{" + Environment.NewLine);

				sbDestino.Append(sqlCommandParameters.ToString());

				sbDestino.Append(Environment.NewLine + "\t\t\t\t\tdb.ExecuteNonQuery(dbCommand);" + Environment.NewLine + Environment.NewLine);

				for (int r = 0; r < listOutput.Count; r++)
				{
					//db.GetParameterValue(dbCommand, "@outputbigint")
					sbDestino.Append("\t\t\t\t\treturn Convert." + Funcoes.GetDataTypeConvert(listOutput[r].DataType.Name) + "(db.GetParameterValue(dbCommand, \"" + listOutput[r].Name.ToLower() + "\"));" + Environment.NewLine);
				}

				if (listOutput.Count <= 0)
				{
					sbDestino = sbDestino.Replace("{@IDT@}", "void");
				}
				else
				{
					sbDestino = sbDestino.Replace("{@IDT@}", GetCSharpDataType(listOutput[0].DataType.Name));
				}

				sbDestino.Append("\t\t\t\t}" + Environment.NewLine);

				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
				sbDestino.Append("\t\t\t{" + Environment.NewLine);
				sbDestino.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
				sbDestino.Append("\t\t\t}" + Environment.NewLine);
				sbDestino.Append("\t\t}");

				forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
																								 sbDestino.ToString());

				formVisualizar.Text = "Visualizar - Método de utilização de SP em Visual Basic 6";

				formVisualizar.ShowDialog();
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}
		private void mnuDeletarRegistrosDuplicados_Click(object sender, EventArgs e)
		{
			try
			{
				if (VerificaSeTreeViewEstaSelecionada() == false){return;} 

				NodeTag nodeTag = getNodeTagFromSelectNode();

				frmDeletarRegistrosDuplicados formDeletar = new frmDeletarRegistrosDuplicados(nodeTag.Tag, m_so);  

				formDeletar.Show(); 
			}
			catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
			{
				Funcoes.LogError(this.Name, smoExc);
			}
			catch (SqlException sqlExc)
			{
				Funcoes.LogError(this.Name, sqlExc);
			}
			catch (Exception exc)
			{
				Funcoes.LogError(this.Name, exc);
			}
		}

        private void mnuListarDescricao_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.FormMain.FormFunction.txtOrigem.Clear();

                if (VerificaSeTreeViewEstaSelecionada())
                {
                    NodeTag nodeTag = (NodeTag)tvwDados.SelectedNode.Tag;

                    tvwDados.SelectedNode.Expand();

                    Table table = nodeTag.GetTable();

                    Columns columns = m_so.GetColumns(table);

                    foreach (Column column in columns)
                    {
                        Funcoes.FormMain.FormFunction.txtOrigem.AppendText(column.Description + Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        #endregion

        private void MnuGerarClasseFileHelper_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            DBTools.classes.ObjectsClass.View view = new DBTools.classes.ObjectsClass.View();
            Columns columns = new Columns();

            bool isTable = false;

            try
            {
                if (VerificaSeTreeViewEstaSelecionada() == false) { return; }

                NodeTag nodeTag = getNodeTagFromSelectNode();

                if (nodeTag.Tag is Table)
                {
                    table = nodeTag.GetTable();
                    columns = m_so.GetColumns(table);
                    isTable = true;
                }
                else if (nodeTag.Tag is DBTools.classes.ObjectsClass.View)
                {
                    view = nodeTag.GetView();
                    columns = m_so.GetColumns(view);
                    isTable = true;
                }

                StringBuilder sbStruct = new StringBuilder();
                StringBuilder sbafterRead = new StringBuilder();

                string tableName = tvwDados.SelectedNode.Text.ToLower();

                sbStruct.Append("\t\tpublic class " + tableName + " : INotifyRead<ImportRecord>");
                sbStruct.Append("\n\t\t{");

                //List<string> listLinesLabel = new List<string>();
                sbafterRead.Append("\n\t\tpublic void AfterRead(AfterReadEventArgs<ImportRecord> e)");
                sbafterRead.Append("\n\t\t{");

                for (int i = 0; i < columns.Count; i++)
                {
                    string dataType = Funcoes.ConvertDataTypeDBToCSharp(columns[i].DataType.SqlDataType.ToString());

                    switch (columns[i].DataType.SqlDataType)
                    {
                        case SqlDataType.Date:
                        case SqlDataType.DateTime2:
                        case SqlDataType.DateTime:
                        case SqlDataType.SmallDateTime:
                            {
                                if (columns[i].Nullable)
                                {
                                    dataType += "?";
                                }
                                sbStruct.Append("\n\t\t\t[FieldConverter(ConverterKind.Date, \"yyyy-MM-dd\")]");
                                break;
                            }
                        case SqlDataType.BigInt:
                        case SqlDataType.Binary:
                        case SqlDataType.Bit:
                        case SqlDataType.Decimal:
                        case SqlDataType.Float:
                        case SqlDataType.Int:
                        case SqlDataType.Money:
                        case SqlDataType.Real:
                        case SqlDataType.SmallInt:
                        case SqlDataType.SmallMoney:
                        case SqlDataType.TinyInt:
                        case SqlDataType.UniqueIdentifier:
                        case SqlDataType.UserDefinedDataType:
                        case SqlDataType.UserDefinedType:
                        case SqlDataType.VarBinary:
                        case SqlDataType.VarBinaryMax:
                        case SqlDataType.Numeric:
                            {
                                if (columns[i].Nullable)
                                {
                                    dataType += "?";
                                }
                                break;
                            }
                        case SqlDataType.Char:
                        case SqlDataType.NChar:
                        case SqlDataType.NText:
                         case SqlDataType.NVarChar:
                        case SqlDataType.NVarCharMax:
                        case SqlDataType.Text:
                        case SqlDataType.VarChar:
                        case SqlDataType.VarCharMax:
                            {
                                sbStruct.Append("\n\t\t\t[FieldTrim(TrimMode.Both)]");

                                sbafterRead.Append("\n\n\t\t\tif (e.Record." + columns[i].Name + ".Length > " + columns[i].DataType.MaximumLength.ToString() + ")");
                                sbafterRead.Append("\n\t\t\t\tthrow new Exception(\"Line \" + e.LineNumber + \": " + columns[i].Name + " is too long\");");
                                break;
                            }
                        default:
                            break;
                    }

                    sbStruct.Append("\n\t\t\t" + "public " + dataType + " " + columns[i].Name + ";");

                    //sbStruct.Append("\n\t\t\t" + lines[0] + ";");
                }

                sbStruct.Append("\n\t\t}");
                sbafterRead.Append("\n\t\t}");

                sbStruct.Append(sbafterRead.ToString());

                forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
                                                                                                 sbStruct.ToString());

                if (isTable)
                {
                    formVisualizar.Text = string.Format("Visualizar - Classe com Tipo de Dados da Tabela {0}", table.Name);
                }
                else
                {
                    formVisualizar.Text = string.Format("Visualizar - Classe com Tipo de Dados da View {0}", view.Name);
                }

                formVisualizar.ShowDialog();
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
    }
}