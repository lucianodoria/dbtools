namespace DBTools.forms
{
    partial class frmJoomlaCriarSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJoomlaCriarSelect));
            this.txtDropdownListsName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gpbColunas = new System.Windows.Forms.GroupBox();
            this.btnText = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValue = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwColunas = new LucianoDoria.Forms.ListViewPlus.ListViewPlus();
            this.clhKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhIdentity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhNulls = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListIcones = new System.Windows.Forms.ImageList(this.components);
            this.btnCreate = new System.Windows.Forms.Button();
            this.gpbColunas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDropdownListsName
            // 
            this.txtDropdownListsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDropdownListsName.Location = new System.Drawing.Point(116, 187);
            this.txtDropdownListsName.Name = "txtDropdownListsName";
            this.txtDropdownListsName.Size = new System.Drawing.Size(219, 21);
            this.txtDropdownListsName.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "DropdownListsName:";
            // 
            // gpbColunas
            // 
            this.gpbColunas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbColunas.Controls.Add(this.btnText);
            this.gpbColunas.Controls.Add(this.txtText);
            this.gpbColunas.Controls.Add(this.label2);
            this.gpbColunas.Controls.Add(this.btnValue);
            this.gpbColunas.Controls.Add(this.txtValue);
            this.gpbColunas.Controls.Add(this.label1);
            this.gpbColunas.Controls.Add(this.lvwColunas);
            this.gpbColunas.Controls.Add(this.txtDropdownListsName);
            this.gpbColunas.Controls.Add(this.label11);
            this.gpbColunas.Location = new System.Drawing.Point(12, 12);
            this.gpbColunas.Name = "gpbColunas";
            this.gpbColunas.Size = new System.Drawing.Size(616, 214);
            this.gpbColunas.TabIndex = 16;
            this.gpbColunas.TabStop = false;
            this.gpbColunas.Text = "Colunas";
            // 
            // btnText
            // 
            this.btnText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnText.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnText.Image = global::DBTools.Properties.Resources.saveico;
            this.btnText.Location = new System.Drawing.Point(533, 160);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(33, 24);
            this.btnText.TabIndex = 38;
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtText.Location = new System.Drawing.Point(332, 163);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(195, 21);
            this.txtText.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Text:";
            // 
            // btnValue
            // 
            this.btnValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValue.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnValue.Image = global::DBTools.Properties.Resources.saveico;
            this.btnValue.Location = new System.Drawing.Point(250, 160);
            this.btnValue.Name = "btnValue";
            this.btnValue.Size = new System.Drawing.Size(33, 24);
            this.btnValue.TabIndex = 35;
            this.btnValue.UseVisualStyleBackColor = true;
            this.btnValue.Click += new System.EventHandler(this.btnValue_Click);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValue.Location = new System.Drawing.Point(49, 160);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(195, 21);
            this.txtValue.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Value:";
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
            this.clhNulls});
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
            this.lvwColunas.Size = new System.Drawing.Size(604, 134);
            this.lvwColunas.SmallImageList = this.imgListIcones;
            this.lvwColunas.Sorter = false;
            this.lvwColunas.TabIndex = 14;
            this.lvwColunas.UseCompatibleStateImageBehavior = false;
            this.lvwColunas.View = System.Windows.Forms.View.Details;
            // 
            // clhKey
            // 
            this.clhKey.Text = "Key";
            this.clhKey.Width = 40;
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
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCreate.Location = new System.Drawing.Point(487, 232);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(137, 24);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Gerar SelectControl";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmJoomlaCriarSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 267);
            this.Controls.Add(this.gpbColunas);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmJoomlaCriarSelect";
            this.Text = "Joomla - Criação de Componente";
            this.Load += new System.EventHandler(this.frmJoomla_Load);
            this.gpbColunas.ResumeLayout(false);
            this.gpbColunas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox gpbColunas;
        private LucianoDoria.Forms.ListViewPlus.ListViewPlus lvwColunas;
        private System.Windows.Forms.ColumnHeader clhKey;
        private System.Windows.Forms.ColumnHeader clhIdentity;
        private System.Windows.Forms.ColumnHeader clhName;
        private System.Windows.Forms.ColumnHeader clhDataType;
        private System.Windows.Forms.ColumnHeader clhSize;
        private System.Windows.Forms.ColumnHeader clhNulls;
        private System.Windows.Forms.ImageList imgListIcones;
        private System.Windows.Forms.TextBox txtDropdownListsName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
    }
}