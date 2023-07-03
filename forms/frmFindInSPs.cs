using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBTools.forms
{
    public partial class frmFindInSPs : Form
    {
        public frmFindInSPs()
        {
            InitializeComponent();
        }

        public string TextValue
        {
            get{return txtTexto.Text.Trim();}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;  
            this.Close(); 
        }
    }
}