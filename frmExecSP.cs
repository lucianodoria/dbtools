using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CriadorBlocoCodigo
{
	public class frmExecSP : System.Windows.Forms.Form
	{
		internal bool blnExecutar = false;
		private System.Windows.Forms.Button btnExecutar;
		internal System.Windows.Forms.DataGrid dg;

		private System.ComponentModel.Container components = null;

		public frmExecSP()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnExecutar = new System.Windows.Forms.Button();
			this.dg = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.SuspendLayout();
			// 
			// btnExecutar
			// 
			this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnExecutar.Location = new System.Drawing.Point(352, 240);
			this.btnExecutar.Name = "btnExecutar";
			this.btnExecutar.Size = new System.Drawing.Size(112, 23);
			this.btnExecutar.TabIndex = 0;
			this.btnExecutar.Text = "&Executar";
			this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
			// 
			// dg
			// 
			this.dg.AllowNavigation = false;
			this.dg.AllowSorting = false;
			this.dg.CaptionVisible = false;
			this.dg.DataMember = "";
			this.dg.Dock = System.Windows.Forms.DockStyle.Top;
			this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dg.Location = new System.Drawing.Point(0, 0);
			this.dg.Name = "dg";
			this.dg.PreferredColumnWidth = 180;
			this.dg.Size = new System.Drawing.Size(472, 232);
			this.dg.TabIndex = 1;
			// 
			// frmExecSP
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 272);
			this.Controls.Add(this.dg);
			this.Controls.Add(this.btnExecutar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmExecSP";
			this.Text = "Executar Procedure: ";
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExecutar_Click(object sender, System.EventArgs e)
		{
			blnExecutar = true;
			this.Close(); 
		}
	}
}
