namespace DBTools.forms
{
    partial class frmServerExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerExplorer));
            this.tvwDados = new System.Windows.Forms.TreeView();
            this.cMenuDB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScriptTableAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScriptTableAsInsertWithValuesToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScriptTableAsCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComandoSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComandoSQLSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComandoSQLInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComandoSQLUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComandoSQLDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecuteSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListarDescricao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListarNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcurarEmSPs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcurarEmSPsPopUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarSPSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarSPInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarSPUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarSPDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcurarTabela = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTabelaVirtualGerar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCriarEnumDaTabela = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarMetodo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarMetodoCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarMetodoConsultaCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGerarMetodoCSharpDAAB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarMetodoConsultaCSharpDAAB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarMetodoVB6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStruct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStructGerarComTiposDeDados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStructGerarSomenteLista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStructGerarComTiposDeDadosPreenchimento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraficos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraficosPizza = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVisualizaPropriedadesTodasTabelas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListGroupQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlterarOwnerdbo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletarRegistrosDuplicados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPropriedades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJoomla = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJoomlaCriarComponente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJoomlaCriarPaginaKnockout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJoomlaGerarSelectControl = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuComVirgula = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTipoDadosCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTipoDados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMinuscula = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListarCampos = new System.Windows.Forms.ToolStripButton();
            this.mnuGerarClasseFileHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenuDB.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwDados
            // 
            this.tvwDados.AllowDrop = true;
            this.tvwDados.ContextMenuStrip = this.cMenuDB;
            this.tvwDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwDados.HideSelection = false;
            this.tvwDados.ImageIndex = 0;
            this.tvwDados.ImageList = this.imageList1;
            this.tvwDados.Location = new System.Drawing.Point(0, 25);
            this.tvwDados.Name = "tvwDados";
            this.tvwDados.SelectedImageIndex = 0;
            this.tvwDados.ShowLines = false;
            this.tvwDados.Size = new System.Drawing.Size(266, 402);
            this.tvwDados.TabIndex = 32;
            this.tvwDados.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDados_BeforeExpand);
            this.tvwDados.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwDados_ItemDrag);
            this.tvwDados.DoubleClick += new System.EventHandler(this.tvwDados_DoubleClick);
            this.tvwDados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwDados_MouseClick);
            this.tvwDados.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwDados_MouseDown);
            this.tvwDados.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvwDados_MouseMove);
            // 
            // cMenuDB
            // 
            this.cMenuDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVisualizar,
            this.mnuSelectFrom,
            this.mnuScriptTableAs,
            this.mnuComandoSQL,
            this.mnuExecuteSP,
            this.mnuListarDescricao,
            this.mnuListarNodes,
            this.mnuProcurarEmSPs,
            this.mnuProcurarEmSPsPopUp,
            this.mnuCriarSP,
            this.mnuProcurarTabela,
            this.mnuTabelaVirtualGerar,
            this.mnuCriarEnumDaTabela,
            this.mnuGerarMetodo,
            this.mnuGerarMetodoVB6,
            this.mnuStruct,
            this.mnuGraficos,
            this.mnuVisualizaPropriedadesTodasTabelas,
            this.mnuListGroupQuery,
            this.mnuAlterarOwnerdbo,
            this.mnuImportExcel,
            this.mnuDeletarRegistrosDuplicados,
            this.mnuAtualizar,
            this.mnuPropriedades,
            this.mnuJoomla,
            this.mnuGerarClasseFileHelper});
            this.cMenuDB.Name = "cMenuDB";
            this.cMenuDB.Size = new System.Drawing.Size(297, 598);
            // 
            // mnuVisualizar
            // 
            this.mnuVisualizar.Image = global::DBTools.Properties.Resources.code;
            this.mnuVisualizar.Name = "mnuVisualizar";
            this.mnuVisualizar.Size = new System.Drawing.Size(296, 22);
            this.mnuVisualizar.Text = "Visualizar";
            this.mnuVisualizar.Visible = false;
            this.mnuVisualizar.Click += new System.EventHandler(this.mnuVisualizar_Click);
            // 
            // mnuSelectFrom
            // 
            this.mnuSelectFrom.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuSelectFrom.Name = "mnuSelectFrom";
            this.mnuSelectFrom.Size = new System.Drawing.Size(296, 22);
            this.mnuSelectFrom.Text = "Select * from";
            this.mnuSelectFrom.Visible = false;
            this.mnuSelectFrom.Click += new System.EventHandler(this.mnuSelectFrom_Click);
            // 
            // mnuScriptTableAs
            // 
            this.mnuScriptTableAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScriptTableAsInsertWithValuesToClipboard,
            this.mnuScriptTableAsCreateTable});
            this.mnuScriptTableAs.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuScriptTableAs.Name = "mnuScriptTableAs";
            this.mnuScriptTableAs.Size = new System.Drawing.Size(296, 22);
            this.mnuScriptTableAs.Text = "Script Table as";
            // 
            // mnuScriptTableAsInsertWithValuesToClipboard
            // 
            this.mnuScriptTableAsInsertWithValuesToClipboard.Image = global::DBTools.Properties.Resources.CopySmall;
            this.mnuScriptTableAsInsertWithValuesToClipboard.Name = "mnuScriptTableAsInsertWithValuesToClipboard";
            this.mnuScriptTableAsInsertWithValuesToClipboard.Size = new System.Drawing.Size(234, 22);
            this.mnuScriptTableAsInsertWithValuesToClipboard.Text = "Insert with values to Clipboard";
            this.mnuScriptTableAsInsertWithValuesToClipboard.Click += new System.EventHandler(this.mnuScriptTableAsInsertWithValuesToClipboard_Click);
            // 
            // mnuScriptTableAsCreateTable
            // 
            this.mnuScriptTableAsCreateTable.Image = global::DBTools.Properties.Resources.CopySmall;
            this.mnuScriptTableAsCreateTable.Name = "mnuScriptTableAsCreateTable";
            this.mnuScriptTableAsCreateTable.Size = new System.Drawing.Size(234, 22);
            this.mnuScriptTableAsCreateTable.Text = "Create Table";
            this.mnuScriptTableAsCreateTable.Click += new System.EventHandler(this.mnuScriptTableAsCreateTable_Click);
            // 
            // mnuComandoSQL
            // 
            this.mnuComandoSQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComandoSQLSelect,
            this.mnuComandoSQLInsert,
            this.mnuComandoSQLUpdate,
            this.mnuComandoSQLDelete});
            this.mnuComandoSQL.Image = global::DBTools.Properties.Resources.wizard16x16;
            this.mnuComandoSQL.Name = "mnuComandoSQL";
            this.mnuComandoSQL.Size = new System.Drawing.Size(296, 22);
            this.mnuComandoSQL.Text = "Customizar comando SQL";
            this.mnuComandoSQL.Visible = false;
            // 
            // mnuComandoSQLSelect
            // 
            this.mnuComandoSQLSelect.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuComandoSQLSelect.Name = "mnuComandoSQLSelect";
            this.mnuComandoSQLSelect.Size = new System.Drawing.Size(121, 22);
            this.mnuComandoSQLSelect.Text = "Select...";
            this.mnuComandoSQLSelect.Click += new System.EventHandler(this.mnuComandoSQL_Select_Click);
            // 
            // mnuComandoSQLInsert
            // 
            this.mnuComandoSQLInsert.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuComandoSQLInsert.Name = "mnuComandoSQLInsert";
            this.mnuComandoSQLInsert.Size = new System.Drawing.Size(121, 22);
            this.mnuComandoSQLInsert.Text = "Insert...";
            this.mnuComandoSQLInsert.Click += new System.EventHandler(this.mnuComandoSQL_Insert_Click);
            // 
            // mnuComandoSQLUpdate
            // 
            this.mnuComandoSQLUpdate.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuComandoSQLUpdate.Name = "mnuComandoSQLUpdate";
            this.mnuComandoSQLUpdate.Size = new System.Drawing.Size(121, 22);
            this.mnuComandoSQLUpdate.Text = "Update...";
            this.mnuComandoSQLUpdate.Click += new System.EventHandler(this.mnuComandoSQL_Update_Click);
            // 
            // mnuComandoSQLDelete
            // 
            this.mnuComandoSQLDelete.Image = global::DBTools.Properties.Resources.AttachProccess;
            this.mnuComandoSQLDelete.Name = "mnuComandoSQLDelete";
            this.mnuComandoSQLDelete.Size = new System.Drawing.Size(121, 22);
            this.mnuComandoSQLDelete.Text = "Delete...";
            this.mnuComandoSQLDelete.Click += new System.EventHandler(this.mnuComandoSQL_Delete_Click);
            // 
            // mnuExecuteSP
            // 
            this.mnuExecuteSP.Image = global::DBTools.Properties.Resources.sp_2005_run;
            this.mnuExecuteSP.Name = "mnuExecuteSP";
            this.mnuExecuteSP.Size = new System.Drawing.Size(296, 22);
            this.mnuExecuteSP.Text = "Executar SP...";
            this.mnuExecuteSP.Visible = false;
            this.mnuExecuteSP.Click += new System.EventHandler(this.mnuExecuteSP_Click);
            // 
            // mnuListarDescricao
            // 
            this.mnuListarDescricao.Image = global::DBTools.Properties.Resources.PropertiesC_;
            this.mnuListarDescricao.Name = "mnuListarDescricao";
            this.mnuListarDescricao.Size = new System.Drawing.Size(296, 22);
            this.mnuListarDescricao.Text = "Listar descrição";
            this.mnuListarDescricao.Visible = false;
            this.mnuListarDescricao.Click += new System.EventHandler(this.mnuListarDescricao_Click);
            // 
            // mnuListarNodes
            // 
            this.mnuListarNodes.Image = global::DBTools.Properties.Resources.treeview;
            this.mnuListarNodes.Name = "mnuListarNodes";
            this.mnuListarNodes.Size = new System.Drawing.Size(296, 22);
            this.mnuListarNodes.Text = "Listar Nodes";
            this.mnuListarNodes.Visible = false;
            this.mnuListarNodes.Click += new System.EventHandler(this.mnuListarNodes_Click);
            // 
            // mnuProcurarEmSPs
            // 
            this.mnuProcurarEmSPs.Image = global::DBTools.Properties.Resources.FindInFiles;
            this.mnuProcurarEmSPs.Name = "mnuProcurarEmSPs";
            this.mnuProcurarEmSPs.Size = new System.Drawing.Size(296, 22);
            this.mnuProcurarEmSPs.Text = "Consultar em SPs...";
            this.mnuProcurarEmSPs.Visible = false;
            this.mnuProcurarEmSPs.Click += new System.EventHandler(this.mnuProcurarEmSPs_Click);
            // 
            // mnuProcurarEmSPsPopUp
            // 
            this.mnuProcurarEmSPsPopUp.Image = global::DBTools.Properties.Resources.sp_find;
            this.mnuProcurarEmSPsPopUp.Name = "mnuProcurarEmSPsPopUp";
            this.mnuProcurarEmSPsPopUp.Size = new System.Drawing.Size(296, 22);
            this.mnuProcurarEmSPsPopUp.Text = "Procurar em SPs...";
            this.mnuProcurarEmSPsPopUp.Visible = false;
            this.mnuProcurarEmSPsPopUp.Click += new System.EventHandler(this.mnuProcurarEmSPsPopUp_Click);
            // 
            // mnuCriarSP
            // 
            this.mnuCriarSP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCriarSPSelect,
            this.mnuCriarSPInsert,
            this.mnuCriarSPUpdate,
            this.mnuCriarSPDelete});
            this.mnuCriarSP.Image = global::DBTools.Properties.Resources.sp_2005;
            this.mnuCriarSP.Name = "mnuCriarSP";
            this.mnuCriarSP.Size = new System.Drawing.Size(296, 22);
            this.mnuCriarSP.Text = "Criar Sored procedure";
            this.mnuCriarSP.Visible = false;
            // 
            // mnuCriarSPSelect
            // 
            this.mnuCriarSPSelect.Image = global::DBTools.Properties.Resources.sp_2005_gerar;
            this.mnuCriarSPSelect.Name = "mnuCriarSPSelect";
            this.mnuCriarSPSelect.Size = new System.Drawing.Size(116, 22);
            this.mnuCriarSPSelect.Text = "Select...";
            this.mnuCriarSPSelect.Click += new System.EventHandler(this.mnuCriarSPSelect_Click);
            // 
            // mnuCriarSPInsert
            // 
            this.mnuCriarSPInsert.Image = global::DBTools.Properties.Resources.sp_2005_gerar;
            this.mnuCriarSPInsert.Name = "mnuCriarSPInsert";
            this.mnuCriarSPInsert.Size = new System.Drawing.Size(116, 22);
            this.mnuCriarSPInsert.Text = "Insert...";
            this.mnuCriarSPInsert.Click += new System.EventHandler(this.mnuCriarSPInsert_Click);
            // 
            // mnuCriarSPUpdate
            // 
            this.mnuCriarSPUpdate.Image = global::DBTools.Properties.Resources.sp_2005_gerar;
            this.mnuCriarSPUpdate.Name = "mnuCriarSPUpdate";
            this.mnuCriarSPUpdate.Size = new System.Drawing.Size(116, 22);
            this.mnuCriarSPUpdate.Text = "Update";
            this.mnuCriarSPUpdate.Click += new System.EventHandler(this.mnuCriarSPUpdate_Click);
            // 
            // mnuCriarSPDelete
            // 
            this.mnuCriarSPDelete.Image = global::DBTools.Properties.Resources.sp_2005_gerar;
            this.mnuCriarSPDelete.Name = "mnuCriarSPDelete";
            this.mnuCriarSPDelete.Size = new System.Drawing.Size(116, 22);
            this.mnuCriarSPDelete.Text = "Delete...";
            this.mnuCriarSPDelete.Click += new System.EventHandler(this.mnuCriarSPDelete_Click);
            // 
            // mnuProcurarTabela
            // 
            this.mnuProcurarTabela.Image = global::DBTools.Properties.Resources.searchTable;
            this.mnuProcurarTabela.Name = "mnuProcurarTabela";
            this.mnuProcurarTabela.Size = new System.Drawing.Size(296, 22);
            this.mnuProcurarTabela.Text = "Procurar Tabela";
            this.mnuProcurarTabela.Visible = false;
            this.mnuProcurarTabela.Click += new System.EventHandler(this.mnuProcurarTabela_Click);
            // 
            // mnuTabelaVirtualGerar
            // 
            this.mnuTabelaVirtualGerar.Image = global::DBTools.Properties.Resources.DataSet;
            this.mnuTabelaVirtualGerar.Name = "mnuTabelaVirtualGerar";
            this.mnuTabelaVirtualGerar.Size = new System.Drawing.Size(296, 22);
            this.mnuTabelaVirtualGerar.Text = "Gerar Tabela Virtual...";
            this.mnuTabelaVirtualGerar.Visible = false;
            this.mnuTabelaVirtualGerar.Click += new System.EventHandler(this.mnuTabelaVirtualGerar_Click);
            // 
            // mnuCriarEnumDaTabela
            // 
            this.mnuCriarEnumDaTabela.Image = global::DBTools.Properties.Resources.Enum;
            this.mnuCriarEnumDaTabela.Name = "mnuCriarEnumDaTabela";
            this.mnuCriarEnumDaTabela.Size = new System.Drawing.Size(296, 22);
            this.mnuCriarEnumDaTabela.Text = "Gerar Enum...";
            this.mnuCriarEnumDaTabela.Visible = false;
            this.mnuCriarEnumDaTabela.Click += new System.EventHandler(this.mnuCriarEnumDaTabela_Click);
            // 
            // mnuGerarMetodo
            // 
            this.mnuGerarMetodo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGerarMetodoCSharp,
            this.mnuGerarMetodoConsultaCSharp,
            this.toolStripSeparator2,
            this.mnuGerarMetodoCSharpDAAB,
            this.mnuGerarMetodoConsultaCSharpDAAB});
            this.mnuGerarMetodo.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodo.Name = "mnuGerarMetodo";
            this.mnuGerarMetodo.Size = new System.Drawing.Size(296, 22);
            this.mnuGerarMetodo.Text = "Gerar Método em C#";
            // 
            // mnuGerarMetodoCSharp
            // 
            this.mnuGerarMetodoCSharp.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodoCSharp.Name = "mnuGerarMetodoCSharp";
            this.mnuGerarMetodoCSharp.Size = new System.Drawing.Size(272, 22);
            this.mnuGerarMetodoCSharp.Text = "Execução de SP...";
            this.mnuGerarMetodoCSharp.Click += new System.EventHandler(this.mnuGerarMetodoCSharp_Click);
            // 
            // mnuGerarMetodoConsultaCSharp
            // 
            this.mnuGerarMetodoConsultaCSharp.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodoConsultaCSharp.Name = "mnuGerarMetodoConsultaCSharp";
            this.mnuGerarMetodoConsultaCSharp.Size = new System.Drawing.Size(272, 22);
            this.mnuGerarMetodoConsultaCSharp.Text = "Execução de SP para consulta...";
            this.mnuGerarMetodoConsultaCSharp.Click += new System.EventHandler(this.mnuGerarMetodoConsultaCSharp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(269, 6);
            // 
            // mnuGerarMetodoCSharpDAAB
            // 
            this.mnuGerarMetodoCSharpDAAB.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodoCSharpDAAB.Name = "mnuGerarMetodoCSharpDAAB";
            this.mnuGerarMetodoCSharpDAAB.Size = new System.Drawing.Size(272, 22);
            this.mnuGerarMetodoCSharpDAAB.Text = "Execução de SP DAAB...";
            this.mnuGerarMetodoCSharpDAAB.Click += new System.EventHandler(this.mnuGerarMetodoCSharpDAAB_Click);
            // 
            // mnuGerarMetodoConsultaCSharpDAAB
            // 
            this.mnuGerarMetodoConsultaCSharpDAAB.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodoConsultaCSharpDAAB.Name = "mnuGerarMetodoConsultaCSharpDAAB";
            this.mnuGerarMetodoConsultaCSharpDAAB.Size = new System.Drawing.Size(272, 22);
            this.mnuGerarMetodoConsultaCSharpDAAB.Text = "Execução de SP DAAB para consulta...";
            this.mnuGerarMetodoConsultaCSharpDAAB.Click += new System.EventHandler(this.mnuGerarMetodoConsultaCSharpDAAB_Click);
            // 
            // mnuGerarMetodoVB6
            // 
            this.mnuGerarMetodoVB6.Image = global::DBTools.Properties.Resources.Method;
            this.mnuGerarMetodoVB6.Name = "mnuGerarMetodoVB6";
            this.mnuGerarMetodoVB6.Size = new System.Drawing.Size(296, 22);
            this.mnuGerarMetodoVB6.Text = "Gerar Método VB6";
            this.mnuGerarMetodoVB6.Click += new System.EventHandler(this.mnuGerarMetodoVB6_Click);
            // 
            // mnuStruct
            // 
            this.mnuStruct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStructGerarComTiposDeDados,
            this.mnuStructGerarSomenteLista,
            this.mnuStructGerarComTiposDeDadosPreenchimento});
            this.mnuStruct.Image = global::DBTools.Properties.Resources.Struct;
            this.mnuStruct.Name = "mnuStruct";
            this.mnuStruct.Size = new System.Drawing.Size(296, 22);
            this.mnuStruct.Text = "Struct";
            this.mnuStruct.Visible = false;
            // 
            // mnuStructGerarComTiposDeDados
            // 
            this.mnuStructGerarComTiposDeDados.Image = global::DBTools.Properties.Resources.Struct_proccess;
            this.mnuStructGerarComTiposDeDados.Name = "mnuStructGerarComTiposDeDados";
            this.mnuStructGerarComTiposDeDados.Size = new System.Drawing.Size(311, 22);
            this.mnuStructGerarComTiposDeDados.Text = "Gerar com tipos de dados...";
            this.mnuStructGerarComTiposDeDados.Click += new System.EventHandler(this.mnuStructGerarComTiposDeDados_Click);
            // 
            // mnuStructGerarSomenteLista
            // 
            this.mnuStructGerarSomenteLista.Image = global::DBTools.Properties.Resources.Struct_proccess;
            this.mnuStructGerarSomenteLista.Name = "mnuStructGerarSomenteLista";
            this.mnuStructGerarSomenteLista.Size = new System.Drawing.Size(311, 22);
            this.mnuStructGerarSomenteLista.Text = "Gerar somente lista...";
            this.mnuStructGerarSomenteLista.Click += new System.EventHandler(this.mnuStructGerarSomenteLista_Click);
            // 
            // mnuStructGerarComTiposDeDadosPreenchimento
            // 
            this.mnuStructGerarComTiposDeDadosPreenchimento.Image = global::DBTools.Properties.Resources.Struct_proccess;
            this.mnuStructGerarComTiposDeDadosPreenchimento.Name = "mnuStructGerarComTiposDeDadosPreenchimento";
            this.mnuStructGerarComTiposDeDadosPreenchimento.Size = new System.Drawing.Size(311, 22);
            this.mnuStructGerarComTiposDeDadosPreenchimento.Text = "Gerar com tipos de dados e preenchimento...";
            this.mnuStructGerarComTiposDeDadosPreenchimento.Click += new System.EventHandler(this.mnuStructGerarComTiposDeDadosPreenchimento_Click);
            // 
            // mnuGraficos
            // 
            this.mnuGraficos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGraficosPizza,
            this.plotToolStripMenuItem});
            this.mnuGraficos.Image = global::DBTools.Properties.Resources.GRAPH07;
            this.mnuGraficos.Name = "mnuGraficos";
            this.mnuGraficos.Size = new System.Drawing.Size(296, 22);
            this.mnuGraficos.Text = "Gráficos";
            // 
            // mnuGraficosPizza
            // 
            this.mnuGraficosPizza.Image = global::DBTools.Properties.Resources.ChartPie16x16;
            this.mnuGraficosPizza.Name = "mnuGraficosPizza";
            this.mnuGraficosPizza.Size = new System.Drawing.Size(180, 22);
            this.mnuGraficosPizza.Text = "Pizza...";
            this.mnuGraficosPizza.Click += new System.EventHandler(this.mnuGraficosPizza_Click);
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.Image = global::DBTools.Properties.Resources.grafico_plot;
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.plotToolStripMenuItem.Text = "Plot...";
            this.plotToolStripMenuItem.Click += new System.EventHandler(this.mnuGraficoPlot_Click);
            // 
            // mnuVisualizaPropriedadesTodasTabelas
            // 
            this.mnuVisualizaPropriedadesTodasTabelas.Image = global::DBTools.Properties.Resources.propriedade_find;
            this.mnuVisualizaPropriedadesTodasTabelas.Name = "mnuVisualizaPropriedadesTodasTabelas";
            this.mnuVisualizaPropriedadesTodasTabelas.Size = new System.Drawing.Size(296, 22);
            this.mnuVisualizaPropriedadesTodasTabelas.Text = "Visualizar propriedades de Todas Tabelas...";
            this.mnuVisualizaPropriedadesTodasTabelas.Visible = false;
            this.mnuVisualizaPropriedadesTodasTabelas.Click += new System.EventHandler(this.mnuVisualizaPropriedadesTodasTabelas_Click);
            // 
            // mnuListGroupQuery
            // 
            this.mnuListGroupQuery.Image = global::DBTools.Properties.Resources.filtro4;
            this.mnuListGroupQuery.Name = "mnuListGroupQuery";
            this.mnuListGroupQuery.Size = new System.Drawing.Size(296, 22);
            this.mnuListGroupQuery.Text = "List Group Query...";
            this.mnuListGroupQuery.Visible = false;
            this.mnuListGroupQuery.Click += new System.EventHandler(this.mnuListGroupQuery_Click);
            // 
            // mnuAlterarOwnerdbo
            // 
            this.mnuAlterarOwnerdbo.Image = global::DBTools.Properties.Resources.userSmall_association;
            this.mnuAlterarOwnerdbo.Name = "mnuAlterarOwnerdbo";
            this.mnuAlterarOwnerdbo.Size = new System.Drawing.Size(296, 22);
            this.mnuAlterarOwnerdbo.Text = "Alterar Owner do objeto para [dbo]";
            this.mnuAlterarOwnerdbo.Visible = false;
            this.mnuAlterarOwnerdbo.Click += new System.EventHandler(this.mnuAlterarOwnerdbo_Click);
            // 
            // mnuImportExcel
            // 
            this.mnuImportExcel.Image = global::DBTools.Properties.Resources.Excel2003File16x16_wizard;
            this.mnuImportExcel.Name = "mnuImportExcel";
            this.mnuImportExcel.Size = new System.Drawing.Size(296, 22);
            this.mnuImportExcel.Text = "Importar do Excel...";
            this.mnuImportExcel.Visible = false;
            this.mnuImportExcel.Click += new System.EventHandler(this.mnuImportExcel_Click);
            // 
            // mnuDeletarRegistrosDuplicados
            // 
            this.mnuDeletarRegistrosDuplicados.Image = global::DBTools.Properties.Resources.tables_rows_delete;
            this.mnuDeletarRegistrosDuplicados.Name = "mnuDeletarRegistrosDuplicados";
            this.mnuDeletarRegistrosDuplicados.Size = new System.Drawing.Size(296, 22);
            this.mnuDeletarRegistrosDuplicados.Text = "Deletar registros duplicados...";
            this.mnuDeletarRegistrosDuplicados.Visible = false;
            this.mnuDeletarRegistrosDuplicados.Click += new System.EventHandler(this.mnuDeletarRegistrosDuplicados_Click);
            // 
            // mnuAtualizar
            // 
            this.mnuAtualizar.Image = global::DBTools.Properties.Resources.refresh20051;
            this.mnuAtualizar.Name = "mnuAtualizar";
            this.mnuAtualizar.Size = new System.Drawing.Size(296, 22);
            this.mnuAtualizar.Text = "Atualizar";
            this.mnuAtualizar.Visible = false;
            this.mnuAtualizar.Click += new System.EventHandler(this.mnuAtualizar_Click);
            // 
            // mnuPropriedades
            // 
            this.mnuPropriedades.Image = global::DBTools.Properties.Resources.propriedade;
            this.mnuPropriedades.Name = "mnuPropriedades";
            this.mnuPropriedades.Size = new System.Drawing.Size(296, 22);
            this.mnuPropriedades.Text = "Propriedades...";
            this.mnuPropriedades.Visible = false;
            this.mnuPropriedades.Click += new System.EventHandler(this.mnuPropriedades_Click);
            // 
            // mnuJoomla
            // 
            this.mnuJoomla.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJoomlaCriarComponente,
            this.mnuJoomlaCriarPaginaKnockout,
            this.mnuJoomlaGerarSelectControl});
            this.mnuJoomla.Image = global::DBTools.Properties.Resources.joomla16x16;
            this.mnuJoomla.Name = "mnuJoomla";
            this.mnuJoomla.Size = new System.Drawing.Size(296, 22);
            this.mnuJoomla.Text = "Joomla";
            this.mnuJoomla.Visible = false;
            // 
            // mnuJoomlaCriarComponente
            // 
            this.mnuJoomlaCriarComponente.Image = global::DBTools.Properties.Resources.joomla16x16;
            this.mnuJoomlaCriarComponente.Name = "mnuJoomlaCriarComponente";
            this.mnuJoomlaCriarComponente.Size = new System.Drawing.Size(246, 22);
            this.mnuJoomlaCriarComponente.Text = "Criar página nativa...";
            this.mnuJoomlaCriarComponente.Click += new System.EventHandler(this.mnuJoomlaCriarComponente_Click);
            // 
            // mnuJoomlaCriarPaginaKnockout
            // 
            this.mnuJoomlaCriarPaginaKnockout.Image = global::DBTools.Properties.Resources.joomla16x16;
            this.mnuJoomlaCriarPaginaKnockout.Name = "mnuJoomlaCriarPaginaKnockout";
            this.mnuJoomlaCriarPaginaKnockout.Size = new System.Drawing.Size(246, 22);
            this.mnuJoomlaCriarPaginaKnockout.Text = "Criar página Knockout...";
            this.mnuJoomlaCriarPaginaKnockout.Click += new System.EventHandler(this.mnuJoomlaCriarPaginaKnockout_Click);
            // 
            // mnuJoomlaGerarSelectControl
            // 
            this.mnuJoomlaGerarSelectControl.Image = global::DBTools.Properties.Resources.Method;
            this.mnuJoomlaGerarSelectControl.Name = "mnuJoomlaGerarSelectControl";
            this.mnuJoomlaGerarSelectControl.Size = new System.Drawing.Size(246, 22);
            this.mnuJoomlaGerarSelectControl.Text = "Gerar SelectControl (JHTMLPlus)";
            this.mnuJoomlaGerarSelectControl.Click += new System.EventHandler(this.mnuJoomlaGerarSelectControl_Click);
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
            this.toolStripSplitButton1,
            this.toolStripSeparator1,
            this.btnListarCampos});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(266, 25);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComVirgula,
            this.mnuTipoDadosCSharp,
            this.mnuTipoDados,
            this.mnuMinuscula});
            this.toolStripSplitButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(127, 22);
            this.toolStripSplitButton1.Text = "Opções de listagem";
            // 
            // mnuComVirgula
            // 
            this.mnuComVirgula.CheckOnClick = true;
            this.mnuComVirgula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mnuComVirgula.Name = "mnuComVirgula";
            this.mnuComVirgula.Size = new System.Drawing.Size(184, 22);
            this.mnuComVirgula.Text = "Incluir virgula";
            // 
            // mnuTipoDadosCSharp
            // 
            this.mnuTipoDadosCSharp.CheckOnClick = true;
            this.mnuTipoDadosCSharp.ForeColor = System.Drawing.Color.SteelBlue;
            this.mnuTipoDadosCSharp.Name = "mnuTipoDadosCSharp";
            this.mnuTipoDadosCSharp.Size = new System.Drawing.Size(184, 22);
            this.mnuTipoDadosCSharp.Text = "Tipo de dados do C#";
            // 
            // mnuTipoDados
            // 
            this.mnuTipoDados.CheckOnClick = true;
            this.mnuTipoDados.ForeColor = System.Drawing.Color.Blue;
            this.mnuTipoDados.Name = "mnuTipoDados";
            this.mnuTipoDados.Size = new System.Drawing.Size(184, 22);
            this.mnuTipoDados.Text = "Incluir tipo de dados";
            // 
            // mnuMinuscula
            // 
            this.mnuMinuscula.Checked = true;
            this.mnuMinuscula.CheckOnClick = true;
            this.mnuMinuscula.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuMinuscula.ForeColor = System.Drawing.Color.Maroon;
            this.mnuMinuscula.Name = "mnuMinuscula";
            this.mnuMinuscula.Size = new System.Drawing.Size(184, 22);
            this.mnuMinuscula.Text = "Minúscula";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnListarCampos
            // 
            this.btnListarCampos.ForeColor = System.Drawing.Color.Maroon;
            this.btnListarCampos.Image = global::DBTools.Properties.Resources.list;
            this.btnListarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListarCampos.Name = "btnListarCampos";
            this.btnListarCampos.Size = new System.Drawing.Size(102, 22);
            this.btnListarCampos.Text = "Listar Campos";
            this.btnListarCampos.Click += new System.EventHandler(this.btnListarCampos_Click);
            // 
            // mnuGerarClasseFileHelper
            // 
            this.mnuGerarClasseFileHelper.Image = global::DBTools.Properties.Resources.sp_2005;
            this.mnuGerarClasseFileHelper.Name = "mnuGerarClasseFileHelper";
            this.mnuGerarClasseFileHelper.Size = new System.Drawing.Size(296, 22);
            this.mnuGerarClasseFileHelper.Text = "Gerar Classe FileHelper...";
            this.mnuGerarClasseFileHelper.Click += new System.EventHandler(this.MnuGerarClasseFileHelper_Click);
            // 
            // frmServerExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 427);
            this.Controls.Add(this.tvwDados);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServerExplorer";
            this.Text = "Server Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServerExplorer_FormClosing);
            this.Load += new System.EventHandler(this.frmServerExplorer_Load);
            this.cMenuDB.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cMenuDB;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualizar;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectFrom;
        private System.Windows.Forms.ToolStripMenuItem mnuComandoSQL;
        private System.Windows.Forms.ToolStripMenuItem mnuComandoSQLSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuComandoSQLInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuComandoSQLUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuComandoSQLDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuExecuteSP;
        private System.Windows.Forms.ToolStripMenuItem mnuListarNodes;
        private System.Windows.Forms.ToolStripMenuItem mnuProcurarEmSPs;
        private System.Windows.Forms.ToolStripMenuItem mnuAtualizar;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarSP;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarSPInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarSPUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarSPDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuProcurarTabela;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuComVirgula;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnListarCampos;
        private System.Windows.Forms.ToolStripMenuItem mnuTipoDados;
        private System.Windows.Forms.ToolStripMenuItem mnuTipoDadosCSharp;
        private System.Windows.Forms.ToolStripMenuItem mnuMinuscula;
        internal System.Windows.Forms.TreeView tvwDados;
        private System.Windows.Forms.ToolStripMenuItem mnuVisualizaPropriedadesTodasTabelas;
        private System.Windows.Forms.ToolStripMenuItem mnuPropriedades;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarSPSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuCriarEnumDaTabela;
        private System.Windows.Forms.ToolStripMenuItem mnuTabelaVirtualGerar;
        private System.Windows.Forms.ToolStripMenuItem mnuProcurarEmSPsPopUp;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodoCSharp;
        private System.Windows.Forms.ToolStripMenuItem mnuStruct;
        private System.Windows.Forms.ToolStripMenuItem mnuStructGerarComTiposDeDados;
        private System.Windows.Forms.ToolStripMenuItem mnuStructGerarSomenteLista;
        private System.Windows.Forms.ToolStripMenuItem mnuGraficos;
        private System.Windows.Forms.ToolStripMenuItem mnuGraficosPizza;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodoConsultaCSharp;
        private System.Windows.Forms.ToolStripMenuItem mnuListGroupQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuAlterarOwnerdbo;
        private System.Windows.Forms.ToolStripMenuItem mnuImportExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodo;
        private System.Windows.Forms.ToolStripMenuItem mnuStructGerarComTiposDeDadosPreenchimento;
        private System.Windows.Forms.ToolStripMenuItem mnuScriptTableAs;
        private System.Windows.Forms.ToolStripMenuItem mnuScriptTableAsInsertWithValuesToClipboard;
        private System.Windows.Forms.ToolStripMenuItem mnuScriptTableAsCreateTable;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodoCSharpDAAB;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodoConsultaCSharpDAAB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarMetodoVB6;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletarRegistrosDuplicados;
        private System.Windows.Forms.ToolStripMenuItem mnuJoomlaCriarComponente;
        private System.Windows.Forms.ToolStripMenuItem mnuJoomla;
        private System.Windows.Forms.ToolStripMenuItem mnuJoomlaGerarSelectControl;
        private System.Windows.Forms.ToolStripMenuItem mnuJoomlaCriarPaginaKnockout;
        private System.Windows.Forms.ToolStripMenuItem mnuListarDescricao;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarClasseFileHelper;
    }
}