using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBTools.classes;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms
{
    public partial class frmSQLKeyValue : Form
    {
        private struct ColumnsColumn
	    {
		    /// <summary>
		    /// 0
		    /// </summary>
		    public const int Key = 0;
            /// <summary>
		    /// 1
		    /// </summary>
		    public const int Identity = 1;
		    /// <summary>
		    /// 2
		    /// </summary>
		    public const int Name = 2;
		    /// <summary>
		    /// 3
		    /// </summary>
		    public const int DataType = 3;
	    }

        private SqlObjectsClass m_so;
        public string Query {get;set;}
        public string KeyField {get;set;}
        public string ValueField {get;set;}
        public string TableName {get;set;}
        public string TablePrefix {get;set;}
        public bool IsTableUser {get;set;}

        public frmSQLKeyValue(ref SqlObjectsClass so)
        {
            m_so = so;

            InitializeComponent();

            Tables tbc = m_so.GetTables(Funcoes.FormMain._tableShowSystemObject); 

            for (int i = 0; i < tbc.Count; i++)
            {
               cboTables.Items.Add(tbc[i].Name);    
            }
        }

        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwColunas.Items.Clear();  

            Columns cols = m_so.GetColumns(m_so.GetTableByName(cboTables.SelectedItem.ToString())); 

            Color foreColor = Color.Black;  

            foreach (DBTools.classes.ObjectsClass.Column column in cols)
            {
                int iconType    = DBTools.forms.frmTablesRowsCount.IconType.Blank;
                foreColor       = Color.Blue;

                string nametableFK  = string.Empty; 
                string columnName   = column.Name;

                if (Funcoes.FormMain._tableShowColumnsDataType)
                {
                    string datatype     = column.DataType.Name;
                    string allowNulls   = column.Nullable ? "null" : "not null";

                    columnName += " (" + Funcoes.GetDataType(column) + ", " + allowNulls + ")";
                }

                if (column.IsPrimaryKey)
                {
                    iconType    = DBTools.forms.frmTablesRowsCount.IconType.PK;
                    foreColor   = Color.DarkGoldenrod;
                    txtKey.Text  = column.Name; 
                }


                ArrayList aDados = new ArrayList();

                aDados.Add("");
                aDados.Add(column.Identity ? "Sim" : "");
                aDados.Add(column.Name);
                aDados.Add(column.DataType.Name.ToLower());
                    
                lvwColunas.Add(aDados, foreColor, iconType);
            }

            lblTotalColunas.Text = lvwColunas.Items.Count.ToString();
    
            if(lvwColunas.Items.Count == 2)
            {
                txtValue.Text = lvwColunas.GetItem(1, ColumnsColumn.Name);  
            }
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            if(lvwColunas.IsSelectedItem)
            {
                txtKey.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name); 
            }
        }

        private void btnValue_Click(object sender, EventArgs e)
        {
            if(lvwColunas.IsSelectedItem)
            {
                txtValue.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name); 
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.TableName = Funcoes.JoomlaGetTableNameSystem(cboTables.SelectedItem.ToString()); 

            this.Query = string.Format("SELECT '0' AS {0}, '-- Selecione uma opção --' AS {1} UNION SELECT {0}, {1} FROM {2}",
                                        txtKey.Text,
                                        txtValue.Text,
                                        this.TableName);
            this.KeyField       = txtKey.Text;
            this.ValueField     = txtValue.Text;
            this.IsTableUser    = this.TableName.ToLower() == "#__users" ? true : false;
            
            if(this.IsTableUser)
            {
                this.TablePrefix = "name_usu";
            }
            else
            {
                string[] tableprefix    = this.TableName.Split('_');
                this.TablePrefix        = tableprefix[tableprefix.Length-1];
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close(); 
        }
    }
}
