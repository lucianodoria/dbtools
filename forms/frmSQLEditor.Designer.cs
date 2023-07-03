namespace DBTools.forms
{
    partial class frmSQLEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLEditor));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlQuery = new System.Windows.Forms.Panel();
            this.txtQuery = new ScintillaNet.Scintilla();
            this.chkMultline = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnAbrirArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalvarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopiar = new System.Windows.Forms.ToolStripButton();
            this.btnColarTexto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnComment = new System.Windows.Forms.ToolStripButton();
            this.btnNoComment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOutIndent = new System.Windows.Forms.ToolStripButton();
            this.btnIndent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunComando = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunComandoSPDataTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApagarTexto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbcResultado = new System.Windows.Forms.TabControl();
            this.tbpResultadoTotal = new System.Windows.Forms.TabPage();
            this.drResultados = new System.Windows.Forms.DataGrid();
            this.tbpListview = new System.Windows.Forms.TabPage();
            this.chkSorterOrder = new System.Windows.Forms.CheckBox();
            this.btnExportarHtml = new System.Windows.Forms.Button();
            this.btnExportarParaExcel = new System.Windows.Forms.Button();
            this.lvwResultado = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.tbpResultadoDados = new System.Windows.Forms.TabPage();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.tbpRasultadoCampos = new System.Windows.Forms.TabPage();
            this.btnExportarExcelColunas = new System.Windows.Forms.Button();
            this.chkIncluirTipo = new System.Windows.Forms.CheckBox();
            this.chkMarcarTodas = new System.Windows.Forms.CheckBox();
            this.btnCopiarCampos = new System.Windows.Forms.Button();
            this.lvwColunas = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkInformarTipoDados = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAplicarCor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboColunas = new System.Windows.Forms.ComboBox();
            this.syntaxDocument1 = new Fireball.Syntax.SyntaxDocument(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Objects_lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Objects_btnExportarExcel = new System.Windows.Forms.Button();
            this.lvwObjects = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhType_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchNOTIN = new System.Windows.Forms.Button();
            this.objects_btnSearch = new System.Windows.Forms.Button();
            this.objects_chkCreateDate = new System.Windows.Forms.CheckBox();
            this.objects_DateControl = new DatePickerPlus.DateControl();
            this.objects_txtName = new System.Windows.Forms.TextBox();
            this.objects_chkName = new System.Windows.Forms.CheckBox();
            this.objects_chkSPs = new System.Windows.Forms.CheckBox();
            this.objects_chkViews = new System.Windows.Forms.CheckBox();
            this.objects_chkTables = new System.Windows.Forms.CheckBox();
            this.imgAutoComplete = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tbcResultado.SuspendLayout();
            this.tbpResultadoTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drResultados)).BeginInit();
            this.tbpListview.SuspendLayout();
            this.tbpResultadoDados.SuspendLayout();
            this.tbpRasultadoCampos.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlQuery);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbcResultado);
            this.splitContainer2.Size = new System.Drawing.Size(658, 433);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.TabIndex = 1;
            // 
            // pnlQuery
            // 
            this.pnlQuery.BackColor = System.Drawing.Color.Transparent;
            this.pnlQuery.Controls.Add(this.txtQuery);
            this.pnlQuery.Controls.Add(this.chkMultline);
            this.pnlQuery.Controls.Add(this.toolStrip1);
            this.pnlQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuery.Location = new System.Drawing.Point(0, 0);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(658, 233);
            this.pnlQuery.TabIndex = 0;
            // 
            // txtQuery
            // 
            this.txtQuery.AllowDrop = true;
            this.txtQuery.AutoComplete.AutoHide = false;
            this.txtQuery.AutoComplete.DropRestOfWord = true;
            this.txtQuery.AutoComplete.IsCaseSensitive = false;
            this.txtQuery.AutoComplete.ListString = "";
            this.txtQuery.AutoComplete.MaxHeight = 10;
            this.txtQuery.ConfigurationManager.Language = "mssql";
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Indentation.IndentWidth = 4;
            this.txtQuery.Indentation.ShowGuides = true;
            this.txtQuery.Indentation.SmartIndentType = ScintillaNet.SmartIndent.CPP2;
            this.txtQuery.Indentation.TabWidth = 4;
            this.txtQuery.Location = new System.Drawing.Point(0, 25);
            this.txtQuery.Margins.Margin0.IsMarkerMargin = true;
            this.txtQuery.Margins.Margin0.Width = 20;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(658, 208);
            this.txtQuery.TabIndex = 11;
            this.txtQuery.CharAdded += new System.EventHandler<ScintillaNet.CharAddedEventArgs>(this.txtQuery_CharAdded);
            // 
            // chkMultline
            // 
            this.chkMultline.AutoSize = true;
            this.chkMultline.ForeColor = System.Drawing.Color.Maroon;
            this.chkMultline.Location = new System.Drawing.Point(430, 6);
            this.chkMultline.Name = "chkMultline";
            this.chkMultline.Size = new System.Drawing.Size(15, 14);
            this.chkMultline.TabIndex = 10;
            this.chkMultline.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSeparator2,
            this.btnRunComando,
            this.toolStripSeparator7,
            this.btnCopiar,
            this.btnColarTexto,
            this.toolStripSeparator6,
            this.btnComment,
            this.btnNoComment,
            this.toolStripSeparator4,
            this.btnOutIndent,
            this.btnIndent,
            this.toolStripSeparator1,
            this.btnRunComandoSPDataTable,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.btnApagarTexto,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(658, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirArquivo,
            this.btnSalvar,
            this.btnSalvarComo});
            this.toolStripSplitButton1.Image = global::DBTools.Properties.Resources.PropertiesC_;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Image = global::DBTools.Properties.Resources.open_file;
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(155, 22);
            this.btnAbrirArquivo.Text = "Abrir";
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::DBTools.Properties.Resources.saveico;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(155, 22);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvarTextoEmArquivo_Click);
            // 
            // btnSalvarComo
            // 
            this.btnSalvarComo.Image = global::DBTools.Properties.Resources.saveico_edit;
            this.btnSalvarComo.Name = "btnSalvarComo";
            this.btnSalvarComo.Size = new System.Drawing.Size(155, 22);
            this.btnSalvarComo.Text = "Salvar como...";
            this.btnSalvarComo.Click += new System.EventHandler(this.btnSalvaArquivoComo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopiar
            // 
            this.btnCopiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopiar.Image = global::DBTools.Properties.Resources.CopySmall;
            this.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(23, 22);
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnColarTexto
            // 
            this.btnColarTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColarTexto.Image = global::DBTools.Properties.Resources.paste;
            this.btnColarTexto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColarTexto.Name = "btnColarTexto";
            this.btnColarTexto.Size = new System.Drawing.Size(23, 22);
            this.btnColarTexto.Text = "Colar Texto";
            this.btnColarTexto.Click += new System.EventHandler(this.btnColarTexto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnComment
            // 
            this.btnComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnComment.Image = global::DBTools.Properties.Resources.comment;
            this.btnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(23, 22);
            this.btnComment.Tag = "1";
            this.btnComment.Text = "Colocar as linhas selecionada como comentário";
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // btnNoComment
            // 
            this.btnNoComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNoComment.Image = global::DBTools.Properties.Resources.no_comment;
            this.btnNoComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNoComment.Name = "btnNoComment";
            this.btnNoComment.Size = new System.Drawing.Size(23, 22);
            this.btnNoComment.Tag = "2";
            this.btnNoComment.Text = "Remove as linhas selecionada do comentário";
            this.btnNoComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOutIndent
            // 
            this.btnOutIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutIndent.Image = global::DBTools.Properties.Resources.text_outdent;
            this.btnOutIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutIndent.Name = "btnOutIndent";
            this.btnOutIndent.Size = new System.Drawing.Size(23, 22);
            this.btnOutIndent.Text = "toolStripButton1";
            this.btnOutIndent.Click += new System.EventHandler(this.btnOutIndent_Click);
            // 
            // btnIndent
            // 
            this.btnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIndent.Image = global::DBTools.Properties.Resources.text_indent;
            this.btnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndent.Name = "btnIndent";
            this.btnIndent.Size = new System.Drawing.Size(23, 22);
            this.btnIndent.Text = "toolStripButton2";
            this.btnIndent.Click += new System.EventHandler(this.btnIndent_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRunComando
            // 
            this.btnRunComando.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunComando.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnRunComando.Image = global::DBTools.Properties.Resources.execute;
            this.btnRunComando.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunComando.Name = "btnRunComando";
            this.btnRunComando.Size = new System.Drawing.Size(77, 22);
            this.btnRunComando.Text = "Executar";
            this.btnRunComando.Click += new System.EventHandler(this.btnRunComando_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRunComandoSPDataTable
            // 
            this.btnRunComandoSPDataTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunComandoSPDataTable.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnRunComandoSPDataTable.Image = global::DBTools.Properties.Resources.execute_tables;
            this.btnRunComandoSPDataTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunComandoSPDataTable.Name = "btnRunComandoSPDataTable";
            this.btnRunComandoSPDataTable.Size = new System.Drawing.Size(197, 22);
            this.btnRunComandoSPDataTable.Text = "Executar SP DataTable Return";
            this.btnRunComandoSPDataTable.Click += new System.EventHandler(this.btnRunComandoSPDataTable_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripLabel1.LinkColor = System.Drawing.Color.Maroon;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel1.Text = "Query multline";
            this.toolStripLabel1.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnApagarTexto
            // 
            this.btnApagarTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApagarTexto.Image = global::DBTools.Properties.Resources.EmptySmall;
            this.btnApagarTexto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApagarTexto.Name = "btnApagarTexto";
            this.btnApagarTexto.Size = new System.Drawing.Size(23, 22);
            this.btnApagarTexto.Text = "Limpar campo";
            this.btnApagarTexto.Click += new System.EventHandler(this.btnApagarTexto_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbcResultado
            // 
            this.tbcResultado.Controls.Add(this.tbpResultadoTotal);
            this.tbcResultado.Controls.Add(this.tbpListview);
            this.tbcResultado.Controls.Add(this.tbpResultadoDados);
            this.tbcResultado.Controls.Add(this.tbpRasultadoCampos);
            this.tbcResultado.Controls.Add(this.tabPage3);
            this.tbcResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcResultado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcResultado.Location = new System.Drawing.Point(0, 0);
            this.tbcResultado.Name = "tbcResultado";
            this.tbcResultado.SelectedIndex = 0;
            this.tbcResultado.Size = new System.Drawing.Size(658, 196);
            this.tbcResultado.TabIndex = 0;
            // 
            // tbpResultadoTotal
            // 
            this.tbpResultadoTotal.Controls.Add(this.drResultados);
            this.tbpResultadoTotal.Location = new System.Drawing.Point(4, 22);
            this.tbpResultadoTotal.Name = "tbpResultadoTotal";
            this.tbpResultadoTotal.Size = new System.Drawing.Size(650, 170);
            this.tbpResultadoTotal.TabIndex = 1;
            this.tbpResultadoTotal.Text = "GridView";
            this.tbpResultadoTotal.UseVisualStyleBackColor = true;
            // 
            // drResultados
            // 
            this.drResultados.DataMember = "";
            this.drResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drResultados.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drResultados.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.drResultados.Location = new System.Drawing.Point(0, 0);
            this.drResultados.Name = "drResultados";
            this.drResultados.ReadOnly = true;
            this.drResultados.Size = new System.Drawing.Size(650, 170);
            this.drResultados.TabIndex = 0;
            // 
            // tbpListview
            // 
            this.tbpListview.Controls.Add(this.chkSorterOrder);
            this.tbpListview.Controls.Add(this.btnExportarHtml);
            this.tbpListview.Controls.Add(this.btnExportarParaExcel);
            this.tbpListview.Controls.Add(this.lvwResultado);
            this.tbpListview.Location = new System.Drawing.Point(4, 22);
            this.tbpListview.Name = "tbpListview";
            this.tbpListview.Size = new System.Drawing.Size(650, 170);
            this.tbpListview.TabIndex = 3;
            this.tbpListview.Text = "Listview";
            this.tbpListview.UseVisualStyleBackColor = true;
            // 
            // chkSorterOrder
            // 
            this.chkSorterOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSorterOrder.AutoSize = true;
            this.chkSorterOrder.ForeColor = System.Drawing.Color.Maroon;
            this.chkSorterOrder.Location = new System.Drawing.Point(3, 148);
            this.chkSorterOrder.Name = "chkSorterOrder";
            this.chkSorterOrder.Size = new System.Drawing.Size(87, 17);
            this.chkSorterOrder.TabIndex = 47;
            this.chkSorterOrder.Text = "Sorter Order";
            this.chkSorterOrder.UseVisualStyleBackColor = true;
            this.chkSorterOrder.CheckedChanged += new System.EventHandler(this.chkSorterOrder_CheckedChanged);
            // 
            // btnExportarHtml
            // 
            this.btnExportarHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarHtml.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarHtml.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnExportarHtml.Image = global::DBTools.Properties.Resources.IE716x16;
            this.btnExportarHtml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarHtml.Location = new System.Drawing.Point(349, 143);
            this.btnExportarHtml.Name = "btnExportarHtml";
            this.btnExportarHtml.Size = new System.Drawing.Size(145, 24);
            this.btnExportarHtml.TabIndex = 46;
            this.btnExportarHtml.Text = "Exportar para Html";
            this.btnExportarHtml.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarHtml.UseVisualStyleBackColor = true;
            this.btnExportarHtml.Click += new System.EventHandler(this.btnExportarHtml_Click);
            // 
            // btnExportarParaExcel
            // 
            this.btnExportarParaExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarParaExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarParaExcel.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExportarParaExcel.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarParaExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarParaExcel.Location = new System.Drawing.Point(500, 143);
            this.btnExportarParaExcel.Name = "btnExportarParaExcel";
            this.btnExportarParaExcel.Size = new System.Drawing.Size(145, 24);
            this.btnExportarParaExcel.TabIndex = 45;
            this.btnExportarParaExcel.Text = "Exportar para Excel";
            this.btnExportarParaExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarParaExcel.UseVisualStyleBackColor = true;
            this.btnExportarParaExcel.Click += new System.EventHandler(this.btnExportarParaExcel_Click);
            // 
            // lvwResultado
            // 
            this.lvwResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResultado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwResultado.FullRowSelect = true;
            this.lvwResultado.GridLines = true;
            this.lvwResultado.HideSelection = false;
            this.lvwResultado.KeyUpDownActivateOnClick = false;
            this.lvwResultado.Location = new System.Drawing.Point(0, 0);
            this.lvwResultado.MultiSelect = false;
            this.lvwResultado.Name = "lvwResultado";
            this.lvwResultado.Size = new System.Drawing.Size(645, 137);
            this.lvwResultado.Sorter = true;
            this.lvwResultado.TabIndex = 6;
            this.lvwResultado.UseCompatibleStateImageBehavior = false;
            this.lvwResultado.View = System.Windows.Forms.View.Details;
            // 
            // tbpResultadoDados
            // 
            this.tbpResultadoDados.Controls.Add(this.txtResultado);
            this.tbpResultadoDados.Location = new System.Drawing.Point(4, 22);
            this.tbpResultadoDados.Name = "tbpResultadoDados";
            this.tbpResultadoDados.Size = new System.Drawing.Size(650, 170);
            this.tbpResultadoDados.TabIndex = 0;
            this.tbpResultadoDados.Text = "Mensagens";
            this.tbpResultadoDados.UseVisualStyleBackColor = true;
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.Location = new System.Drawing.Point(0, 0);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(650, 170);
            this.txtResultado.TabIndex = 0;
            // 
            // tbpRasultadoCampos
            // 
            this.tbpRasultadoCampos.Controls.Add(this.btnExportarExcelColunas);
            this.tbpRasultadoCampos.Controls.Add(this.chkIncluirTipo);
            this.tbpRasultadoCampos.Controls.Add(this.chkMarcarTodas);
            this.tbpRasultadoCampos.Controls.Add(this.btnCopiarCampos);
            this.tbpRasultadoCampos.Controls.Add(this.lvwColunas);
            this.tbpRasultadoCampos.Location = new System.Drawing.Point(4, 22);
            this.tbpRasultadoCampos.Name = "tbpRasultadoCampos";
            this.tbpRasultadoCampos.Size = new System.Drawing.Size(650, 170);
            this.tbpRasultadoCampos.TabIndex = 2;
            this.tbpRasultadoCampos.Text = "Campos";
            this.tbpRasultadoCampos.UseVisualStyleBackColor = true;
            // 
            // btnExportarExcelColunas
            // 
            this.btnExportarExcelColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcelColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcelColunas.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExportarExcelColunas.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarExcelColunas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcelColunas.Location = new System.Drawing.Point(329, 141);
            this.btnExportarExcelColunas.Name = "btnExportarExcelColunas";
            this.btnExportarExcelColunas.Size = new System.Drawing.Size(145, 24);
            this.btnExportarExcelColunas.TabIndex = 46;
            this.btnExportarExcelColunas.Text = "Exportar para Excel";
            this.btnExportarExcelColunas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcelColunas.UseVisualStyleBackColor = true;
            this.btnExportarExcelColunas.Click += new System.EventHandler(this.btnExportarExcelColunas_Click);
            // 
            // chkIncluirTipo
            // 
            this.chkIncluirTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIncluirTipo.AutoSize = true;
            this.chkIncluirTipo.ForeColor = System.Drawing.Color.Navy;
            this.chkIncluirTipo.Location = new System.Drawing.Point(100, 146);
            this.chkIncluirTipo.Name = "chkIncluirTipo";
            this.chkIncluirTipo.Size = new System.Drawing.Size(78, 17);
            this.chkIncluirTipo.TabIndex = 8;
            this.chkIncluirTipo.Text = "Incluir Tipo";
            // 
            // chkMarcarTodas
            // 
            this.chkMarcarTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMarcarTodas.AutoSize = true;
            this.chkMarcarTodas.ForeColor = System.Drawing.Color.Navy;
            this.chkMarcarTodas.Location = new System.Drawing.Point(3, 146);
            this.chkMarcarTodas.Name = "chkMarcarTodas";
            this.chkMarcarTodas.Size = new System.Drawing.Size(91, 17);
            this.chkMarcarTodas.TabIndex = 7;
            this.chkMarcarTodas.Text = "Marcar Todas";
            this.chkMarcarTodas.CheckedChanged += new System.EventHandler(this.chkMarcarTodas_CheckedChanged);
            // 
            // btnCopiarCampos
            // 
            this.btnCopiarCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiarCampos.ForeColor = System.Drawing.Color.Maroon;
            this.btnCopiarCampos.Image = global::DBTools.Properties.Resources.CopySmall;
            this.btnCopiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiarCampos.Location = new System.Drawing.Point(480, 141);
            this.btnCopiarCampos.Name = "btnCopiarCampos";
            this.btnCopiarCampos.Size = new System.Drawing.Size(165, 24);
            this.btnCopiarCampos.TabIndex = 6;
            this.btnCopiarCampos.Text = "Copiar campos selecionados";
            this.btnCopiarCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiarCampos.Click += new System.EventHandler(this.btnCopiarCampos_Click);
            // 
            // lvwColunas
            // 
            this.lvwColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwColunas.CheckBoxes = true;
            this.lvwColunas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwColunas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwColunas.FullRowSelect = true;
            this.lvwColunas.HideSelection = false;
            this.lvwColunas.KeyUpDownActivateOnClick = false;
            this.lvwColunas.Location = new System.Drawing.Point(0, 0);
            this.lvwColunas.MultiSelect = false;
            this.lvwColunas.Name = "lvwColunas";
            this.lvwColunas.Size = new System.Drawing.Size(645, 135);
            this.lvwColunas.Sorter = true;
            this.lvwColunas.TabIndex = 5;
            this.lvwColunas.UseCompatibleStateImageBehavior = false;
            this.lvwColunas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ordem";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome do campo";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkInformarTipoDados);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.btnAplicarCor);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cboColunas);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(650, 170);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Forecolor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkInformarTipoDados
            // 
            this.chkInformarTipoDados.AutoSize = true;
            this.chkInformarTipoDados.ForeColor = System.Drawing.Color.Maroon;
            this.chkInformarTipoDados.Location = new System.Drawing.Point(19, 36);
            this.chkInformarTipoDados.Name = "chkInformarTipoDados";
            this.chkInformarTipoDados.Size = new System.Drawing.Size(136, 17);
            this.chkInformarTipoDados.TabIndex = 3;
            this.chkInformarTipoDados.Text = "Informar tipo de dados";
            this.chkInformarTipoDados.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(9, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 123);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "                                            ";
            // 
            // btnAplicarCor
            // 
            this.btnAplicarCor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarCor.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAplicarCor.Image = global::DBTools.Properties.Resources.fontcolor;
            this.btnAplicarCor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarCor.Location = new System.Drawing.Point(390, 6);
            this.btnAplicarCor.Name = "btnAplicarCor";
            this.btnAplicarCor.Size = new System.Drawing.Size(94, 24);
            this.btnAplicarCor.TabIndex = 2;
            this.btnAplicarCor.Text = "Aplicar cor";
            this.btnAplicarCor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicarCor.UseVisualStyleBackColor = true;
            this.btnAplicarCor.Click += new System.EventHandler(this.btnAplicarCor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coluna:";
            // 
            // cboColunas
            // 
            this.cboColunas.ForeColor = System.Drawing.Color.Blue;
            this.cboColunas.FormattingEnabled = true;
            this.cboColunas.Location = new System.Drawing.Point(56, 9);
            this.cboColunas.Name = "cboColunas";
            this.cboColunas.Size = new System.Drawing.Size(328, 21);
            this.cboColunas.TabIndex = 0;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        "codeEditorControl1"};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 465);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(664, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Objects_lblTotal);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Objects_btnExportarExcel);
            this.tabPage2.Controls.Add(this.lvwObjects);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Objects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Objects_lblTotal
            // 
            this.Objects_lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Objects_lblTotal.AutoSize = true;
            this.Objects_lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Objects_lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Objects_lblTotal.Location = new System.Drawing.Point(44, 406);
            this.Objects_lblTotal.Name = "Objects_lblTotal";
            this.Objects_lblTotal.Size = new System.Drawing.Size(14, 13);
            this.Objects_lblTotal.TabIndex = 4;
            this.Objects_lblTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total:";
            // 
            // Objects_btnExportarExcel
            // 
            this.Objects_btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Objects_btnExportarExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Objects_btnExportarExcel.ForeColor = System.Drawing.Color.SteelBlue;
            this.Objects_btnExportarExcel.Image = global::DBTools.Properties.Resources.excel16x16;
            this.Objects_btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Objects_btnExportarExcel.Location = new System.Drawing.Point(509, 409);
            this.Objects_btnExportarExcel.Name = "Objects_btnExportarExcel";
            this.Objects_btnExportarExcel.Size = new System.Drawing.Size(145, 24);
            this.Objects_btnExportarExcel.TabIndex = 2;
            this.Objects_btnExportarExcel.Text = "Exportar para Excel";
            this.Objects_btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Objects_btnExportarExcel.UseVisualStyleBackColor = true;
            this.Objects_btnExportarExcel.Click += new System.EventHandler(this.Objects_btnExportarExcel_Click);
            // 
            // lvwObjects
            // 
            this.lvwObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhName,
            this.clhOwner,
            this.clhCreateDate,
            this.clhType_desc,
            this.clhID});
            this.lvwObjects.FullRowSelect = true;
            this.lvwObjects.HideSelection = false;
            this.lvwObjects.KeyUpDownActivateOnClick = false;
            this.lvwObjects.Location = new System.Drawing.Point(6, 126);
            this.lvwObjects.Name = "lvwObjects";
            this.lvwObjects.Size = new System.Drawing.Size(648, 277);
            this.lvwObjects.SmallImageList = this.imgIcon;
            this.lvwObjects.Sorter = true;
            this.lvwObjects.TabIndex = 1;
            this.lvwObjects.UseCompatibleStateImageBehavior = false;
            this.lvwObjects.View = System.Windows.Forms.View.Details;
            // 
            // clhName
            // 
            this.clhName.Text = "Name";
            this.clhName.Width = 250;
            // 
            // clhOwner
            // 
            this.clhOwner.Text = "Owner";
            this.clhOwner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clhCreateDate
            // 
            this.clhCreateDate.Text = "Create Date";
            this.clhCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhCreateDate.Width = 120;
            // 
            // clhType_desc
            // 
            this.clhType_desc.Text = "Type";
            this.clhType_desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhType_desc.Width = 100;
            // 
            // clhID
            // 
            this.clhID.Text = "ID";
            this.clhID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhID.Width = 80;
            // 
            // imgIcon
            // 
            this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcon.Images.SetKeyName(0, "tables1.ico");
            this.imgIcon.Images.SetKeyName(1, "view_2005.ico");
            this.imgIcon.Images.SetKeyName(2, "sp_2005.ico");
            this.imgIcon.Images.SetKeyName(3, "tables_row_2005.ico");
            this.imgIcon.Images.SetKeyName(4, "sp_row_2005.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearchNOTIN);
            this.groupBox1.Controls.Add(this.objects_btnSearch);
            this.groupBox1.Controls.Add(this.objects_chkCreateDate);
            this.groupBox1.Controls.Add(this.objects_DateControl);
            this.groupBox1.Controls.Add(this.objects_txtName);
            this.groupBox1.Controls.Add(this.objects_chkName);
            this.groupBox1.Controls.Add(this.objects_chkSPs);
            this.groupBox1.Controls.Add(this.objects_chkViews);
            this.groupBox1.Controls.Add(this.objects_chkTables);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnSearchNOTIN
            // 
            this.btnSearchNOTIN.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchNOTIN.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSearchNOTIN.Image = global::DBTools.Properties.Resources.Find16x16;
            this.btnSearchNOTIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchNOTIN.Location = new System.Drawing.Point(113, 77);
            this.btnSearchNOTIN.Name = "btnSearchNOTIN";
            this.btnSearchNOTIN.Size = new System.Drawing.Size(112, 25);
            this.btnSearchNOTIN.TabIndex = 8;
            this.btnSearchNOTIN.Text = "Search NOT IN";
            this.btnSearchNOTIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchNOTIN.UseVisualStyleBackColor = true;
            this.btnSearchNOTIN.Click += new System.EventHandler(this.btnSearchNOTIN_Click);
            // 
            // objects_btnSearch
            // 
            this.objects_btnSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objects_btnSearch.ForeColor = System.Drawing.Color.SteelBlue;
            this.objects_btnSearch.Image = global::DBTools.Properties.Resources.Find16x16;
            this.objects_btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objects_btnSearch.Location = new System.Drawing.Point(231, 77);
            this.objects_btnSearch.Name = "objects_btnSearch";
            this.objects_btnSearch.Size = new System.Drawing.Size(99, 25);
            this.objects_btnSearch.TabIndex = 7;
            this.objects_btnSearch.Text = "Search";
            this.objects_btnSearch.UseVisualStyleBackColor = true;
            this.objects_btnSearch.Click += new System.EventHandler(this.objects_btnSearch_Click);
            // 
            // objects_chkCreateDate
            // 
            this.objects_chkCreateDate.AutoSize = true;
            this.objects_chkCreateDate.ForeColor = System.Drawing.Color.Maroon;
            this.objects_chkCreateDate.Location = new System.Drawing.Point(6, 77);
            this.objects_chkCreateDate.Name = "objects_chkCreateDate";
            this.objects_chkCreateDate.Size = new System.Drawing.Size(85, 17);
            this.objects_chkCreateDate.TabIndex = 6;
            this.objects_chkCreateDate.Text = "Create Date";
            this.objects_chkCreateDate.UseVisualStyleBackColor = true;
            this.objects_chkCreateDate.CheckedChanged += new System.EventHandler(this.objects_chkCreateDate_CheckedChanged);
            // 
            // objects_DateControl
            // 
            this.objects_DateControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objects_DateControl.BackColorGroupBox = System.Drawing.Color.Transparent;
            this.objects_DateControl.DateEnd = new System.DateTime(2011, 9, 1, 9, 28, 59, 342);
            this.objects_DateControl.DateEndFull = new System.DateTime(2011, 9, 1, 23, 59, 59, 0);
            this.objects_DateControl.DateStart = new System.DateTime(2011, 9, 1, 9, 28, 59, 342);
            this.objects_DateControl.DateStartFull = new System.DateTime(2011, 9, 1, 0, 0, 0, 0);
            this.objects_DateControl.Enabled = false;
            this.objects_DateControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objects_DateControl.ForeColorGroupBox = System.Drawing.Color.Maroon;
            this.objects_DateControl.HourEnd = new System.DateTime(2005, 7, 18, 23, 59, 59, 0);
            this.objects_DateControl.HourStart = new System.DateTime(2005, 7, 18, 0, 0, 0, 0);
            this.objects_DateControl.Location = new System.Drawing.Point(336, 13);
            this.objects_DateControl.MaximumSize = new System.Drawing.Size(312, 98);
            this.objects_DateControl.MinimumSize = new System.Drawing.Size(312, 98);
            this.objects_DateControl.Name = "objects_DateControl";
            this.objects_DateControl.Size = new System.Drawing.Size(312, 98);
            this.objects_DateControl.TabIndex = 5;
            // 
            // objects_txtName
            // 
            this.objects_txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.objects_txtName.Location = new System.Drawing.Point(82, 50);
            this.objects_txtName.Name = "objects_txtName";
            this.objects_txtName.Size = new System.Drawing.Size(248, 21);
            this.objects_txtName.TabIndex = 4;
            this.objects_txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.objects_txtName_KeyUp);
            // 
            // objects_chkName
            // 
            this.objects_chkName.AutoSize = true;
            this.objects_chkName.Checked = true;
            this.objects_chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objects_chkName.ForeColor = System.Drawing.Color.Maroon;
            this.objects_chkName.Location = new System.Drawing.Point(6, 52);
            this.objects_chkName.Name = "objects_chkName";
            this.objects_chkName.Size = new System.Drawing.Size(57, 17);
            this.objects_chkName.TabIndex = 3;
            this.objects_chkName.Text = "Name:";
            this.objects_chkName.UseVisualStyleBackColor = true;
            this.objects_chkName.CheckedChanged += new System.EventHandler(this.objects_chkName_CheckedChanged);
            // 
            // objects_chkSPs
            // 
            this.objects_chkSPs.Checked = true;
            this.objects_chkSPs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objects_chkSPs.ForeColor = System.Drawing.Color.Maroon;
            this.objects_chkSPs.Image = global::DBTools.Properties.Resources.sp_2005;
            this.objects_chkSPs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objects_chkSPs.Location = new System.Drawing.Point(170, 20);
            this.objects_chkSPs.Name = "objects_chkSPs";
            this.objects_chkSPs.Size = new System.Drawing.Size(146, 26);
            this.objects_chkSPs.TabIndex = 2;
            this.objects_chkSPs.Text = "      Storeds Procedures";
            this.objects_chkSPs.UseVisualStyleBackColor = true;
            // 
            // objects_chkViews
            // 
            this.objects_chkViews.Checked = true;
            this.objects_chkViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objects_chkViews.ForeColor = System.Drawing.Color.Maroon;
            this.objects_chkViews.Image = global::DBTools.Properties.Resources.view_2005;
            this.objects_chkViews.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objects_chkViews.Location = new System.Drawing.Point(88, 20);
            this.objects_chkViews.Name = "objects_chkViews";
            this.objects_chkViews.Size = new System.Drawing.Size(76, 26);
            this.objects_chkViews.TabIndex = 1;
            this.objects_chkViews.Text = "      Views";
            this.objects_chkViews.UseVisualStyleBackColor = true;
            // 
            // objects_chkTables
            // 
            this.objects_chkTables.Checked = true;
            this.objects_chkTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objects_chkTables.ForeColor = System.Drawing.Color.Maroon;
            this.objects_chkTables.Image = global::DBTools.Properties.Resources.tables1;
            this.objects_chkTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.objects_chkTables.Location = new System.Drawing.Point(6, 20);
            this.objects_chkTables.Name = "objects_chkTables";
            this.objects_chkTables.Size = new System.Drawing.Size(76, 26);
            this.objects_chkTables.TabIndex = 0;
            this.objects_chkTables.Text = "      Tables";
            this.objects_chkTables.UseVisualStyleBackColor = true;
            // 
            // imgAutoComplete
            // 
            this.imgAutoComplete.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAutoComplete.ImageStream")));
            this.imgAutoComplete.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAutoComplete.Images.SetKeyName(0, "table.bmp");
            this.imgAutoComplete.Images.SetKeyName(1, "view.bmp");
            this.imgAutoComplete.Images.SetKeyName(2, "sp.bmp");
            this.imgAutoComplete.Images.SetKeyName(3, "row.bmp");
            this.imgAutoComplete.Images.SetKeyName(4, "sp_row.bmp");
            // 
            // frmSQLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 465);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSQLEditor";
            this.Text = "SQL Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSQLEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmSQLEditor_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbcResultado.ResumeLayout(false);
            this.tbpResultadoTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drResultados)).EndInit();
            this.tbpListview.ResumeLayout(false);
            this.tbpListview.PerformLayout();
            this.tbpResultadoDados.ResumeLayout(false);
            this.tbpResultadoDados.PerformLayout();
            this.tbpRasultadoCampos.ResumeLayout(false);
            this.tbpRasultadoCampos.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlQuery;
        private System.Windows.Forms.TabControl tbcResultado;
        private System.Windows.Forms.TabPage tbpResultadoTotal;
        private System.Windows.Forms.DataGrid drResultados;
        private System.Windows.Forms.TabPage tbpListview;
        private System.Windows.Forms.Button btnExportarParaExcel;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwResultado;
        private System.Windows.Forms.TabPage tbpResultadoDados;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TabPage tbpRasultadoCampos;
        private System.Windows.Forms.CheckBox chkIncluirTipo;
        private System.Windows.Forms.CheckBox chkMarcarTodas;
        private System.Windows.Forms.Button btnCopiarCampos;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwColunas;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnExportarHtml;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Objects_lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Objects_btnExportarExcel;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwObjects;
        private System.Windows.Forms.ColumnHeader clhName;
        private System.Windows.Forms.ColumnHeader clhOwner;
        private System.Windows.Forms.ColumnHeader clhCreateDate;
        private System.Windows.Forms.ColumnHeader clhID;
        private System.Windows.Forms.CheckBox objects_chkTables;
        private System.Windows.Forms.CheckBox objects_chkSPs;
        private System.Windows.Forms.CheckBox objects_chkViews;
        private System.Windows.Forms.TextBox objects_txtName;
        private System.Windows.Forms.CheckBox objects_chkName;
        private System.Windows.Forms.Button objects_btnSearch;
        private System.Windows.Forms.CheckBox objects_chkCreateDate;
        private DatePickerPlus.DateControl objects_DateControl;
        private System.Windows.Forms.ImageList imgIcon;
        private System.Windows.Forms.ColumnHeader clhType_desc;
        private Fireball.Syntax.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnApagarTexto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRunComando;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRunComandoSPDataTable;
        private System.Windows.Forms.CheckBox chkMultline;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.CheckBox chkSorterOrder;
        private System.Windows.Forms.Button btnSearchNOTIN;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkInformarTipoDados;
        private System.Windows.Forms.Button btnAplicarCor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboColunas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportarExcelColunas;
        private System.Windows.Forms.ImageList imgAutoComplete;
        private System.Windows.Forms.ToolStripButton btnComment;
        private System.Windows.Forms.ToolStripButton btnNoComment;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnAbrirArquivo;
        private System.Windows.Forms.ToolStripMenuItem btnSalvar;
        private System.Windows.Forms.ToolStripMenuItem btnSalvarComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal ScintillaNet.Scintilla txtQuery;
        private System.Windows.Forms.ToolStripButton btnCopiar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnColarTexto;
        private System.Windows.Forms.ToolStripButton btnOutIndent;
        private System.Windows.Forms.ToolStripButton btnIndent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}