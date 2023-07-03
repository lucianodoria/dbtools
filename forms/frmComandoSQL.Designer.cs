namespace DBTools
{
    partial class frmComandoSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComandoSQL));
            this.lvwCampos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lvwWhere = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhWhereColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gpbWhere = new System.Windows.Forms.GroupBox();
            this.btnWhereRowDown = new System.Windows.Forms.Button();
            this.dtpValor = new System.Windows.Forms.DateTimePicker();
            this.btnWhereRowUp = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.Where_lblValor = new System.Windows.Forms.Label();
            this.Where_btnRemoverTodos = new System.Windows.Forms.Button();
            this.Where_btnRemoverUm = new System.Windows.Forms.Button();
            this.Where_btnInserirTodos = new System.Windows.Forms.Button();
            this.Where_btnInserirUm = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            this.btnSelectRowDown = new System.Windows.Forms.Button();
            this.btnSelectRowUp = new System.Windows.Forms.Button();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.Select_btnRemoverTodos = new System.Windows.Forms.Button();
            this.Select_btnRemoverUm = new System.Windows.Forms.Button();
            this.Select_btnInserirTodos = new System.Windows.Forms.Button();
            this.Select_btnInserirUm = new System.Windows.Forms.Button();
            this.lvwSelect = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhSelectColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.gpbOrderBy = new System.Windows.Forms.GroupBox();
            this.btnOrderByRowDown = new System.Windows.Forms.Button();
            this.OrderBy_btnRemoverTodos = new System.Windows.Forms.Button();
            this.btnOrderByRowUp = new System.Windows.Forms.Button();
            this.OrderBy_btnRemoverUm = new System.Windows.Forms.Button();
            this.OrderBy_btnInserirTodos = new System.Windows.Forms.Button();
            this.OrderBy_btnInserirUm = new System.Windows.Forms.Button();
            this.lvwOrderBy = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.cboOrderByType = new System.Windows.Forms.ComboBox();
            this.gpbWhere.SuspendLayout();
            this.gpbSelect.SuspendLayout();
            this.gpbOrderBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCampos
            // 
            this.lvwCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhColumn,
            this.columnHeader1,
            this.columnHeader7});
            this.lvwCampos.ForeColor = System.Drawing.Color.Maroon;
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.HideSelection = false;
            this.lvwCampos.KeyUpDownActivateOnClick = false;
            this.lvwCampos.Location = new System.Drawing.Point(12, 12);
            this.lvwCampos.MultiSelect = false;
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(221, 483);
            this.lvwCampos.Sorter = true;
            this.lvwCampos.TabIndex = 0;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            this.lvwCampos.Click += new System.EventHandler(this.lvwCampos_Click);
            this.lvwCampos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwCampos_KeyUp);
            // 
            // clhColumn
            // 
            this.clhColumn.Text = "Column";
            this.clhColumn.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Campos";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Código Tipo";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 0;
            // 
            // lvwWhere
            // 
            this.lvwWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWhere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhWhereColumn,
            this.columnHeader2});
            this.lvwWhere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lvwWhere.FullRowSelect = true;
            this.lvwWhere.HideSelection = false;
            this.lvwWhere.KeyUpDownActivateOnClick = false;
            this.lvwWhere.Location = new System.Drawing.Point(60, 37);
            this.lvwWhere.MultiSelect = false;
            this.lvwWhere.Name = "lvwWhere";
            this.lvwWhere.Size = new System.Drawing.Size(219, 102);
            this.lvwWhere.Sorter = false;
            this.lvwWhere.TabIndex = 1;
            this.lvwWhere.UseCompatibleStateImageBehavior = false;
            this.lvwWhere.View = System.Windows.Forms.View.Details;
            // 
            // clhWhereColumn
            // 
            this.clhWhereColumn.DisplayIndex = 1;
            this.clhWhereColumn.Text = "Column";
            this.clhWhereColumn.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "Campos";
            this.columnHeader2.Width = 190;
            // 
            // gpbWhere
            // 
            this.gpbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWhere.Controls.Add(this.btnWhereRowDown);
            this.gpbWhere.Controls.Add(this.dtpValor);
            this.gpbWhere.Controls.Add(this.btnWhereRowUp);
            this.gpbWhere.Controls.Add(this.txtValor);
            this.gpbWhere.Controls.Add(this.Where_lblValor);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverTodos);
            this.gpbWhere.Controls.Add(this.Where_btnRemoverUm);
            this.gpbWhere.Controls.Add(this.Where_btnInserirTodos);
            this.gpbWhere.Controls.Add(this.Where_btnInserirUm);
            this.gpbWhere.Controls.Add(this.lvwWhere);
            this.gpbWhere.Location = new System.Drawing.Point(239, 205);
            this.gpbWhere.Name = "gpbWhere";
            this.gpbWhere.Size = new System.Drawing.Size(314, 145);
            this.gpbWhere.TabIndex = 2;
            this.gpbWhere.TabStop = false;
            this.gpbWhere.Text = "WHERE";
            // 
            // btnWhereRowDown
            // 
            this.btnWhereRowDown.Image = global::DBTools.Properties.Resources.ARW07DN;
            this.btnWhereRowDown.Location = new System.Drawing.Point(285, 63);
            this.btnWhereRowDown.Name = "btnWhereRowDown";
            this.btnWhereRowDown.Size = new System.Drawing.Size(23, 23);
            this.btnWhereRowDown.TabIndex = 11;
            this.btnWhereRowDown.UseVisualStyleBackColor = true;
            this.btnWhereRowDown.Click += new System.EventHandler(this.btnWhereRowDown_Click);
            // 
            // dtpValor
            // 
            this.dtpValor.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpValor.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpValor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValor.Location = new System.Drawing.Point(106, 11);
            this.dtpValor.Name = "dtpValor";
            this.dtpValor.Size = new System.Drawing.Size(173, 21);
            this.dtpValor.TabIndex = 9;
            this.dtpValor.Visible = false;
            // 
            // btnWhereRowUp
            // 
            this.btnWhereRowUp.Image = global::DBTools.Properties.Resources.ARW07UP;
            this.btnWhereRowUp.Location = new System.Drawing.Point(285, 37);
            this.btnWhereRowUp.Name = "btnWhereRowUp";
            this.btnWhereRowUp.Size = new System.Drawing.Size(23, 23);
            this.btnWhereRowUp.TabIndex = 10;
            this.btnWhereRowUp.UseVisualStyleBackColor = true;
            this.btnWhereRowUp.Click += new System.EventHandler(this.btnWhereRowUp_Click);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(106, 11);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(173, 21);
            this.txtValor.TabIndex = 8;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Where_lblValor
            // 
            this.Where_lblValor.AutoSize = true;
            this.Where_lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_lblValor.ForeColor = System.Drawing.Color.Navy;
            this.Where_lblValor.Location = new System.Drawing.Point(60, 14);
            this.Where_lblValor.Name = "Where_lblValor";
            this.Where_lblValor.Size = new System.Drawing.Size(40, 13);
            this.Where_lblValor.TabIndex = 7;
            this.Where_lblValor.Text = "Valor:";
            // 
            // Where_btnRemoverTodos
            // 
            this.Where_btnRemoverTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Where_btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnRemoverTodos.ForeColor = System.Drawing.Color.Maroon;
            this.Where_btnRemoverTodos.Location = new System.Drawing.Point(6, 117);
            this.Where_btnRemoverTodos.Name = "Where_btnRemoverTodos";
            this.Where_btnRemoverTodos.Size = new System.Drawing.Size(48, 23);
            this.Where_btnRemoverTodos.TabIndex = 5;
            this.Where_btnRemoverTodos.Text = "<<";
            this.Where_btnRemoverTodos.UseVisualStyleBackColor = true;
            this.Where_btnRemoverTodos.Click += new System.EventHandler(this.Where_btnRemoverTodos_Click);
            // 
            // Where_btnRemoverUm
            // 
            this.Where_btnRemoverUm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Where_btnRemoverUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnRemoverUm.ForeColor = System.Drawing.Color.Maroon;
            this.Where_btnRemoverUm.Location = new System.Drawing.Point(6, 88);
            this.Where_btnRemoverUm.Name = "Where_btnRemoverUm";
            this.Where_btnRemoverUm.Size = new System.Drawing.Size(48, 23);
            this.Where_btnRemoverUm.TabIndex = 4;
            this.Where_btnRemoverUm.Text = "<";
            this.Where_btnRemoverUm.UseVisualStyleBackColor = true;
            this.Where_btnRemoverUm.Click += new System.EventHandler(this.Where_btnRemoverUm_Click);
            // 
            // Where_btnInserirTodos
            // 
            this.Where_btnInserirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnInserirTodos.ForeColor = System.Drawing.Color.Blue;
            this.Where_btnInserirTodos.Location = new System.Drawing.Point(6, 48);
            this.Where_btnInserirTodos.Name = "Where_btnInserirTodos";
            this.Where_btnInserirTodos.Size = new System.Drawing.Size(48, 23);
            this.Where_btnInserirTodos.TabIndex = 3;
            this.Where_btnInserirTodos.Text = ">>";
            this.Where_btnInserirTodos.UseVisualStyleBackColor = true;
            this.Where_btnInserirTodos.Visible = false;
            this.Where_btnInserirTodos.Click += new System.EventHandler(this.Where_btnInserirTodos_Click);
            // 
            // Where_btnInserirUm
            // 
            this.Where_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.Where_btnInserirUm.Location = new System.Drawing.Point(6, 19);
            this.Where_btnInserirUm.Name = "Where_btnInserirUm";
            this.Where_btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.Where_btnInserirUm.TabIndex = 2;
            this.Where_btnInserirUm.Text = ">";
            this.Where_btnInserirUm.UseVisualStyleBackColor = true;
            this.Where_btnInserirUm.Click += new System.EventHandler(this.Where_btnInserirUm_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnOK.Image = global::DBTools.Properties.Resources.AttachProccess1;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(460, 500);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Gerar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancelar.Location = new System.Drawing.Point(361, 500);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 24);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbSelect.Controls.Add(this.btnSelectRowDown);
            this.gpbSelect.Controls.Add(this.btnSelectRowUp);
            this.gpbSelect.Controls.Add(this.txtTop);
            this.gpbSelect.Controls.Add(this.lblTop);
            this.gpbSelect.Controls.Add(this.Select_btnRemoverTodos);
            this.gpbSelect.Controls.Add(this.Select_btnRemoverUm);
            this.gpbSelect.Controls.Add(this.Select_btnInserirTodos);
            this.gpbSelect.Controls.Add(this.Select_btnInserirUm);
            this.gpbSelect.Controls.Add(this.lvwSelect);
            this.gpbSelect.Location = new System.Drawing.Point(239, 10);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(314, 189);
            this.gpbSelect.TabIndex = 5;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "SELECT";
            // 
            // btnSelectRowDown
            // 
            this.btnSelectRowDown.Image = global::DBTools.Properties.Resources.ARW07DN;
            this.btnSelectRowDown.Location = new System.Drawing.Point(285, 39);
            this.btnSelectRowDown.Name = "btnSelectRowDown";
            this.btnSelectRowDown.Size = new System.Drawing.Size(23, 23);
            this.btnSelectRowDown.TabIndex = 9;
            this.btnSelectRowDown.UseVisualStyleBackColor = true;
            this.btnSelectRowDown.Click += new System.EventHandler(this.btnSelectRowDown_Click);
            // 
            // btnSelectRowUp
            // 
            this.btnSelectRowUp.Image = global::DBTools.Properties.Resources.ARW07UP;
            this.btnSelectRowUp.Location = new System.Drawing.Point(285, 13);
            this.btnSelectRowUp.Name = "btnSelectRowUp";
            this.btnSelectRowUp.Size = new System.Drawing.Size(23, 23);
            this.btnSelectRowUp.TabIndex = 8;
            this.btnSelectRowUp.UseVisualStyleBackColor = true;
            this.btnSelectRowUp.Click += new System.EventHandler(this.btnSelectRowUp_Click);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(6, 103);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(48, 21);
            this.txtTop.TabIndex = 7;
            this.txtTop.Text = "0";
            this.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.Color.Navy;
            this.lblTop.Location = new System.Drawing.Point(15, 87);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(32, 13);
            this.lblTop.TabIndex = 6;
            this.lblTop.Text = "TOP";
            // 
            // Select_btnRemoverTodos
            // 
            this.Select_btnRemoverTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Select_btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnRemoverTodos.ForeColor = System.Drawing.Color.Maroon;
            this.Select_btnRemoverTodos.Location = new System.Drawing.Point(6, 161);
            this.Select_btnRemoverTodos.Name = "Select_btnRemoverTodos";
            this.Select_btnRemoverTodos.Size = new System.Drawing.Size(48, 23);
            this.Select_btnRemoverTodos.TabIndex = 5;
            this.Select_btnRemoverTodos.Text = "<<";
            this.Select_btnRemoverTodos.UseVisualStyleBackColor = true;
            this.Select_btnRemoverTodos.Click += new System.EventHandler(this.Select_btnRemoverTodos_Click);
            // 
            // Select_btnRemoverUm
            // 
            this.Select_btnRemoverUm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Select_btnRemoverUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnRemoverUm.ForeColor = System.Drawing.Color.Maroon;
            this.Select_btnRemoverUm.Location = new System.Drawing.Point(6, 132);
            this.Select_btnRemoverUm.Name = "Select_btnRemoverUm";
            this.Select_btnRemoverUm.Size = new System.Drawing.Size(48, 23);
            this.Select_btnRemoverUm.TabIndex = 4;
            this.Select_btnRemoverUm.Text = "<";
            this.Select_btnRemoverUm.UseVisualStyleBackColor = true;
            this.Select_btnRemoverUm.Click += new System.EventHandler(this.Select_btnRemoverUm_Click);
            // 
            // Select_btnInserirTodos
            // 
            this.Select_btnInserirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnInserirTodos.ForeColor = System.Drawing.Color.Blue;
            this.Select_btnInserirTodos.Location = new System.Drawing.Point(6, 48);
            this.Select_btnInserirTodos.Name = "Select_btnInserirTodos";
            this.Select_btnInserirTodos.Size = new System.Drawing.Size(48, 23);
            this.Select_btnInserirTodos.TabIndex = 3;
            this.Select_btnInserirTodos.Text = ">>";
            this.Select_btnInserirTodos.UseVisualStyleBackColor = true;
            this.Select_btnInserirTodos.Click += new System.EventHandler(this.Select_btnInserirTodos_Click);
            // 
            // Select_btnInserirUm
            // 
            this.Select_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.Select_btnInserirUm.Location = new System.Drawing.Point(6, 19);
            this.Select_btnInserirUm.Name = "Select_btnInserirUm";
            this.Select_btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.Select_btnInserirUm.TabIndex = 2;
            this.Select_btnInserirUm.Text = ">";
            this.Select_btnInserirUm.UseVisualStyleBackColor = true;
            this.Select_btnInserirUm.Click += new System.EventHandler(this.Select_btnInserirUm_Click);
            // 
            // lvwSelect
            // 
            this.lvwSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhSelectColumn,
            this.columnHeader3});
            this.lvwSelect.ForeColor = System.Drawing.Color.Blue;
            this.lvwSelect.FullRowSelect = true;
            this.lvwSelect.HideSelection = false;
            this.lvwSelect.KeyUpDownActivateOnClick = false;
            this.lvwSelect.Location = new System.Drawing.Point(60, 13);
            this.lvwSelect.MultiSelect = false;
            this.lvwSelect.Name = "lvwSelect";
            this.lvwSelect.Size = new System.Drawing.Size(219, 170);
            this.lvwSelect.Sorter = false;
            this.lvwSelect.TabIndex = 1;
            this.lvwSelect.UseCompatibleStateImageBehavior = false;
            this.lvwSelect.View = System.Windows.Forms.View.Details;
            // 
            // clhSelectColumn
            // 
            this.clhSelectColumn.DisplayIndex = 1;
            this.clhSelectColumn.Text = "Column";
            this.clhSelectColumn.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 0;
            this.columnHeader3.Text = "Campos";
            this.columnHeader3.Width = 190;
            // 
            // gpbOrderBy
            // 
            this.gpbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbOrderBy.Controls.Add(this.cboOrderByType);
            this.gpbOrderBy.Controls.Add(this.btnOrderByRowDown);
            this.gpbOrderBy.Controls.Add(this.OrderBy_btnRemoverTodos);
            this.gpbOrderBy.Controls.Add(this.btnOrderByRowUp);
            this.gpbOrderBy.Controls.Add(this.OrderBy_btnRemoverUm);
            this.gpbOrderBy.Controls.Add(this.OrderBy_btnInserirTodos);
            this.gpbOrderBy.Controls.Add(this.OrderBy_btnInserirUm);
            this.gpbOrderBy.Controls.Add(this.lvwOrderBy);
            this.gpbOrderBy.Location = new System.Drawing.Point(239, 356);
            this.gpbOrderBy.Name = "gpbOrderBy";
            this.gpbOrderBy.Size = new System.Drawing.Size(314, 138);
            this.gpbOrderBy.TabIndex = 6;
            this.gpbOrderBy.TabStop = false;
            this.gpbOrderBy.Text = "ORDER BY";
            // 
            // btnOrderByRowDown
            // 
            this.btnOrderByRowDown.Image = global::DBTools.Properties.Resources.ARW07DN;
            this.btnOrderByRowDown.Location = new System.Drawing.Point(285, 37);
            this.btnOrderByRowDown.Name = "btnOrderByRowDown";
            this.btnOrderByRowDown.Size = new System.Drawing.Size(23, 23);
            this.btnOrderByRowDown.TabIndex = 13;
            this.btnOrderByRowDown.UseVisualStyleBackColor = true;
            this.btnOrderByRowDown.Click += new System.EventHandler(this.btnOrderByRowDown_Click);
            // 
            // OrderBy_btnRemoverTodos
            // 
            this.OrderBy_btnRemoverTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OrderBy_btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBy_btnRemoverTodos.ForeColor = System.Drawing.Color.Maroon;
            this.OrderBy_btnRemoverTodos.Location = new System.Drawing.Point(6, 83);
            this.OrderBy_btnRemoverTodos.Name = "OrderBy_btnRemoverTodos";
            this.OrderBy_btnRemoverTodos.Size = new System.Drawing.Size(48, 23);
            this.OrderBy_btnRemoverTodos.TabIndex = 5;
            this.OrderBy_btnRemoverTodos.Text = "<<";
            this.OrderBy_btnRemoverTodos.UseVisualStyleBackColor = true;
            this.OrderBy_btnRemoverTodos.Click += new System.EventHandler(this.OrderBy_btnRemoverTodos_Click);
            // 
            // btnOrderByRowUp
            // 
            this.btnOrderByRowUp.Image = global::DBTools.Properties.Resources.ARW07UP;
            this.btnOrderByRowUp.Location = new System.Drawing.Point(285, 11);
            this.btnOrderByRowUp.Name = "btnOrderByRowUp";
            this.btnOrderByRowUp.Size = new System.Drawing.Size(23, 23);
            this.btnOrderByRowUp.TabIndex = 12;
            this.btnOrderByRowUp.UseVisualStyleBackColor = true;
            this.btnOrderByRowUp.Click += new System.EventHandler(this.btnOrderByRowUp_Click);
            // 
            // OrderBy_btnRemoverUm
            // 
            this.OrderBy_btnRemoverUm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OrderBy_btnRemoverUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBy_btnRemoverUm.ForeColor = System.Drawing.Color.Maroon;
            this.OrderBy_btnRemoverUm.Location = new System.Drawing.Point(6, 60);
            this.OrderBy_btnRemoverUm.Name = "OrderBy_btnRemoverUm";
            this.OrderBy_btnRemoverUm.Size = new System.Drawing.Size(48, 23);
            this.OrderBy_btnRemoverUm.TabIndex = 4;
            this.OrderBy_btnRemoverUm.Text = "<";
            this.OrderBy_btnRemoverUm.UseVisualStyleBackColor = true;
            this.OrderBy_btnRemoverUm.Click += new System.EventHandler(this.OrderBy_btnRemoverUm_Click);
            // 
            // OrderBy_btnInserirTodos
            // 
            this.OrderBy_btnInserirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBy_btnInserirTodos.ForeColor = System.Drawing.Color.Blue;
            this.OrderBy_btnInserirTodos.Location = new System.Drawing.Point(6, 37);
            this.OrderBy_btnInserirTodos.Name = "OrderBy_btnInserirTodos";
            this.OrderBy_btnInserirTodos.Size = new System.Drawing.Size(48, 23);
            this.OrderBy_btnInserirTodos.TabIndex = 3;
            this.OrderBy_btnInserirTodos.Text = ">>";
            this.OrderBy_btnInserirTodos.UseVisualStyleBackColor = true;
            this.OrderBy_btnInserirTodos.Click += new System.EventHandler(this.OrderBy_btnInserirTodos_Click);
            // 
            // OrderBy_btnInserirUm
            // 
            this.OrderBy_btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBy_btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.OrderBy_btnInserirUm.Location = new System.Drawing.Point(6, 14);
            this.OrderBy_btnInserirUm.Name = "OrderBy_btnInserirUm";
            this.OrderBy_btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.OrderBy_btnInserirUm.TabIndex = 2;
            this.OrderBy_btnInserirUm.Text = ">";
            this.OrderBy_btnInserirUm.UseVisualStyleBackColor = true;
            this.OrderBy_btnInserirUm.Click += new System.EventHandler(this.OrderBy_btnInserirUm_Click);
            // 
            // lvwOrderBy
            // 
            this.lvwOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderBy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lvwOrderBy.ForeColor = System.Drawing.Color.SteelBlue;
            this.lvwOrderBy.FullRowSelect = true;
            this.lvwOrderBy.HideSelection = false;
            this.lvwOrderBy.KeyUpDownActivateOnClick = false;
            this.lvwOrderBy.Location = new System.Drawing.Point(60, 11);
            this.lvwOrderBy.MultiSelect = false;
            this.lvwOrderBy.Name = "lvwOrderBy";
            this.lvwOrderBy.Size = new System.Drawing.Size(219, 121);
            this.lvwOrderBy.Sorter = false;
            this.lvwOrderBy.TabIndex = 1;
            this.lvwOrderBy.UseCompatibleStateImageBehavior = false;
            this.lvwOrderBy.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 1;
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 0;
            this.columnHeader9.Text = "Campos";
            this.columnHeader9.Width = 190;
            // 
            // cboOrderByType
            // 
            this.cboOrderByType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboOrderByType.FormattingEnabled = true;
            this.cboOrderByType.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.cboOrderByType.Location = new System.Drawing.Point(6, 111);
            this.cboOrderByType.Name = "cboOrderByType";
            this.cboOrderByType.Size = new System.Drawing.Size(48, 21);
            this.cboOrderByType.TabIndex = 14;
            // 
            // frmComando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(559, 526);
            this.Controls.Add(this.gpbOrderBy);
            this.Controls.Add(this.gpbSelect);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbWhere);
            this.Controls.Add(this.lvwCampos);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComando";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comandos SQL";
            this.gpbWhere.ResumeLayout(false);
            this.gpbWhere.PerformLayout();
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.gpbOrderBy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button Where_btnRemoverTodos;
        private System.Windows.Forms.Button Where_btnRemoverUm;
        private System.Windows.Forms.Button Where_btnInserirTodos;
        private System.Windows.Forms.Button Where_btnInserirUm;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button Select_btnRemoverTodos;
        private System.Windows.Forms.Button Select_btnRemoverUm;
        private System.Windows.Forms.Button Select_btnInserirTodos;
        private System.Windows.Forms.Button Select_btnInserirUm;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader clhWhereColumn;
        private System.Windows.Forms.ColumnHeader clhSelectColumn;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwCampos;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwWhere;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwSelect;
        private System.Windows.Forms.ColumnHeader clhColumn;
        internal System.Windows.Forms.GroupBox gpbWhere;
        internal System.Windows.Forms.GroupBox gpbSelect;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label Where_lblValor;
        private System.Windows.Forms.DateTimePicker dtpValor;
        internal System.Windows.Forms.GroupBox gpbOrderBy;
        private System.Windows.Forms.Button OrderBy_btnRemoverTodos;
        private System.Windows.Forms.Button OrderBy_btnRemoverUm;
        private System.Windows.Forms.Button OrderBy_btnInserirTodos;
        private System.Windows.Forms.Button OrderBy_btnInserirUm;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwOrderBy;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnWhereRowDown;
        private System.Windows.Forms.Button btnWhereRowUp;
        private System.Windows.Forms.Button btnSelectRowDown;
        private System.Windows.Forms.Button btnSelectRowUp;
        private System.Windows.Forms.Button btnOrderByRowDown;
        private System.Windows.Forms.Button btnOrderByRowUp;
        private System.Windows.Forms.ComboBox cboOrderByType;
    }
}