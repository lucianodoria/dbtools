using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;
using DBTools.classes;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms
{
    public partial class frmTablesRowsCount : Form
    {
        private struct ColumnsTables
	    {
		    public const int Table          = 0;
		    public const int Owner          = 1;
		    public const int Rows           = 2;
		    public const int DataCriacao    = 3;
		    public const int ID             = 4;
            public const int RowsOrder      = 5;
	    }
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
		    /// <summary>
		    /// 4
		    /// </summary>
		    public const int Size = 4;
		    /// <summary>
		    /// 5
		    /// </summary>
		    public const int Nulls = 5;
		    /// <summary>
		    /// 6
		    /// </summary>
		    public const int NameTableFK = 6;
            /// <summary>
		    /// 7
		    /// </summary>
		    public const int IndexName = 7;
            /// <summary>
		    /// 8
		    /// </summary>
		    public const int FillFactor = 8;
	    }
        public struct IconType
        {
            public const int Table      = 0;
            public const int TableRow   = 1;
            public const int Blank      = 2;
            public const int PK         = 3;
            public const int FK         = 4;
            public const int Index      = 5;
        }

        private object m_objectItem;
        private SqlObjectsClass m_so;

        public frmTablesRowsCount(object item, SqlObjectsClass so)
        {
            InitializeComponent();
            
            m_so            = so;
            m_objectItem    = item; 
        }
        
#region FORM

        private void frmTablesRowsCount_Load(object sender, EventArgs e)
        {
            //lvwTables.ColumnNotSortOrder = ColumnsTables.Rows;  
            lvwTables.ColumnsWidthLoad();
            lvwColunas.ColumnsWidthLoad();
  
            ListarTabelas();
        }
        private void frmTablesRowsCount_FormClosing(object sender, FormClosingEventArgs e)
        {
            lvwTables.ColumnsWidthSave();
            lvwColunas.ColumnsWidthSave();  
        }

#endregion

#region FUNCOES

        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 22/11/2007 08:16
        * Data de modificação	= 
        **************************************************************/
        private void ListarTabelas()
        {
            try
            {
                Funcoes.ShowCursor(this, CursorType.WaitCursor);
                gpbExportar.Enabled                 = false;
                btnExportarParaExcel.Enabled        = false;
                btnExportarParaExcelColunas.Enabled = false;

                Color foreColor = Color.Black;

                if (m_objectItem is TreeNodeCollection)
                {
                    Tables tables = m_so.TablesCache;

                    foreach (Table table in tables)
                    {
                        ArrayList aDados = new ArrayList();

                        aDados.Add(table.Name);
                        aDados.Add(table.Owner);
                        aDados.Add(table.RowCount.ToString("n0"));
                        aDados.Add(table.CreateDate.ToString("dd/MM/yyyy HH:mm:ss"));
                        aDados.Add(table.Id);
                        aDados.Add(table.RowCount);

                        foreColor = table.RowCount < 500000 ? Color.Blue : Color.Red;

                        lvwTables.Add(aDados, foreColor, 0);
                    }
                }
                else if (m_objectItem is Table)
                {
                    splitTables.SplitterDistance    = 100;
                    splitTables.IsSplitterFixed     = true;
                    splitTables.FixedPanel          = FixedPanel.Panel1;  

                    Table table = (Table)m_objectItem;

                    ArrayList aDados = new ArrayList();

                    m_so.SetRowCount(ref table);

                    aDados.Add(table.Name);
                    aDados.Add(table.Owner);
                    aDados.Add(table.RowCount);
                    aDados.Add(table.CreateDate.ToString("dd/MM/yyyy HH:mm:ss"));
                    aDados.Add(table.Id);

                    foreColor = table.RowCount < 500000 ? Color.Blue : Color.Red;

                    lvwTables.Add(aDados, foreColor, 0);
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
            finally
            {
                lvwTables.Sorter                    = true;
                gpbExportar.Enabled                 = true;
                btnExportarParaExcel.Enabled        = true;
                btnExportarParaExcelColunas.Enabled = true;
                Funcoes.ShowCursor(this, CursorType.Default);
            }
        }

#endregion

#region EVENTOS

        private void btnExportarParaExcel_Click(object sender, EventArgs e)
        {
            try
            {
                btnExportarParaExcel.Enabled = false;

                lvwTables.ExportToExcel();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                btnExportarParaExcel.Enabled = true;
            }
        }
        private void lvwTables_ChangeItems()
        {
            lblTotal.Text = lvwTables.Items.Count.ToString();    
        }
        private void lvwColunas_ChangeItems()
        {
            lblTotalColunas.Text = lvwColunas.Items.Count.ToString();     
        }
        private void lvwTables_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == ColumnsTables.Rows)
            {
                System.Windows.Forms.SortOrder sortOrder = new System.Windows.Forms.SortOrder();
 
                if(lvwTables.SortOrder == System.Windows.Forms.SortOrder.Descending)
                {
                    sortOrder = System.Windows.Forms.SortOrder.Ascending;
                }
                else
                {
                    sortOrder = System.Windows.Forms.SortOrder.Descending;
                }

                lvwTables.ColumnSorter(ColumnsTables.RowsOrder, ColumnsTables.Rows, sortOrder);     
            }
        }
        private void lvwTables_Click(object sender, EventArgs e)
        {
            Color foreColor = Color.Black;  

            try
            {
                Funcoes.ShowCursor(this, CursorType.WaitCursor);   

                lvwColunas.Items.Clear();

                Table table = m_so.GetTableByID(int.Parse(lvwTables.GetSelectedItem(ColumnsTables.ID)));  

                Columns columns = m_so.GetColumns(table);

                foreach (Column column in columns)
                {
                    int iconType    = IconType.Blank;
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
                        iconType    = IconType.PK;
                        foreColor   = Color.DarkGoldenrod;  
                    }

                    if(column.IsForeignKey)
                    {
                        #region É FK(ForeignKey)                    

                        iconType    = IconType.FK;
                        foreColor   = Color.DimGray;  

                        nametableFK = column.TableForeignKey.Name;
                        #endregion
                    }

                    ArrayList aDados = new ArrayList();

                    aDados.Add("");
                    aDados.Add(column.Identity ? "Sim" : "");
                    aDados.Add(column.Name);
                    aDados.Add(column.DataType.Name.ToLower());
                    
                    if(column.DataType.Name.ToLower() == "decimal" || column.DataType.Name.ToLower() == "numeric")
                    {
                        aDados.Add(column.DataType.MaximumLength.ToString() + "(" + column.DataType.NumericPrecision.ToString()  + "," + column.DataType.NumericScale.ToString() + ")");
                    }
                    else
                    {
                        aDados.Add(column.DataType.MaximumLength);
                    }
                    
                    aDados.Add(column.Nullable ? "null" : "not null");//column.AllowNulls ? "X":"");
                    aDados.Add(nametableFK);
                    aDados.Add("");
                    aDados.Add("");
  
                    lvwColunas.Add(aDados, foreColor, iconType);
                    //lvwColunas.Items[lvwTables.Items.Count-1].Tag = column;
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
            finally
            {
                Funcoes.ShowCursor(this, CursorType.Default);   
            }
        }
        private void btnExportarParaExcelColunas_Click(object sender, EventArgs e)
        {
            try
            {
                btnExportarParaExcelColunas.Enabled = false;

                lvwColunas.ExportToExcel();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                btnExportarParaExcelColunas.Enabled = true;
            }
        }
        private void btnExportarTabelaColunas_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
 
            try
            {
                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                pgbListar.Minimum   = 0;
                pgbListar.Maximum   = lvwTables.ItemCount;  
                pgbListar.Value     = 0;

                for (int i = 0; i < lvwTables.ItemCount; i++)
                {
                    Table table = m_so.GetTableByID(int.Parse(lvwTables.GetItem(i, ColumnsTables.ID)));  

                    sb.Append(table.Name + Environment.NewLine);

                    Columns columns = m_so.GetColumns(table);    

                    foreach (Column column in columns)
                    {
                        sb.Append(column.Name + Environment.NewLine);
                    } 

                    sb.Append(Environment.NewLine);

                    pgbListar.Value = i;
                }

                Funcoes.FileWrite(Application.StartupPath + @"\listaTabelasColunas.txt", sb.ToString(), true, true);    
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
                Funcoes.ShowCursor(this, CursorType.Default);   
            }
        }


#endregion

    }
}