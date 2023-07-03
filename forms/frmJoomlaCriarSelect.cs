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

namespace DBTools.forms
{
    public partial class frmJoomlaCriarSelect : Form
    {
        private struct ColumnsColumn
	    {
		    public const int Key = 0;
		    public const int Identity = 1;
		    public const int Name = 2;
            public const int FieldLabel = 3;
		    public const int DataType = 4;
		    public const int Size = 5;
		    public const int Nulls = 6;
		    public const int FieldType = 7;
	    }

        private DBTools.classes.ObjectsClass.Table m_table;
        private DBTools.classes.ObjectsClass.Columns m_columns; 
        private SqlObjectsClass m_so;
        
        private Dictionary<string, string> m_FieldType = new Dictionary<string,string>();

        public frmJoomlaCriarSelect(DBTools.classes.ObjectsClass.Table table, SqlObjectsClass so)
        {
            InitializeComponent();

            m_so    = so;
            m_table = table;
            m_columns = m_so.GetColumns(m_table);

            string[] tableNameArray = m_table.Name.Split('_');

            txtDropdownListsName.Text = m_table.Name.Replace("_", "").Replace(tableNameArray[0], "").Replace(tableNameArray[1], "").ToUpperFirstChar();

            Color foreColor = Color.Black;

            foreach (DBTools.classes.ObjectsClass.Column column in m_columns)
            {
                int iconType = DBTools.forms.frmTablesRowsCount.IconType.Blank;
                foreColor = Color.Blue;

                string nametableFK = string.Empty;
                string columnName = column.Name;

                if (Funcoes.FormMain._tableShowColumnsDataType)
                {
                    string datatype = column.DataType.Name;
                    string allowNulls = column.Nullable ? "null" : "not null";

                    columnName += " (" + Funcoes.GetDataType(column) + ", " + allowNulls + ")";
                }

                if (column.IsPrimaryKey)
                {
                    iconType = DBTools.forms.frmTablesRowsCount.IconType.PK;
                    foreColor = Color.DarkGoldenrod;
                }

                ArrayList aDados = new ArrayList();

                aDados.Add("");
                aDados.Add(column.Identity ? "Sim" : "");
                aDados.Add(column.Name);
                aDados.Add(column.DataType.Name.ToLower());

                if (column.DataType.Name.ToLower() == "decimal" || column.DataType.Name.ToLower() == "numeric")
                {
                    aDados.Add(column.DataType.MaximumLength.ToString() + "(" + column.DataType.NumericPrecision.ToString() + "," + column.DataType.NumericScale.ToString() + ")");
                }
                else
                {
                    aDados.Add(column.DataType.MaximumLength);
                }

                aDados.Add(column.Nullable ? "null" : "not null");//column.AllowNulls ? "X":"");

                lvwColunas.Add(aDados, foreColor, iconType);

                lvwColunas.Items[lvwColunas.ItemCount - 1].Tag = column;
            }
        }

        private void frmJoomla_Load(object sender, EventArgs e)
        {
        
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string[] tableNameArray = m_table.Name.Split('_');

            string tableName = m_table.Name.Replace(tableNameArray[0], "#_");

            string html = "public static function Select{2}($id, $name, $optionsCaption = null, $required = false, $datamsgrequired = \"\", $readonly = false){4}" +
                                "{{4}" +
                                "\treturn JHtmlPlus::SQLControl($id, $name, '{0}', '{1}','{2}', $optionsCaption, \"SELECT {0}, {1} FROM {3} ORDER BY {1}\", $readonly, $required, $datamsgrequired);{4}" +
                                "}{4}";
                                
            html = html.Replace("{0}", txtValue.Text);
            html = html.Replace("{1}", txtText.Text);
            html = html.Replace("{2}", txtDropdownListsName.Text);
            html = html.Replace("{3}", tableName);
            html = html.Replace("{4}", Environment.NewLine);

            Clipboard.SetText(html); 

            MessageBox.Show("Gerado com sucesso e adicionado no clipboard!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); 
        }
        private string GetDataTypeFormField(DBTools.classes.ObjectsClass.Column column)
        {   
            string fieldType = ""; 

            switch (column.DataType.SqlDataType)
                {
                    case DBTools.classes.ObjectsClass.SqlDataType.None:
                    case DBTools.classes.ObjectsClass.SqlDataType.Text:
                    case DBTools.classes.ObjectsClass.SqlDataType.VarChar:
                    case DBTools.classes.ObjectsClass.SqlDataType.VarCharMax:
                    case DBTools.classes.ObjectsClass.SqlDataType.Variant:
                    case DBTools.classes.ObjectsClass.SqlDataType.NChar:
                    case DBTools.classes.ObjectsClass.SqlDataType.NText:
                    case DBTools.classes.ObjectsClass.SqlDataType.NVarChar:
                    case DBTools.classes.ObjectsClass.SqlDataType.NVarCharMax:
                    case DBTools.classes.ObjectsClass.SqlDataType.Char:
                        {
                            fieldType = "Text";
                            break;
                        }
                    case DBTools.classes.ObjectsClass.SqlDataType.SmallDateTime:
                    case DBTools.classes.ObjectsClass.SqlDataType.Date:
                    case DBTools.classes.ObjectsClass.SqlDataType.Time:
                    case DBTools.classes.ObjectsClass.SqlDataType.DateTimeOffset:
                    case DBTools.classes.ObjectsClass.SqlDataType.DateTime2:
                    case DBTools.classes.ObjectsClass.SqlDataType.DateTime:
                        {
                            fieldType = "Datepicker";
                            break;
                        }
                    case DBTools.classes.ObjectsClass.SqlDataType.Decimal:
                    case DBTools.classes.ObjectsClass.SqlDataType.Numeric:
                        {
                            fieldType = "Money";
                            break;
                        }
                    default:
                        {
                            fieldType = "Text";
                            break;
                        }
                }

            if(column.IsPrimaryKey)
            {
                fieldType = "PrimaryKey";
            }

            if(column.Name.ToLower() == "published")
            {
                fieldType = "Published";
            } 

            return fieldType;

        }

        private void btnValue_Click(object sender, EventArgs e)
        {
            txtValue.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name); 
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            txtText.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name); 
        }
    }
}
