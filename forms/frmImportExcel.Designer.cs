namespace DBTools.forms
{
    partial class frmImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcel));
            this.lvwExcelColumns = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ldPanel1 = new LDControls.LDPanel();
            this.ldPanel2 = new LDControls.LDPanel();
            this.lvwSPParams = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhColunaExcel = new System.Windows.Forms.ColumnHeader();
            this.clhParam = new System.Windows.Forms.ColumnHeader();
            this.clhIndexExcel = new System.Windows.Forms.ColumnHeader();
            this.clhValorDefault = new System.Windows.Forms.ColumnHeader();
            this.imgListIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnRemoverTodos = new System.Windows.Forms.Button();
            this.btnRemoverUm = new System.Windows.Forms.Button();
            this.btnInserirTodos = new System.Windows.Forms.Button();
            this.btnInserirUm = new System.Windows.Forms.Button();
            this.btnGerarQuery = new System.Windows.Forms.Button();
            this.txtArquivoExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelecionarArquivo = new System.Windows.Forms.Button();
            this.txtValorDefault = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAplicarValorDefault = new System.Windows.Forms.Button();
            this.ldPanel1.SuspendLayout();
            this.ldPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwExcelColumns
            // 
            this.lvwExcelColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwExcelColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwExcelColumns.FullRowSelect = true;
            this.lvwExcelColumns.HideSelection = false;
            this.lvwExcelColumns.KeyUpDownActivateOnClick = false;
            this.lvwExcelColumns.Location = new System.Drawing.Point(2, 23);
            this.lvwExcelColumns.MultiSelect = false;
            this.lvwExcelColumns.Name = "lvwExcelColumns";
            this.lvwExcelColumns.Size = new System.Drawing.Size(223, 397);
            this.lvwExcelColumns.Sorter = false;
            this.lvwExcelColumns.TabIndex = 0;
            this.lvwExcelColumns.UseCompatibleStateImageBehavior = false;
            this.lvwExcelColumns.View = System.Windows.Forms.View.Details;
            this.lvwExcelColumns.DoubleClick += new System.EventHandler(this.btnInserirUm_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cod.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Coluna";
            this.columnHeader2.Width = 150;
            // 
            // ldPanel1
            // 
            this.ldPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ldPanel1.Controls.Add(this.lvwExcelColumns);
            this.ldPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldPanel1.Icon = null;
            this.ldPanel1.LineWidth = 2;
            this.ldPanel1.Location = new System.Drawing.Point(12, 41);
            this.ldPanel1.Name = "ldPanel1";
            this.ldPanel1.Padding = new System.Windows.Forms.Padding(2, 23, 2, 2);
            this.ldPanel1.PanelBackColor = System.Drawing.Color.WhiteSmoke;
            this.ldPanel1.PanelBackColor2 = System.Drawing.Color.WhiteSmoke;
            this.ldPanel1.PanelBackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ldPanel1.PanelLineColor = System.Drawing.Color.Navy;
            this.ldPanel1.PanelPadding = 0;
            this.ldPanel1.PanelTopColor = System.Drawing.Color.SteelBlue;
            this.ldPanel1.PanelTopColor2 = System.Drawing.Color.Navy;
            this.ldPanel1.Radius = 0;
            this.ldPanel1.ShowLineRound = true;
            this.ldPanel1.Size = new System.Drawing.Size(227, 422);
            this.ldPanel1.Skin = LDControls.SkinPanel.TopColor;
            this.ldPanel1.TabIndex = 1;
            this.ldPanel1.Title = "Excel Columns";
            this.ldPanel1.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.ldPanel1.TitleColor = System.Drawing.Color.White;
            this.ldPanel1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ldPanel2
            // 
            this.ldPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ldPanel2.Controls.Add(this.lvwSPParams);
            this.ldPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldPanel2.Icon = null;
            this.ldPanel2.LineWidth = 2;
            this.ldPanel2.Location = new System.Drawing.Point(299, 41);
            this.ldPanel2.Name = "ldPanel2";
            this.ldPanel2.Padding = new System.Windows.Forms.Padding(2, 23, 2, 2);
            this.ldPanel2.PanelBackColor = System.Drawing.Color.WhiteSmoke;
            this.ldPanel2.PanelBackColor2 = System.Drawing.Color.WhiteSmoke;
            this.ldPanel2.PanelBackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ldPanel2.PanelLineColor = System.Drawing.Color.Navy;
            this.ldPanel2.PanelPadding = 0;
            this.ldPanel2.PanelTopColor = System.Drawing.Color.SteelBlue;
            this.ldPanel2.PanelTopColor2 = System.Drawing.Color.Navy;
            this.ldPanel2.Radius = 0;
            this.ldPanel2.ShowLineRound = true;
            this.ldPanel2.Size = new System.Drawing.Size(461, 422);
            this.ldPanel2.Skin = LDControls.SkinPanel.TopColor;
            this.ldPanel2.TabIndex = 2;
            this.ldPanel2.Title = "Sotored Procedures Params";
            this.ldPanel2.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.ldPanel2.TitleColor = System.Drawing.Color.White;
            this.ldPanel2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lvwSPParams
            // 
            this.lvwSPParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhColunaExcel,
            this.clhParam,
            this.clhIndexExcel,
            this.clhValorDefault});
            this.lvwSPParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSPParams.FullRowSelect = true;
            this.lvwSPParams.HideSelection = false;
            this.lvwSPParams.KeyUpDownActivateOnClick = false;
            this.lvwSPParams.Location = new System.Drawing.Point(2, 23);
            this.lvwSPParams.MultiSelect = false;
            this.lvwSPParams.Name = "lvwSPParams";
            this.lvwSPParams.Size = new System.Drawing.Size(457, 397);
            this.lvwSPParams.SmallImageList = this.imgListIcons;
            this.lvwSPParams.Sorter = false;
            this.lvwSPParams.TabIndex = 0;
            this.lvwSPParams.UseCompatibleStateImageBehavior = false;
            this.lvwSPParams.View = System.Windows.Forms.View.Details;
            // 
            // clhColunaExcel
            // 
            this.clhColunaExcel.Text = "Coluna Excel";
            this.clhColunaExcel.Width = 240;
            // 
            // clhParam
            // 
            this.clhParam.Text = "Param";
            this.clhParam.Width = 200;
            // 
            // clhIndexExcel
            // 
            this.clhIndexExcel.Text = "Index Excel";
            this.clhIndexExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhIndexExcel.Width = 0;
            // 
            // clhValorDefault
            // 
            this.clhValorDefault.Text = "Valor Default";
            this.clhValorDefault.Width = 0;
            // 
            // imgListIcons
            // 
            this.imgListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIcons.ImageStream")));
            this.imgListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIcons.Images.SetKeyName(0, "database_run.ico");
            this.imgListIcons.Images.SetKeyName(1, "database2005Express.ico");
            this.imgListIcons.Images.SetKeyName(2, "FolderTables2005.ico");
            this.imgListIcons.Images.SetKeyName(3, "tables1.ico");
            this.imgListIcons.Images.SetKeyName(4, "tableRow2005.ico");
            this.imgListIcons.Images.SetKeyName(5, "view_2005.ico");
            this.imgListIcons.Images.SetKeyName(6, "sp_2005.ico");
            this.imgListIcons.Images.SetKeyName(7, "sp_row_2005.ico");
            this.imgListIcons.Images.SetKeyName(8, "PK.ico");
            this.imgListIcons.Images.SetKeyName(9, "FK.ico");
            this.imgListIcons.Images.SetKeyName(10, "tableFK.ico");
            this.imgListIcons.Images.SetKeyName(11, "sp_output.ico");
            this.imgListIcons.Images.SetKeyName(12, "viewRow2005.ico");
            this.imgListIcons.Images.SetKeyName(13, "FolderViews2005.ico");
            this.imgListIcons.Images.SetKeyName(14, "FolderSPs2005.ico");
            // 
            // btnRemoverTodos
            // 
            this.btnRemoverTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverTodos.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverTodos.Location = new System.Drawing.Point(247, 221);
            this.btnRemoverTodos.Name = "btnRemoverTodos";
            this.btnRemoverTodos.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverTodos.TabIndex = 9;
            this.btnRemoverTodos.Text = "<<";
            this.btnRemoverTodos.UseVisualStyleBackColor = true;
            this.btnRemoverTodos.Click += new System.EventHandler(this.btnRemoverTodos_Click);
            // 
            // btnRemoverUm
            // 
            this.btnRemoverUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverUm.ForeColor = System.Drawing.Color.Maroon;
            this.btnRemoverUm.Location = new System.Drawing.Point(247, 192);
            this.btnRemoverUm.Name = "btnRemoverUm";
            this.btnRemoverUm.Size = new System.Drawing.Size(48, 23);
            this.btnRemoverUm.TabIndex = 8;
            this.btnRemoverUm.Text = "<";
            this.btnRemoverUm.UseVisualStyleBackColor = true;
            this.btnRemoverUm.Click += new System.EventHandler(this.btnRemoverUm_Click);
            // 
            // btnInserirTodos
            // 
            this.btnInserirTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirTodos.ForeColor = System.Drawing.Color.Blue;
            this.btnInserirTodos.Location = new System.Drawing.Point(247, 115);
            this.btnInserirTodos.Name = "btnInserirTodos";
            this.btnInserirTodos.Size = new System.Drawing.Size(48, 23);
            this.btnInserirTodos.TabIndex = 7;
            this.btnInserirTodos.Text = ">>";
            this.btnInserirTodos.UseVisualStyleBackColor = true;
            this.btnInserirTodos.Click += new System.EventHandler(this.btnInserirTodos_Click);
            // 
            // btnInserirUm
            // 
            this.btnInserirUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirUm.ForeColor = System.Drawing.Color.Blue;
            this.btnInserirUm.Location = new System.Drawing.Point(247, 86);
            this.btnInserirUm.Name = "btnInserirUm";
            this.btnInserirUm.Size = new System.Drawing.Size(48, 23);
            this.btnInserirUm.TabIndex = 6;
            this.btnInserirUm.Text = ">";
            this.btnInserirUm.UseVisualStyleBackColor = true;
            this.btnInserirUm.Click += new System.EventHandler(this.btnInserirUm_Click);
            // 
            // btnGerarQuery
            // 
            this.btnGerarQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarQuery.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGerarQuery.Location = new System.Drawing.Point(653, 469);
            this.btnGerarQuery.Name = "btnGerarQuery";
            this.btnGerarQuery.Size = new System.Drawing.Size(107, 23);
            this.btnGerarQuery.TabIndex = 10;
            this.btnGerarQuery.Text = "Gerar Query";
            this.btnGerarQuery.UseVisualStyleBackColor = true;
            this.btnGerarQuery.Click += new System.EventHandler(this.btnGerarQuery_Click);
            // 
            // txtArquivoExcel
            // 
            this.txtArquivoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArquivoExcel.BackColor = System.Drawing.Color.Ivory;
            this.txtArquivoExcel.ForeColor = System.Drawing.Color.Blue;
            this.txtArquivoExcel.Location = new System.Drawing.Point(115, 10);
            this.txtArquivoExcel.Name = "txtArquivoExcel";
            this.txtArquivoExcel.ReadOnly = true;
            this.txtArquivoExcel.Size = new System.Drawing.Size(605, 20);
            this.txtArquivoExcel.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Arquivo Excel(xls):";
            // 
            // btnSelecionarArquivo
            // 
            this.btnSelecionarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionarArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarArquivo.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSelecionarArquivo.Image = global::DBTools.Properties.Resources.open_file;
            this.btnSelecionarArquivo.Location = new System.Drawing.Point(726, 10);
            this.btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            this.btnSelecionarArquivo.Size = new System.Drawing.Size(34, 23);
            this.btnSelecionarArquivo.TabIndex = 13;
            this.btnSelecionarArquivo.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivo.Click += new System.EventHandler(this.btnSelecionarArquivo_Click);
            // 
            // txtValorDefault
            // 
            this.txtValorDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValorDefault.Location = new System.Drawing.Point(405, 471);
            this.txtValorDefault.Name = "txtValorDefault";
            this.txtValorDefault.Size = new System.Drawing.Size(171, 20);
            this.txtValorDefault.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(298, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Definir valor default:";
            // 
            // btnAplicarValorDefault
            // 
            this.btnAplicarValorDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAplicarValorDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarValorDefault.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAplicarValorDefault.Image = global::DBTools.Properties.Resources.tables_row_edit;
            this.btnAplicarValorDefault.Location = new System.Drawing.Point(582, 469);
            this.btnAplicarValorDefault.Name = "btnAplicarValorDefault";
            this.btnAplicarValorDefault.Size = new System.Drawing.Size(36, 23);
            this.btnAplicarValorDefault.TabIndex = 16;
            this.btnAplicarValorDefault.UseVisualStyleBackColor = true;
            this.btnAplicarValorDefault.Click += new System.EventHandler(this.btnAplicarValorDefault_Click);
            // 
            // frmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 503);
            this.Controls.Add(this.btnAplicarValorDefault);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorDefault);
            this.Controls.Add(this.btnSelecionarArquivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArquivoExcel);
            this.Controls.Add(this.btnGerarQuery);
            this.Controls.Add(this.btnRemoverTodos);
            this.Controls.Add(this.btnRemoverUm);
            this.Controls.Add(this.btnInserirTodos);
            this.Controls.Add(this.btnInserirUm);
            this.Controls.Add(this.ldPanel2);
            this.Controls.Add(this.ldPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Excel";
            this.ldPanel1.ResumeLayout(false);
            this.ldPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwExcelColumns;
        private LDControls.LDPanel ldPanel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private LDControls.LDPanel ldPanel2;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwSPParams;
        private System.Windows.Forms.ColumnHeader clhColunaExcel;
        private System.Windows.Forms.ColumnHeader clhParam;
        private System.Windows.Forms.Button btnRemoverTodos;
        private System.Windows.Forms.Button btnRemoverUm;
        private System.Windows.Forms.Button btnInserirTodos;
        private System.Windows.Forms.Button btnInserirUm;
        private System.Windows.Forms.Button btnGerarQuery;
        private System.Windows.Forms.TextBox txtArquivoExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelecionarArquivo;
        private System.Windows.Forms.ColumnHeader clhIndexExcel;
        private System.Windows.Forms.ImageList imgListIcons;
        private System.Windows.Forms.ColumnHeader clhValorDefault;
        private System.Windows.Forms.TextBox txtValorDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAplicarValorDefault;
    }
}