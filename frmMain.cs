using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;   
using System.IO;
using System.Text;
using System.Xml;
using DBTools.classes;
using DBTools.forms;
using System.Threading;
using Microsoft.SqlServer.Management.Smo;
using Crom.Controls;
using System.Reflection;
using System.Diagnostics;

namespace DBTools
{
    public enum ServerType
    {
        SQLServer   = 1,
        MySQL       = 2
    }

    public partial class frmMain : Form   
	{
        private SQLSmoTools m_sqlSmoTools               = new SQLSmoTools();
		private ArrayList   m_aItem				        = new ArrayList();

        internal frmServerExplorer  FormServerExplorer  = null;
        internal frmSQLEditor       FormSQLEditor       = null;
        internal frmFunction        FormFunction        = null;
        internal ServerType         _serverType         = new ServerType(); 

        //
        //Configurações do Bancos de Dados
        //
        internal bool _dataBaseShowSystemObject            = false;
        internal bool _dataBaseShowDenyReader              = false;
        //
        //Configurações Tabelas
        //
        internal bool _tableShowSystemObject               = false;
        internal bool _tableShowColumnsDataType            = false;
        internal bool _tableShowFK                         = false;
        //
        //Configurações Views
        //
        internal bool _viewShowSystemObject               = false;
        internal bool _viewShowColumnsDataType            = false;
        //
        //Configurações SPs
        //
        internal bool _spShowSystemObject                  = false;
        internal bool _spShowColumnsDataType               = false;

        internal string server      = string.Empty;
        internal string database    = string.Empty; 
        internal string user        = string.Empty; 
        internal string passowrd    = string.Empty;

        internal string _TEXT_FORM = "";

        /// <summary>
        /// Resgata a classe SQLSMOTools
        /// </summary>
        public SQLSmoTools SqlSmoTools
        {
            get { return m_sqlSmoTools; }
        }

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //cboServers.Items.AddRange(SqlLocator.GetServers());
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            _TEXT_FORM = string.Format("DBTools v{0} {1} - SQL Server 2017 - by Luciano Dória", Application.ProductVersion, versionInfo.LegalTrademarks); 
        }

#region FORMS

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.Text  = _TEXT_FORM;

                Control.CheckForIllegalCrossThreadCalls = false;

                Funcoes.FormMain = this;

                dockPanelMain.LeftPanelWidth = 240;
                //ListarSkins(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o DBTools?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                if(FormSQLEditor != null){FormSQLEditor.Close();}

                m_sqlSmoTools.DisConnect();
                m_sqlSmoTools = null;
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
            finally
            {
                Application.ExitThread();
            }
        }

#endregion

#region FUNÇÕES ESPECIAIS

        internal void SetTextDataBase(string dataBase)
        {
            this.Text				= _TEXT_FORM + " - [" + dataBase + "]";
            FormSQLEditor.Text		= "SQL Editor - [" + dataBase + "]";
            FormSQLEditor.DataBaseName = dataBase;
            FormSQLEditor.SetAutoCompleteDefault(); 
        }

        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 09/07/2008 07:47
        * Data de modificação	= 
        **************************************************************/
        private void ListarSkins()
        {
            try
            {
                RegistrosINI INI = new RegistrosINI();

                INI.Arquivo = Application.StartupPath + @"\DBTools.ini";
                INI.Sessao  = "SKIN";

                string skinName = INI.Ler("SkinName", "");

                string path = Application.StartupPath + @"\Skins\";

                string[] files = Directory.GetFiles(path, "*.skf");    

                if(skinName == "")
                {
                    mnuEditarSkinsSem.Checked = true; 
                }

                for (int i = 0; i < files.Length; i++)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    
                    menuItem.Tag        = Path.GetFileName(files[i]); 
                    menuItem.Text       = Path.GetFileNameWithoutExtension(files[i]).Replace("_"," ");
                    menuItem.ForeColor  = Color.Maroon;  
                    menuItem.Click +=new EventHandler(mnuEditarSkinsSem_Click); 

                    this.mnuEditarSkins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    menuItem});

                    if(skinName == menuItem.Tag.ToString())
                    {
                        menuItem.Checked = true;
 
                        //ApplySkin(menuItem.Tag.ToString()); 
                    }
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
#endregion

#region EVENTOS DE OBJETOS

        private void mnuArquivoSair_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        private void mnuExibirServerExplorer_Click(object sender, EventArgs e)
        {
            FormServerExplorer  = new DBTools.forms.frmServerExplorer();

            // Add and dock the form in the left panel of the container
            dockPanelMain.DockToolWindow(FormServerExplorer, zDockMode.Left);

            // Show the form
            FormServerExplorer.Show();
            Application.DoEvents(); 
            mnuExibirServerExplorer.Enabled = false;
        }
        private void mnuExibirSQLEditor_Click(object sender, EventArgs e)
        {
            FormSQLEditor       = new DBTools.forms.frmSQLEditor();

            // Add and dock the form in the left panel of the container
            dockPanelMain.DockToolWindow(FormSQLEditor, zDockMode.Fill);

            // Show the form
            FormSQLEditor.Show();
            Application.DoEvents(); 
            mnuExibirSQLEditor.Enabled = false;
        }
        private void mnuExibirFuncoes_Click(object sender, EventArgs e)
        {
            FormFunction        = new frmFunction();

            // Add and dock the form in the left panel of the container
            dockPanelMain.DockToolWindow(FormFunction, zDockMode.Fill);

            // Show the form
            FormFunction.Show();
            Application.DoEvents();
            mnuExibirFuncoes.Enabled = false;
        }
        private void mnuArquivoVisualizarLogErro_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Application.StartupPath + @"\LogDeErro.txt";

                if (File.Exists(fileName))
                {
                    Funcoes.ExecuteFile(fileName, "");
                }
                else
                {
                    MessageBox.Show("Arquivo de log de erro não existe!\n\n" +
                                    "Path:" + fileName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void mnuFerramentasGerenciadoWebServices_Click(object sender, EventArgs e)
        {
            frmGerenciadorWebService formGerWebService = new frmGerenciadorWebService();
 
            formGerWebService.Show(); 
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogon formLogon = new frmLogon();

                if (formLogon.ShowDialog() == DialogResult.Cancel) { return; }

                m_sqlSmoTools   = formLogon.SqlSMOTools;
                _serverType     = formLogon.ServerType;  
                //
                //Configurações do Bancos de Dados
                //
                _dataBaseShowSystemObject     = formLogon.chkDataBaseShowSystemObject.Checked;
                _dataBaseShowDenyReader       = formLogon.chkDataBaseShowDenyReader.Checked;
                //
                //Configurações Tabelas
                //
                _tableShowSystemObject         = formLogon.chkTableShowSystemObject.Checked;
                _tableShowColumnsDataType      = formLogon.chkTableShowColumnsDataType.Checked;
                _tableShowFK                   = formLogon.chkTableShowFK.Checked;
                //
                //Configurações Views
                //
                _viewShowSystemObject          = formLogon.chkViewShowSystemObject.Checked;
                _viewShowColumnsDataType       = formLogon.chkViewShowColumnsDataType.Checked;
                //
                //Configurações SPs
                //
                _spShowSystemObject            = formLogon.chkSPShowSystemObject.Checked;
                _spShowColumnsDataType         = formLogon.chkSPShowColumnsDataType.Checked;
                
                btnConectar.Enabled             = false;
                btnDesconectar.Enabled          = true;
                mnuArquivoConectar.Enabled      = false;
                mnuArquivoDesconectar.Enabled   = true;

                mnuExibirFuncoes.Enabled        = true;
                mnuExibirServerExplorer.Enabled = true;
                mnuExibirSQLEditor.Enabled      = true;  

                mnuExibirServerExplorer_Click(null, null);
                mnuExibirSQLEditor_Click(null, null);
                mnuExibirFuncoes_Click(null, null);
                
                FormSQLEditor.Activate(); 
                FormServerExplorer.Atualizar(_serverType);  
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
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            btnConectar.Enabled             = true;
            btnDesconectar.Enabled          = false;
            mnuArquivoConectar.Enabled      = true;
            mnuArquivoDesconectar.Enabled   = false;

            // remove todos os nós do controle
            FormServerExplorer.tvwDados.Nodes.Clear();    

            try
            {
                mnuExibirFuncoes.Enabled        = false;
                mnuExibirServerExplorer.Enabled = false;
                mnuExibirSQLEditor.Enabled      = false;  

                FormServerExplorer.Hide();
                FormFunction.Hide();
                FormSQLEditor.Hide();  

                m_sqlSmoTools.DisConnect(); 
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

#endregion

#region Skin
        private void mnuEditarSkinsSem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in this.mnuEditarSkins.DropDownItems)
            {
                item.Checked = false;
            }

            if(menuItem.Tag == null)
            {
                RegistrosINI INI = new RegistrosINI();

                INI.Arquivo = Application.StartupPath + @"\DBTools.ini";
                INI.Sessao  = "SKIN";

                INI.Gravar("SkinName", "");

                menuItem.Checked = true;
                //skinCrafter1.RemoveSkin();
            }
            else
            {
                menuItem.Checked = true;
            
                ApplySkin(menuItem.Tag.ToString()); 
            }

        }
        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 09/07/2008 08:27
        * Data de modificação	= 
        **************************************************************/
        private void ApplySkin(string fileName)
        {
            try
            {
                string fileNameSkin = Application.StartupPath + @"\Skins\" + fileName;
             
                //DMSoft.SkinCrafter.Init();

                //skinCrafter1.RemoveSkin();
                //skinCrafter1.LoadSkinFromFile(fileNameSkin);
                //skinCrafter1.ApplySkin();

                //DMSoft.SkinCrafter.Terminate();

                RegistrosINI INI = new RegistrosINI();

                INI.Arquivo = Application.StartupPath + @"\DBTools.ini";
                INI.Sessao  = "SKIN";

                INI.Gravar("SkinName", fileName); 
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        #endregion

        private void JoomlaPacotesDeInstalaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJoomlaPacoteInstalacao formJoomlaPacoteInstalacao = new frmJoomlaPacoteInstalacao();

            formJoomlaPacoteInstalacao.Show();
        }

        private void JoomlaScriptXMLStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJoomlaXMLToScript formJoomlaXMLToScript = new frmJoomlaXMLToScript();

            formJoomlaXMLToScript.Show();
        }
    }
}

