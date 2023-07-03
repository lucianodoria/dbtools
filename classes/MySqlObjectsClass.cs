using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using DBTools.classes.ObjectsClass;
using MySql.Data.MySqlClient;

namespace DBTools.classes
{
    public class MySqlObjectsClass : IDataBaseObjects
    {
        private DataTable						_dtIdentity			= new DataTable();
        private DataTable						_dtOwner			= new DataTable();
        private DataTable						_dtRowsCount		= new DataTable();
        private Tables							_tables				= new Tables();
        private Views							_views				= new Views();
        private StoredProcedures				_storedProcedures	= new StoredProcedures();
        private Dictionary<short, SqlDataType>	_dicSqlDataType		= new Dictionary<short, SqlDataType>();
        private MySqlConnection					_conn;
        private string							_serverName;
        private string							_dataBase;
        private string							_userName;
        private string							_password;
        private int								_connectTimeout;

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
        public string DataBase
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
            set {_connectTimeout = value; }
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

        public MySqlObjectsClass()
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
        }

        public void InitConfig(ConnectionStringBuilder connBuilder)
        {
            string query = string.Empty;
 
            try
            {
                this.ServerName     = connBuilder.ServerName;
                this.DataBase       = connBuilder.DataBase;
                this.UserName       = connBuilder.UserName;
                this.Password       = connBuilder.Password;

                this.Conect(); 

                //#region Fill Identity Table
                //query = "SELECT c.COLUMN_NAME AS ColumnName, c.DATA_TYPE AS 'DataType'" +
                //                                                      " FROM INFORMATION_SCHEMA.COLUMNS AS c" +
                //                                                      " INNER JOIN" +
                //                                                      " INFORMATION_SCHEMA.TABLES AS t " +
                //                                                      " ON c.TABLE_SCHEMA = t.TABLE_SCHEMA AND c.TABLE_NAME = t.TABLE_NAME" +
                //                                                      " WHERE COLUMNPROPERTY(OBJECT_ID(t.TABLE_SCHEMA + '.' + t.TABLE_NAME), c.COLUMN_NAME, 'isIdentity') = 1" +
                //                                                      " AND t.TABLE_TYPE = 'BASE TABLE'";

                //_dtIdentity = this.Query(query);
                //#endregion

                //#region Fill Owner Table
                //query = "SELECT dbo.sysobjects.id, dbo.sysobjects.name AS name_object, dbo.sysobjects.uid, dbo.sysusers.name AS nome_owner" +
                //        " FROM dbo.sysusers RIGHT OUTER JOIN" +
                //        " dbo.sysobjects ON dbo.sysusers.uid = dbo.sysobjects.uid";

                //_dtOwner = this.Query(query);
                //#endregion

                //#region Fill RowsCounter Table
                //query = "SELECT so.id, [RowCount] = MAX(si.rows)" + 
                //        " FROM sysobjects so, sysindexes si " + 
                //        " WHERE so.xtype = 'U' AND si.id = so.id" + 
                //        " GROUP BY so.id" + 
                //        " ORDER BY 2 DESC";

                //_dtRowsCount = this.Query(query);
                //#endregion

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

        public Table GetTableByID(int id)
        {
            Table tableNull = new Table();
 
            try
            {
                tableNull.Id    = 0;
                tableNull.Name  = string.Empty;
                tableNull.Owner = string.Empty;

                foreach (Table table in _tables)
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
        public Tables GetTables()
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
        public Tables GetTables(bool showSystemObject)
        {
            Tables tbc = new Tables();

            try
            {
                _tables.Clear();
                //fillOwnerTable();

                //string whereSystemObject = "";

                //if (showSystemObject)
                //{
                //    whereSystemObject = "OR xtype like 'S'";
                //}

                //// preenche tabela com as informações das PK
                //string query = "select object_id, column_id, name from sys.identity_columns";

                //m_dtSys_identity_columns =  Funcoes.FormMain.SqlSmoTools.Query(query);

                string query = string.Format("SHOW TABLE STATUS FROM {0}", this.DataBase);

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Table table = new Table();

                    table.Id            = 0;//Convert.ToInt32(dt.Rows[i]["id"]);
                    table.Name          = dt.Rows[i]["name"].ToString();

                    if(dt.Rows[i]["Create_time"] != DBNull.Value)
                    {
                        table.CreateDate    = Convert.ToDateTime(dt.Rows[i]["Create_time"]); 
                    }
                    else
                    {
                        table.CreateDate = DateTime.Now;
                    }
                    
                    table.DataBase      = this.DataBase;
                    table.Owner         = "";//getOwnerObject(table.Name); 
                    
                    if(dt.Rows[i]["Rows"] != DBNull.Value)
                    {
                        table.RowCount      = Convert.ToInt32(dt.Rows[i]["Rows"]); 
                    }
                    else
                    {
                        table.RowCount = 0;
                    }

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

        public Views GetViews()
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
        public Views GetViews(bool showSystemObject)
        {
            Views vwc = new Views();

            try
            {
                _views.Clear();

                DataTable dt = this.Query("SELECT name, id FROM sysobjects WHERE xtype like 'V' ORDER BY name");

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
                //fillOwnerTable();

                DataTable dt = this.Query("SELECT name, id FROM sysobjects WHERE xtype like 'P' ORDER BY name");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StoredProcedure sp = new StoredProcedure();

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
                //DataTable dtPK = this.Query("exec sp_pkeys '" + name + "'");
                //DataTable dtFK = this.Query("select fk.fkeyid, fk.fkey, fk.rkeyid, obj.name " + 
                //                            " from sysforeignkeys fk left outer join sysobjects obj on fk.rkeyid=obj.id" + 
                //                            " where fk.fkeyid="  + id.ToString());

                //Field      | Type     | Null | Key | Default | Extra

                string query = string.Format("SHOW COLUMNS FROM {1}.{0}", name, dataBase);

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Column col = new Column();
                    ColumnDataType cdt = new ColumnDataType();

                    string	field	= dt.Rows[i]["Field"].ToString().Trim();
                    string	type	= dt.Rows[i]["Type"].ToString().Trim();
                    bool	isNull	= dt.Rows[i]["Null"].ToString().Trim() == "NO" ? false : true;
                    string	key		= dt.Rows[i]["Key"].ToString().Trim();
                    string	extra	= dt.Rows[i]["Extra"].ToString().Trim();

                    col.DataBase	= dataBase;
                    col.Id			= 0;//Convert.ToInt32(dt.Rows[i]["colid"]);
                    col.Name		= field;
                    col.Nullable	= isNull;
                    col.Identity	= extra.Contains("auto_increment");

                    //DataRow[] drPK = dtPK.Select("COLUMN_NAME LIKE '" + col.Name + "'");

                    if(key == "PRI")
                    {
                        col.IsPrimaryKey = true;
                    }
                    else
                    {
                        col.IsPrimaryKey = false;
                    }

                    //DataRow[] dr = dtFK.Select("fkey=" + col.Id.ToString());   

                    //if(dr.Length > 0)
                    //{
                    //    col.IsForeignKey = true;

                    //    Table tbl = new Table();

                    //    tbl.Id    = Convert.ToInt32(dr[0]["rkeyid"]);
                    //    tbl.Name  = dr[0]["name"].ToString();

                    //    col.TableForeignKey = tbl;
                    //}
                    //else
                    //{
                        col.IsForeignKey    = false;
                        col.TableForeignKey = new Table();
                    //}

                    MySQLDataType mySQLDataType = getColumnType(name, field); 

                    cdt.SqlDataType         = mySQLDataType.SqlDataType;
                    cdt.MaximumLength       = mySQLDataType.CharacterMaximumLength;
                    cdt.Name                = mySQLDataType.DataType;
                    cdt.NumericPrecision    = mySQLDataType.NumericPrecision;
                    cdt.NumericScale        = mySQLDataType.NumericScale;

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
        
        private struct MySQLDataType
        {
            public string TableCatalog;
            public string TableSchema;
            public string TableName;
            public string ColumnName;
            public string OrdinalPosition;
            public string IsNullable;
            public string DataType;
            public int CharacterMaximumLength;
            public string CharacterOctetLength;
            public int NumericPrecision;
            public int NumericScale;
            public string CharacterSetName;
            public string CollationName;
            public string ColumnType;
            public string ColumnKey;
            public SqlDataType SqlDataType;
        }

        private MySQLDataType getColumnType(string table, string columName)
        {
            MySQLDataType mySQLDataType = new MySqlObjectsClass.MySQLDataType(); 

            try
            {
                string query = string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name='{0}' AND COLUMN_NAME='{1}';", table, columName);

                DataTable dt = this.Query(query);

                mySQLDataType.TableCatalog              = dt.Rows[0]["TABLE_CATALOG"].ToString().Trim();
                mySQLDataType.TableSchema               = dt.Rows[0]["TABLE_SCHEMA"].ToString().Trim();
                mySQLDataType.TableName                 = dt.Rows[0]["TABLE_NAME"].ToString().Trim();
                mySQLDataType.ColumnName                = dt.Rows[0]["COLUMN_NAME"].ToString().Trim();
                mySQLDataType.OrdinalPosition           = dt.Rows[0]["ORDINAL_POSITION"].ToString().Trim();
                mySQLDataType.IsNullable                = dt.Rows[0]["IS_NULLABLE"].ToString().Trim();
                mySQLDataType.DataType                  = dt.Rows[0]["DATA_TYPE"].ToString().Trim();
                mySQLDataType.CharacterMaximumLength    = dt.Rows[0]["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim().Length == 0 ? 0 : dt.Rows[0]["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim().ToInt32();
                mySQLDataType.CharacterOctetLength      = dt.Rows[0]["CHARACTER_OCTET_LENGTH"].ToString().Trim();
                mySQLDataType.NumericPrecision          = dt.Rows[0]["NUMERIC_PRECISION"].ToString().Trim().Length == 0 ? 0 : dt.Rows[0]["NUMERIC_PRECISION"].ToString().Trim().ToInt32();
                mySQLDataType.NumericScale              = dt.Rows[0]["NUMERIC_SCALE"].ToString().Trim().Length == 0 ? 0 : dt.Rows[0]["NUMERIC_SCALE"].ToString().Trim().ToInt32();
                mySQLDataType.CharacterSetName          = dt.Rows[0]["CHARACTER_SET_NAME"].ToString().Trim();
                mySQLDataType.CollationName             = dt.Rows[0]["COLLATION_NAME"].ToString().Trim();
                mySQLDataType.ColumnType                = dt.Rows[0]["COLUMN_TYPE"].ToString().Trim();
                mySQLDataType.ColumnKey                 = dt.Rows[0]["COLUMN_KEY"].ToString().Trim();

                switch (mySQLDataType.DataType.ToUpper())
                {
                    case "INT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Int;
                            break;
                        }
                    case "VARCHAR" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.VarChar;
                            break;
                        }
                    case "TEXT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Text;
                            break;
                        }
                    case "DATE" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Date;
                            break;
                        }
                    case "TINYINT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.TinyInt;
                            break;
                        }
                    case "SMALLINT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.SmallInt;
                            break;
                        }
                    case "MEDIUMINT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Int;
                            break;
                        }
                    case "BIGINT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.BigInt;
                            break;
                        }
                    case "DECIMAL" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Decimal;
                            break;
                        }
                    case "FLOAT" :
                    case "DOUBLE" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Float;
                            break;
                        }
                    case "REAL" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Real;
                            break;
                        }
                    case "BIT" :
                    case "BOOLEAN" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Bit;
                            break;
                        }
                    case "SERIAL" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.BigInt;
                            break;
                        }
                    case "DATETIME" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.DateTime;
                            break;
                        }
                    case "TIMESTAMP" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Timestamp;
                            break;
                        }
                    case "TIME" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Time;
                            break;
                        }
                    case "YEAR" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Int;
                            break;
                        }
                    case "CHAR" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Char;
                            break;
                        }
                    case "TINYTEXT" :
                    case "MEDIUMTEXT" :
                    case "LONGTEXT" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Text;
                            break;
                        }
                    case "BINARY" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Binary;
                            break;
                        }
                    case "VARBINARY" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.VarBinary;
                            break;
                        }
                    case "TINYBLOB" :
                    case "MEDIUMBLOB" :
                    case "BLOB" :
                    case "LONGBLOB" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.Image;
                            break;
                        }
                    case "ENUM" :
                    case "SET" :
                    case "GEOMETRY" :
                    case "POINT" :
                    case "LINESTRING" :
                    case "POLYGON" :
                    case "MULTIPOINT" :
                    case "MULTILINESTRING" :
                    case "MULTIPOLYGON" :
                    case "GEOMETRYCOLLECTION" :
                        {
                            mySQLDataType.SqlDataType = SqlDataType.None;
                            break;
                        }
                    default:
                        {
                            mySQLDataType.SqlDataType = SqlDataType.None;
                        }
                        break;
                }


                return mySQLDataType;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }

        public StoredProcedureParameters GetStoredProcedureParameters(StoredProcedure sp)
        {
            StoredProcedureParameters sppc = new StoredProcedureParameters();

            try
            {
                string query = "SELECT col.colid, col.name, col.xusertype, tp.name as xusertype_name, col.length, col.xprec, col.xscale, col.isoutparam" + 
                                " FROM syscolumns col left outer join systypes tp on col.xusertype=tp.xusertype" +  
                                " WHERE col.id=" + sp.Id.ToString() +
                                " ORDER BY colorder" ;

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StoredProcedureParameter spp = new StoredProcedureParameter();
                    ColumnDataType cdt = new ColumnDataType();
                    short xusertype = 0;

                    spp.DataBase            = sp.DataBase;
                    spp.StoredProcedure     = sp;
                    spp.Id                  = Convert.ToInt32(dt.Rows[i]["colid"]);
                    spp.Name                = dt.Rows[i]["name"].ToString();
                    spp.IsOutputParameter   = Convert.ToBoolean(dt.Rows[i]["isoutparam"]);

                    xusertype               = Convert.ToInt16(dt.Rows[i]["xusertype"]);
                    cdt.SqlDataType         = _dicSqlDataType[xusertype];

                    cdt.MaximumLength       = Convert.ToInt16(dt.Rows[i]["length"]);
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

        public DataTable GetAutoCompleteList()
        {
            try
            {
                DataTable dtTable = new DataTable();

                dtTable.Columns.Add("DataBase");
                dtTable.Columns.Add("ObjectType"); 
                dtTable.Columns.Add("ObjectName");
                dtTable.Columns.Add("List");

                string query = string.Format("SHOW TABLES FROM {0}", this.DataBase);

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tableName = dt.Rows[i][0].ToString();

                    string textList = getColumns(tableName);

                    dtTable.Rows.Add(this.DataBase,
                                    2, //type = Table 
                                    tableName,
                                    textList); 
                }

                return dtTable;
            }
            catch (Exception exc)
            {
                throw (exc); 
            }
        }
        private string getColumns(string tableName)
        {
            string textList = "";

            try
            {

                bool espace = false;

                string query = string.Format("SHOW COLUMNS FROM {1}.{0}", tableName, this.DataBase);

                DataTable dt = this.Query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     if(espace){textList += " ";}
		 
                    textList += dt.Rows[i]["Field"].ToString();

                    espace = true;
                }

                return textList;
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
                _conn                  = new MySqlConnection();
                //m_conn.ConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4};", ServerName, DataBaseName, UserName, Password, 3306);
                _conn.ConnectionString = string.Format("Server={0};User Id={1};Password={2};Port={3};Database=mysql", ServerName, UserName, Password, 3306);
			}
			catch (Exception e)
			{
				_conn = null;
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
 
				MySqlCommand sqlCommand = new MySqlCommand(query, _conn);

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
			    MySqlCommand sqlCommand = new MySqlCommand(queryCommand, _conn);

			    sqlCommand.ExecuteNonQuery();
            }
			catch (Exception e)
			{
				throw e;
			}
		}
    }
}
