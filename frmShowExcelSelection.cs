using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CriadorBlocoCodigo
{
    public partial class frmShowExcelSelection : Form
    {
        internal DialogResult dialogresult = DialogResult.Cancel;
        internal System.Collections.Generic.List<int> lstColumns = new List<int>();  
        internal System.Windows.Forms.ListView  objListViewPlus = null;
  
        public frmShowExcelSelection()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    lstColumns.Add(int.Parse(lvwCampos.Items[i].Text));    
                }
                
                dialogresult = DialogResult.OK;
                this.Close(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dialogresult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if(lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo primeiro!",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                lvwCampos.SelectedItems[0].Remove();      
            }
            catch (Exception exc)
            {
                                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListarCampos()
        {
            try
            {
                for (int i = 0; i < objListViewPlus.Columns.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    
                    item.Text = i.ToString();
                    item.SubItems.Add(objListViewPlus.Columns[i].Text);
                    
                    lvwCampos.Items.Add(item);   
                }
            }
            catch (Exception exc)
            {
                                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmShowExcelSelection_Load(object sender, EventArgs e)
        {
            ListarCampos();
        }

        private void lvwCampos_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete){btnRemover_Click(null, null);}
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if(lvwCampos.SelectedItems[0].Index > 0)
                {
                    int index = lvwCampos.SelectedItems[0].Index;
 
                    string[] strOrigem  = {lvwCampos.Items[index].Text,lvwCampos.Items[index].SubItems[1].Text};
                    string[] strDestino = { lvwCampos.Items[index-1].Text, lvwCampos.Items[index-1].SubItems[1].Text };

                    lvwCampos.Items[index].Text             = strDestino[0];
                    lvwCampos.Items[index].SubItems[1].Text = strDestino[1];

                    lvwCampos.Items[index-1].Text               = strOrigem[0];
                    lvwCampos.Items[index-1].SubItems[1].Text   = strOrigem[1];

                    lvwCampos.Items[index-1].Selected = true; 
                }
            }
            catch (Exception exc)
            {
                                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo primeiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lvwCampos.SelectedItems[0].Index < lvwCampos.Items.Count-1)
                {
                    int index = lvwCampos.SelectedItems[0].Index;

                    string[] strOrigem = { lvwCampos.Items[index].Text, lvwCampos.Items[index].SubItems[1].Text };
                    string[] strDestino = { lvwCampos.Items[index + 1].Text, lvwCampos.Items[index + 1].SubItems[1].Text };

                    lvwCampos.Items[index].Text = strDestino[0];
                    lvwCampos.Items[index].SubItems[1].Text = strDestino[1];

                    lvwCampos.Items[index + 1].Text = strOrigem[0];
                    lvwCampos.Items[index + 1].SubItems[1].Text = strOrigem[1];

                    lvwCampos.Items[index + 1].Selected = true;   
                }
            }
            catch (Exception exc)
            {
                                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}