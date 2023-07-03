namespace DBTools.forms
{
    partial class frmPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisa));
            this.lvwPesquisa = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhStoredProcedure = new System.Windows.Forms.ColumnHeader();
            this.clhOcorrencias = new System.Windows.Forms.ColumnHeader();
            this.clhTexto = new System.Windows.Forms.ColumnHeader();
            this.pgbPesquisa = new System.Windows.Forms.ProgressBar();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwPesquisa
            // 
            this.lvwPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPesquisa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhStoredProcedure,
            this.clhOcorrencias,
            this.clhTexto});
            this.lvwPesquisa.ForeColor = System.Drawing.Color.Maroon;
            this.lvwPesquisa.FullRowSelect = true;
            this.lvwPesquisa.HideSelection = false;
            this.lvwPesquisa.KeyUpDownActivateOnClick = false;
            this.lvwPesquisa.Location = new System.Drawing.Point(12, 12);
            this.lvwPesquisa.MultiSelect = false;
            this.lvwPesquisa.Name = "lvwPesquisa";
            this.lvwPesquisa.Size = new System.Drawing.Size(566, 331);
            this.lvwPesquisa.Sorter = true;
            this.lvwPesquisa.TabIndex = 0;
            this.lvwPesquisa.UseCompatibleStateImageBehavior = false;
            this.lvwPesquisa.View = System.Windows.Forms.View.Details;
            this.lvwPesquisa.DoubleClick += new System.EventHandler(this.lvwPesquisa_DoubleClick);
            // 
            // clhStoredProcedure
            // 
            this.clhStoredProcedure.Text = "Stored Procedure";
            this.clhStoredProcedure.Width = 470;
            // 
            // clhOcorrencias
            // 
            this.clhOcorrencias.Text = "Ocorrências";
            this.clhOcorrencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhOcorrencias.Width = 75;
            // 
            // clhTexto
            // 
            this.clhTexto.Text = "Texto da SP";
            this.clhTexto.Width = 0;
            // 
            // pgbPesquisa
            // 
            this.pgbPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbPesquisa.Location = new System.Drawing.Point(12, 369);
            this.pgbPesquisa.Name = "pgbPesquisa";
            this.pgbPesquisa.Size = new System.Drawing.Size(413, 16);
            this.pgbPesquisa.TabIndex = 1;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExportarExcel.Image = global::DBTools.Properties.Resources.excel16x16;
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcel.Location = new System.Drawing.Point(436, 361);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(142, 24);
            this.btnExportarExcel.TabIndex = 2;
            this.btnExportarExcel.Text = "Exportar para Excel";
            this.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(57, 346);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(14, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0";
            // 
            // frmPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 396);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.pgbPesquisa);
            this.Controls.Add(this.lvwPesquisa);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa";
            this.Load += new System.EventHandler(this.frmPesquisa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwPesquisa;
        private System.Windows.Forms.ColumnHeader clhStoredProcedure;
        private System.Windows.Forms.ColumnHeader clhOcorrencias;
        private System.Windows.Forms.ProgressBar pgbPesquisa;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ColumnHeader clhTexto;
    }
}