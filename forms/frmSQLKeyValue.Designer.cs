namespace DBTools.forms
{
    partial class frmSQLKeyValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLKeyValue));
            this.gpbColunas = new System.Windows.Forms.GroupBox();
            this.lblTotalColunas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwColunas = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhIdentity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListIcones = new System.Windows.Forms.ImageList(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnKey = new System.Windows.Forms.Button();
            this.btnValue = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbColunas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbColunas
            // 
            this.gpbColunas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbColunas.Controls.Add(this.lblTotalColunas);
            this.gpbColunas.Controls.Add(this.label3);
            this.gpbColunas.Controls.Add(this.lvwColunas);
            this.gpbColunas.Location = new System.Drawing.Point(12, 60);
            this.gpbColunas.Name = "gpbColunas";
            this.gpbColunas.Size = new System.Drawing.Size(403, 273);
            this.gpbColunas.TabIndex = 17;
            this.gpbColunas.TabStop = false;
            this.gpbColunas.Text = "Colunas";
            // 
            // lblTotalColunas
            // 
            this.lblTotalColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalColunas.AutoSize = true;
            this.lblTotalColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalColunas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalColunas.Location = new System.Drawing.Point(47, 248);
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
            this.label3.Location = new System.Drawing.Point(6, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total:";
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
            this.clhDataType});
            this.lvwColunas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwColunas.ForeColor = System.Drawing.Color.Maroon;
            this.lvwColunas.FullRowSelect = true;
            this.lvwColunas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwColunas.HideSelection = false;
            this.lvwColunas.KeyUpDownActivateOnClick = false;
            this.lvwColunas.Location = new System.Drawing.Point(6, 20);
            this.lvwColunas.MultiSelect = false;
            this.lvwColunas.Name = "lvwColunas";
            this.lvwColunas.ShowGroups = false;
            this.lvwColunas.Size = new System.Drawing.Size(391, 225);
            this.lvwColunas.SmallImageList = this.imgListIcones;
            this.lvwColunas.Sorter = false;
            this.lvwColunas.TabIndex = 14;
            this.lvwColunas.UseCompatibleStateImageBehavior = false;
            this.lvwColunas.View = System.Windows.Forms.View.Details;
            this.lvwColunas.DoubleClick += new System.EventHandler(this.btnValue_Click);
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
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnOK.Location = new System.Drawing.Point(340, 423);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboTables
            // 
            this.cboTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point(6, 15);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(391, 21);
            this.cboTables.TabIndex = 17;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.Ivory;
            this.txtKey.Location = new System.Drawing.Point(62, 347);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(303, 21);
            this.txtKey.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Key:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboTables);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 42);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabelas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.Ivory;
            this.txtValue.Location = new System.Drawing.Point(62, 373);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(303, 21);
            this.txtValue.TabIndex = 23;
            // 
            // btnKey
            // 
            this.btnKey.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKey.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnKey.Image = global::DBTools.Properties.Resources.paste;
            this.btnKey.Location = new System.Drawing.Point(371, 345);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(25, 23);
            this.btnKey.TabIndex = 25;
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // btnValue
            // 
            this.btnValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnValue.Image = global::DBTools.Properties.Resources.paste;
            this.btnValue.Location = new System.Drawing.Point(371, 371);
            this.btnValue.Name = "btnValue";
            this.btnValue.Size = new System.Drawing.Size(25, 23);
            this.btnValue.TabIndex = 26;
            this.btnValue.UseVisualStyleBackColor = true;
            this.btnValue.Click += new System.EventHandler(this.btnValue_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancelar.Location = new System.Drawing.Point(259, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSQLKeyValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 458);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnValue);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbColunas);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSQLKeyValue";
            this.Text = "SQL - Key Value";
            this.gpbColunas.ResumeLayout(false);
            this.gpbColunas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbColunas;
        private System.Windows.Forms.Label lblTotalColunas;
        private System.Windows.Forms.Label label3;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwColunas;
        private System.Windows.Forms.ColumnHeader clhKey;
        private System.Windows.Forms.ColumnHeader clhIdentity;
        private System.Windows.Forms.ColumnHeader clhName;
        private System.Windows.Forms.ColumnHeader clhDataType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboTables;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Button btnValue;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imgListIcones;
    }
}