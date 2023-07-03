using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LDChartControlPlus;
using System.IO;
using DBTools.classes;
using System.Threading;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms
{
    public partial class frmListGroupQuery : Form
    {
        private string m_objectFrom = string.Empty;
 
        public frmListGroupQuery(object item, SqlObjectsClass so)
        {
            Columns columns = new Columns();

            InitializeComponent();

            if(item is Table)
            {
                Table table = (Table)item; 

                m_objectFrom = table.Name;  

                columns = so.GetColumns(table); 
            }
            else if(item is DBTools.classes.ObjectsClass.View)
            {
                DBTools.classes.ObjectsClass.View view = (DBTools.classes.ObjectsClass.View)item; 

                m_objectFrom = view.Name;  

                columns = so.GetColumns(view); 
            }

            for (int i = 0; i < columns.Count; i++)
            { 
                ArrayList aDados = new ArrayList();  

                bool isDateTime = false;
                Color foreColor = Color.Blue;  

                if(columns[i].DataType.SqlDataType == SqlDataType.DateTime)
                {
                    foreColor   = Color.Maroon; 
                    isDateTime  = true;
                }

                aDados.Add(columns[i].Name);  
                aDados.Add(isDateTime.ToString());

                lvwCampos.Add(aDados, foreColor);  
            }
        }

#region FORM

        private void frmGraficoPlot_Load(object sender, EventArgs e)
        {
            cboTipoValue.SelectedIndex = 0;
            cboWhereType.SelectedIndex = 0; 
        }

#endregion

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

                txtWhere.Text = columnName;  
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread(new ThreadStart(Executar));

                t.IsBackground = true;
                t.Start();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Executar()
        {
            string whereAS              = "";
            string whereColumn          = "";
            string whereType            = "";
            string where                = "";
            string query                = "";
            string queryColumnsSelect   = "";
            string arquivo              = string.Empty; 
            List<string> columnsList    = new List<string>(); 
            List<string> columnsListAs  = new List<string>(); 
            
            try
            {
                Funcoes.ActvButton(ref btnExecutar);

                whereColumn = txtWhere.Text.Trim();   
                whereAS     = txtWhereDescricao.Text.Trim();   

                bool virgula = false;

                for (int i = 0; i < lvwColumns.Items.Count; i++)
                {
                    if(virgula){queryColumnsSelect += ", ";}

                    columnsList.Add(lvwColumns.GetItem(i, 0)); 
                    columnsListAs.Add(lvwColumns.GetItem(i, 1)); 

                    queryColumnsSelect += lvwColumns.GetItem(i, 0);

                    virgula = true;
                }

                if(cboWhereType.SelectedIndex == 6) 
                {
                    whereType = cboWhereType.Text + " '{0}' "; 
                }
                else
                {
                    whereType = cboWhereType.Text + " {0} "; 
                }

                query = "SELECT " + queryColumnsSelect +
                        " FROM " + m_objectFrom +
                        " WHERE " + whereColumn + " " + whereType;

                for (int i = 0; i < lvwWhere.Items.Count; i++)
                {
                    where += " AND ";
                    where += lvwWhere.GetItem(i, 0) + " ";
                }

                query += where; 

                if(txtOrderBy.Text.Trim().Length > 0)
                {
                    query += " ORDER BY " + txtOrderBy.Text.Trim();  
                }

                StringBuilder sb = new StringBuilder();

                if(rdbExportarHtml.Checked)
                {
                    #region Exportar para Html

                    sb.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">" + Environment.NewLine);
                    sb.Append("<html>" + Environment.NewLine);
                    sb.Append("<head>" + Environment.NewLine);
                    sb.Append("<title></title>" + Environment.NewLine);
                    sb.Append("</head>" + Environment.NewLine);
                    sb.Append("<body leftmargin=\"0\" rightmargin=\"0\" bottommargin=\"0\" topmargin=\"0\" marginwidth=\"0\" marginheight=\"0\">" + Environment.NewLine);
                    sb.Append("<P>" + Environment.NewLine);
                    sb.Append("<TABLE id=\"Table12\" height=\"32\" width=\"100%\" bordercolordark=\"#f1f1f1\" bordercolorlight=\"#f1f1f1\" cellspacing=\"0\" cellpadding=\"2\" border=\"1\">" + Environment.NewLine);

                    string columnsNames = "";

                    columnsNames += "<TR>";

                    for (int p = 0; p < columnsListAs.Count; p++)
                    {
                        columnsNames += "<TD bgColor=\"#3399ff\" height=\"19\">" + Environment.NewLine;
                        columnsNames += "<P align=\"left\" style=\"font-size: 10pt\"><FONT class=\"estilo2\" color=\"#ffffff\"><STRONG>" + columnsListAs[p] + "</STRONG></FONT></P>" + Environment.NewLine;
                        columnsNames += "</TD>" + Environment.NewLine;
                    }

                    columnsNames += "</TR>";
                    
                    pgbConsulta.Minimum = 0;
                    pgbConsulta.Maximum = txtWhereValues.Lines.Length-1;
                    pgbConsulta.Value   = 0;

                    for (int i = 0; i < txtWhereValues.Lines.Length; i++)
                    {
                        string value = txtWhereValues.Lines[i].Trim();
                        
                        pgbConsulta.Value = i;

                        if(value.Length <= 0){continue; }
     
                        #region Insere os nomes das colunas

                        sb.Append("<tr >" + Environment.NewLine);
                        sb.Append("<td style=\"color: white; background-color: steelblue; font-weight: bold; font-size: 10pt;\" colspan=\"" + columnsList.Count.ToString() + "\">" + Environment.NewLine);
                        sb.Append(whereAS + ": " + value + "</td>" + Environment.NewLine);
                        sb.Append("</tr>" + Environment.NewLine);
                        sb.Append(columnsNames + Environment.NewLine);

                        #endregion

                        #region Colunas

                        string queryTemp = string.Format(query, value);
                        
                        DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(queryTemp);

                        if(dt.Rows.Count > 0)
                        {
                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                sb.Append("<TR>" + Environment.NewLine);

                                for (int c = 0; c < columnsList.Count; c++)
                                {
                                    string rowValue = dt.Rows[r][columnsList[c]].ToString();
                                    //
                                    //Campo
                                    //
                                    sb.Append("<TD>" + Environment.NewLine);
                                    sb.Append("<P align=\"left\" style=\"font-size: 10pt\"><FONT class=\"estilo1\" color=\"blue\">" + rowValue + "</FONT></P>" + Environment.NewLine);
                                    sb.Append("</TD>" + Environment.NewLine);
                                }

                                sb.Append("</TR>" + Environment.NewLine);
                            }
                        }
                        else
                        {
                            sb.Append("<TR>" + Environment.NewLine);
                            sb.Append("<TD>" + Environment.NewLine);
                            sb.Append("<P align=\"left\" style=\"font-size: 10pt\"><FONT class=\"estilo1\" color=\"red\" colspan=\"" + columnsList.Count.ToString() + "\">Não retornou valor!</FONT></P>" + Environment.NewLine);
                            sb.Append("</TD>" + Environment.NewLine);
                            sb.Append("</TR>" + Environment.NewLine);
                        }

                        #endregion 
                    }

                    sb.Append("</TABLE>" + Environment.NewLine);

                    sb.Append("</P>" + Environment.NewLine);
                    sb.Append("<BR>" + Environment.NewLine);
                    sb.Append("</P>" + Environment.NewLine);
                    sb.Append("</body>" + Environment.NewLine);
                    sb.Append("</html>" + Environment.NewLine);

                    arquivo  = Application.StartupPath + @"\temp.html";

                    #endregion
                }
                else
                {
                    #region Exportar para Excel

                    string tab = "";

                    sb.Append(tab + whereAS);
                    tab = "\t";

                    foreach (string columnName  in columnsListAs)
                    {
                        sb.Append(tab + columnName);
                        tab = "\t";
                    }
                    
                    sb.Append("\n");

                    pgbConsulta.Minimum = 0;
                    pgbConsulta.Maximum = txtWhereValues.Lines.Length-1;
                    pgbConsulta.Value   = 0;

                    for (int i = 0; i < txtWhereValues.Lines.Length; i++)
                    {
                        string value = txtWhereValues.Lines[i].Trim();
                        
                        pgbConsulta.Value = i;

                        if(value.Length <= 0){continue; }

                        #region Colunas

                        string queryTemp = string.Format(query, value);
                        
                        DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(queryTemp);

                        if(dt.Rows.Count > 0)
                        {
                            #region Retornou valor

                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                tab = "";

                                sb.Append(tab + value);
                                tab = "\t";

                                for (int c = 0; c < columnsList.Count; c++)
                                {
                                    string rowValue = dt.Rows[r][columnsList[c]].ToString();
                                    //
                                    //Campo
                                    //
                                    sb.Append(tab + rowValue);
                                    tab = "\t";
                                }

                                sb.Append("\n");
                            }

                            #endregion
                        }
                        else
                        {
                            #region Não retornou valor!

                            tab = "";

                            sb.Append(tab + value);
                            tab = "\t";

                            for (int c = 0; c < columnsList.Count; c++)
                            {
                                //
                                //Campo
                                //
                                sb.Append(tab + "Não retornou valor!");
                                tab = "\t";
                            }

                            sb.Append("\n");

                            #endregion
                        }

                        arquivo  = Application.StartupPath + @"\temp.xls";
                        
                        #endregion  
                    }

                    #endregion
                }

                DLLFuncoes.Funcoes func = new DLLFuncoes.Funcoes();

                func.GravarNoArquivo(arquivo, sb.ToString(), true);

                if (File.Exists(arquivo))
                {
                    Funcoes.ExecuteFile(arquivo, "");
                }
                else
                {
                    MessageBox.Show("Arquivo não foi criado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ActvButton(ref btnExecutar);
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

                aDados.Add(columnName);
                aDados.Add(txtColumnAs.Text.Trim());
                
                lvwColumns.Add(aDados);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void Where_btnRemoverUm_Click(object sender, EventArgs e)
        {
            lvwColumns.SelectedItems[0].Remove();   
        }
        private void Where_btnRemoverTodos_Click(object sender, EventArgs e)
        {
            lvwColumns.Items.Clear();  
        }
        private void cboTipoValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lvwCampos_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = lvwCampos.GetSelectedItem(0);
  
                txtColumnAs.Text = columnName;  
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnOrderByClear_Click(object sender, EventArgs e)
        {
            txtOrderBy.Clear();  
        }
        private void btnOrderBy_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtOrderBy.Text = lvwCampos.GetSelectedItem(0);    
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnInserirUmWhere_Click(object sender, EventArgs e)
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

                aDados.Add(columnName + " " + cboTipoValue.Text + " " + txtValor.Text.Trim());
                
                lvwWhere.Add(aDados);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnRemoverUmWhere_Click(object sender, EventArgs e)
        {
            lvwWhere.SelectedItems[0].Remove(); 
        }
        private void btnRemoverTodosWhere_Click(object sender, EventArgs e)
        {
            lvwWhere.Items.Clear();  
        }
        private void btnSelectRowUp_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwColumns, MoveType.Up);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnSelectRowDown_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwColumns, MoveType.Down);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

#endregion

    }
}
