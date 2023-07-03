namespace DBTools.forms
{
    partial class frmJoomlaPacoteInstalacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileInstall = new System.Windows.Forms.TextBox();
            this.btnSelecionarProjeto = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.txtComponente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtDataBaseServer = new System.Windows.Forms.TextBox();
            this.txtDataCriacao = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMenus = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtTableExtension = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkPublishUpdatePackage = new System.Windows.Forms.CheckBox();
            this.chkCreateUpdatePackage = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkPublishInstallPackage = new System.Windows.Forms.CheckBox();
            this.chkCreateInstallPackage = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbgProgresso = new System.Windows.Forms.ProgressBar();
            this.lblStatusProgresso = new System.Windows.Forms.Label();
            this.pbgProgressoPrincipal = new System.Windows.Forms.ProgressBar();
            this.btnReleaseNotes = new System.Windows.Forms.Button();
            this.btnDeployQuickStarter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta do Projeto:";
            // 
            // txtFileInstall
            // 
            this.txtFileInstall.Location = new System.Drawing.Point(99, 15);
            this.txtFileInstall.Name = "txtFileInstall";
            this.txtFileInstall.Size = new System.Drawing.Size(430, 20);
            this.txtFileInstall.TabIndex = 1;
            this.txtFileInstall.Text = "K:\\DORIATI_GIT\\JooMob4";
            // 
            // btnSelecionarProjeto
            // 
            this.btnSelecionarProjeto.Location = new System.Drawing.Point(535, 13);
            this.btnSelecionarProjeto.Name = "btnSelecionarProjeto";
            this.btnSelecionarProjeto.Size = new System.Drawing.Size(82, 23);
            this.btnSelecionarProjeto.TabIndex = 2;
            this.btnSelecionarProjeto.Text = "Selecionar";
            this.btnSelecionarProjeto.UseVisualStyleBackColor = true;
            this.btnSelecionarProjeto.Click += new System.EventHandler(this.btnSelecionarProjeto_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDebug.Location = new System.Drawing.Point(3, 3);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(895, 586);
            this.txtDebug.TabIndex = 29;
            // 
            // txtComponente
            // 
            this.txtComponente.Location = new System.Drawing.Point(99, 48);
            this.txtComponente.Name = "txtComponente";
            this.txtComponente.Size = new System.Drawing.Size(155, 20);
            this.txtComponente.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Componente:";
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(99, 155);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(155, 20);
            this.txtDataBaseName.TabIndex = 26;
            // 
            // txtDataBaseServer
            // 
            this.txtDataBaseServer.Location = new System.Drawing.Point(100, 128);
            this.txtDataBaseServer.Name = "txtDataBaseServer";
            this.txtDataBaseServer.Size = new System.Drawing.Size(155, 20);
            this.txtDataBaseServer.TabIndex = 25;
            // 
            // txtDataCriacao
            // 
            this.txtDataCriacao.Location = new System.Drawing.Point(100, 101);
            this.txtDataCriacao.Name = "txtDataCriacao";
            this.txtDataCriacao.Size = new System.Drawing.Size(155, 20);
            this.txtDataCriacao.TabIndex = 24;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(462, 707);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cacelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeploy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeploy.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDeploy.Image = global::DBTools.Properties.Resources.publish;
            this.btnDeploy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeploy.Location = new System.Drawing.Point(797, 707);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(120, 23);
            this.btnDeploy.TabIndex = 22;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.BtnDeploy_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Data Base Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Data Base Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Data de Criação:";
            // 
            // txtVersao
            // 
            this.txtVersao.Location = new System.Drawing.Point(99, 75);
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(155, 20);
            this.txtVersao.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Versão:";
            // 
            // dgvModules
            // 
            this.dgvModules.AllowUserToAddRows = false;
            this.dgvModules.AllowUserToDeleteRows = false;
            this.dgvModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvModules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModules.Location = new System.Drawing.Point(3, 16);
            this.dgvModules.Name = "dgvModules";
            this.dgvModules.ReadOnly = true;
            this.dgvModules.Size = new System.Drawing.Size(880, 135);
            this.dgvModules.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvModules);
            this.groupBox1.Location = new System.Drawing.Point(9, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 154);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Módulos";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvMenus);
            this.groupBox2.Location = new System.Drawing.Point(12, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(883, 154);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menus";
            // 
            // dgvMenus
            // 
            this.dgvMenus.AllowUserToAddRows = false;
            this.dgvMenus.AllowUserToDeleteRows = false;
            this.dgvMenus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMenus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenus.Location = new System.Drawing.Point(3, 16);
            this.dgvMenus.Name = "dgvMenus";
            this.dgvMenus.ReadOnly = true;
            this.dgvMenus.Size = new System.Drawing.Size(877, 135);
            this.dgvMenus.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(909, 618);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTableExtension);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtVersao);
            this.tabPage1.Controls.Add(this.txtComponente);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnSelecionarProjeto);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtFileInstall);
            this.tabPage1.Controls.Add(this.txtDataBaseName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtDataBaseServer);
            this.tabPage1.Controls.Add(this.txtDataCriacao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(901, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Geral";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtTableExtension
            // 
            this.txtTableExtension.Location = new System.Drawing.Point(353, 48);
            this.txtTableExtension.Name = "txtTableExtension";
            this.txtTableExtension.Size = new System.Drawing.Size(155, 20);
            this.txtTableExtension.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Table Extension:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvTables);
            this.groupBox3.Location = new System.Drawing.Point(9, 501);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(883, 85);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabelas";
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTables.Location = new System.Drawing.Point(3, 16);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.Size = new System.Drawing.Size(877, 66);
            this.dgvTables.TabIndex = 30;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(901, 592);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Configurações";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chkPublishUpdatePackage);
            this.groupBox5.Controls.Add(this.chkCreateUpdatePackage);
            this.groupBox5.Location = new System.Drawing.Point(3, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(895, 204);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Atualização";
            // 
            // chkPublishUpdatePackage
            // 
            this.chkPublishUpdatePackage.AutoSize = true;
            this.chkPublishUpdatePackage.Checked = true;
            this.chkPublishUpdatePackage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPublishUpdatePackage.Location = new System.Drawing.Point(6, 42);
            this.chkPublishUpdatePackage.Name = "chkPublishUpdatePackage";
            this.chkPublishUpdatePackage.Size = new System.Drawing.Size(174, 17);
            this.chkPublishUpdatePackage.TabIndex = 2;
            this.chkPublishUpdatePackage.Text = "Publicar Pacote de Atualização";
            this.chkPublishUpdatePackage.UseVisualStyleBackColor = true;
            // 
            // chkCreateUpdatePackage
            // 
            this.chkCreateUpdatePackage.AutoSize = true;
            this.chkCreateUpdatePackage.Checked = true;
            this.chkCreateUpdatePackage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateUpdatePackage.Location = new System.Drawing.Point(6, 19);
            this.chkCreateUpdatePackage.Name = "chkCreateUpdatePackage";
            this.chkCreateUpdatePackage.Size = new System.Drawing.Size(157, 17);
            this.chkCreateUpdatePackage.TabIndex = 1;
            this.chkCreateUpdatePackage.Text = "Criar Pacote de Atualização";
            this.chkCreateUpdatePackage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkPublishInstallPackage);
            this.groupBox4.Controls.Add(this.chkCreateInstallPackage);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(895, 192);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Instalação";
            // 
            // chkPublishInstallPackage
            // 
            this.chkPublishInstallPackage.AutoSize = true;
            this.chkPublishInstallPackage.Checked = true;
            this.chkPublishInstallPackage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPublishInstallPackage.Location = new System.Drawing.Point(6, 42);
            this.chkPublishInstallPackage.Name = "chkPublishInstallPackage";
            this.chkPublishInstallPackage.Size = new System.Drawing.Size(168, 17);
            this.chkPublishInstallPackage.TabIndex = 1;
            this.chkPublishInstallPackage.Text = "Publicar Pacote de Instalação";
            this.chkPublishInstallPackage.UseVisualStyleBackColor = true;
            // 
            // chkCreateInstallPackage
            // 
            this.chkCreateInstallPackage.AutoSize = true;
            this.chkCreateInstallPackage.Checked = true;
            this.chkCreateInstallPackage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateInstallPackage.Location = new System.Drawing.Point(6, 19);
            this.chkCreateInstallPackage.Name = "chkCreateInstallPackage";
            this.chkCreateInstallPackage.Size = new System.Drawing.Size(151, 17);
            this.chkCreateInstallPackage.TabIndex = 0;
            this.chkCreateInstallPackage.Text = "Criar Pacote de Instalação";
            this.chkCreateInstallPackage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDebug);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(901, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pbgProgresso
            // 
            this.pbgProgresso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbgProgresso.Location = new System.Drawing.Point(12, 678);
            this.pbgProgresso.Name = "pbgProgresso";
            this.pbgProgresso.Size = new System.Drawing.Size(905, 23);
            this.pbgProgresso.TabIndex = 34;
            // 
            // lblStatusProgresso
            // 
            this.lblStatusProgresso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatusProgresso.AutoSize = true;
            this.lblStatusProgresso.Location = new System.Drawing.Point(9, 662);
            this.lblStatusProgresso.Name = "lblStatusProgresso";
            this.lblStatusProgresso.Size = new System.Drawing.Size(61, 13);
            this.lblStatusProgresso.TabIndex = 36;
            this.lblStatusProgresso.Text = "Status: ???";
            // 
            // pbgProgressoPrincipal
            // 
            this.pbgProgressoPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbgProgressoPrincipal.Location = new System.Drawing.Point(12, 636);
            this.pbgProgressoPrincipal.Name = "pbgProgressoPrincipal";
            this.pbgProgressoPrincipal.Size = new System.Drawing.Size(905, 23);
            this.pbgProgressoPrincipal.TabIndex = 37;
            // 
            // btnReleaseNotes
            // 
            this.btnReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReleaseNotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleaseNotes.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnReleaseNotes.Image = global::DBTools.Properties.Resources.bloco_de_notas16x16;
            this.btnReleaseNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReleaseNotes.Location = new System.Drawing.Point(543, 707);
            this.btnReleaseNotes.Name = "btnReleaseNotes";
            this.btnReleaseNotes.Size = new System.Drawing.Size(109, 23);
            this.btnReleaseNotes.TabIndex = 38;
            this.btnReleaseNotes.Text = "Release Notes";
            this.btnReleaseNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReleaseNotes.UseVisualStyleBackColor = true;
            this.btnReleaseNotes.Click += new System.EventHandler(this.BtnReleaseNotes_Click);
            // 
            // btnDeployQuickStarter
            // 
            this.btnDeployQuickStarter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeployQuickStarter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeployQuickStarter.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDeployQuickStarter.Location = new System.Drawing.Point(658, 707);
            this.btnDeployQuickStarter.Name = "btnDeployQuickStarter";
            this.btnDeployQuickStarter.Size = new System.Drawing.Size(133, 23);
            this.btnDeployQuickStarter.TabIndex = 39;
            this.btnDeployQuickStarter.Text = "Deploy QuickStart";
            this.btnDeployQuickStarter.UseVisualStyleBackColor = true;
            this.btnDeployQuickStarter.Click += new System.EventHandler(this.BtnDeployQuickStart_Click);
            // 
            // frmJoomlaPacoteInstalacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 742);
            this.Controls.Add(this.btnDeployQuickStarter);
            this.Controls.Add(this.btnReleaseNotes);
            this.Controls.Add(this.pbgProgressoPrincipal);
            this.Controls.Add(this.lblStatusProgresso);
            this.Controls.Add(this.pbgProgresso);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDeploy);
            this.Name = "frmJoomlaPacoteInstalacao";
            this.Text = "Joomla Pacote de Instalação";
            this.Load += new System.EventHandler(this.FrmJoomlaPacoteInstalacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileInstall;
        private System.Windows.Forms.Button btnSelecionarProjeto;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.TextBox txtComponente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.TextBox txtDataBaseServer;
        private System.Windows.Forms.TextBox txtDataCriacao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localizacao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMenus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTableExtension;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar pbgProgresso;
        private System.Windows.Forms.Label lblStatusProgresso;
        private System.Windows.Forms.ProgressBar pbgProgressoPrincipal;
        private System.Windows.Forms.Button btnReleaseNotes;
        private System.Windows.Forms.Button btnDeployQuickStarter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkCreateUpdatePackage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkCreateInstallPackage;
        private System.Windows.Forms.CheckBox chkPublishUpdatePackage;
        private System.Windows.Forms.CheckBox chkPublishInstallPackage;
    }
}