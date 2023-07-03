namespace DBTools.forms
{
    partial class frmGerenciadorWebService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerenciadorWebService));
            this.btnResgatar = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMetodos = new System.Windows.Forms.ComboBox();
            this.cboServicos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGerarCodigoCSharp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRemoverParametroUser = new System.Windows.Forms.CheckBox();
            this.chkAlterarSelectParaGet = new System.Windows.Forms.CheckBox();
            this.chkCriarCodigoTodosWebMetodos = new System.Windows.Forms.CheckBox();
            this.chkConverterXMLParaDataTable = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.drResultados = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pgbMetodos = new System.Windows.Forms.ProgressBar();
            this.lvwMetodos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnExportarExcelListaMetodos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drResultados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResgatar
            // 
            this.btnResgatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResgatar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResgatar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnResgatar.Image = global::DBTools.Properties.Resources.webrefrence_search;
            this.btnResgatar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResgatar.Location = new System.Drawing.Point(461, 6);
            this.btnResgatar.Name = "btnResgatar";
            this.btnResgatar.Size = new System.Drawing.Size(144, 24);
            this.btnResgatar.TabIndex = 0;
            this.btnResgatar.Text = "Resgatar Métodos";
            this.btnResgatar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResgatar.UseVisualStyleBackColor = true;
            this.btnResgatar.Click += new System.EventHandler(this.btnResgatar_Click);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtURL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtURL.ForeColor = System.Drawing.Color.Blue;
            this.txtURL.Location = new System.Drawing.Point(66, 8);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(389, 21);
            this.txtURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Métodos:";
            // 
            // cboMetodos
            // 
            this.cboMetodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodos.Enabled = false;
            this.cboMetodos.ForeColor = System.Drawing.Color.Blue;
            this.cboMetodos.FormattingEnabled = true;
            this.cboMetodos.Location = new System.Drawing.Point(66, 61);
            this.cboMetodos.Name = "cboMetodos";
            this.cboMetodos.Size = new System.Drawing.Size(405, 21);
            this.cboMetodos.TabIndex = 5;
            // 
            // cboServicos
            // 
            this.cboServicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicos.ForeColor = System.Drawing.Color.Blue;
            this.cboServicos.FormattingEnabled = true;
            this.cboServicos.Location = new System.Drawing.Point(66, 34);
            this.cboServicos.Name = "cboServicos";
            this.cboServicos.Size = new System.Drawing.Size(232, 21);
            this.cboServicos.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(9, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Serviços:";
            // 
            // btnGerarCodigoCSharp
            // 
            this.btnGerarCodigoCSharp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarCodigoCSharp.Enabled = false;
            this.btnGerarCodigoCSharp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarCodigoCSharp.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGerarCodigoCSharp.Image = global::DBTools.Properties.Resources.Method;
            this.btnGerarCodigoCSharp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCodigoCSharp.Location = new System.Drawing.Point(476, 451);
            this.btnGerarCodigoCSharp.Name = "btnGerarCodigoCSharp";
            this.btnGerarCodigoCSharp.Size = new System.Drawing.Size(129, 24);
            this.btnGerarCodigoCSharp.TabIndex = 8;
            this.btnGerarCodigoCSharp.Text = "Gerar Código C#";
            this.btnGerarCodigoCSharp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarCodigoCSharp.UseVisualStyleBackColor = true;
            this.btnGerarCodigoCSharp.Click += new System.EventHandler(this.btnGerarCodigoCSharp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chkRemoverParametroUser);
            this.groupBox1.Controls.Add(this.chkAlterarSelectParaGet);
            this.groupBox1.Controls.Add(this.chkCriarCodigoTodosWebMetodos);
            this.groupBox1.Controls.Add(this.chkConverterXMLParaDataTable);
            this.groupBox1.Location = new System.Drawing.Point(12, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 112);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // chkRemoverParametroUser
            // 
            this.chkRemoverParametroUser.AutoSize = true;
            this.chkRemoverParametroUser.Checked = true;
            this.chkRemoverParametroUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoverParametroUser.ForeColor = System.Drawing.Color.Maroon;
            this.chkRemoverParametroUser.Location = new System.Drawing.Point(6, 43);
            this.chkRemoverParametroUser.Name = "chkRemoverParametroUser";
            this.chkRemoverParametroUser.Size = new System.Drawing.Size(326, 17);
            this.chkRemoverParametroUser.TabIndex = 3;
            this.chkRemoverParametroUser.Text = "Remover parâmetro \"User\" da lista de parâmetros dos métodos.";
            this.chkRemoverParametroUser.UseVisualStyleBackColor = true;
            // 
            // chkAlterarSelectParaGet
            // 
            this.chkAlterarSelectParaGet.AutoSize = true;
            this.chkAlterarSelectParaGet.ForeColor = System.Drawing.Color.Maroon;
            this.chkAlterarSelectParaGet.Location = new System.Drawing.Point(6, 89);
            this.chkAlterarSelectParaGet.Name = "chkAlterarSelectParaGet";
            this.chkAlterarSelectParaGet.Size = new System.Drawing.Size(403, 17);
            this.chkAlterarSelectParaGet.TabIndex = 2;
            this.chkAlterarSelectParaGet.Text = "Alterar de \"Select\" para \"Get\" nos métodos de retorno que comece com Select.";
            this.chkAlterarSelectParaGet.UseVisualStyleBackColor = true;
            // 
            // chkCriarCodigoTodosWebMetodos
            // 
            this.chkCriarCodigoTodosWebMetodos.AutoSize = true;
            this.chkCriarCodigoTodosWebMetodos.Checked = true;
            this.chkCriarCodigoTodosWebMetodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCriarCodigoTodosWebMetodos.ForeColor = System.Drawing.Color.Maroon;
            this.chkCriarCodigoTodosWebMetodos.Location = new System.Drawing.Point(6, 20);
            this.chkCriarCodigoTodosWebMetodos.Name = "chkCriarCodigoTodosWebMetodos";
            this.chkCriarCodigoTodosWebMetodos.Size = new System.Drawing.Size(215, 17);
            this.chkCriarCodigoTodosWebMetodos.TabIndex = 1;
            this.chkCriarCodigoTodosWebMetodos.Text = "Criar código para todos os web métodos";
            this.chkCriarCodigoTodosWebMetodos.UseVisualStyleBackColor = true;
            this.chkCriarCodigoTodosWebMetodos.CheckedChanged += new System.EventHandler(this.chkCriarCodigoTodosWebMetodos_CheckedChanged);
            // 
            // chkConverterXMLParaDataTable
            // 
            this.chkConverterXMLParaDataTable.AutoSize = true;
            this.chkConverterXMLParaDataTable.ForeColor = System.Drawing.Color.Maroon;
            this.chkConverterXMLParaDataTable.Location = new System.Drawing.Point(6, 66);
            this.chkConverterXMLParaDataTable.Name = "chkConverterXMLParaDataTable";
            this.chkConverterXMLParaDataTable.Size = new System.Drawing.Size(207, 17);
            this.chkConverterXMLParaDataTable.TabIndex = 0;
            this.chkConverterXMLParaDataTable.Text = "Converter XmlElement para DataTable";
            this.chkConverterXMLParaDataTable.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Image = global::DBTools.Properties.Resources.Method;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(477, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Executar método";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // drResultados
            // 
            this.drResultados.DataMember = "";
            this.drResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drResultados.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drResultados.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.drResultados.Location = new System.Drawing.Point(3, 17);
            this.drResultados.Name = "drResultados";
            this.drResultados.ReadOnly = true;
            this.drResultados.Size = new System.Drawing.Size(587, 50);
            this.drResultados.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.drResultados);
            this.groupBox2.Location = new System.Drawing.Point(10, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 70);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // pgbMetodos
            // 
            this.pgbMetodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbMetodos.Location = new System.Drawing.Point(12, 458);
            this.pgbMetodos.Name = "pgbMetodos";
            this.pgbMetodos.Size = new System.Drawing.Size(458, 13);
            this.pgbMetodos.TabIndex = 13;
            // 
            // lvwMetodos
            // 
            this.lvwMetodos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMetodos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwMetodos.ForeColor = System.Drawing.Color.Blue;
            this.lvwMetodos.FullRowSelect = true;
            this.lvwMetodos.HideSelection = false;
            this.lvwMetodos.KeyUpDownActivateOnClick = false;
            this.lvwMetodos.Location = new System.Drawing.Point(12, 88);
            this.lvwMetodos.Name = "lvwMetodos";
            this.lvwMetodos.Size = new System.Drawing.Size(591, 133);
            this.lvwMetodos.SmallImageList = this.imgIcons;
            this.lvwMetodos.Sorter = true;
            this.lvwMetodos.TabIndex = 14;
            this.lvwMetodos.UseCompatibleStateImageBehavior = false;
            this.lvwMetodos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Método";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Retorno";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Qtd. parâmetros";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "Method.ico");
            // 
            // btnExportarExcelListaMetodos
            // 
            this.btnExportarExcelListaMetodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportarExcelListaMetodos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcelListaMetodos.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExportarExcelListaMetodos.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarExcelListaMetodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcelListaMetodos.Location = new System.Drawing.Point(10, 227);
            this.btnExportarExcelListaMetodos.Name = "btnExportarExcelListaMetodos";
            this.btnExportarExcelListaMetodos.Size = new System.Drawing.Size(144, 24);
            this.btnExportarExcelListaMetodos.TabIndex = 15;
            this.btnExportarExcelListaMetodos.Text = "Exportar para Excel";
            this.btnExportarExcelListaMetodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcelListaMetodos.UseVisualStyleBackColor = true;
            this.btnExportarExcelListaMetodos.Click += new System.EventHandler(this.btnExportarExcelListaMetodos_Click);
            // 
            // frmGerenciadorWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 487);
            this.Controls.Add(this.btnExportarExcelListaMetodos);
            this.Controls.Add(this.lvwMetodos);
            this.Controls.Add(this.pgbMetodos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGerarCodigoCSharp);
            this.Controls.Add(this.cboServicos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMetodos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnResgatar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGerenciadorWebService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de WebServices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drResultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResgatar;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMetodos;
        private System.Windows.Forms.ComboBox cboServicos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGerarCodigoCSharp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkConverterXMLParaDataTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkCriarCodigoTodosWebMetodos;
        private System.Windows.Forms.DataGrid drResultados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pgbMetodos;
        private System.Windows.Forms.CheckBox chkAlterarSelectParaGet;
        private System.Windows.Forms.CheckBox chkRemoverParametroUser;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwMetodos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnExportarExcelListaMetodos;
        private System.Windows.Forms.ImageList imgIcons;
    }
}