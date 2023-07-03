namespace DBTools.forms
{
    partial class frmVisualizarSPView
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
            Fireball.Windows.Forms.LineMarginRender lineMarginRender1 = new Fireball.Windows.Forms.LineMarginRender();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarSPView));
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.txtText = new Fireball.Windows.Forms.CodeEditorControl();
            this.syntaxDocument1 = new Fireball.Syntax.SyntaxDocument(this.components);
            this.btnCheckSyntax = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToClipboard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToClipboard.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCopyToClipboard.Image = global::DBTools.Properties.Resources.CopySmall;
            this.btnCopyToClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(478, 429);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(186, 24);
            this.btnCopyToClipboard.TabIndex = 1;
            this.btnCopyToClipboard.Text = "Copiar para Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnExecutar
            // 
            this.btnExecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecutar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecutar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnExecutar.Image = global::DBTools.Properties.Resources.execute;
            this.btnExecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecutar.Location = new System.Drawing.Point(152, 429);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(107, 24);
            this.btnExecutar.TabIndex = 2;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Visible = false;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // txtText
            // 
            this.txtText.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.AutoListPosition = null;
            this.txtText.AutoListSelectedText = "a123";
            this.txtText.AutoListVisible = false;
            this.txtText.CopyAsRTF = false;
            this.txtText.Document = this.syntaxDocument1;
            this.txtText.InfoTipCount = 1;
            this.txtText.InfoTipPosition = null;
            this.txtText.InfoTipSelectedIndex = 1;
            this.txtText.InfoTipVisible = false;
            lineMarginRender1.Bounds = new System.Drawing.Rectangle(19, 0, 19, 16);
            this.txtText.LineMarginRender = lineMarginRender1;
            this.txtText.Location = new System.Drawing.Point(0, 0);
            this.txtText.LockCursorUpdate = false;
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Saved = false;
            this.txtText.ShowScopeIndicator = false;
            this.txtText.Size = new System.Drawing.Size(669, 423);
            this.txtText.SmoothScroll = false;
            this.txtText.SplitviewH = -4;
            this.txtText.SplitviewV = -4;
            this.txtText.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.txtText.TabIndex = 3;
            this.txtText.Text = "codeEditorControl1";
            this.txtText.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // btnCheckSyntax
            // 
            this.btnCheckSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckSyntax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckSyntax.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCheckSyntax.Image = global::DBTools.Properties.Resources.sp_2005_ok;
            this.btnCheckSyntax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckSyntax.Location = new System.Drawing.Point(12, 429);
            this.btnCheckSyntax.Name = "btnCheckSyntax";
            this.btnCheckSyntax.Size = new System.Drawing.Size(134, 24);
            this.btnCheckSyntax.TabIndex = 4;
            this.btnCheckSyntax.Text = "Checar Syntax";
            this.btnCheckSyntax.UseVisualStyleBackColor = true;
            this.btnCheckSyntax.Visible = false;
            this.btnCheckSyntax.Click += new System.EventHandler(this.btnCheckSyntax_Click);
            // 
            // frmVisualizarSPView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 462);
            this.Controls.Add(this.btnCheckSyntax);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizarSPView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnExecutar;
        private Fireball.Windows.Forms.CodeEditorControl txtText;
        private Fireball.Syntax.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.Button btnCheckSyntax;






    }
}