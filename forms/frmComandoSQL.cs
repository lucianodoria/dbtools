using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace DBTools
{
    public partial class frmComandoSQL : Form
    {
        private struct ColumnsOrigem
	    {
            //length
            public const int Length     = 0;
            public const int ColumnName = 1;
		    public const int DataType   = 2;
	    }
        private struct ColumnsSelect
	    {
		    public const int DataType   = 0;
            public const int ColumnName = 1;
	    }
        private struct ColumnsWhere
	    {
		    public const int DataType   = 0;
            public const int ColumnName = 1;
	    }
        private struct ColumnsOrderBy
	    {
            public const int ColumnName = 1;
	    }
        public enum CommandType
        {
            SELECT              = 0,
            UPDATE              = 1,
            INSERT              = 2,
            DELETE              = 3,
            CREATE_SP_SELECT    = 4,
            CREATE_SP_INSERT    = 5,
            CREATE_SP_UPDATE    = 6,
            CREATE_SP_DELETE    = 7
        }

        private List<string>    m_camposSelect         = new List<string>();
        private List<string>    m_camposWhere          = new List<string>();
        private List<string>    m_camposSelectDataType = new List<string>();
        private List<string>    m_camposWhereDataType  = new List<string>();
        private List<string>    m_camposOrderBy        = new List<string>();
        private CommandType     m_commandType          = new CommandType();
        private int             m_topQuery              = 0;

        public int TopQuery
        {
            get { return m_topQuery; }
            set { m_topQuery = value; }
        }
        internal List<string> CamposSelect
        {
            get { return m_camposSelect; }
            set { m_camposSelect = value; }
        }
        public List<string> CamposSelectDataType
        {
            get { return m_camposSelectDataType; }
            set { m_camposSelectDataType = value; }
        }
        internal List<string> CamposWhere
        {
            get { return m_camposWhere; }
            set { m_camposWhere = value; }
        }
        public List<string> CamposWhereDataType
        {
            get { return m_camposWhereDataType; }
            set { m_camposWhereDataType = value; }
        }
        internal List<string> CamposOrderBy
        {
            get { return m_camposOrderBy; }
            set { m_camposOrderBy = value; }
        }

        public frmComandoSQL(CommandType commandType)
        {
            m_commandType = commandType;
 
            InitializeComponent();

            switch (m_commandType)
            {
                case CommandType.INSERT:
                case CommandType.CREATE_SP_INSERT:
                    {
                        lblTop.Visible      = false;
                        txtTop.Visible      = false;
                        gpbWhere.Enabled    = false; 
                        gpbOrderBy.Enabled  = false;
                        gpbSelect.Text      = "INSERT";
                        break;
                    }
                case CommandType.UPDATE:
                    {
                        lblTop.Visible      = false;
                        txtTop.Visible      = false;
                        gpbOrderBy.Enabled  = false;
                        break;
                    }
                case CommandType.DELETE:
                    {
                        lblTop.Visible      = false;
                        txtTop.Visible      = false;
                        gpbSelect.Enabled   = false;
                        gpbOrderBy.Enabled  = false; 
                        break;
                    }
               case CommandType.CREATE_SP_SELECT:
                    {
                        Where_lblValor.Visible  = false;
                        dtpValor.Visible        = false;
                        txtValor.Visible        = false;
                        break;
                    }
                case CommandType.CREATE_SP_UPDATE:
                    {
                        lblTop.Visible          = false;
                        txtTop.Visible          = false;
                        Where_lblValor.Visible  = false;
                        dtpValor.Visible        = false;
                        txtValor.Visible        = false;
                        gpbOrderBy.Enabled      = false;
                        gpbSelect.Text          = "UPDATE";
                        break;
                    }
                case CommandType.CREATE_SP_DELETE:
                    {
                        Where_lblValor.Visible  = false;
                        dtpValor.Visible        = false;
                        txtValor.Visible        = false;
                        lblTop.Visible          = false;
                        txtTop.Visible          = false;
                        gpbSelect.Enabled       = false;
                        gpbOrderBy.Enabled      = false;
                        gpbSelect.Text          = "DELETE";
                        break;
                    }
            }

            cboOrderByType.SelectedIndex = 0;
        }

        private void Select_btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCampos.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string columnName = lvwCampos.GetSelectedItem(ColumnsOrigem.ColumnName);

                if (lvwSelect.ItemExist(columnName, ColumnsOrigem.ColumnName)) { return; }
                if (columnName == "*" && lvwSelect.Items.Count > 0) { return; }
                if (lvwSelect.ItemExist("*", ColumnsOrigem.ColumnName)) { return; }

                ArrayList aDados = new ArrayList();

                aDados.Add(Funcoes.GetDataType(lvwCampos.GetSelectedItem(ColumnsOrigem.DataType), int.Parse(lvwCampos.GetSelectedItem(ColumnsOrigem.Length))));
                aDados.Add(columnName);

                lvwSelect.Add(aDados);
            }
            catch (SmoException smoExc)
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
        private void Where_btnInserirUm_Click(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string columnName   = lvwCampos.GetSelectedItem(ColumnsOrigem.ColumnName);
            string dataType     = lvwCampos.GetSelectedItem(ColumnsOrigem.DataType); 

            if(columnName == "*"){return;}

            ArrayList aDados = new ArrayList();

            aDados.Add(Funcoes.GetDataType(dataType, int.Parse(lvwCampos.GetSelectedItem(ColumnsOrigem.Length))));

            if (m_commandType == CommandType.CREATE_SP_INSERT ||
                m_commandType == CommandType.CREATE_SP_UPDATE ||
                m_commandType == CommandType.CREATE_SP_DELETE ||
                m_commandType == CommandType.CREATE_SP_SELECT)
            {
                aDados.Add(columnName);
            }
            else
            {
                aDados.Add(columnName + PegaTipoOperador(dataType));
            }

            lvwWhere.Add(aDados);  
        }
        private void Select_btnRemoverUm_Click(object sender, EventArgs e)
        {
            if (lvwSelect.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo [Select]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvwSelect.SelectedItems[0].Remove();
        }
        private void Where_btnRemoverUm_Click(object sender, EventArgs e)
        {
            if (lvwWhere.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo [Where]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvwWhere.SelectedItems[0].Remove();
        }
        private void Select_btnInserirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                lvwSelect.Items.Clear();
  
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    string columnName = lvwCampos.GetItem(i, ColumnsOrigem.ColumnName);

                    if(columnName == "*"){continue;}
                    if(lvwSelect.ItemExist(columnName, ColumnsOrigem.ColumnName)){continue;} 
                    if(lvwSelect.ItemExist("*", ColumnsOrigem.ColumnName)){return;}

                    ArrayList aDados = new ArrayList();

                    aDados.Add(Funcoes.GetDataType(lvwCampos.GetItem(i, ColumnsOrigem.DataType), int.Parse(lvwCampos.GetItem(i, ColumnsOrigem.Length))));
                    aDados.Add(columnName);

                    lvwSelect.Add(aDados);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Where_btnInserirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    aDados.Add(Funcoes.GetDataType(lvwCampos.GetItem(i, 2), int.Parse(lvwCampos.GetItem(i, 0))));

                    if (m_commandType == CommandType.CREATE_SP_INSERT ||
                        m_commandType == CommandType.CREATE_SP_UPDATE ||
                        m_commandType == CommandType.CREATE_SP_DELETE ||
                        m_commandType == CommandType.CREATE_SP_SELECT)
                    {
                        aDados.Add(lvwCampos.GetItem(i, 1));
                    }
                    else
                    {
                        aDados.Add(lvwCampos.GetItem(i, 1) + PegaTipoOperador(lvwCampos.GetItem(i, 2)));
                    }

                    lvwWhere.Add(aDados);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Select_btnRemoverTodos_Click(object sender, EventArgs e)
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
        private void Where_btnRemoverTodos_Click(object sender, EventArgs e)
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
            try
            {
                for (int i = 0; i < lvwSelect.Items.Count; i++)
                {
                    CamposSelect.Add(lvwSelect.GetItem(i, ColumnsSelect.ColumnName));
                    CamposSelectDataType.Add(lvwSelect.GetItem(i, ColumnsSelect.DataType));
                }

                for (int i = 0; i < lvwWhere.Items.Count; i++)
                {
                    CamposWhere.Add(lvwWhere.GetItem(i, ColumnsWhere.ColumnName));
                    CamposWhereDataType.Add(lvwWhere.GetItem(i, ColumnsWhere.DataType));
                }

                for (int i = 0; i < lvwOrderBy.Items.Count; i++)
                {
                    CamposOrderBy.Add(lvwOrderBy.GetItem(i, ColumnsOrderBy.ColumnName));
                }

                try
                {
                    TopQuery = int.Parse(txtTop.Text.Trim());
                }
                catch
                {
                    TopQuery = 0;
                }

                this.DialogResult  = DialogResult.OK;
                this.Close();
            }
            catch (SmoException smoExc)
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

        private string PegaTipoOperador(string cod)
        {
            try
            {
                string tipoDado = string.Empty;

                switch (cod)
                {
                    case "text":
                    case "ntext":
                    case "varchar":
                    case "char":
                    case "nvarchar":
                    case "nchar":
                        {
                            tipoDado = " like '%" + txtValor.Text + "%'";
                            break;
                        }
                    case "tinyint":
                    case "smallint":
                    case "int":
                    case "real":
                    case "money":
                    case "decimal":
                    case "smallmoney":
                    case "float":
                    case "bit":
                    case "numeric":
                    case "bigint":
                    case "varbinary":
                    case "binary":
                        {
                            tipoDado = " =" + txtValor.Text;
                            break;
                        }
                    case "datetime":
                    case "smalldatetime":
                        {
                            tipoDado = " >= '" + dtpValor.Value.ToString("MM/dd/yyyy HH:mm:ss") + "'";
                            break;
                        }
                    case "timestamp":
                    case "sql_variant":
                    case "uniqueidentifier":
                    case "image":
                        {
                            tipoDado = " ?";
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
        private bool TipoValorDateTime(string cod)
        {
            try
            {
                switch (cod)
                {
                    case "text":
                    case "ntext":
                    case "varchar":
                    case "char":
                    case "nvarchar":
                    case "nchar":
                    case "tinyint":
                    case "smallint":
                    case "int":
                    case "real":
                    case "money":
                    case "decimal":
                    case "smallmoney":
                    case "float":
                    case "bit":
                    case "numeric":
                    case "bigint":
                    case "varbinary":
                    case "binary":
                    case "timestamp":
                    case "sql_variant":
                    case "uniqueidentifier":
                    case "image":
                        {
                            return false;
                        }
                    case "datetime":
                    case "smalldatetime":
                        {
                            return true; 
                        }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void lvwCampos_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_commandType != CommandType.CREATE_SP_INSERT &&
                    m_commandType != CommandType.CREATE_SP_UPDATE &&
                    m_commandType != CommandType.CREATE_SP_DELETE &&
                    m_commandType != CommandType.CREATE_SP_SELECT)
                {
                    string dataType = lvwCampos.GetSelectedItem(2);

                    if (TipoValorDateTime(dataType))
                    {
                        txtValor.Visible = false;
                        dtpValor.Visible = true;
                    }
                    else
                    {
                        txtValor.Clear();
                        dtpValor.Visible = false;
                        txtValor.Visible = true;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OrderBy_btnInserirUm_Click(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string columnName = lvwCampos.GetSelectedItem(ColumnsOrigem.ColumnName); 

            if(columnName == "*"){return;}

            if(lvwOrderBy.ItemExist(columnName, ColumnsOrderBy.ColumnName)){return;}     

            ArrayList aDados = new ArrayList();

            aDados.Add("0");
            aDados.Add(lvwCampos.GetSelectedItem(ColumnsOrigem.ColumnName) + " " + cboOrderByType.Text);

            lvwOrderBy.Add(aDados);
        }
        private void OrderBy_btnInserirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwCampos.Items.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    aDados.Add(" ");
                    aDados.Add(lvwCampos.Items[i].SubItems[1].Text);

                    lvwOrderBy.Add(aDados);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OrderBy_btnRemoverUm_Click(object sender, EventArgs e)
        {
            if (lvwOrderBy.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um campo [Order By]!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvwOrderBy.SelectedItems[0].Remove();
        }
        private void OrderBy_btnRemoverTodos_Click(object sender, EventArgs e)
        {
            try
            {
                lvwOrderBy.Items.Clear();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void lvwCampos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                lvwCampos_Click(null, null); 
            }
        }
        private void btnSelectRowUp_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwSelect, MoveType.Up);
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
                Funcoes.ListViewMoveRow(ref lvwSelect, MoveType.Down);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnWhereRowUp_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwWhere, MoveType.Up);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnWhereRowDown_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwWhere, MoveType.Down);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnOrderByRowUp_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwOrderBy, MoveType.Up);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnOrderByRowDown_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.ListViewMoveRow(ref lvwOrderBy, MoveType.Down);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
    }
}