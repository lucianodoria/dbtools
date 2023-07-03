using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBTools.classes;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;  

namespace DBTools.forms
{
    public partial class frmLogon : Form
    {
        private DataTable	_dtServes			= new DataTable("Config");
        private DataTable	_dtUsers			= new DataTable("Users");
        private string		_fileNameServers	= string.Empty;
        private string		_fileNameUsers		= string.Empty;
        private SQLSmoTools	_sqlSMOTools		= new SQLSmoTools();
        private ServerType	_serverType			= new ServerType();

        public SQLSmoTools SqlSMOTools
        {
            get { return _sqlSMOTools; }
        }
        public ServerType ServerType
        {
            get { return _serverType; }
        }

        public frmLogon()
        {
            InitializeComponent();

            cboAutenticacao.SelectedIndex = 0;
 
            _dtServes.Columns.Add("ServerType");
            _dtServes.Columns.Add("Server");
 
            _dtUsers.Columns.Add("ServerType");
            _dtUsers.Columns.Add("Server");
            _dtUsers.Columns.Add("User");
            _dtUsers.Columns.Add("Password");
            _dtUsers.Columns.Add("RememberPassword");
            _dtUsers.Columns.Add("IntegratedSecurity"); 
        }

#region FORM

        private void frmLogon_Load(object sender, EventArgs e)
        {
            try
            {
                _fileNameServers    = Application.StartupPath + @"\Servers.xml";
                _fileNameUsers      = Application.StartupPath + @"\Users.xml";

                if(File.Exists(_fileNameServers))
                {
                    _dtServes.ReadXml(_fileNameServers); 
                }

                if(File.Exists(_fileNameUsers))
                {
                    _dtUsers.ReadXml(_fileNameUsers); 
                }

                cboServerType.SelectedIndex = 1; 

                registrosCarregar(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frmLogon_FormClosing(object sender, FormClosingEventArgs e)
        {
            registrosGravar(); 
        }

#endregion

#region FUNCOES

        private void registrosCarregar()
		{
			try
			{
                RegistrosINI INI = new RegistrosINI();

                INI.Arquivo = Application.StartupPath + @"\DBTools.ini";
                //
                //DATA_BASE
                //
                INI.Sessao = "DATA_BASE";

                chkDataBaseShowDenyReader.Checked   = INI.Ler("DataBaseShowDenyReader", false);
                chkDataBaseShowSystemObject.Checked = INI.Ler("DataBaseShowSystemObject", false);
                //
                //TABLE
                //           
                INI.Sessao = "TABLE";

                chkTableShowColumnsDataType.Checked = INI.Ler("TableShowColumnsDataType", false);
                chkTableShowFK.Checked = INI.Ler("TableShowFK", true);
                chkTableShowSystemObject.Checked = INI.Ler("TableShowSystemObject", false);
                //
                //VIEW
                //
                INI.Sessao = "VIEW";

                chkViewShowColumnsDataType.Checked = INI.Ler("ViewShowColumnsDataType", false);
                chkViewShowSystemObject.Checked = INI.Ler("ViewShowSystemObject", false);
                //
                //STORED_PROCEDURE
                //
                INI.Sessao = "STORED_PROCEDURE";

                chkSPShowColumnsDataType.Checked = INI.Ler("SPShowColumnsDataType", false);
                chkSPShowSystemObject.Checked = INI.Ler("SPShowSystemObject", false);              

            }
            catch (SmoException smoExc)
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
        private void registrosGravar()
		{
			try
            {
                RegistrosINI INI = new RegistrosINI();

                INI.Arquivo = Application.StartupPath + @"\DBTools.ini";
                //
                //DATA_BASE
                //
                INI.Sessao = "DATA_BASE";

                INI.Gravar("DataBaseShowDenyReader", chkDataBaseShowDenyReader.Checked);
                INI.Gravar("DataBaseShowSystemObject", chkDataBaseShowSystemObject.Checked);
                //
                //TABLE
                //           
                INI.Sessao = "TABLE";

                INI.Gravar("TableShowColumnsDataType", chkTableShowColumnsDataType.Checked);
                INI.Gravar("TableShowFK", chkTableShowFK.Checked);
                INI.Gravar("TableShowSystemObject", chkTableShowSystemObject.Checked);
                //
                //VIEW
                //
                INI.Sessao = "VIEW";

                INI.Gravar("ViewShowColumnsDataType", chkViewShowColumnsDataType.Checked);
                INI.Gravar("ViewShowSystemObject", chkViewShowSystemObject.Checked);
                //
                //STORED_PROCEDURE
                //
                INI.Sessao = "STORED_PROCEDURE";

                INI.Gravar("SPShowColumnsDataType", chkSPShowColumnsDataType.Checked);
                INI.Gravar("SPShowSystemObject", chkSPShowSystemObject.Checked);
			}
            catch (SmoException smoExc)
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
        private void saveConfig(string user, 
                                string password, 
                                bool rememberPassword,
                                string serverType,
                                string server,
                                bool integratedSecurity)
        { 
            password = CryptographyClass.Criptografar(password); 

            if (_dtServes.Rows.Count > 0)
            {
                #region Existe servidor

                string querySelect = string.Format("ServerType='{0}' AND Server='{1}'", serverType, server);

                #region Servidor

                DataRow[] drServer = _dtServes.Select(querySelect);

                if (drServer.Length <= 0)
                {
                    // insere um novo registro, pois não existe
                    object[] rowServer  = {serverType, server};

                    _dtServes.Rows.Add(rowServer);
                }

                #endregion

                #region Usuário

                DataRow[] drUser = _dtUsers.Select(string.Format("{0} AND User='{1}'", querySelect, user));

                if (drUser.Length == 1)
                {
                    #region Usuário Existe
                    // atualiza pois já existe a registro
                    _dtUsers.Select(querySelect)[0]["User"]               = user;
                    _dtUsers.Select(querySelect)[0]["RememberPassword"]   = rememberPassword;

                    if (rememberPassword)
                    {
                        _dtUsers.Select(querySelect)[0]["Password"] = password;
                    }

                    _dtUsers.Select(querySelect)[0]["IntegratedSecurity"]   = integratedSecurity;

                    #endregion
                }
                else
                {
                    #region Usuário não existe

                    // insere um novo registro, pois não existe
                    object[] rowUser    = {serverType, server, user, password, rememberPassword, integratedSecurity};

                    _dtUsers.Rows.Add(rowUser);

                    #endregion
                }

                #endregion

                #endregion
            }
            else
            {
                #region Não existe

                // insere um novo registro, pois não existe
                object[] rowServer  = {serverType, server};
                object[] rowUser    = {serverType, server, user, password, rememberPassword, integratedSecurity};

                _dtServes.Rows.Add(rowServer);
                _dtUsers.Rows.Add(rowUser);

                #endregion
            }

            _dtServes.WriteXml(_fileNameServers); 
            _dtUsers.WriteXml(_fileNameUsers); 
        }



#endregion

#region EVENTOS DE OBJETOS

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string  user                = "";
            string  password            = "";
            bool    rememberPassword    = false;
            string  serverType          = "";
            string  server              = "";
            bool    integratedSecurity  = false;

            try
            {
                server                  = cboServers.Text.Trim();
                _sqlSMOTools.ServerName = server;
                serverType              = cboServerType.Text.Trim();   

                if(cboAutenticacao.SelectedIndex == 0)
                {
                    _sqlSMOTools.IntegratedSecurity = true;
                    integratedSecurity              = true;
                }
                else
                {
                    user                        = cboUser.Text.Trim();
                    password                    = txtPassword.Text.Trim();
                    rememberPassword            = chkRememberPassword.Checked;
                    integratedSecurity          = false;

                    _sqlSMOTools.UserName      = user;
                    _sqlSMOTools.Password      = password;
                }

                saveConfig(user, password, rememberPassword, serverType, server, integratedSecurity);

                // desconecta primeiro
                _sqlSMOTools.DisConnect();
                _sqlSMOTools.Connect();

                this.DialogResult = DialogResult.OK;   
                this.Close();
            }
            catch (SmoException smoExc)
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
        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            if (gpbTabela.Visible)
            {
                gpbBancoDados.Visible   = false;
                gpbTabela.Visible       = false;
                gpbView.Visible         = false;
                gpbSP.Visible           = false;
                this.Height             = this.MinimumSize.Height;
                btnOpcoes.Text          = "Opções >>";
            }
            else
            {
                gpbBancoDados.Visible   = true;
                gpbTabela.Visible       = true;
                gpbView.Visible         = true;
                gpbSP.Visible           = true;
                this.Height             = this.MaximumSize.Height;
                btnOpcoes.Text          = "<< Opções";
            }
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return){btnConectar_Click(null, null);}  
        }
        private void cboServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  serverType = cboServerType.Text.Trim();

            // limpa os campos
            cboUser.Items.Clear();  
            cboUser.Text                    = string.Empty;
            txtPassword.Text                = string.Empty;;
            chkRememberPassword.Checked     = false;
            cboAutenticacao.SelectedIndex   = 1; 
            cboServers.Items.Clear();
            cboServers.Text = string.Empty; 
  
            _serverType = cboServerType.SelectedIndex == 0 ? ServerType.MySQL : ServerType.SQLServer;

            if(_dtServes.Rows.Count > 0)
            {
                string querySelect = string.Format("ServerType='{0}'", serverType);

                DataRow[] drServers = _dtServes.Select(querySelect);

                foreach (var dr in drServers)
                {
                    cboServers.Items.Add(dr["Server"]);
                }

                if(cboServers.Items.Count > 0)
                {
                    cboServers.SelectedIndex = 0;
                }
            }
        }
        private void cboServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  serverType          = cboServerType.Text.Trim();
            string  server              = cboServers.Text.Trim();

            if(_dtUsers.Rows.Count > 0)
            {
                string querySelect = string.Format("ServerType='{0}' AND Server='{1}'", serverType, server);

                DataRow[] drUsers = _dtUsers.Select(querySelect);

                foreach (var drUser in drUsers)
                {
                    if(drUser["User"].ToString().Trim().Length <= 0){continue;}  

                    cboUser.Items.Add(drUser["User"]);   
                }
            }

            if(cboUser.Items.Count > 0){cboUser.SelectedIndex = 0;}
        }
        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  password            = "";
            bool    rememberPassword    = false;
            string  serverType          = cboServerType.Text.Trim();
            string  server              = cboServers.Text.Trim();
            string  user                = cboUser.Text.Trim();
            bool    integratedSecurity  = false;

            if(_dtUsers.Rows.Count > 0)
            {
                string querySelect = string.Format("ServerType='{0}' AND Server='{1}' AND User='{2}'", serverType, server, user);

                DataRow[] drUsers = _dtUsers.Select(querySelect);

                if(drUsers.Length > 0)
                {
                    rememberPassword    = Convert.ToBoolean(drUsers[0]["RememberPassword"]);
                    integratedSecurity  = Convert.ToBoolean(drUsers[0]["IntegratedSecurity"]);

                    if(rememberPassword)
                    {
                        password = CryptographyClass.Descriptografar(drUsers[0]["Password"].ToString());
                    }
                }
            }

            txtPassword.Text                = password;
            chkRememberPassword.Checked     = rememberPassword;
            cboAutenticacao.SelectedIndex   = integratedSecurity ?  0:1; 
        }
        private void cboAutenticacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlLogin.Enabled = cboAutenticacao.SelectedIndex == 1 ? true:false;  
        }

#endregion


    }
}