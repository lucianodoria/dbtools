using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBTools.classes;
using System.Collections;
using System.Threading;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms
{
    public partial class frmDeletarRegistrosDuplicados : Form
    {
        private string m_objectFrom = string.Empty;

        public frmDeletarRegistrosDuplicados(object item, SqlObjectsClass so)
        {
            Columns columns = new Columns();

            InitializeComponent();

            Table table = (Table)item; 

            m_objectFrom = table.Name;  

            columns = so.GetColumns(table); 

            for (int i = 0; i < columns.Count; i++)
            { 
                ArrayList aDados = new ArrayList();  

                Color foreColor = Color.Blue;  

                aDados.Add(columns[i].Name);  
                aDados.Add((int)columns[i].DataType.SqlDataType);

                lvwCampos.Add(aDados, foreColor);  
            }
        }

        private void frmDeletarRegistrosDuplicados_Load(object sender, EventArgs e)
        {

        }

#region EVENTOS
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                //Thread t = new Thread(new ThreadStart(Deletar));

                //t.IsBackground = true;
                //t.Start();

                Deletar();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void Deletar()
        {
            string query        = string.Empty;
            string stringFormat = string.Empty;
            string columnDupli  = string.Empty;
            string columnWhere  = string.Empty;
            SqlDataType sqlDataTypeDuplic = new SqlDataType(); 
            SqlDataType sqlDataTypeWhere = new SqlDataType(); 

            try
            {
                if(txtColunaDuplicada.Tag == null)
                {
                    MessageBox.Show("Informe a coluna duplicada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if(txtColunaWhere.Tag == null)
                {
                    MessageBox.Show("Informe a coluna Where!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                columnDupli         = txtColunaDuplicada.Text;
                sqlDataTypeDuplic   = (SqlDataType)Convert.ToInt32(txtColunaDuplicada.Tag);

                columnWhere         = txtColunaWhere.Text;
                sqlDataTypeWhere   = (SqlDataType)Convert.ToInt32(txtColunaWhere.Tag);

                switch (sqlDataTypeDuplic)
                {
                    case SqlDataType.BigInt:
                    case SqlDataType.Binary:
                    case SqlDataType.Bit:
                    case SqlDataType.Decimal:
                    case SqlDataType.Float:
                    case SqlDataType.Int:
                    case SqlDataType.Money:
                    case SqlDataType.Numeric:
                    case SqlDataType.Real:
                    case SqlDataType.SmallInt:
                    case SqlDataType.SmallMoney:
                    case SqlDataType.VarBinary:
                    case SqlDataType.VarBinaryMax:
                        {
                            stringFormat = "SELECT TOP {0} {1} FROM {2} WHERE {3}={4}";
                            break;
                        }
                    case SqlDataType.Char:
                    case SqlDataType.DateTime:
                    case SqlDataType.NChar:
                    case SqlDataType.NText:
                    case SqlDataType.NVarChar:
                    case SqlDataType.NVarCharMax:
                    case SqlDataType.SmallDateTime:
                    case SqlDataType.SysName:
                    case SqlDataType.Text:
                    case SqlDataType.Timestamp:
                    case SqlDataType.TinyInt:
                    case SqlDataType.UniqueIdentifier:
                    case SqlDataType.VarChar:
                    case SqlDataType.VarCharMax:
                    case SqlDataType.Variant:
                    case SqlDataType.Xml:
                        {
                            stringFormat = "SELECT TOP {0} {1},{3} FROM {2} WHERE {3}='{4}'";
                            break;
                        }
                    default:
                        {
                            stringFormat = "SELECT TOP {0} {1},{3} FROM {2} WHERE {3}='{4}'";
                            break;
                        }
                }

                query = string.Format("SELECT {0}, COUNT(*) AS total FROM {1}" + 
                                      " GROUP BY {0} HAVING COUNT(*) > 1", columnDupli, m_objectFrom);
  
                DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query);

                pgbRegistros.Maximum    = dt.Rows.Count-1;
                pgbRegistros.Minimum    = 0;
                pgbRegistros.Value      = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pgbRegistros.Value = i;

                    string  valorCodigo     = dt.Rows[i][columnDupli].ToString();
                    int     total           = Convert.ToInt32(dt.Rows[i]["total"])-1;

                    query = string.Format(stringFormat, total, columnWhere, m_objectFrom, columnDupli, valorCodigo);

                    DataTable dtDuplicado = Funcoes.FormMain.SqlSmoTools.Query(query);

                    for (int r = 0; r < dtDuplicado.Rows.Count; r++)
                    {
                        long idValor = Convert.ToInt64(dtDuplicado.Rows[r][columnWhere]);

                        string sqlCommand = string.Format("DELETE {0} WHERE {1}={2}", m_objectFrom, columnWhere, idValor);    

                        Funcoes.FormMain.SqlSmoTools.ExecuteNonQuery(sqlCommand);
                    }
                }

                MessageBox.Show("Finalizado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void btnColunaDuplicadadaAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtColunaDuplicada.Clear(); 
                txtColunaDuplicada.Tag      = null;

                if(lvwCampos.SelectedItemCount <= 0)
                {
                    MessageBox.Show("Selecione uma coluna!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtColunaDuplicada.Text = lvwCampos.GetSelectedItem(0);
                txtColunaDuplicada.Tag  = lvwCampos.GetSelectedItem(1);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnColunaWhereAdd_Click(object sender, EventArgs e)
        {
            bool isNumeric = false;

            try
            {
                txtColunaWhere.Clear(); 
                txtColunaWhere.Tag      = null;

                if(lvwCampos.SelectedItemCount <= 0)
                {
                    MessageBox.Show("Selecione uma coluna!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SqlDataType sqlDataTypeWhere   = (SqlDataType)int.Parse(lvwCampos.GetSelectedItem(1));

                switch (sqlDataTypeWhere)
                {
                    case SqlDataType.BigInt:
                    case SqlDataType.Binary:
                    case SqlDataType.Bit:
                    case SqlDataType.Decimal:
                    case SqlDataType.Float:
                    case SqlDataType.Int:
                    case SqlDataType.Money:
                    case SqlDataType.Numeric:
                    case SqlDataType.Real:
                    case SqlDataType.SmallInt:
                    case SqlDataType.SmallMoney:
                    case SqlDataType.VarBinary:
                    case SqlDataType.VarBinaryMax:
                        {
                            isNumeric = true;
                            break;
                        }
                    default:
                        {
                            isNumeric = false;
                            break;
                        }
                }

                if(isNumeric == false)
                {
                    MessageBox.Show("A coluna Where tem ser do tipo númerico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtColunaWhere.Text     = lvwCampos.GetSelectedItem(0);
                txtColunaWhere.Tag      = lvwCampos.GetSelectedItem(1);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
 #endregion



    }
}
