namespace DBTools.forms
{
    partial class frmDeletarRegistrosDuplicados
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
            this.lvwCampos = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhCampos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpbWhere = new System.Windows.Forms.GroupBox();
            this.txtColunaWhere = new System.Windows.Forms.TextBox();
            this.Where_lblValor = new System.Windows.Forms.Label();
            this.btnColunaWhereAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtColunaDuplicada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColunaDuplicadadaAdd = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.pgbRegistros = new System.Windows.Forms.ProgressBar();
            this.gpbWhere.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCampos
            // 
            this.lvwCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhCampos,
            this.clhColumn});
            this.lvwCampos.ForeColor = System.Drawing.Color.Maroon;
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.HideSelection = false;
            this.lvwCampos.KeyUpDownActivateOnClick = false;
            this.lvwCampos.Location = new System.Drawing.Point(3, 3);
            this.lvwCampos.MultiSelect = false;
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(287, 424);
            this.lvwCampos.Sorter = true;
            this.lvwCampos.TabIndex = 1;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            // 
            // clhCampos
            // 
            this.clhCampos.Text = "Campos";
            this.clhCampos.Width = 200;
            // 
            // clhColumn
            // 
            this.clhColumn.Text = "SqlDataType";
            this.clhColumn.Width = 0;
            // 
            // gpbWhere
            // 
            this.gpbWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbWhere.Controls.Add(this.txtColunaWhere);
            this.gpbWhere.Controls.Add(this.Where_lblValor);
            this.gpbWhere.Controls.Add(this.btnColunaWhereAdd);
            this.gpbWhere.Location = new System.Drawing.Point(296, 59);
            this.gpbWhere.Name = "gpbWhere";
            this.gpbWhere.Size = new System.Drawing.Size(354, 50);
            this.gpbWhere.TabIndex = 22;
            this.gpbWhere.TabStop = false;
            this.gpbWhere.Text = "Coluna Where para deletar";
            // 
            // txtColunaWhere
            // 
            this.txtColunaWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColunaWhere.BackColor = System.Drawing.Color.Ivory;
            this.txtColunaWhere.ForeColor = System.Drawing.Color.Blue;
            this.txtColunaWhere.Location = new System.Drawing.Point(116, 21);
            this.txtColunaWhere.Name = "txtColunaWhere";
            this.txtColunaWhere.ReadOnly = true;
            this.txtColunaWhere.Size = new System.Drawing.Size(232, 21);
            this.txtColunaWhere.TabIndex = 8;
            // 
            // Where_lblValor
            // 
            this.Where_lblValor.AutoSize = true;
            this.Where_lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Where_lblValor.ForeColor = System.Drawing.Color.Navy;
            this.Where_lblValor.Location = new System.Drawing.Point(60, 24);
            this.Where_lblValor.Name = "Where_lblValor";
            this.Where_lblValor.Size = new System.Drawing.Size(50, 13);
            this.Where_lblValor.TabIndex = 7;
            this.Where_lblValor.Text = "Coluna:";
            // 
            // btnColunaWhereAdd
            // 
            this.btnColunaWhereAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColunaWhereAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnColunaWhereAdd.Location = new System.Drawing.Point(6, 19);
            this.btnColunaWhereAdd.Name = "btnColunaWhereAdd";
            this.btnColunaWhereAdd.Size = new System.Drawing.Size(48, 23);
            this.btnColunaWhereAdd.TabIndex = 2;
            this.btnColunaWhereAdd.Text = ">";
            this.btnColunaWhereAdd.UseVisualStyleBackColor = true;
            this.btnColunaWhereAdd.Click += new System.EventHandler(this.btnColunaWhereAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtColunaDuplicada);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnColunaDuplicadadaAdd);
            this.groupBox1.Location = new System.Drawing.Point(296, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 50);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coluna duplicada";
            // 
            // txtColunaDuplicada
            // 
            this.txtColunaDuplicada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColunaDuplicada.BackColor = System.Drawing.Color.Ivory;
            this.txtColunaDuplicada.ForeColor = System.Drawing.Color.Blue;
            this.txtColunaDuplicada.Location = new System.Drawing.Point(116, 21);
            this.txtColunaDuplicada.Name = "txtColunaDuplicada";
            this.txtColunaDuplicada.ReadOnly = true;
            this.txtColunaDuplicada.Size = new System.Drawing.Size(232, 21);
            this.txtColunaDuplicada.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(60, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Coluna:";
            // 
            // btnColunaDuplicadadaAdd
            // 
            this.btnColunaDuplicadadaAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColunaDuplicadadaAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnColunaDuplicadadaAdd.Location = new System.Drawing.Point(6, 19);
            this.btnColunaDuplicadadaAdd.Name = "btnColunaDuplicadadaAdd";
            this.btnColunaDuplicadadaAdd.Size = new System.Drawing.Size(48, 23);
            this.btnColunaDuplicadadaAdd.TabIndex = 2;
            this.btnColunaDuplicadadaAdd.Text = ">";
            this.btnColunaDuplicadadaAdd.UseVisualStyleBackColor = true;
            this.btnColunaDuplicadadaAdd.Click += new System.EventHandler(this.btnColunaDuplicadadaAdd_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancelar.Location = new System.Drawing.Point(458, 433);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 24);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.ForeColor = System.Drawing.Color.Red;
            this.btnDeletar.Image = global::DBTools.Properties.Resources.Decline;
            this.btnDeletar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletar.Location = new System.Drawing.Point(557, 433);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(93, 24);
            this.btnDeletar.TabIndex = 24;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // pgbRegistros
            // 
            this.pgbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbRegistros.Location = new System.Drawing.Point(3, 443);
            this.pgbRegistros.Name = "pgbRegistros";
            this.pgbRegistros.Size = new System.Drawing.Size(449, 13);
            this.pgbRegistros.TabIndex = 26;
            // 
            // frmDeletarRegistrosDuplicados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(662, 469);
            this.Controls.Add(this.pgbRegistros);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbWhere);
            this.Controls.Add(this.lvwCampos);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(668, 493);
            this.MinimumSize = new System.Drawing.Size(668, 493);
            this.Name = "frmDeletarRegistrosDuplicados";
            this.Text = "Deletar Registros Duplicados";
            this.Load += new System.EventHandler(this.frmDeletarRegistrosDuplicados_Load);
            this.gpbWhere.ResumeLayout(false);
            this.gpbWhere.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwCampos;
        private System.Windows.Forms.ColumnHeader clhColumn;
        private System.Windows.Forms.ColumnHeader clhCampos;
        internal System.Windows.Forms.GroupBox gpbWhere;
        private System.Windows.Forms.TextBox txtColunaWhere;
        private System.Windows.Forms.Label Where_lblValor;
        private System.Windows.Forms.Button btnColunaWhereAdd;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtColunaDuplicada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColunaDuplicadadaAdd;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.ProgressBar pgbRegistros;
    }
}