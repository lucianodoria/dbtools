namespace DBTools.forms
{
    partial class frmLogon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogon));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServerType = new System.Windows.Forms.ComboBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAutenticacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.gpbTabela = new System.Windows.Forms.GroupBox();
            this.chkTableShowColumnsDataType = new System.Windows.Forms.CheckBox();
            this.chkTableShowFK = new System.Windows.Forms.CheckBox();
            this.chkTableShowSystemObject = new System.Windows.Forms.CheckBox();
            this.btnOpcoes = new System.Windows.Forms.Button();
            this.gpbSP = new System.Windows.Forms.GroupBox();
            this.chkSPShowColumnsDataType = new System.Windows.Forms.CheckBox();
            this.chkSPShowSystemObject = new System.Windows.Forms.CheckBox();
            this.gpbView = new System.Windows.Forms.GroupBox();
            this.chkViewShowColumnsDataType = new System.Windows.Forms.CheckBox();
            this.chkViewShowSystemObject = new System.Windows.Forms.CheckBox();
            this.gpbBancoDados = new System.Windows.Forms.GroupBox();
            this.chkDataBaseShowDenyReader = new System.Windows.Forms.CheckBox();
            this.chkDataBaseShowSystemObject = new System.Windows.Forms.CheckBox();
            this.groupBox7.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.gpbTabela.SuspendLayout();
            this.gpbSP.SuspendLayout();
            this.gpbView.SuspendLayout();
            this.gpbBancoDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.cboServerType);
            this.groupBox7.Controls.Add(this.pnlLogin);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.cboAutenticacao);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.cboServers);
            this.groupBox7.Controls.Add(this.btnCancelar);
            this.groupBox7.Controls.Add(this.btnConectar);
            this.groupBox7.Location = new System.Drawing.Point(12, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(369, 210);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Conexão";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "       Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboServerType
            // 
            this.cboServerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServerType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServerType.ForeColor = System.Drawing.Color.Blue;
            this.cboServerType.Items.AddRange(new object[] {
            "MySQL",
            "SQL Server"});
            this.cboServerType.Location = new System.Drawing.Point(120, 20);
            this.cboServerType.Name = "cboServerType";
            this.cboServerType.Size = new System.Drawing.Size(104, 21);
            this.cboServerType.Sorted = true;
            this.cboServerType.TabIndex = 0;
            this.cboServerType.SelectedIndexChanged += new System.EventHandler(this.cboServerType_SelectedIndexChanged);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.cboUser);
            this.pnlLogin.Controls.Add(this.chkRememberPassword);
            this.pnlLogin.Controls.Add(this.label9);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.label10);
            this.pnlLogin.Enabled = false;
            this.pnlLogin.Location = new System.Drawing.Point(27, 101);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(334, 71);
            this.pnlLogin.TabIndex = 3;
            // 
            // cboUser
            // 
            this.cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.ForeColor = System.Drawing.Color.Blue;
            this.cboUser.Location = new System.Drawing.Point(93, 3);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(156, 21);
            this.cboUser.Sorted = true;
            this.cboUser.TabIndex = 1;
            this.cboUser.SelectedIndexChanged += new System.EventHandler(this.cboUsuario_SelectedIndexChanged);
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberPassword.ForeColor = System.Drawing.Color.Maroon;
            this.chkRememberPassword.Location = new System.Drawing.Point(93, 51);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(98, 17);
            this.chkRememberPassword.TabIndex = 3;
            this.chkRememberPassword.Text = "Lembrar Senha";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "       Usuário:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Blue;
            this.txtPassword.Location = new System.Drawing.Point(93, 27);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 21);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyUp);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(3, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 11;
            this.label10.Text = "       Senha:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(8, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tipo Autenticação:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAutenticacao
            // 
            this.cboAutenticacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAutenticacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutenticacao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAutenticacao.ForeColor = System.Drawing.Color.Blue;
            this.cboAutenticacao.Items.AddRange(new object[] {
            "Autenticação Windows",
            "Autenticação SQL Server"});
            this.cboAutenticacao.Location = new System.Drawing.Point(120, 74);
            this.cboAutenticacao.Name = "cboAutenticacao";
            this.cboAutenticacao.Size = new System.Drawing.Size(241, 21);
            this.cboAutenticacao.TabIndex = 2;
            this.cboAutenticacao.SelectedIndexChanged += new System.EventHandler(this.cboAutenticacao_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(8, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "       Server:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboServers
            // 
            this.cboServers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServers.ForeColor = System.Drawing.Color.Blue;
            this.cboServers.Location = new System.Drawing.Point(120, 47);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(241, 21);
            this.cboServers.Sorted = true;
            this.cboServers.TabIndex = 1;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.cboServers_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.Maroon;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(257, 178);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 24);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConectar
            // 
            this.btnConectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConectar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnConectar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConectar.ForeColor = System.Drawing.Color.Navy;
            this.btnConectar.Image = ((System.Drawing.Image)(resources.GetObject("btnConectar.Image")));
            this.btnConectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConectar.Location = new System.Drawing.Point(120, 178);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(104, 24);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "&Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // gpbTabela
            // 
            this.gpbTabela.Controls.Add(this.chkTableShowColumnsDataType);
            this.gpbTabela.Controls.Add(this.chkTableShowFK);
            this.gpbTabela.Controls.Add(this.chkTableShowSystemObject);
            this.gpbTabela.Location = new System.Drawing.Point(12, 288);
            this.gpbTabela.Name = "gpbTabela";
            this.gpbTabela.Size = new System.Drawing.Size(369, 86);
            this.gpbTabela.TabIndex = 45;
            this.gpbTabela.TabStop = false;
            this.gpbTabela.Text = "Configurações das Tabelas";
            this.gpbTabela.Visible = false;
            // 
            // chkTableShowColumnsDataType
            // 
            this.chkTableShowColumnsDataType.AutoSize = true;
            this.chkTableShowColumnsDataType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTableShowColumnsDataType.ForeColor = System.Drawing.Color.Maroon;
            this.chkTableShowColumnsDataType.Location = new System.Drawing.Point(11, 43);
            this.chkTableShowColumnsDataType.Name = "chkTableShowColumnsDataType";
            this.chkTableShowColumnsDataType.Size = new System.Drawing.Size(155, 17);
            this.chkTableShowColumnsDataType.TabIndex = 2;
            this.chkTableShowColumnsDataType.Text = "Visualizar tipos das colunas";
            this.chkTableShowColumnsDataType.UseVisualStyleBackColor = true;
            // 
            // chkTableShowFK
            // 
            this.chkTableShowFK.AutoSize = true;
            this.chkTableShowFK.Checked = true;
            this.chkTableShowFK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTableShowFK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTableShowFK.ForeColor = System.Drawing.Color.Maroon;
            this.chkTableShowFK.Location = new System.Drawing.Point(11, 63);
            this.chkTableShowFK.Name = "chkTableShowFK";
            this.chkTableShowFK.Size = new System.Drawing.Size(147, 17);
            this.chkTableShowFK.TabIndex = 1;
            this.chkTableShowFK.Text = "Visualizar FK e sua tabela";
            this.chkTableShowFK.UseVisualStyleBackColor = true;
            // 
            // chkTableShowSystemObject
            // 
            this.chkTableShowSystemObject.AutoSize = true;
            this.chkTableShowSystemObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTableShowSystemObject.ForeColor = System.Drawing.Color.Maroon;
            this.chkTableShowSystemObject.Location = new System.Drawing.Point(11, 20);
            this.chkTableShowSystemObject.Name = "chkTableShowSystemObject";
            this.chkTableShowSystemObject.Size = new System.Drawing.Size(162, 17);
            this.chkTableShowSystemObject.TabIndex = 0;
            this.chkTableShowSystemObject.Text = "Visualizar tabelas do sistema";
            this.chkTableShowSystemObject.UseVisualStyleBackColor = true;
            // 
            // btnOpcoes
            // 
            this.btnOpcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpcoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOpcoes.Location = new System.Drawing.Point(269, 218);
            this.btnOpcoes.Name = "btnOpcoes";
            this.btnOpcoes.Size = new System.Drawing.Size(104, 23);
            this.btnOpcoes.TabIndex = 1;
            this.btnOpcoes.Text = "Opções >>";
            this.btnOpcoes.UseVisualStyleBackColor = true;
            this.btnOpcoes.Click += new System.EventHandler(this.btnOpcoes_Click);
            // 
            // gpbSP
            // 
            this.gpbSP.Controls.Add(this.chkSPShowColumnsDataType);
            this.gpbSP.Controls.Add(this.chkSPShowSystemObject);
            this.gpbSP.Location = new System.Drawing.Point(12, 453);
            this.gpbSP.Name = "gpbSP";
            this.gpbSP.Size = new System.Drawing.Size(369, 63);
            this.gpbSP.TabIndex = 44;
            this.gpbSP.TabStop = false;
            this.gpbSP.Text = "Configurações das Stored Procedures";
            this.gpbSP.Visible = false;
            // 
            // chkSPShowColumnsDataType
            // 
            this.chkSPShowColumnsDataType.AutoSize = true;
            this.chkSPShowColumnsDataType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSPShowColumnsDataType.ForeColor = System.Drawing.Color.Maroon;
            this.chkSPShowColumnsDataType.Location = new System.Drawing.Point(11, 43);
            this.chkSPShowColumnsDataType.Name = "chkSPShowColumnsDataType";
            this.chkSPShowColumnsDataType.Size = new System.Drawing.Size(174, 17);
            this.chkSPShowColumnsDataType.TabIndex = 4;
            this.chkSPShowColumnsDataType.Text = "Visualizar tipos dos parâmetros";
            this.chkSPShowColumnsDataType.UseVisualStyleBackColor = true;
            // 
            // chkSPShowSystemObject
            // 
            this.chkSPShowSystemObject.AutoSize = true;
            this.chkSPShowSystemObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSPShowSystemObject.ForeColor = System.Drawing.Color.Maroon;
            this.chkSPShowSystemObject.Location = new System.Drawing.Point(11, 20);
            this.chkSPShowSystemObject.Name = "chkSPShowSystemObject";
            this.chkSPShowSystemObject.Size = new System.Drawing.Size(144, 17);
            this.chkSPShowSystemObject.TabIndex = 0;
            this.chkSPShowSystemObject.Text = "Visualizar SPs do sistema";
            this.chkSPShowSystemObject.UseVisualStyleBackColor = true;
            // 
            // gpbView
            // 
            this.gpbView.Controls.Add(this.chkViewShowColumnsDataType);
            this.gpbView.Controls.Add(this.chkViewShowSystemObject);
            this.gpbView.Location = new System.Drawing.Point(12, 380);
            this.gpbView.Name = "gpbView";
            this.gpbView.Size = new System.Drawing.Size(369, 67);
            this.gpbView.TabIndex = 43;
            this.gpbView.TabStop = false;
            this.gpbView.Text = "Configurações das Views";
            this.gpbView.Visible = false;
            // 
            // chkViewShowColumnsDataType
            // 
            this.chkViewShowColumnsDataType.AutoSize = true;
            this.chkViewShowColumnsDataType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewShowColumnsDataType.ForeColor = System.Drawing.Color.Maroon;
            this.chkViewShowColumnsDataType.Location = new System.Drawing.Point(11, 43);
            this.chkViewShowColumnsDataType.Name = "chkViewShowColumnsDataType";
            this.chkViewShowColumnsDataType.Size = new System.Drawing.Size(155, 17);
            this.chkViewShowColumnsDataType.TabIndex = 3;
            this.chkViewShowColumnsDataType.Text = "Visualizar tipos das colunas";
            this.chkViewShowColumnsDataType.UseVisualStyleBackColor = true;
            // 
            // chkViewShowSystemObject
            // 
            this.chkViewShowSystemObject.AutoSize = true;
            this.chkViewShowSystemObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewShowSystemObject.ForeColor = System.Drawing.Color.Maroon;
            this.chkViewShowSystemObject.Location = new System.Drawing.Point(11, 20);
            this.chkViewShowSystemObject.Name = "chkViewShowSystemObject";
            this.chkViewShowSystemObject.Size = new System.Drawing.Size(154, 17);
            this.chkViewShowSystemObject.TabIndex = 0;
            this.chkViewShowSystemObject.Text = "Visualizar views do sistema";
            this.chkViewShowSystemObject.UseVisualStyleBackColor = true;
            // 
            // gpbBancoDados
            // 
            this.gpbBancoDados.Controls.Add(this.chkDataBaseShowDenyReader);
            this.gpbBancoDados.Controls.Add(this.chkDataBaseShowSystemObject);
            this.gpbBancoDados.Location = new System.Drawing.Point(12, 219);
            this.gpbBancoDados.Name = "gpbBancoDados";
            this.gpbBancoDados.Size = new System.Drawing.Size(369, 63);
            this.gpbBancoDados.TabIndex = 2;
            this.gpbBancoDados.TabStop = false;
            this.gpbBancoDados.Text = "Configurações dos Bancos de Dados";
            this.gpbBancoDados.Visible = false;
            // 
            // chkDataBaseShowDenyReader
            // 
            this.chkDataBaseShowDenyReader.AutoSize = true;
            this.chkDataBaseShowDenyReader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDataBaseShowDenyReader.ForeColor = System.Drawing.Color.Maroon;
            this.chkDataBaseShowDenyReader.Location = new System.Drawing.Point(11, 43);
            this.chkDataBaseShowDenyReader.Name = "chkDataBaseShowDenyReader";
            this.chkDataBaseShowDenyReader.Size = new System.Drawing.Size(280, 17);
            this.chkDataBaseShowDenyReader.TabIndex = 4;
            this.chkDataBaseShowDenyReader.Text = "Visualizar Bancos de Dados Sem permissão de acesso";
            this.chkDataBaseShowDenyReader.UseVisualStyleBackColor = true;
            // 
            // chkDataBaseShowSystemObject
            // 
            this.chkDataBaseShowSystemObject.AutoSize = true;
            this.chkDataBaseShowSystemObject.Checked = true;
            this.chkDataBaseShowSystemObject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataBaseShowSystemObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDataBaseShowSystemObject.ForeColor = System.Drawing.Color.Maroon;
            this.chkDataBaseShowSystemObject.Location = new System.Drawing.Point(11, 20);
            this.chkDataBaseShowSystemObject.Name = "chkDataBaseShowSystemObject";
            this.chkDataBaseShowSystemObject.Size = new System.Drawing.Size(204, 17);
            this.chkDataBaseShowSystemObject.TabIndex = 0;
            this.chkDataBaseShowSystemObject.Text = "Visualizar Banco de Dados do sistema";
            this.chkDataBaseShowSystemObject.UseVisualStyleBackColor = true;
            // 
            // frmLogon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(391, 250);
            this.Controls.Add(this.btnOpcoes);
            this.Controls.Add(this.gpbTabela);
            this.Controls.Add(this.gpbSP);
            this.Controls.Add(this.gpbView);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.gpbBancoDados);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(397, 583);
            this.MinimumSize = new System.Drawing.Size(397, 274);
            this.Name = "frmLogon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conexão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogon_FormClosing);
            this.Load += new System.EventHandler(this.frmLogon_Load);
            this.groupBox7.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.gpbTabela.ResumeLayout(false);
            this.gpbTabela.PerformLayout();
            this.gpbSP.ResumeLayout(false);
            this.gpbSP.PerformLayout();
            this.gpbView.ResumeLayout(false);
            this.gpbView.PerformLayout();
            this.gpbBancoDados.ResumeLayout(false);
            this.gpbBancoDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox gpbTabela;
        private System.Windows.Forms.GroupBox gpbSP;
        private System.Windows.Forms.GroupBox gpbView;
        private System.Windows.Forms.Button btnOpcoes;
        internal System.Windows.Forms.CheckBox chkTableShowColumnsDataType;
        internal System.Windows.Forms.CheckBox chkTableShowFK;
        internal System.Windows.Forms.CheckBox chkTableShowSystemObject;
        internal System.Windows.Forms.CheckBox chkSPShowColumnsDataType;
        internal System.Windows.Forms.CheckBox chkSPShowSystemObject;
        internal System.Windows.Forms.CheckBox chkViewShowColumnsDataType;
        internal System.Windows.Forms.CheckBox chkViewShowSystemObject;
        private System.Windows.Forms.GroupBox gpbBancoDados;
        internal System.Windows.Forms.CheckBox chkDataBaseShowDenyReader;
        internal System.Windows.Forms.CheckBox chkDataBaseShowSystemObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAutenticacao;
        private System.Windows.Forms.Panel pnlLogin;
        internal System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboServerType;
        private System.Windows.Forms.ComboBox cboUser;
    }
}