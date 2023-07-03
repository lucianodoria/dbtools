using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LDChartControlPlus;
using System.Data.SqlClient;
using DBTools.classes;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms.graficos
{
    public partial class frmGraficoPizza : Form
    {
        private string      m_objectName    = string.Empty;
        private SqlDataType m_sqlDataType   = SqlDataType.VarChar; 
 
        public frmGraficoPizza(object item, SqlObjectsClass so)
        {
            InitializeComponent();

            Columns columns = new Columns(); 

            ArrayList aDados = new ArrayList();  

            if(item is Table)
            {
                Table table = (Table)item; 

                m_objectName = table.Name;  

                columns = so.GetColumns(table); 
            }
            else if(item is DBTools.classes.ObjectsClass.View)
            {
               DBTools.classes.ObjectsClass.View view = (DBTools.classes.ObjectsClass.View)item; 

                m_objectName = view.Name;  

                columns = so.GetColumns(view);   
            }

            for (int i = 0; i < columns.Count; i++)
            { 
                aDados.Add(columns[i].Name);  
                aDados.Add(((int)columns[i].DataType.SqlDataType));

                lvwCampos.Add(aDados);  

                aDados.Clear(); 
            }
        }

#region EVENTOS

        private void Select_btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string columnName = lvwCampos.GetSelectedItem(0);

                txtSelect.Text = columnName;
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void frmGraficoPizza_Load(object sender, EventArgs e)
        {
            cboTipoValue.SelectedIndex = 0; 
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            string select       = "";
            string where        = "";
            string query_temp   = "SELECT {0}, COUNT(*) AS total FROM {1} {2} GROUP BY {0} ORDER BY total";
            string query        = "";

            try
            {
                Funcoes.ActvButton(ref btnFill);

                select = " [" + txtSelect.Text + "] ";  

                bool and = false;

                if(lvwWhere.Items.Count > 0){ where += " WHERE ";}

                for (int i = 0; i < lvwWhere.Items.Count; i++)
                {
                    if (and) { where += " AND "; }

                    where += " " + lvwWhere.GetItem(i, 0) + " ";

                    and = true;
                }

                query = string.Format(query_temp, select, m_objectName, where);

                DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query);

                List<Pie.PieItem> lstPieItem = new List<Pie.PieItem>();

                // apaga os valores já inseridos
                msChartPie.Series[0].Points.Clear(); 

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string  descricao   = dt.Rows[i][0].ToString().Trim();
                    int     total       = Convert.ToInt32(dt.Rows[i]["total"]);

                    Pie.PieItem pieItem = new Pie.PieItem();

                    if (chkPizzaSiglaNome.Checked)
                    {
                        pieItem.Label = Funcoes.GetSiglaFromName(descricao);
                    }
                    else
                    {
                        pieItem.Label = descricao;
                    }

                    if (chkPizzaMostrarTotal.Checked)
                    {
                        pieItem.Label += "(" + total.ToString() + ")";
                    }

                    pieItem.Value = total;

                    msChartPie.Series[0].Points.AddY(total);  
                    msChartPie.Series[0].Points[i].LegendText = descricao + "(#VAL)";

                    lstPieItem.Add(pieItem);
                }

                piePizza.AddPieItems(lstPieItem);

                tbcGrafico.SelectedIndex = 2;
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ActvButton(ref btnFill);
            }
        }
        private void Where_btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string columnName = lvwCampos.GetSelectedItem(0);

                ArrayList aDados = new ArrayList();

                if(m_sqlDataType == SqlDataType.SmallDateTime ||
                   m_sqlDataType == SqlDataType.DateTime ||
                   m_sqlDataType == SqlDataType.Timestamp)
                {
                    aDados.Add(columnName + " " + cboTipoValue.Text + " '" + dtpValor.Value.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }
                else
                {
                    aDados.Add(columnName + " " + cboTipoValue.Text + " " + txtValor.Text.Trim());
                }

                lvwWhere.Add(aDados);
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Where_btnRemoverUm_Click(object sender, EventArgs e)
        {
            try
            {
                lvwWhere.SelectedItems[0].Remove(); 
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Where_btnRemoverTodos_Click(object sender, EventArgs e)
        {
            lvwWhere.Items.Clear();
        }

#endregion

        private void cboTipoValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipoValue.Text)
            {
                //case "=":
                //case ">": 
                //case "<":
                //case "<>":
                //case ">=":
                //case "<=":
                //case "LIKE":
                //case "IN":
                //case "NOT IN":
                //    {
                //        txtValor.ReadOnly = false; 
                //        break;
                //    }
                case "IS NULL":
                case "IS NOT NULL":
                    {
                        txtValor.Clear(); 
                        txtValor.ReadOnly = true; 
                        break;
                    }
                default:
                    {
                        txtValor.ReadOnly = false; 
                        break;
                    }
            }
        }

        private void lvwCampos_Click(object sender, EventArgs e)
        {
            try
            {
                dtpValor.Visible = false;
                txtValor.Visible = false;
 
                int dataType = int.Parse(lvwCampos.GetSelectedItem(1));

                m_sqlDataType = (SqlDataType)dataType;

                if(m_sqlDataType == SqlDataType.SmallDateTime ||
                   m_sqlDataType == SqlDataType.DateTime ||
                   m_sqlDataType == SqlDataType.Timestamp)
                {
                    dtpValor.Visible = true;
                }
                else
                {
                    txtValor.Visible = true;
                }
            }
            catch (Microsoft.SqlServer.Management.Smo.SmoException smoExc)
            {
                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            } 
        }

        private void msChartPie_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(msChartPie.Width, msChartPie.Height);     

                msChartPie.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));    
                
                Clipboard.SetImage(bmp);

                MessageBox.Show("Imagem salva no clipboard do Windows." +
                                "\n\nObs: para colar basta clicar Ctrl+V.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }

        }

        private void txtTituloMSChart_TextChanged(object sender, EventArgs e)
        {
            msChartPie.Titles[0].Text = txtTituloMSChart.Text;    
        }

    }
}
