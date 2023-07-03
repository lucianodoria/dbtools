using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

namespace DBTools
{
    public partial class frmMain
    {

        #region Windows Form Designer generated code

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConectar = new System.Windows.Forms.ToolStripButton();
            this.btnDesconectar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoConectar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoDesconectar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArquivoVisualizarLogErro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArquivoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditarSkins = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditarSkinsSem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExibir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExibirServerExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExibirSQLEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExibirFuncoes = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasGerenciadoWebServices = new System.Windows.Forms.ToolStripMenuItem();
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joomlaScriptXMLStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgbMain = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTempoDecorrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanelMain = new Crom.Controls.DockContainer();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database_run.ico");
            this.imageList1.Images.SetKeyName(1, "database2005Express.ico");
            this.imageList1.Images.SetKeyName(2, "FolderTables2005.ico");
            this.imageList1.Images.SetKeyName(3, "tables1.ico");
            this.imageList1.Images.SetKeyName(4, "tableRow2005.ico");
            this.imageList1.Images.SetKeyName(5, "view_2005.ico");
            this.imageList1.Images.SetKeyName(6, "sp_2005.ico");
            this.imageList1.Images.SetKeyName(7, "sp_row_2005.ico");
            this.imageList1.Images.SetKeyName(8, "PK.ico");
            this.imageList1.Images.SetKeyName(9, "FK.ico");
            this.imageList1.Images.SetKeyName(10, "tableFK.ico");
            this.imageList1.Images.SetKeyName(11, "sp_output.ico");
            this.imageList1.Images.SetKeyName(12, "viewRow2005.ico");
            this.imageList1.Images.SetKeyName(13, "FolderViews2005.ico");
            this.imageList1.Images.SetKeyName(14, "FolderSPs2005.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConectar,
            this.btnDesconectar,
            this.toolStripSeparator1,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(715, 25);
            this.toolStrip1.TabIndex = 36;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConectar
            // 
            this.btnConectar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConectar.Image = global::DBTools.Properties.Resources.database_connect;
            this.btnConectar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(23, 22);
            this.btnConectar.ToolTipText = "Conecta no SQL Server";
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDesconectar.Enabled = false;
            this.btnDesconectar.Image = global::DBTools.Properties.Resources.database_desconnect;
            this.btnDesconectar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(23, 22);
            this.btnDesconectar.ToolTipText = "Desconecta do SQL Server";
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::DBTools.Properties.Resources.refreshSQL2005;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.ToolTipText = "Atualiza o Banco de dados";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivo,
            this.mnuEditar,
            this.mnuExibir,
            this.ferramentasToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuArquivo
            // 
            this.mnuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivoConectar,
            this.mnuArquivoDesconectar,
            this.toolStripMenuItem1,
            this.mnuArquivoVisualizarLogErro,
            this.toolStripMenuItem2,
            this.mnuArquivoSair});
            this.mnuArquivo.Name = "mnuArquivo";
            this.mnuArquivo.Size = new System.Drawing.Size(61, 20);
            this.mnuArquivo.Text = "Arquivo";
            // 
            // mnuArquivoConectar
            // 
            this.mnuArquivoConectar.Image = global::DBTools.Properties.Resources.database_connect;
            this.mnuArquivoConectar.Name = "mnuArquivoConectar";
            this.mnuArquivoConectar.Size = new System.Drawing.Size(192, 22);
            this.mnuArquivoConectar.Text = "Conectar...";
            this.mnuArquivoConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // mnuArquivoDesconectar
            // 
            this.mnuArquivoDesconectar.Enabled = false;
            this.mnuArquivoDesconectar.Image = global::DBTools.Properties.Resources.database_desconnect;
            this.mnuArquivoDesconectar.Name = "mnuArquivoDesconectar";
            this.mnuArquivoDesconectar.Size = new System.Drawing.Size(192, 22);
            this.mnuArquivoDesconectar.Text = "Desconectar...";
            this.mnuArquivoDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuArquivoVisualizarLogErro
            // 
            this.mnuArquivoVisualizarLogErro.Image = global::DBTools.Properties.Resources.error_list;
            this.mnuArquivoVisualizarLogErro.Name = "mnuArquivoVisualizarLogErro";
            this.mnuArquivoVisualizarLogErro.Size = new System.Drawing.Size(192, 22);
            this.mnuArquivoVisualizarLogErro.Text = "Visualizar log de erro...";
            this.mnuArquivoVisualizarLogErro.Click += new System.EventHandler(this.mnuArquivoVisualizarLogErro_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuArquivoSair
            // 
            this.mnuArquivoSair.Name = "mnuArquivoSair";
            this.mnuArquivoSair.Size = new System.Drawing.Size(192, 22);
            this.mnuArquivoSair.Text = "Sair";
            this.mnuArquivoSair.Click += new System.EventHandler(this.mnuArquivoSair_Click);
            // 
            // mnuEditar
            // 
            this.mnuEditar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditarSkins});
            this.mnuEditar.Name = "mnuEditar";
            this.mnuEditar.Size = new System.Drawing.Size(49, 20);
            this.mnuEditar.Text = "Editar";
            this.mnuEditar.Visible = false;
            // 
            // mnuEditarSkins
            // 
            this.mnuEditarSkins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditarSkinsSem});
            this.mnuEditarSkins.Image = global::DBTools.Properties.Resources.form2005;
            this.mnuEditarSkins.Name = "mnuEditarSkins";
            this.mnuEditarSkins.Size = new System.Drawing.Size(101, 22);
            this.mnuEditarSkins.Text = "Skins";
            // 
            // mnuEditarSkinsSem
            // 
            this.mnuEditarSkinsSem.Name = "mnuEditarSkinsSem";
            this.mnuEditarSkinsSem.Size = new System.Drawing.Size(122, 22);
            this.mnuEditarSkinsSem.Text = "Sem Skin";
            this.mnuEditarSkinsSem.Click += new System.EventHandler(this.mnuEditarSkinsSem_Click);
            // 
            // mnuExibir
            // 
            this.mnuExibir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExibirServerExplorer,
            this.mnuExibirSQLEditor,
            this.mnuExibirFuncoes});
            this.mnuExibir.Name = "mnuExibir";
            this.mnuExibir.Size = new System.Drawing.Size(48, 20);
            this.mnuExibir.Text = "Exibir";
            // 
            // mnuExibirServerExplorer
            // 
            this.mnuExibirServerExplorer.Enabled = false;
            this.mnuExibirServerExplorer.Image = global::DBTools.Properties.Resources.servers2005;
            this.mnuExibirServerExplorer.Name = "mnuExibirServerExplorer";
            this.mnuExibirServerExplorer.Size = new System.Drawing.Size(180, 22);
            this.mnuExibirServerExplorer.Text = "Server Explorer...";
            this.mnuExibirServerExplorer.Click += new System.EventHandler(this.mnuExibirServerExplorer_Click);
            // 
            // mnuExibirSQLEditor
            // 
            this.mnuExibirSQLEditor.Enabled = false;
            this.mnuExibirSQLEditor.Image = global::DBTools.Properties.Resources.code;
            this.mnuExibirSQLEditor.Name = "mnuExibirSQLEditor";
            this.mnuExibirSQLEditor.Size = new System.Drawing.Size(180, 22);
            this.mnuExibirSQLEditor.Text = "SQL Editor...";
            this.mnuExibirSQLEditor.Click += new System.EventHandler(this.mnuExibirSQLEditor_Click);
            // 
            // mnuExibirFuncoes
            // 
            this.mnuExibirFuncoes.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuExibirFuncoes.Name = "mnuExibirFuncoes";
            this.mnuExibirFuncoes.Size = new System.Drawing.Size(180, 22);
            this.mnuExibirFuncoes.Text = "Funções...";
            this.mnuExibirFuncoes.Click += new System.EventHandler(this.mnuExibirFuncoes_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.mnuFerramentasGerenciadoWebServices,
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem,
            this.joomlaScriptXMLStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.configuraçõesToolStripMenuItem.Text = "Configurações...";
            this.configuraçõesToolStripMenuItem.Visible = false;
            // 
            // mnuFerramentasGerenciadoWebServices
            // 
            this.mnuFerramentasGerenciadoWebServices.Image = global::DBTools.Properties.Resources.webrefrence;
            this.mnuFerramentasGerenciadoWebServices.Name = "mnuFerramentasGerenciadoWebServices";
            this.mnuFerramentasGerenciadoWebServices.Size = new System.Drawing.Size(235, 22);
            this.mnuFerramentasGerenciadoWebServices.Text = "Gerenciador de WebServices...";
            this.mnuFerramentasGerenciadoWebServices.Click += new System.EventHandler(this.mnuFerramentasGerenciadoWebServices_Click);
            // 
            // joomlaPacotesDeInstalaçãoToolStripMenuItem
            // 
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem.Image = global::DBTools.Properties.Resources.joomla16x16;
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem.Name = "joomlaPacotesDeInstalaçãoToolStripMenuItem";
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem.Text = "Joomla Pacotes de Instalação";
            this.joomlaPacotesDeInstalaçãoToolStripMenuItem.Click += new System.EventHandler(this.JoomlaPacotesDeInstalaçãoToolStripMenuItem_Click);
            // 
            // joomlaScriptXMLStripMenuItem
            // 
            this.joomlaScriptXMLStripMenuItem.Image = global::DBTools.Properties.Resources.joomla16x16;
            this.joomlaScriptXMLStripMenuItem.Name = "joomlaScriptXMLStripMenuItem";
            this.joomlaScriptXMLStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.joomlaScriptXMLStripMenuItem.Text = "Joomla importar XML to Script";
            this.joomlaScriptXMLStripMenuItem.Click += new System.EventHandler(this.JoomlaScriptXMLStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBToolsToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // dBToolsToolStripMenuItem
            // 
            this.dBToolsToolStripMenuItem.Name = "dBToolsToolStripMenuItem";
            this.dBToolsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dBToolsToolStripMenuItem.Text = "DBTools...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbMain,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.lblTempoDecorrido});
            this.statusStrip1.Location = new System.Drawing.Point(0, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 22);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgbMain
            // 
            this.pgbMain.Name = "pgbMain";
            this.pgbMain.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel2.Image = global::DBTools.Properties.Resources.timer;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // lblTempoDecorrido
            // 
            this.lblTempoDecorrido.Name = "lblTempoDecorrido";
            this.lblTempoDecorrido.Size = new System.Drawing.Size(13, 17);
            this.lblTempoDecorrido.Text = "0";
            // 
            // dockPanelMain
            // 
            this.dockPanelMain.BackColor = System.Drawing.SystemColors.Window;
            this.dockPanelMain.BottomPanelHeight = 150;
            this.dockPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanelMain.LeftPanelWidth = 150;
            this.dockPanelMain.Location = new System.Drawing.Point(0, 49);
            this.dockPanelMain.MinimumSize = new System.Drawing.Size(504, 515);
            this.dockPanelMain.Name = "dockPanelMain";
            this.dockPanelMain.RightPanelWidth = 150;
            this.dockPanelMain.Size = new System.Drawing.Size(715, 515);
            this.dockPanelMain.TabIndex = 44;
            this.dockPanelMain.TopPanelHeight = 150;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(715, 586);
            this.Controls.Add(this.dockPanelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(723, 614);
            this.Name = "frmMain";
            this.Text = "DBTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new frmMain());
        }

        #endregion

        private ToolStrip toolStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuArquivo;
        private ToolStripMenuItem mnuArquivoSair;
        private ToolStripMenuItem mnuExibir;
        private ToolStripMenuItem ferramentasToolStripMenuItem;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripButton btnConectar;
        private ToolStripButton btnDesconectar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnRefresh;
        private ToolStripMenuItem mnuArquivoConectar;
        private ToolStripMenuItem mnuArquivoDesconectar;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem dBToolsToolStripMenuItem;
        private ToolStripMenuItem mnuArquivoVisualizarLogErro;
        private ToolStripSeparator toolStripMenuItem2;
        internal ToolStripProgressBar pgbMain;
        private ToolStripMenuItem mnuEditar;
        private ToolStripMenuItem mnuEditarSkins;
        private ToolStripMenuItem mnuEditarSkinsSem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        internal ToolStripStatusLabel lblTempoDecorrido;
        private ToolStripMenuItem mnuFerramentasGerenciadoWebServices;
        private Crom.Controls.DockContainer dockPanelMain;
        internal ToolStripMenuItem mnuExibirServerExplorer;
        internal ToolStripMenuItem mnuExibirSQLEditor;
        internal ToolStripMenuItem mnuExibirFuncoes;
        private ToolStripMenuItem joomlaPacotesDeInstalaçãoToolStripMenuItem;
        private ToolStripMenuItem joomlaScriptXMLStripMenuItem;
    }
}
