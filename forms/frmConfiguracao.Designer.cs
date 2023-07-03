namespace DBTools.forms
{
    partial class frmConfiguracao
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkVisualizarTiposDadosColumasTabela = new System.Windows.Forms.CheckBox();
            this.chkVisualizarFKNaTabela = new System.Windows.Forms.CheckBox();
            this.chkNaoVisualizarTabelasDoSistema = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkVisualizarTiposDadosParametrosSP = new System.Windows.Forms.CheckBox();
            this.chkNaoVisualizarSPsDoSistema = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkVisualizarTiposDadosColumasView = new System.Windows.Forms.CheckBox();
            this.chkNaoVisualizarViewsDoSistema = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkVisualizarTiposDadosColumasTabela);
            this.groupBox6.Controls.Add(this.chkVisualizarFKNaTabela);
            this.groupBox6.Controls.Add(this.chkNaoVisualizarTabelasDoSistema);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(369, 86);
            this.groupBox6.TabIndex = 42;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Configurações das Tabelas";
            // 
            // chkVisualizarTiposDadosColumasTabela
            // 
            this.chkVisualizarTiposDadosColumasTabela.AutoSize = true;
            this.chkVisualizarTiposDadosColumasTabela.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisualizarTiposDadosColumasTabela.Location = new System.Drawing.Point(11, 66);
            this.chkVisualizarTiposDadosColumasTabela.Name = "chkVisualizarTiposDadosColumasTabela";
            this.chkVisualizarTiposDadosColumasTabela.Size = new System.Drawing.Size(155, 17);
            this.chkVisualizarTiposDadosColumasTabela.TabIndex = 2;
            this.chkVisualizarTiposDadosColumasTabela.Text = "Visualizar tipos das colunas";
            this.chkVisualizarTiposDadosColumasTabela.UseVisualStyleBackColor = true;
            // 
            // chkVisualizarFKNaTabela
            // 
            this.chkVisualizarFKNaTabela.AutoSize = true;
            this.chkVisualizarFKNaTabela.Checked = true;
            this.chkVisualizarFKNaTabela.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisualizarFKNaTabela.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisualizarFKNaTabela.Location = new System.Drawing.Point(11, 43);
            this.chkVisualizarFKNaTabela.Name = "chkVisualizarFKNaTabela";
            this.chkVisualizarFKNaTabela.Size = new System.Drawing.Size(147, 17);
            this.chkVisualizarFKNaTabela.TabIndex = 1;
            this.chkVisualizarFKNaTabela.Text = "Visualizar FK e sua tabela";
            this.chkVisualizarFKNaTabela.UseVisualStyleBackColor = true;
            // 
            // chkNaoVisualizarTabelasDoSistema
            // 
            this.chkNaoVisualizarTabelasDoSistema.AutoSize = true;
            this.chkNaoVisualizarTabelasDoSistema.Checked = true;
            this.chkNaoVisualizarTabelasDoSistema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoVisualizarTabelasDoSistema.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNaoVisualizarTabelasDoSistema.Location = new System.Drawing.Point(11, 20);
            this.chkNaoVisualizarTabelasDoSistema.Name = "chkNaoVisualizarTabelasDoSistema";
            this.chkNaoVisualizarTabelasDoSistema.Size = new System.Drawing.Size(184, 17);
            this.chkNaoVisualizarTabelasDoSistema.TabIndex = 0;
            this.chkNaoVisualizarTabelasDoSistema.Text = "Não visualizar tabelas do sistema";
            this.chkNaoVisualizarTabelasDoSistema.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkVisualizarTiposDadosParametrosSP);
            this.groupBox5.Controls.Add(this.chkNaoVisualizarSPsDoSistema);
            this.groupBox5.Location = new System.Drawing.Point(7, 177);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(374, 63);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Configurações das Stored Procedures";
            // 
            // chkVisualizarTiposDadosParametrosSP
            // 
            this.chkVisualizarTiposDadosParametrosSP.AutoSize = true;
            this.chkVisualizarTiposDadosParametrosSP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisualizarTiposDadosParametrosSP.Location = new System.Drawing.Point(11, 43);
            this.chkVisualizarTiposDadosParametrosSP.Name = "chkVisualizarTiposDadosParametrosSP";
            this.chkVisualizarTiposDadosParametrosSP.Size = new System.Drawing.Size(174, 17);
            this.chkVisualizarTiposDadosParametrosSP.TabIndex = 4;
            this.chkVisualizarTiposDadosParametrosSP.Text = "Visualizar tipos dos parâmetros";
            this.chkVisualizarTiposDadosParametrosSP.UseVisualStyleBackColor = true;
            // 
            // chkNaoVisualizarSPsDoSistema
            // 
            this.chkNaoVisualizarSPsDoSistema.AutoSize = true;
            this.chkNaoVisualizarSPsDoSistema.Checked = true;
            this.chkNaoVisualizarSPsDoSistema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoVisualizarSPsDoSistema.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNaoVisualizarSPsDoSistema.Location = new System.Drawing.Point(11, 20);
            this.chkNaoVisualizarSPsDoSistema.Name = "chkNaoVisualizarSPsDoSistema";
            this.chkNaoVisualizarSPsDoSistema.Size = new System.Drawing.Size(166, 17);
            this.chkNaoVisualizarSPsDoSistema.TabIndex = 0;
            this.chkNaoVisualizarSPsDoSistema.Text = "Não visualizar SPs do sistema";
            this.chkNaoVisualizarSPsDoSistema.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkVisualizarTiposDadosColumasView);
            this.groupBox3.Controls.Add(this.chkNaoVisualizarViewsDoSistema);
            this.groupBox3.Location = new System.Drawing.Point(12, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 67);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurações das Views";
            // 
            // chkVisualizarTiposDadosColumasView
            // 
            this.chkVisualizarTiposDadosColumasView.AutoSize = true;
            this.chkVisualizarTiposDadosColumasView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisualizarTiposDadosColumasView.Location = new System.Drawing.Point(11, 43);
            this.chkVisualizarTiposDadosColumasView.Name = "chkVisualizarTiposDadosColumasView";
            this.chkVisualizarTiposDadosColumasView.Size = new System.Drawing.Size(155, 17);
            this.chkVisualizarTiposDadosColumasView.TabIndex = 3;
            this.chkVisualizarTiposDadosColumasView.Text = "Visualizar tipos das colunas";
            this.chkVisualizarTiposDadosColumasView.UseVisualStyleBackColor = true;
            // 
            // chkNaoVisualizarViewsDoSistema
            // 
            this.chkNaoVisualizarViewsDoSistema.AutoSize = true;
            this.chkNaoVisualizarViewsDoSistema.Checked = true;
            this.chkNaoVisualizarViewsDoSistema.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoVisualizarViewsDoSistema.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNaoVisualizarViewsDoSistema.Location = new System.Drawing.Point(11, 20);
            this.chkNaoVisualizarViewsDoSistema.Name = "chkNaoVisualizarViewsDoSistema";
            this.chkNaoVisualizarViewsDoSistema.Size = new System.Drawing.Size(176, 17);
            this.chkNaoVisualizarViewsDoSistema.TabIndex = 0;
            this.chkNaoVisualizarViewsDoSistema.Text = "Não visualizar views do sistema";
            this.chkNaoVisualizarViewsDoSistema.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(301, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(220, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 289);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguracao";
            this.Text = "Configurações";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkVisualizarTiposDadosColumasTabela;
        private System.Windows.Forms.CheckBox chkVisualizarFKNaTabela;
        private System.Windows.Forms.CheckBox chkNaoVisualizarTabelasDoSistema;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkVisualizarTiposDadosParametrosSP;
        private System.Windows.Forms.CheckBox chkNaoVisualizarSPsDoSistema;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkVisualizarTiposDadosColumasView;
        private System.Windows.Forms.CheckBox chkNaoVisualizarViewsDoSistema;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}