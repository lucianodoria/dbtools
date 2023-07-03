using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CriadorBlocoCodigo
{
    public partial class frmComando : Form
    {
        internal DialogResult dialogresult  = DialogResult.Cancel;
        internal List<string> campos_select = new List<string>();
        internal List<string> campos_where  = new List<string>(); 

        public frmComando()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ArrayList aDados = new ArrayList();

            aDados.Add(" ");
            aDados.Add(lvwCampos.SelectedItems[0].SubItems[1].Text);

            lvwSelect.Add(aDados);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int cod = int.Parse(lvwCampos.GetSelectedItem(2)); 

            ArrayList aDados = new ArrayList();
 
            aDados.Add(" ");
            aDados.Add(lvwCampos.GetSelectedItem(1) + PegaTipoOperador(cod));

            lvwWhere.Add(aDados);  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (lvwSelect.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo [Select]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvwSelect.SelectedItems[0].Remove();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvwWhere.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo [Where]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvwWhere.SelectedItems[0].Remove();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    aDados.Add(" ");
                    aDados.Add(lvwCampos.Items[i].SubItems[1].Text);

                    lvwSelect.Add(aDados);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    aDados.Add(" ");
                    aDados.Add(lvwCampos.Items[i].SubItems[1].Text);

                    lvwWhere.Add(aDados);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                lvwSelect.Items.Clear(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lvwWhere.Items.Clear(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lvwSelect.Items.Count; i++)
            {
                campos_select.Add(lvwSelect.Items[i].SubItems[1].Text);    
            }

            for (int i = 0; i < lvwWhere.Items.Count; i++)
            {
                campos_where.Add(lvwWhere.Items[i].SubItems[1].Text);
            }

            dialogresult = DialogResult.OK;    
            this.Close(); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dialogresult = DialogResult.Cancel; 
            this.Close(); 
        }

        private string PegaTipoOperador(int cod)
        {
            try
            {
                string tipoDado = string.Empty;

                switch (cod)
                {
                    case 34:// image
                        {
                            tipoDado = "?";
                            break;
                        }
                    case 35:// text
                    case 99:// ntext
                    case 167:// varchar
                    case 175:// char
                    case 231:// nvarchar
                    case 239:// nchar
                        {
                            tipoDado = " like '%%'";
                            break;
                        }
                    case 36:// uniqueidentifier
                        {
                            tipoDado = "?";
                            break;
                        }
                    case 48:// tinyint
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 52:// smallint
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 56:// int
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 61:// datetime
                    case 58:// smalldatetime
                        {
                            tipoDado = " >= '" + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")+ "'";
                            break;
                        }
                    case 59:// real
                    case 60:// money
                    case 106:// decimal
                    case 122:// smallmoney
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 62:// float
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 98:// sql_variant
                        {
                            tipoDado = "?";
                            break;
                        }
                    case 104:// bit
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 108:// numeric
                    case 127:// bigint
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 165:// varbinary
                    case 173:// binary
                        {
                            tipoDado = " =";
                            break;
                        }
                    case 189:// timestamp
                        {
                            tipoDado = "?";
                            break;
                        }
                }

                return tipoDado;
            }
            catch
            {
                return "Erro!";
            }
        }
    }
}