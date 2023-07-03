namespace DBTools.forms
{
    partial class frmListGroupQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListGroupQuery));
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            this.cboWhereType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWhereDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.Select_btnInserirUm = new System.Windows.Forms.Button();
            this.gpbWhere = new System.Windows.Forms.GroupBox();
            this.btnSelectRowDown = new System.Windows.Forms.Button();
            this.btnSelectRowUp = new System.Windows.Forms.Button();
            this.txtColumnAs = new System.Windows.Forms.TextBox();
            this.Where_lblValor = new System.Windows.Forms.Label();
            this.btnRemoverTodosColumn = new System.Windows.Forms.Button();
            this.btnRemoverUmColumn = new System.Windows.Forms.Button();
            this.btnInserirUmColumn = new System.Windows.Forms.Button();
            this.lvwColumns = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhWhereColumn = new System.Windows.Forms.ColumnHeader();
            this.clhAs = new System.Windows.Forms.ColumnHeader();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.gpbQuery = new System.Windows.Forms.GroupBox();
            this.lvwCampos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhColumnName = new System.Windows.Forms.ColumnHeader();
            this.clhColumnIsDate = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWhereValues = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOrderByClear = new System.Windows.Forms.Button();
            this.txtOrderBy = new System.Windows.Forms.TextBox();
            this.btnOrderBy = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboTipoValue = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoverTodosWhere = new System.Windows.Forms.Button();
            this.btnRemoverUmWhere = new System.Windows.Forms.Button();
            this.btnInserirUmWhere = new System.Windows.Forms.Button();
            this.lvwWhere = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.pgbConsulta = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdbExportarExcel = new System.Windows.Forms.RadioButton();
            this.rdbExportarHtml = new System.Windows.Forms.RadioButton();
            this.gpbSelect.SuspendLayout();
            this.gpbWhere.SuspendLayout();
            this.gpbQuery.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSelect.Controls.Add(this.cboWhereType);
            this.gpbSelect.Controls.Add(this.label3);
            this.gpbSelect.Controls.Add(this.txtWhereDescricao);
            this.gpbSelect.Controls.Add(this.label1);
            this.gpbSelect.Controls.Add(this.txtWhere);
            this.gpbSelect.Controls.Add(this.Select_btnInserirUm);
            this.gpbSelect.Location = new System.Drawing.Point(447, 12);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(538, 100);
            this.gpbSelect.TabIndex = 23;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "Where";
            // 
            // cboWhereType
            // 
            this.cboWhereType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWhereType.ForeColor = System.Drawing.Color.Blue;
            this.cboWhereType.FormattingEnabled = true;
            this.cboWhereType.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "<>",
            ">=",
            "<=",
            "LIKE"});
            this.cboWhereType.Location = new System.Drawing.Point(77, 47);
            this.cboWhereType.Name = "cboWhereType";
            this.cboWhereType.Size = new System.Drawing.Size(109, 21);
            this.cboWhereType.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type:";
            // 
            // txtWhereDescricao
            // 
            this.txtWhereDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhereDescricao.ForeColor = System.Drawing.Color.Blue;
            this.txtWhereDescricao.Location = new System.Drawing.Point(77, 74);
            this.txtWhereDescricao.Name = "txtWhereDescricao";
            this.txtWhereDescricao.Size = new System.Drawing.Size(455, 20);
            this.txtWhereDescricao.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Descrição:";
            // 
            // txtWhere
            // 
            this.txtWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhere.BackColor = System.Drawing.Color.Ivory;
            this.txtWhere.ForeColor = System.Drawing.Color.Blue;
            this.txtWhere.Location = new System.Drawing.Point(77, 21);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.ReadOnly = true;
            this.txtWhere.Size = new System.Drawing.Size(455, 20);
            this.txtWhere.TabIndex = 3;
            // 
            // Select_btnInserirUm
            // 
            this.Select_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.Select_btnInserirUm.Location = new System.Drawing.Point(6, 19);
            this.Select_btnInserirUm.Name = "Select_btnInserirUm";
            this.Select_btnInserirUm.Size = new System.Drawing.Size(65, 23);
            this.Select_btnInserirUm.TabIndex = 2;
            this.Select_btnInserirUm.Text = ">";
            this.Select_btnInserirUm.UseVisualStyleBackColor = true;
            this.Select_btnInserirUm.Click += new System.EventHandler(this.Select_btnInserirUm_Click);
            // 
            // gpbWhere
            // 
            this.gpbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWhere.Controls.Add(this.btnSelectRowDown);
            this.gpbWhere.Controls.Add(this.btnSelectRowUp);
            this.gpbWhere.Controls.Add(this.txtColumnAs);
            this.gpbWhere.Controls.Add(this.Where_lblValor);
            this.gpbWhere.Controls.Add(this.btnRemoverTodosColumn);
            this.gpbWhere.Controls.Add(this.btnRemoverUmColumn);
            this.gpbWhere.Controls.Add(this.btnInserirUmColumn);
            this.gpbWhere.Controls.Add(this.lvwColumns);
            this.gpbWhere.Location = new System.Drawing.Point(447, 112);
            this.gpbWhere.Name = "gpbWhere";
            this.gpbWhere.Size = new System.Drawing.Size(538, 233);
            this.gpbWhere.TabIndex = 21;
            this.gpbWhere.TabStop = false;
            this.gpbWhere.Text = "Columns";
            // 
            // btnSelectRowDown
            // 
            this.btnSelectRowDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectRowDown.Image = global::DBTools.Properties.Resources.ARW07DN;
            this.btnSelectRowDown.Location = new System.Drawing.Point(509, 63);
            this.btnSelectRowDown.Name = "btnSelectRowDown";
            this.btnSelectRowDown.Size = new System.Drawing.Size(23, 23);
            this.btnSelectRowDown.TabIndex = 11;
            this.btnSelectRowDown.UseVisualStyleBackColor = true;
            this.btnSelectRowDown.Click += new System.EventHandler(this.btnSelectRowDown_Click);
            // 
            // btnSelectRowUp
            // 
            this.btnSelectRowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectRowUp.Image = global::DBTools.Properties.Resources.ARW07UP;
            this.btnSelectRowUp.Location = new System.Drawing.Point(509, 37);
            this.btnSelectRowUp.Name = "btnSelectRowUp";
            this.btnSelectRowUp.Size = new System.Drawing.Size(23, 23);
            this.btnSelectRowUp.TabIndex = 10;
            this.btnSelectRowUp.UseVisualStyleBackColor = true;
            this.btnSelectRowUp.Click += new System.EventHandler(this.btnSelectRowUp_Click);
            // 
            // txtColumnAs
            // 
            this.txtColumnAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnAs.ForeColor = System.Drawing.Color.Blue;
            this.txtColumnAs.Location = new System.Drawing.Point(91, 11);
            this.txtColumnAs.Name = "txtColumnAs";
            this.txtColumnAs.Size = new System.Drawing.Size(441, 20);
            this.txtColumnAs.TabIndex = 8;
            // 
            // Where_lblValor
            // 
            this.Where_lblValor.AutoSize = true;
            this.Where_lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_lblValor.ForeColor = System.Drawing.Color.Navy;
            this.Where_lblValor.Location = new System.Drawing.Point(60, 14);
            this.Where_lblValor.Name = "Where_lblValor";
            this.Where_lblValor.Size = new System.Drawing.Size(25, 13);
            this.Where_lblValor.TabIndex = 7;
            this.Where_lblValor.Text = "As:";
            // 
            // btnRemoverTodosColumn
            // 
            this.btnRemoverTodosColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverTodosColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverTodosColumn.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverTodosColumn.Location = new System.Drawing.Point(6, 205);
            this.btnRemoverTodosColumn.Name = "btnRemoverTodosColumn";
            this.btnRemoverTodosColumn.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverTodosColumn.TabIndex = 5;
            this.btnRemoverTodosColumn.Text = "<<";
            this.btnRemoverTodosColumn.UseVisualStyleBackColor = true;
            this.btnRemoverTodosColumn.Click += new System.EventHandler(this.Where_btnRemoverTodos_Click);
            // 
            // btnRemoverUmColumn
            // 
            this.btnRemoverUmColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverUmColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverUmColumn.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverUmColumn.Location = new System.Drawing.Point(6, 176);
            this.btnRemoverUmColumn.Name = "btnRemoverUmColumn";
            this.btnRemoverUmColumn.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverUmColumn.TabIndex = 4;
            this.btnRemoverUmColumn.Text = "<";
            this.btnRemoverUmColumn.UseVisualStyleBackColor = true;
            this.btnRemoverUmColumn.Click += new System.EventHandler(this.Where_btnRemoverUm_Click);
            // 
            // btnInserirUmColumn
            // 
            this.btnInserirUmColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirUmColumn.ForeColor = System.Drawing.Color.Blue;
            this.btnInserirUmColumn.Location = new System.Drawing.Point(6, 19);
            this.btnInserirUmColumn.Name = "btnInserirUmColumn";
            this.btnInserirUmColumn.Size = new System.Drawing.Size(48, 23);
            this.btnInserirUmColumn.TabIndex = 2;
            this.btnInserirUmColumn.Text = ">";
            this.btnInserirUmColumn.UseVisualStyleBackColor = true;
            this.btnInserirUmColumn.Click += new System.EventHandler(this.Where_btnInserirUm_Click);
            // 
            // lvwColumns
            // 
            this.lvwColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhWhereColumn,
            this.clhAs});
            this.lvwColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lvwColumns.FullRowSelect = true;
            this.lvwColumns.HideSelection = false;
            this.lvwColumns.KeyUpDownActivateOnClick = false;
            this.lvwColumns.Location = new System.Drawing.Point(60, 37);
            this.lvwColumns.MultiSelect = false;
            this.lvwColumns.Name = "lvwColumns";
            this.lvwColumns.Size = new System.Drawing.Size(443, 190);
            this.lvwColumns.Sorter = false;
            this.lvwColumns.TabIndex = 1;
            this.lvwColumns.UseCompatibleStateImageBehavior = false;
            this.lvwColumns.View = System.Windows.Forms.View.Details;
            // 
            // clhWhereColumn
            // 
            this.clhWhereColumn.Text = "Column";
            this.clhWhereColumn.Width = 200;
            // 
            // clhAs
            // 
            this.clhAs.Text = "As";
            this.clhAs.Width = 250;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecutar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExecutar.Image = global::DBTools.Properties.Resources.run;
            this.btnExecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecutar.Location = new System.Drawing.Point(907, 637);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(78, 23);
            this.btnExecutar.TabIndex = 0;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // gpbQuery
            // 
            this.gpbQuery.Controls.Add(this.lvwCampos);
            this.gpbQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbQuery.Location = new System.Drawing.Point(0, 0);
            this.gpbQuery.Name = "gpbQuery";
            this.gpbQuery.Size = new System.Drawing.Size(275, 648);
            this.gpbQuery.TabIndex = 19;
            this.gpbQuery.TabStop = false;
            this.gpbQuery.Text = "Columns";
            // 
            // lvwCampos
            // 
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhColumnName,
            this.clhColumnIsDate});
            this.lvwCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCampos.ForeColor = System.Drawing.Color.Maroon;
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.HideSelection = false;
            this.lvwCampos.KeyUpDownActivateOnClick = true;
            this.lvwCampos.Location = new System.Drawing.Point(3, 16);
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(269, 629);
            this.lvwCampos.Sorter = true;
            this.lvwCampos.TabIndex = 0;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            this.lvwCampos.Click += new System.EventHandler(this.lvwCampos_Click);
            // 
            // clhColumnName
            // 
            this.clhColumnName.Text = "Columns";
            this.clhColumnName.Width = 250;
            // 
            // clhColumnIsDate
            // 
            this.clhColumnIsDate.Text = "É Data";
            this.clhColumnIsDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhColumnIsDate.Width = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PropertiesC#.ico");
            this.imageList1.Images.SetKeyName(1, "grafico_plot.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWhereValues);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 648);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            // 
            // txtWhereValues
            // 
            this.txtWhereValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWhereValues.Location = new System.Drawing.Point(3, 16);
            this.txtWhereValues.MaxLength = 10000000;
            this.txtWhereValues.Multiline = true;
            this.txtWhereValues.Name = "txtWhereValues";
            this.txtWhereValues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWhereValues.Size = new System.Drawing.Size(152, 629);
            this.txtWhereValues.TabIndex = 0;
            this.txtWhereValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOrderByClear);
            this.groupBox2.Controls.Add(this.txtOrderBy);
            this.groupBox2.Controls.Add(this.btnOrderBy);
            this.groupBox2.Location = new System.Drawing.Point(447, 582);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 49);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order By";
            // 
            // btnOrderByClear
            // 
            this.btnOrderByClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderByClear.ForeColor = System.Drawing.Color.Blue;
            this.btnOrderByClear.Image = global::DBTools.Properties.Resources.EmptySmall;
            this.btnOrderByClear.Location = new System.Drawing.Point(491, 19);
            this.btnOrderByClear.Name = "btnOrderByClear";
            this.btnOrderByClear.Size = new System.Drawing.Size(42, 23);
            this.btnOrderByClear.TabIndex = 4;
            this.btnOrderByClear.UseVisualStyleBackColor = true;
            this.btnOrderByClear.Click += new System.EventHandler(this.btnOrderByClear_Click);
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderBy.BackColor = System.Drawing.Color.Ivory;
            this.txtOrderBy.ForeColor = System.Drawing.Color.Blue;
            this.txtOrderBy.Location = new System.Drawing.Point(77, 21);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.ReadOnly = true;
            this.txtOrderBy.Size = new System.Drawing.Size(408, 20);
            this.txtOrderBy.TabIndex = 3;
            // 
            // btnOrderBy
            // 
            this.btnOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderBy.ForeColor = System.Drawing.Color.Blue;
            this.btnOrderBy.Location = new System.Drawing.Point(6, 19);
            this.btnOrderBy.Name = "btnOrderBy";
            this.btnOrderBy.Size = new System.Drawing.Size(65, 23);
            this.btnOrderBy.TabIndex = 2;
            this.btnOrderBy.Text = ">";
            this.btnOrderBy.UseVisualStyleBackColor = true;
            this.btnOrderBy.Click += new System.EventHandler(this.btnOrderBy_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cboTipoValue);
            this.groupBox3.Controls.Add(this.txtValor);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnRemoverTodosWhere);
            this.groupBox3.Controls.Add(this.btnRemoverUmWhere);
            this.groupBox3.Controls.Add(this.btnInserirUmWhere);
            this.groupBox3.Controls.Add(this.lvwWhere);
            this.groupBox3.Location = new System.Drawing.Point(447, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(538, 225);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WHERE";
            // 
            // cboTipoValue
            // 
            this.cboTipoValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValue.ForeColor = System.Drawing.Color.Blue;
            this.cboTipoValue.FormattingEnabled = true;
            this.cboTipoValue.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "<>",
            ">=",
            "<=",
            "LIKE",
            "IN",
            "NOT IN",
            "IS NULL",
            "IS NOT NULL"});
            this.cboTipoValue.Location = new System.Drawing.Point(106, 11);
            this.cboTipoValue.Name = "cboTipoValue";
            this.cboTipoValue.Size = new System.Drawing.Size(97, 21);
            this.cboTipoValue.TabIndex = 10;
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.ForeColor = System.Drawing.Color.Blue;
            this.txtValor.Location = new System.Drawing.Point(209, 11);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(323, 20);
            this.txtValor.TabIndex = 8;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(60, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valor:";
            // 
            // btnRemoverTodosWhere
            // 
            this.btnRemoverTodosWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverTodosWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverTodosWhere.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverTodosWhere.Location = new System.Drawing.Point(6, 197);
            this.btnRemoverTodosWhere.Name = "btnRemoverTodosWhere";
            this.btnRemoverTodosWhere.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverTodosWhere.TabIndex = 5;
            this.btnRemoverTodosWhere.Text = "<<";
            this.btnRemoverTodosWhere.UseVisualStyleBackColor = true;
            this.btnRemoverTodosWhere.Click += new System.EventHandler(this.btnRemoverTodosWhere_Click);
            // 
            // btnRemoverUmWhere
            // 
            this.btnRemoverUmWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverUmWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverUmWhere.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverUmWhere.Location = new System.Drawing.Point(6, 168);
            this.btnRemoverUmWhere.Name = "btnRemoverUmWhere";
            this.btnRemoverUmWhere.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverUmWhere.TabIndex = 4;
            this.btnRemoverUmWhere.Text = "<";
            this.btnRemoverUmWhere.UseVisualStyleBackColor = true;
            this.btnRemoverUmWhere.Click += new System.EventHandler(this.btnRemoverUmWhere_Click);
            // 
            // btnInserirUmWhere
            // 
            this.btnInserirUmWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirUmWhere.ForeColor = System.Drawing.Color.Blue;
            this.btnInserirUmWhere.Location = new System.Drawing.Point(6, 37);
            this.btnInserirUmWhere.Name = "btnInserirUmWhere";
            this.btnInserirUmWhere.Size = new System.Drawing.Size(48, 23);
            this.btnInserirUmWhere.TabIndex = 2;
            this.btnInserirUmWhere.Text = ">";
            this.btnInserirUmWhere.UseVisualStyleBackColor = true;
            this.btnInserirUmWhere.Click += new System.EventHandler(this.btnInserirUmWhere_Click);
            // 
            // lvwWhere
            // 
            this.lvwWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWhere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwWhere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lvwWhere.FullRowSelect = true;
            this.lvwWhere.HideSelection = false;
            this.lvwWhere.KeyUpDownActivateOnClick = false;
            this.lvwWhere.Location = new System.Drawing.Point(60, 37);
            this.lvwWhere.MultiSelect = false;
            this.lvwWhere.Name = "lvwWhere";
            this.lvwWhere.Size = new System.Drawing.Size(472, 182);
            this.lvwWhere.Sorter = false;
            this.lvwWhere.TabIndex = 1;
            this.lvwWhere.UseCompatibleStateImageBehavior = false;
            this.lvwWhere.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            this.columnHeader1.Width = 320;
            // 
            // pgbConsulta
            // 
            this.pgbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbConsulta.Location = new System.Drawing.Point(447, 641);
            this.pgbConsulta.Name = "pgbConsulta";
            this.pgbConsulta.Size = new System.Drawing.Size(182, 15);
            this.pgbConsulta.TabIndex = 27;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpbQuery);
            this.splitContainer1.Size = new System.Drawing.Size(437, 648);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 28;
            // 
            // rdbExportarExcel
            // 
            this.rdbExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbExportarExcel.Checked = true;
            this.rdbExportarExcel.ForeColor = System.Drawing.Color.Maroon;
            this.rdbExportarExcel.Image = global::DBTools.Properties.Resources.excel16x16;
            this.rdbExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdbExportarExcel.Location = new System.Drawing.Point(635, 636);
            this.rdbExportarExcel.Name = "rdbExportarExcel";
            this.rdbExportarExcel.Size = new System.Drawing.Size(133, 24);
            this.rdbExportarExcel.TabIndex = 29;
            this.rdbExportarExcel.TabStop = true;
            this.rdbExportarExcel.Text = "Exportar para Excel";
            this.rdbExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbExportarExcel.UseVisualStyleBackColor = true;
            // 
            // rdbExportarHtml
            // 
            this.rdbExportarHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbExportarHtml.ForeColor = System.Drawing.Color.Blue;
            this.rdbExportarHtml.Image = global::DBTools.Properties.Resources.HtmlPage;
            this.rdbExportarHtml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdbExportarHtml.Location = new System.Drawing.Point(774, 636);
            this.rdbExportarHtml.Name = "rdbExportarHtml";
            this.rdbExportarHtml.Size = new System.Drawing.Size(127, 24);
            this.rdbExportarHtml.TabIndex = 30;
            this.rdbExportarHtml.Text = "Exportar para Html";
            this.rdbExportarHtml.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbExportarHtml.UseVisualStyleBackColor = true;
            // 
            // frmListGroupQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Controls.Add(this.rdbExportarHtml);
            this.Controls.Add(this.rdbExportarExcel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pgbConsulta);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.gpbWhere);
            this.Controls.Add(this.gpbSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListGroupQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Group Query";
            this.Load += new System.EventHandler(this.frmGraficoPlot_Load);
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.gpbWhere.ResumeLayout(false);
            this.gpbWhere.PerformLayout();
            this.gpbQuery.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gpbQuery;
        private System.Windows.Forms.Button btnExecutar;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwCampos;
        internal System.Windows.Forms.GroupBox gpbWhere;
        private System.Windows.Forms.TextBox txtColumnAs;
        private System.Windows.Forms.Label Where_lblValor;
        private System.Windows.Forms.Button btnRemoverTodosColumn;
        private System.Windows.Forms.Button btnRemoverUmColumn;
        private System.Windows.Forms.Button btnInserirUmColumn;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwColumns;
        private System.Windows.Forms.ColumnHeader clhWhereColumn;
        private System.Windows.Forms.ColumnHeader clhColumnName;
        internal System.Windows.Forms.GroupBox gpbSelect;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Button Select_btnInserirUm;
        private System.Windows.Forms.ColumnHeader clhColumnIsDate;
        private System.Windows.Forms.ColumnHeader clhAs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWhereDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWhereValues;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOrderBy;
        private System.Windows.Forms.Button btnOrderBy;
        private System.Windows.Forms.Button btnOrderByClear;
        internal System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboTipoValue;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoverTodosWhere;
        private System.Windows.Forms.Button btnRemoverUmWhere;
        private System.Windows.Forms.Button btnInserirUmWhere;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwWhere;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ProgressBar pgbConsulta;
        private System.Windows.Forms.Button btnSelectRowDown;
        private System.Windows.Forms.Button btnSelectRowUp;
        private System.Windows.Forms.ComboBox cboWhereType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdbExportarExcel;
        private System.Windows.Forms.RadioButton rdbExportarHtml;
    }
}