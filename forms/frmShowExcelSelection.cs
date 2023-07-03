using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace forms
{
    internal partial class frmShowExcelSelection : Form
    {
        private DialogResult m_dialogresult                                     = DialogResult.Cancel;
        private System.Collections.Generic.List<int> m_listColumns              = new List<int>();

        internal DialogResult Dialogresult
        {
            get { return m_dialogresult; }
            set { m_dialogresult = value; }
        }
        internal System.Collections.Generic.List<int> ListColumns
        {
            get { return m_listColumns; }
            set { m_listColumns = value; }
        }
  
        public frmShowExcelSelection(List<string> columns)
        {
            InitializeComponent();

            ListarCampos(columns); 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    ListColumns.Add(int.Parse(lvwCampos.Items[i].Text));
                }

                Dialogresult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dialogresult = DialogResult.Cancel;
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

                for (int i = lvwCampos.SelectedItems.Count; i > 0; i--)
                {
                    lvwCampos.SelectedItems[i-1].Remove();       
                }  
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListarCampos(List<string> columns)
        {
            try
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    
                    item.Text = i.ToString();
                    item.SubItems.Add(columns[i]);
                    
                    lvwCampos.Items.Add(item);   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    lvwCampos.Items[index].Selected             = false;
                    lvwCampos.Items[index-1].Selected           = true; 
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    lvwCampos.Items[index + 1].Text             = strOrigem[0];
                    lvwCampos.Items[index + 1].SubItems[1].Text = strOrigem[1];

                    lvwCampos.Items[index].Selected             = false; 
                    lvwCampos.Items[index + 1].Selected         = true;   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}