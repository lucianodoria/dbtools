namespace DBTools.forms
{
    partial class frmTablesRowsCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTablesRowsCount));
            this.lvwTables = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhRows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhDataCriacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListIcones = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExportarParaExcel = new System.Windows.Forms.Button();
            this.lvwColunas = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhIdentity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhNulls = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTableFK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhIndexName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhFillfactor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbColunas = new System.Windows.Forms.GroupBox();
            this.btnExportarParaExcelColunas = new System.Windows.Forms.Button();
            this.lblTotalColunas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitTables = new System.Windows.Forms.SplitContainer();
            this.gpbExportar = new System.Windows.Forms.GroupBox();
            this.pgbListar = new System.Windows.Forms.ProgressBar();
            this.rdbExportarHTML = new System.Windows.Forms.RadioButton();
            this.btnExportarTabelaColunas = new System.Windows.Forms.Button();
            this.rdbExportarArquivoTexto = new System.Windows.Forms.RadioButton();
            this.lblListIndex = new System.Windows.Forms.Label();
            this.clhRowsOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbColunas.SuspendLayout();
            this.splitTables.Panel1.SuspendLayout();
            this.splitTables.Panel2.SuspendLayout();
            this.splitTables.SuspendLayout();
            this.gpbExportar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwTables
            // 
            this.lvwTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhTable,
            this.clhOwner,
            this.clhRows,
            this.clhDataCriacao,
            this.clhID,
            this.clhRowsOrder});
            this.lvwTables.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTables.ForeColor = System.Drawing.Color.Black;
            this.lvwTables.FullRowSelect = true;
            this.lvwTables.HideSelection = false;
            this.lvwTables.KeyUpDownActivateOnClick = true;
            this.lvwTables.Location = new System.Drawing.Point(6, 3);
            this.lvwTables.MultiSelect = false;
            this.lvwTables.Name = "lvwTables";
            this.lvwTables.Size = new System.Drawing.Size(800, 188);
            this.lvwTables.SmallImageList = this.imgListIcones;
            this.lvwTables.Sorter = false;
            this.lvwTables.TabIndex = 7;
            this.lvwTables.UseCompatibleStateImageBehavior = false;
            this.lvwTables.View = System.Windows.Forms.View.Details;
            this.lvwTables.ChangeItems += new LucianoDoria.Forms.ListViewPlus.ListViewPlus.ListViewChangeDelegate(this.lvwTables_ChangeItems);
            this.lvwTables.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwTables_ColumnClick);
            this.lvwTables.Click += new System.EventHandler(this.lvwTables_Click);
            // 
            // clhTable
            // 
            this.clhTable.Text = "Table";
            this.clhTable.Width = 300;
            // 
            // clhOwner
            // 
            this.clhOwner.Text = "Owner";
            this.clhOwner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhOwner.Width = 100;
            // 
            // clhRows
            // 
            this.clhRows.Text = "Rows";
            this.clhRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhRows.Width = 100;
            // 
            // clhDataCriacao
            // 
            this.clhDataCriacao.Text = "Data de criação";
            this.clhDataCriacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhDataCriacao.Width = 120;
            // 
            // clhID
            // 
            this.clhID.Text = "ID";
            this.clhID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhID.Width = 0;
            // 
            // imgListIcones
            // 
            this.imgListIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListIcones.ImageStream")));
            this.imgListIcones.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListIcones.Images.SetKeyName(0, "tables2_2005.ico");
            this.imgListIcones.Images.SetKeyName(1, "tables_row_2005.ico");
            this.imgListIcones.Images.SetKeyName(2, "Blank.ico");
            this.imgListIcones.Images.SetKeyName(3, "PK.ico");
            this.imgListIcones.Images.SetKeyName(4, "FK.ico");
            this.imgListIcones.Images.SetKeyName(5, "index.ico");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotal.Location = new System.Drawing.Point(47, 194);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(14, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "0";
            // 
            // btnExportarParaExcel
            // 
            this.btnExportarParaExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarParaExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarParaExcel.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnExportarParaExcel.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarParaExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarParaExcel.Location = new System.Drawing.Point(618, 211);
            this.btnExportarParaExcel.Name = "btnExportarParaExcel";
            this.btnExportarParaExcel.Size = new System.Drawing.Size(191, 25);
            this.btnExportarParaExcel.TabIndex = 13;
            this.btnExportarParaExcel.Text = "Exportar para Excel";
            this.btnExportarParaExcel.UseVisualStyleBackColor = true;
            this.btnExportarParaExcel.Click += new System.EventHandler(this.btnExportarParaExcel_Click);
            // 
            // lvwColunas
            // 
            this.lvwColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwColunas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhKey,
            this.clhIdentity,
            this.clhName,
            this.clhDataType,
            this.clhSize,
            this.clhNulls,
            this.clhTableFK,
            this.clhIndexName,
            this.clhFillfactor});
            this.lvwColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwColunas.ForeColor = System.Drawing.Color.Maroon;
            this.lvwColunas.FullRowSelect = true;
            this.lvwColunas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwColunas.HideSelection = false;
            this.lvwColunas.KeyUpDownActivateOnClick = false;
            this.lvwColunas.LargeImageList = this.imgListIcones;
            this.lvwColunas.Location = new System.Drawing.Point(6, 20);
            this.lvwColunas.MultiSelect = false;
            this.lvwColunas.Name = "lvwColunas";
            this.lvwColunas.ShowGroups = false;
            this.lvwColunas.Size = new System.Drawing.Size(800, 178);
            this.lvwColunas.SmallImageList = this.imgListIcones;
            this.lvwColunas.Sorter = false;
            this.lvwColunas.StateImageList = this.imgListIcones;
            this.lvwColunas.TabIndex = 14;
            this.lvwColunas.UseCompatibleStateImageBehavior = false;
            this.lvwColunas.View = System.Windows.Forms.View.Details;
            this.lvwColunas.ChangeItems += new LucianoDoria.Forms.ListViewPlus.ListViewPlus.ListViewChangeDelegate(this.lvwColunas_ChangeItems);
            // 
            // clhKey
            // 
            this.clhKey.Text = "Key";
            this.clhKey.Width = 35;
            // 
            // clhIdentity
            // 
            this.clhIdentity.Text = "Identity";
            this.clhIdentity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clhName
            // 
            this.clhName.Text = "Name";
            this.clhName.Width = 200;
            // 
            // clhDataType
            // 
            this.clhDataType.Text = "Data type";
            this.clhDataType.Width = 80;
            // 
            // clhSize
            // 
            this.clhSize.Text = "Size(Precision, Scale)";
            this.clhSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhSize.Width = 120;
            // 
            // clhNulls
            // 
            this.clhNulls.Text = "Nulls";
            this.clhNulls.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhNulls.Width = 50;
            // 
            // clhTableFK
            // 
            this.clhTableFK.Text = "Table FK";
            this.clhTableFK.Width = 100;
            // 
            // clhIndexName
            // 
            this.clhIndexName.Text = "Index Name";
            this.clhIndexName.Width = 150;
            // 
            // clhFillfactor
            // 
            this.clhFillfactor.Text = "Fill Factor %";
            this.clhFillfactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhFillfactor.Width = 80;
            // 
            // gpbColunas
            // 
            this.gpbColunas.Controls.Add(this.btnExportarParaExcelColunas);
            this.gpbColunas.Controls.Add(this.lblTotalColunas);
            this.gpbColunas.Controls.Add(this.label3);
            this.gpbColunas.Controls.Add(this.lvwColunas);
            this.gpbColunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbColunas.Location = new System.Drawing.Point(0, 0);
            this.gpbColunas.Name = "gpbColunas";
            this.gpbColunas.Size = new System.Drawing.Size(812, 235);
            this.gpbColunas.TabIndex = 15;
            this.gpbColunas.TabStop = false;
            this.gpbColunas.Text = "Colunas";
            // 
            // btnExportarParaExcelColunas
            // 
            this.btnExportarParaExcelColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarParaExcelColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarParaExcelColunas.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnExportarParaExcelColunas.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarParaExcelColunas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarParaExcelColunas.Location = new System.Drawing.Point(615, 204);
            this.btnExportarParaExcelColunas.Name = "btnExportarParaExcelColunas";
            this.btnExportarParaExcelColunas.Size = new System.Drawing.Size(191, 25);
            this.btnExportarParaExcelColunas.TabIndex = 17;
            this.btnExportarParaExcelColunas.Text = "Exportar para Excel";
            this.btnExportarParaExcelColunas.UseVisualStyleBackColor = true;
            this.btnExportarParaExcelColunas.Click += new System.EventHandler(this.btnExportarParaExcelColunas_Click);
            // 
            // lblTotalColunas
            // 
            this.lblTotalColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalColunas.AutoSize = true;
            this.lblTotalColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalColunas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalColunas.Location = new System.Drawing.Point(47, 201);
            this.lblTotalColunas.Name = "lblTotalColunas";
            this.lblTotalColunas.Size = new System.Drawing.Size(14, 13);
            this.lblTotalColunas.TabIndex = 16;
            this.lblTotalColunas.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(6, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total:";
            // 
            // splitTables
            // 
            this.splitTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTables.Location = new System.Drawing.Point(0, 0);
            this.splitTables.Name = "splitTables";
            this.splitTables.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTables.Panel1
            // 
            this.splitTables.Panel1.Controls.Add(this.gpbExportar);
            this.splitTables.Panel1.Controls.Add(this.lblListIndex);
            this.splitTables.Panel1.Controls.Add(this.btnExportarParaExcel);
            this.splitTables.Panel1.Controls.Add(this.lvwTables);
            this.splitTables.Panel1.Controls.Add(this.lblTotal);
            this.splitTables.Panel1.Controls.Add(this.label1);
            // 
            // splitTables.Panel2
            // 
            this.splitTables.Panel2.Controls.Add(this.gpbColunas);
            this.splitTables.Size = new System.Drawing.Size(812, 478);
            this.splitTables.SplitterDistance = 239;
            this.splitTables.TabIndex = 16;
            // 
            // gpbExportar
            // 
            this.gpbExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbExportar.Controls.Add(this.pgbListar);
            this.gpbExportar.Controls.Add(this.rdbExportarHTML);
            this.gpbExportar.Controls.Add(this.btnExportarTabelaColunas);
            this.gpbExportar.Controls.Add(this.rdbExportarArquivoTexto);
            this.gpbExportar.Location = new System.Drawing.Point(129, 194);
            this.gpbExportar.Name = "gpbExportar";
            this.gpbExportar.Size = new System.Drawing.Size(483, 42);
            this.gpbExportar.TabIndex = 17;
            this.gpbExportar.TabStop = false;
            this.gpbExportar.Text = "Exporta lista de Tabelas e suas colunas";
            // 
            // pgbListar
            // 
            this.pgbListar.Location = new System.Drawing.Point(244, 20);
            this.pgbListar.Name = "pgbListar";
            this.pgbListar.Size = new System.Drawing.Size(119, 13);
            this.pgbListar.TabIndex = 18;
            // 
            // rdbExportarHTML
            // 
            this.rdbExportarHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbExportarHTML.Enabled = false;
            this.rdbExportarHTML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdbExportarHTML.Image = global::DBTools.Properties.Resources.HtmlPage;
            this.rdbExportarHTML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdbExportarHTML.Location = new System.Drawing.Point(143, 16);
            this.rdbExportarHTML.Name = "rdbExportarHTML";
            this.rdbExportarHTML.Size = new System.Drawing.Size(95, 23);
            this.rdbExportarHTML.TabIndex = 17;
            this.rdbExportarHTML.Text = "Para HTML";
            this.rdbExportarHTML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbExportarHTML.UseVisualStyleBackColor = true;
            // 
            // btnExportarTabelaColunas
            // 
            this.btnExportarTabelaColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarTabelaColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarTabelaColunas.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExportarTabelaColunas.Image = global::DBTools.Properties.Resources.bloco_de_notas16x16;
            this.btnExportarTabelaColunas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarTabelaColunas.Location = new System.Drawing.Point(369, 12);
            this.btnExportarTabelaColunas.Name = "btnExportarTabelaColunas";
            this.btnExportarTabelaColunas.Size = new System.Drawing.Size(108, 25);
            this.btnExportarTabelaColunas.TabIndex = 15;
            this.btnExportarTabelaColunas.Text = "Exportar";
            this.btnExportarTabelaColunas.UseVisualStyleBackColor = true;
            this.btnExportarTabelaColunas.Click += new System.EventHandler(this.btnExportarTabelaColunas_Click);
            // 
            // rdbExportarArquivoTexto
            // 
            this.rdbExportarArquivoTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbExportarArquivoTexto.Checked = true;
            this.rdbExportarArquivoTexto.ForeColor = System.Drawing.Color.Blue;
            this.rdbExportarArquivoTexto.Image = global::DBTools.Properties.Resources.bloco_de_notas16x16;
            this.rdbExportarArquivoTexto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdbExportarArquivoTexto.Location = new System.Drawing.Point(6, 16);
            this.rdbExportarArquivoTexto.Name = "rdbExportarArquivoTexto";
            this.rdbExportarArquivoTexto.Size = new System.Drawing.Size(131, 23);
            this.rdbExportarArquivoTexto.TabIndex = 16;
            this.rdbExportarArquivoTexto.TabStop = true;
            this.rdbExportarArquivoTexto.Text = "Para Arquivo texto";
            this.rdbExportarArquivoTexto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbExportarArquivoTexto.UseVisualStyleBackColor = true;
            // 
            // lblListIndex
            // 
            this.lblListIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblListIndex.AutoSize = true;
            this.lblListIndex.ForeColor = System.Drawing.Color.Maroon;
            this.lblListIndex.Location = new System.Drawing.Point(101, 194);
            this.lblListIndex.Name = "lblListIndex";
            this.lblListIndex.Size = new System.Drawing.Size(22, 13);
            this.lblListIndex.TabIndex = 14;
            this.lblListIndex.Text = "???";
            // 
            // clhRowsOrder
            // 
            this.clhRowsOrder.Text = "Rows";
            this.clhRowsOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhRowsOrder.Width = 0;
            // 
            // frmTablesRowsCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 478);
            this.Controls.Add(this.splitTables);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTablesRowsCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tables - Rows count";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTablesRowsCount_FormClosing);
            this.Load += new System.EventHandler(this.frmTablesRowsCount_Load);
            this.gpbColunas.ResumeLayout(false);
            this.gpbColunas.PerformLayout();
            this.splitTables.Panel1.ResumeLayout(false);
            this.splitTables.Panel1.PerformLayout();
            this.splitTables.Panel2.ResumeLayout(false);
            this.splitTables.ResumeLayout(false);
            this.gpbExportar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clhTable;
        private System.Windows.Forms.ColumnHeader clhOwner;
        private System.Windows.Forms.ColumnHeader clhRows;
        private System.Windows.Forms.ColumnHeader clhDataCriacao;
        private System.Windows.Forms.ImageList imgListIcones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwTables;
        private System.Windows.Forms.Button btnExportarParaExcel;
        private System.Windows.Forms.GroupBox gpbColunas;
        private System.Windows.Forms.ColumnHeader clhKey;
        private System.Windows.Forms.ColumnHeader clhName;
        private System.Windows.Forms.ColumnHeader clhDataType;
        private System.Windows.Forms.ColumnHeader clhSize;
        private System.Windows.Forms.ColumnHeader clhNulls;
        private System.Windows.Forms.Label lblTotalColunas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader clhTableFK;
        private System.Windows.Forms.Button btnExportarParaExcelColunas;
        private System.Windows.Forms.SplitContainer splitTables;
        private System.Windows.Forms.Label lblListIndex;
        private System.Windows.Forms.ColumnHeader clhIndexName;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwColunas;
        private System.Windows.Forms.ColumnHeader clhFillfactor;
        private System.Windows.Forms.ColumnHeader clhID;
        private System.Windows.Forms.GroupBox gpbExportar;
        private System.Windows.Forms.Button btnExportarTabelaColunas;
        private System.Windows.Forms.RadioButton rdbExportarArquivoTexto;
        private System.Windows.Forms.RadioButton rdbExportarHTML;
        private System.Windows.Forms.ProgressBar pgbListar;
        private System.Windows.Forms.ColumnHeader clhIdentity;
        private System.Windows.Forms.ColumnHeader clhRowsOrder;
    }
}