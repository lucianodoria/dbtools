using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DBTools.classes.ObjectsClass;

namespace DBTools.classes
{
    public class SqlServerObjectsClass : IDataBaseObjects 
    {
        private DataTable _dtIdentity  = new DataTable();
        private DataTable _dtOwner     = new DataTable();
        private DataTable _dtRowsCount = new DataTable(); 

        private Dictionary<short, SqlDataType> _dicSqlDataType = new Dictionary<short, SqlDataType>();

        private SqlConnection _conn;
        private ConnectionStringBuilder _connBuilder = new ConnectionStringBuilder();

        private Tables _tables = new Tables();
        private Views _views = new Views();
        private StoredProcedures _storedProcedures = new StoredProcedures();
        
        /// <summary>
        /// 
        /// </summary>
        public ConnectionStringBuilder ConnBuilder
        {
            get { return _connBuilder; }
            set { _connBuilder = value; }
        }
        /// <summary>
        /// Informe o nome do Servidor a ser conectado.
        /// </summary>
        public string ServerName
        {
            get { return _connBuilder.ServerName; }
            set { _connBuilder.ServerName = value; }
        }
        /// <summary>
        /// Informe o nome do Banco a ser acessado.
        /// </summary>
        public string DataBase
        {
            get { return _connBuilder.DataBase; }
            set { _connBuilder.DataBase = value; }
        }
        /// <summary>
        /// Informe o usuário a se conectar no Servidor.
        /// </summary>
        public string UserName
        {
            get { return _connBuilder.UserName; }
            set { _connBuilder.UserName = value; }
        }
        /// <summary>
        /// Informe a senha a se conectar no Servidor.
        /// </summary>
        public string Password
        {
            get { return _connBuilder.Password; }
            set { _connBuilder.Password = value; }
        }
        /// <summary>
        /// Informe se vai ser usado o IntegratedSecurity.
        /// </summary>
        public bool IntegratedSecurity
        {
            get { return _connBuilder.IntegratedSecurity; }
            set { _connBuilder.IntegratedSecurity = value; }
        }
        /// <summary>
        /// Informe o tempo para expirar ao tentar fazer uma conexão.
        /// </summary>
        public int ConnectTimeout
        {
            get { return _connBuilder.ConnectTimeout; }
            set { _connBuilder.ConnectTimeout = value; }
        }

        /// <summary>
        /// Resgata as Tabelas em cache. 
        /// </summary>
        public Tables TablesCache
        {
            get { return _tables; }
        }
        /// <summary>
        /// Resgata as Views em cache. 
        /// </summary>
        public Views ViewsCache
        {
            get { return _views; }
        }
        /// <summary>
        /// Resgata as StoredProcedures Views em cache. 
        /// </summary>
        public StoredProcedures StoredProceduresCache
        {
            get { return _storedProcedures; }
        }  

        public SqlServerObjectsClass()
        {
            _dicSqlDataType.Add(0, SqlDataType.None);
            _dicSqlDataType.Add(127, SqlDataType.BigInt);
            _dicSqlDataType.Add(173, SqlDataType.Binary);
            _dicSqlDataType.Add(104, SqlDataType.Bit);
            _dicSqlDataType.Add(175, SqlDataType.Char);
            _dicSqlDataType.Add(61, SqlDataType.DateTime);
            _dicSqlDataType.Add(106, SqlDataType.Decimal);
            _dicSqlDataType.Add(62, SqlDataType.Float);
            _dicSqlDataType.Add(34, SqlDataType.Image);
            _dicSqlDataType.Add(56, SqlDataType.Int);
            _dicSqlDataType.Add(60, SqlDataType.Money);
            _dicSqlDataType.Add(239, SqlDataType.NChar);
            _dicSqlDataType.Add(99, SqlDataType.NText);
            _dicSqlDataType.Add(231, SqlDataType.NVarChar);
            //m_dicSqlDataType.Add(0, SqlDataType.NVarCharMax);
            _dicSqlDataType.Add(59, SqlDataType.Real);
            _dicSqlDataType.Add(58, SqlDataType.SmallDateTime);
            _dicSqlDataType.Add(52, SqlDataType.SmallInt);
            _dicSqlDataType.Add(122, SqlDataType.SmallMoney);
            _dicSqlDataType.Add(35, SqlDataType.Text);
            _dicSqlDataType.Add(189, SqlDataType.Timestamp);
            _dicSqlDataType.Add(48, SqlDataType.TinyInt);
            _dicSqlDataType.Add(36, SqlDataType.UniqueIdentifier);
            //m_dicSqlDataType.Add(0, SqlDataType.UserDefinedDataType);
            //m_dicSqlDataType.Add(0, SqlDataType.UserDefinedType);
            _dicSqlDataType.Add(165, SqlDataType.VarBinary);
            //m_dicSqlDataType.Add(0, SqlDataType.VarBinaryMax);
            _dicSqlDataType.Add(167, SqlDataType.VarChar);
            //m_dicSqlDataType.Add(0, SqlDataType.VarCharMax);
            //m_dicSqlDataType.Add(0, SqlDataType.Variant);
            _dicSqlDataType.Add(241, SqlDataType.Xml);
            //m_dicSqlDataType.Add(0, SqlDataType.SysName);
            _dicSqlDataType.Add(108, SqlDataType.Numeric);
            _dicSqlDataType.Add(40, SqlDataType.Date);
        }

        public void InitConfig(ConnectionStringBuilder connBuilder)
        {
            string query = string.Empty;
 
            try
            {
                this.ConnBuilder = connBuilder;

                this.Conect(); 

                #region Fill Identity Table
                query = "SELECT c.COLUMN_NAME AS ColumnName, c.DATA_TYPE AS 'DataType'" +
                                                                      " FROM INFORMATION_SCHEMA.COLUMNS AS c" +
                                                                      " INNER JOIN" +
                                                                      " INFORMATION_SCHEMA.TABLES AS t " +
                                                                      " ON c.TABLE_SCHEMA = t.TABLE_SCHEMA AND c.TABLE_NAME = t.TABLE_NAME" +
                                                                      " WHERE COLUMNPROPERTY(OBJECT_ID(t.TABLE_SCHEMA + '.' + t.TABLE_NAME), c.COLUMN_NAME, 'isIdentity') = 1" +
                                                                      " AND t.TABLE_TYPE = 'BASE TABLE'";

                _dtIdentity = this.Query(query);
                #endregion

                #region Fill Owner Table
                query = "SELECT dbo.sysobjects.id, dbo.sysobjects.name AS name_object, dbo.sysobjects.uid, dbo.sysusers.name AS nome_owner" +
                        " FROM dbo.sysusers RIGHT OUTER JOIN" +
                        " dbo.sysobjects ON dbo.sysusers.uid = dbo.sysobjects.uid";

                _dtOwner = this.Query(query);
                #endregion

                #region Fill RowsCounter Table
                query = "SELECT so.id, [RowCount] = MAX(si.rows)" + 
                        " FROM sysobjects so, sysindexes si " + 
                        " WHERE so.xtype = 'U' AND si.id = so.id" + 
                        " GROUP BY so.id" + 
                        " ORDER BY 2 DESC";

                _dtRowsCount = this.Query(query);
                #endregion

            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private void fillOwnerTable()
        {
            string query = string.Empty;
 
            try
            {
                //fill Owner Table
                query = "SELECT dbo.sysobjects.id, dbo.sysobjects.name AS name_object, dbo.sysobjects.uid, dbo.sysusers.name AS nome_owner" +
                        " FROM dbo.sysusers RIGHT OUTER JOIN" +
                        " dbo.sysobjects ON dbo.sysusers.uid = dbo.sysobjects.uid";

                _dtOwner = this.Query(query);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }

        public Tables GetTablesCache()
        {
            return this.TablesCache; 
        }
        public Views GetViewsCache()
        {
            return this.ViewsCache; 
        }
        public StoredProcedures GetStoredProceduresCache()
        {
            return this.StoredProceduresCache; 
        }

        public ObjectsClass.Table GetTableByID(int id)
        {
            ObjectsClass.Table tableNull = new ObjectsClass.Table();
 
            try
            {
                tableNull.Id    = 0;
                tableNull.Name  = string.Empty;
                tableNull.Owner = string.Empty;

                foreach (ObjectsClass.Table table in _tables)
	            {
		            if(table.Id == id)
                    {
                        return table;
                    }
	            }

                return tableNull;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public Table GetTableByName(string name)
        {
            Table tableNull = new Table();
 
            try
            {
                tableNull.Id    = 0;
                tableNull.Name  = string.Empty;
                tableNull.Owner = string.Empty;

                foreach (Table table in _tables)
	            {
		            if(table.Name.ToLower() == name.ToLower())
                    {
                        return table;
                    }
	            }

                return tableNull;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public ObjectsClass.Tables GetTables()
        {
            try
            {
                return this.GetTables(false);
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public ObjectsClass.Tables GetTables(bool showSystemObject)
        {
            ObjectsClass.Tables tbc = new ObjectsClass.Tables();

            try
            {
                _tables.Clear();
                fillOwnerTable();

                string whereSystemObject = "";

                if (showSystemObject)
                {
                    whereSystemObject = "OR xtype like 'S'";
                }

                //// preenche tabela com as informações das PK
                //string query = "select object_id, column_id, name from sys.identity_columns";

                //m_dtSys_identity_columns =  Funcoes.FormMain.SqlSmoTools.Query(query);

                string query = "SELECT so.id, so.name, so.crdate " + 
                                " FROM sysobjects so " + 
                                " WHERE xtype like 'U' " + whereSystemObject + " ORDER BY name";

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ObjectsClass.Table table = new ObjectsClass.Table();

                    table.Id            = Convert.ToInt32(dt.Rows[i]["id"]);
                    table.Name          = dt.Rows[i]["name"].ToString();
                    table.CreateDate    = Convert.ToDateTime(dt.Rows[i]["crdate"]); 
                    table.DataBase      = this.DataBase;
                    table.Owner         = getOwnerObject(table.Name); 
                    table.RowCount      = getRowCount(table.Id); 
   
                    tbc.Add(table);
                }

                _tables = tbc;

                return tbc;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }

        public DataTable GetAutoCompleteList()
        {
            try
            {
                DataTable dtTable = new DataTable(this.DataBase);

                dtTable.Columns.Add("ObjectType"); 
                dtTable.Columns.Add("ObjectName");
                dtTable.Columns.Add("ObjectNameImg");
                dtTable.Columns.Add("List");

                string query = "SELECT so.id, so.name, so.xtype" + 
                                " FROM sysobjects so " + 
                                " WHERE xtype like 'U' OR xtype like 'V' OR xtype like 'P' AND so.category <> 2 ORDER BY so.xtype, so.name";

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id          = Convert.ToInt32(dt.Rows[i]["id"]);
                    string name     = dt.Rows[i]["name"].ToString().Trim();
                    string xtype    = dt.Rows[i]["xtype"].ToString().Trim();
                    int type        = 2;
                    string nameImg  = name;
                    string imgID    = string.Empty; 

                    switch (xtype)
                    {
                        case "U":{type = 1; nameImg += "?0"; imgID = "?3"; break;}//Table
                        case "V":{type = 2; nameImg += "?1"; imgID = "?3"; break;}//View
                        case "P":{type = 3; nameImg += "?2"; imgID = "?4"; break;}//StoredProcedure
                    }

                    string textList = getColumns(id, imgID);

                    dtTable.Rows.Add(type, 
                                    name,
                                    nameImg,
                                    textList); 
                }

                return dtTable;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private string getColumns(int id, string imgID)
        {
            string textList = "";

            try
            {
                string query = "SELECT col.name" + 
                                " FROM syscolumns col left outer join systypes tp on col.xusertype=tp.xusertype" +  
                                " WHERE col.id=" + id.ToString() +
                                " ORDER BY col.name" ;

                DataTable dt = this.Query(query);

                bool virgula = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(virgula){textList += ",";}
		 
                    textList += dt.Rows[i]["name"].ToString() + imgID;

                    virgula = true;
                }

                return textList;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }

        public ObjectsClass.Views GetViews()
        {
            try
            {
                return this.GetViews(false);
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public ObjectsClass.Views GetViews(bool showSystemObject)
        {
            ObjectsClass.Views vwc = new ObjectsClass.Views();

            try
            {
                _views.Clear();

                string whereSystemObject = "";

                if (showSystemObject)
                {
                    //whereSystemObject = "OR xtype like 'S'";
                    whereSystemObject = "AND category <> 2"; 
                }

                DataTable dt = this.Query("SELECT name, id FROM sysobjects WHERE xtype like 'V' " + whereSystemObject + " ORDER BY name");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    View view = new View();

                    view.Id        = Convert.ToInt32(dt.Rows[i]["id"]);
                    view.Name      = dt.Rows[i]["name"].ToString();
                    view.DataBase  = this.DataBase;
                    view.Owner     = getOwnerObject(view.Name); 
   
                    vwc.Add(view);
                }

                _views = vwc;

                return vwc;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }

        public StoredProcedures GetStoredProcedures()
        {
            try
            {
                return this.GetStoredProcedures(false);
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public StoredProcedures GetStoredProcedures(bool showSystemObject)
        {
            StoredProcedures spc = new StoredProcedures();

            try
            {
                _storedProcedures.Clear();
                fillOwnerTable();
 
                string whereSystemObject = "";

                if (showSystemObject)
                {
                    //whereSystemObject = "OR xtype like 'S'";
                    whereSystemObject = "AND category <> 2"; 
                }

                DataTable dt = this.Query("SELECT name, id FROM sysobjects WHERE xtype like 'P' " + whereSystemObject + " ORDER BY name");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ObjectsClass.StoredProcedure sp = new ObjectsClass.StoredProcedure();

                    sp.Id        = Convert.ToInt32(dt.Rows[i]["id"]);
                    sp.Name      = dt.Rows[i]["name"].ToString();
                    sp.DataBase  = this.DataBase;
                    sp.Owner     = getOwnerObject(sp.Name); 
   
                    spc.Add(sp);
                }

                _storedProcedures = spc;

                return spc;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }

        public Columns GetColumns(Table table)
        {
            try
            {
                return this.getColumns(table.Id, table.Name, table.DataBase);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        public Columns GetColumns(View view)
        {
            try
            {
                return this.getColumns(view.Id, view.Name, view.DataBase);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        public Columns GetColumns(object objectItem)
        {
            int     id          = 0;
            string  name        = string.Empty;
            string  dataBase    = string.Empty;

            try
            {
                if(objectItem is Table)
                {
                    Table table = (Table)objectItem;
 
                    id          = table.Id;
                    name        = table.Name;
                    dataBase    = table.DataBase; 
                }
                else if(objectItem is View)
                {
                    View view = (View)objectItem;
 
                    id          = view.Id;
                    name        = view.Name;
                    dataBase    = view.DataBase; 
                }

                return this.getColumns(id, name, dataBase);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private Columns getColumns(int id, string name, string dataBase)
        {
            Columns cc = new Columns();

            try
            {
                DataTable dtPK = this.Query("exec sp_pkeys '" + name + "'");
                DataTable dtFK = this.Query("select fk.fkeyid, fk.fkey, fk.rkeyid, obj.name " + 
                                            " from sysforeignkeys fk left outer join sysobjects obj on fk.rkeyid=obj.id" + 
                                            " where fk.fkeyid="  + id.ToString());

                string query = "SELECT col.colid, col.name, col.xusertype, tp.name as xusertype_name, col.length,col.prec, col.xprec, col.xscale, col.isnullable" +
                               ", (SELECT TOP 1 ep.value FROM sys.extended_properties AS ep WHERE ep.major_id = col.id and ep.minor_id = col.colid ) AS [Description]" + 
                               " FROM syscolumns col left outer join systypes tp on col.xusertype=tp.xusertype" +  
                               " WHERE col.id=" + id.ToString() +
                               " ORDER BY colorder" ;

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ObjectsClass.Column col = new ObjectsClass.Column();
                    ObjectsClass.ColumnDataType cdt = new ObjectsClass.ColumnDataType();
                    short xusertype = 0;

                    col.DataBase            = dataBase; 
                    col.Id                  = Convert.ToInt32(dt.Rows[i]["colid"]);
                    col.Name                = dt.Rows[i]["name"].ToString();
                    col.Description         = dt.Rows[i]["Description"].ToString();
                    col.Nullable            = Convert.ToBoolean(dt.Rows[i]["isnullable"]);

                    DataRow[] drIdentity = _dtIdentity.Select("ColumnName LIKE '" + col.Name + "'"); 

                    col.Identity = drIdentity.Length > 0 ? true : false;
                    
                    DataRow[] drPK = dtPK.Select("COLUMN_NAME LIKE '" + col.Name + "'");

                    if(drPK.Length > 0)
                    {
                        col.IsPrimaryKey = true;
                    }
                    else
                    {
                        col.IsPrimaryKey = false;
                    }

                    DataRow[] dr = dtFK.Select("fkey=" + col.Id.ToString());   

                    if(dr.Length > 0)
                    {
                        col.IsForeignKey = true;

                        Table tbl = new Table();

                        tbl.Id    = Convert.ToInt32(dr[0]["rkeyid"]);
                        tbl.Name  = dr[0]["name"].ToString();

                        col.TableForeignKey = tbl;
                    }
                    else
                    {
                        col.IsForeignKey    = false;
                        col.TableForeignKey = new Table();
                    }

                    xusertype               = Convert.ToInt16(dt.Rows[i]["xusertype"]);
                    cdt.SqlDataType         = _dicSqlDataType[xusertype];
                    cdt.MaximumLength       = dt.Rows[i]["prec"] != DBNull.Value  ? Convert.ToInt16(dt.Rows[i]["prec"]) : (short)0;
                    cdt.Name                = dt.Rows[i]["xusertype_name"].ToString();
                    cdt.NumericPrecision    = dt.Rows[i]["xprec"] != DBNull.Value  ? Convert.ToInt16(dt.Rows[i]["xprec"]) : (short)0;
                    cdt.NumericScale        = dt.Rows[i]["xscale"] != DBNull.Value  ? Convert.ToInt16(dt.Rows[i]["xscale"]) : (short)0;

                    col.DataType = cdt;

                    cc.Add(col);
                }

                return cc;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
            
        public ObjectsClass.StoredProcedureParameters GetStoredProcedureParameters(StoredProcedure sp)
        {
            ObjectsClass.StoredProcedureParameters sppc = new ObjectsClass.StoredProcedureParameters();

            try
            {
                string query = "SELECT col.colid, col.name, col.xusertype, tp.name as xusertype_name, col.length, col.prec, col.xprec, col.xscale, col.isoutparam" + 
                                " FROM syscolumns col left outer join systypes tp on col.xusertype=tp.xusertype" +  
                                " WHERE col.id=" + sp.Id.ToString() +
                                " ORDER BY colorder" ;

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ObjectsClass.StoredProcedureParameter spp = new ObjectsClass.StoredProcedureParameter();
                    ObjectsClass.ColumnDataType cdt = new ObjectsClass.ColumnDataType();
                    short xusertype = 0;

                    spp.DataBase            = sp.DataBase;
                    spp.StoredProcedure     = sp;
                    spp.Id                  = Convert.ToInt32(dt.Rows[i]["colid"]);
                    spp.Name                = dt.Rows[i]["name"].ToString();
                    spp.IsOutputParameter   = Convert.ToBoolean(dt.Rows[i]["isoutparam"]);

                    xusertype               = Convert.ToInt16(dt.Rows[i]["xusertype"]);
                    cdt.SqlDataType         = _dicSqlDataType[xusertype];

                    cdt.MaximumLength       = Convert.ToInt16(dt.Rows[i]["prec"]);//length
                    cdt.Name                = dt.Rows[i]["xusertype_name"].ToString();
                    cdt.NumericPrecision    = Convert.ToInt16(dt.Rows[i]["xprec"]);
                    cdt.NumericScale        = Convert.ToInt16(dt.Rows[i]["xscale"]);

                    spp.DataType = cdt;
                   
                    switch (spp.DataType.SqlDataType) 
                    {
                        case SqlDataType.Char:
                        case SqlDataType.NChar:
                        case SqlDataType.NVarChar:
                        case SqlDataType.Binary:
                        case SqlDataType.VarBinary:
                        case SqlDataType.VarChar:
                            {
                                spp.TypeWithLength = spp.DataType.Name + "(" + spp.DataType.MaximumLength.ToString() + ")";
                                break;
                            }
                        case SqlDataType.Numeric:
                            {
                                spp.TypeWithLength = spp.DataType.Name + "(" + spp.DataType.MaximumLength.ToString() + ",0)";
                                break;
                            }
                        default:
                            {
                                spp.TypeWithLength = spp.DataType.Name;
                                break;
                            }
                    }

                    sppc.Add(spp);
                }

                return sppc;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }

        public string GetText(View view)
        {
            try
            {
                return this.getText(view.Name);
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public string GetText(StoredProcedure sp)
        {
            try
            {
                return this.getText(sp.Name);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        public void SetRowCount(ref Table table)
        {
            try
            {
                DataTable dt = this.Query("SELECT COUNT(*) as count FROM " + table.Name);

                table.RowCount = Convert.ToInt32(dt.Rows[0]["count"]);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        public int GetRowCount(Table table)
        {
            try
            {
                DataTable dt = this.Query("SELECT COUNT(*) as count FROM " + table.Name);

                return Convert.ToInt32(dt.Rows[0]["count"]);
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        public int getRowCount(int tableID)
        {
            int rowCount = 0;

            try
            {
                DataRow[] dr = _dtRowsCount.Select("id=" + tableID.ToString());   

                if(dr.Length == 1)
                {
                    rowCount = Convert.ToInt32(dr[0]["RowCount"]);
                }

                return rowCount;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private string getText(string objectName)
        {
            StringBuilder sb = new StringBuilder();
 
            try
            {
                string query = string.Format("exec sp_helptext '{0}'", objectName);

                DataTable dt = this.Query(query);

                foreach (DataRow dr in dt.Rows)
	            {
                    sb.Append(dr["Text"].ToString()); 
	            }

                return sb.ToString();
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private string getOwnerObject(string objectName)
        {
            string ownerObject = "";

            try
            {
                objectName = objectName.Replace("'", "''"); 

                DataRow[] dr = _dtOwner.Select("name_object LIKE '" + objectName + "'");   
 
                if(dr.Length == 1)
                {
                    ownerObject = dr[0]["nome_owner"].ToString();  
                }

                return ownerObject;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }

        		/// <summary>
		/// Função para conectar no banco.
		/// </summary>
		public void Conect()
		{
			try
			{
                _conn = new SqlConnection(); 

                if(_connBuilder.IntegratedSecurity)
                {
                    _conn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", 
                                                            _connBuilder.ServerName,
                                                            _connBuilder.DataBase);
                }
                else
                {
                    _conn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", 
                                                            _connBuilder.ServerName,
                                                            _connBuilder.DataBase,
                                                            _connBuilder.UserName,
                                                            _connBuilder.Password);
                }
			}
			catch (Exception e)
			{
				_conn = null;
				throw e;
			}
		}
		/// <summary>
		/// Função para conectar no banco.
		/// </summary>
		/// <param name="connBuilder">String de conexão</param>
		public void Conect(ConnectionStringBuilder connBuilder)
		{
			try
			{
				_connBuilder = connBuilder;
 	 
                this.Conect(); 
			}
			catch (Exception e)
			{
				throw e;
			}
		}

        /// <summary>
		/// Função para conectar no banco.
		/// </summary>
		public void Open()
		{
			try
			{
  				this.Close(); 
                _conn.Open();
			}
			catch (Exception e)
			{
				_conn = null;
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
			    if(_conn != null)
			    {
				    _conn.Close();
			    }
            }
			catch (Exception e)
			{
				_conn = null;
				throw e;
			}
		}

		/// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="query">Informe uma consulta SQL.</param>
		/// <returns>Retorna um SqlDataReader</returns>
		public SqlDataReader Query(string query, CommandBehavior cb)
		{
            try
            {
                this.Open();

			    SqlCommand sqlCommand = new SqlCommand(query, _conn);

			    SqlDataReader dr = sqlCommand.ExecuteReader(cb);  
					
                this.Close(); 

			    return dr;
            }
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Função para gerar uma consulta.
		/// </summary>
		/// <param name="query">Informe uma consulta SQL.</param>
		/// <returns>Retorna um DataTable</returns>
		public DataTable Query(string query)
		{
			try
			{
                this.Open();
 
				SqlCommand sqlCommand = new SqlCommand(query, _conn);

                sqlCommand.CommandTimeout = 360;

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				
				DataTable dt = new DataTable(); 
                
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
			    SqlCommand sqlCommand = new SqlCommand(queryCommand, _conn);

			    sqlCommand.ExecuteNonQuery();
            }
			catch (Exception e)
			{
				throw e;
			}
		}
    }
}
