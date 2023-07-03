using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.SqlClient;
using DBTools.classes.ObjectsClass;

namespace DBTools.forms
{
    public partial class frmImportExcel : Form
    {
        private struct ColumnsExcel
		{
            public const int Index		= 0;
			public const int Coluna	    = 1;
		}
        private struct ColumnsSP
		{
			public const int ColunaExcel	= 0;
			public const int Param			= 1;
			public const int IndexExcel		= 2;
			public const int ValorDefault	= 3;
		}
        private struct IconType
        {
            public const int Server = 0;
            public const int DataBase = 1;
            public const int FolderTable = 2;
            public const int Table = 3;
            public const int TableRow = 4;
            public const int View = 5;
            public const int SP = 6;
            public const int SPRow = 7;
            public const int PK = 8;
            public const int FK = 9;
            public const int TableFK = 10;
            public const int SPRowOutput = 11;
            public const int ViewRow = 12;
            public const int FolderView = 13;
            public const int FolderSP = 14;
        }

        private StoredProcedure m_storedProcedure;
        private string          m_maskSP            = string.Empty;  

        public frmImportExcel(StoredProcedure storedProcedure)
        {
            m_storedProcedure = storedProcedure;

            InitializeComponent();

            ListarParametros();

            Control.CheckForIllegalCrossThreadCalls = false; 
        }

        #region FUNCOES

        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 14/07/2009 08:24
        * Data de modificação	= 
        **************************************************************/
        private void ListarParametros()
        {
            try
            {
                //foreach (StoredProcedureParameter parameter in m_storedProcedure.Parameters)
                //{
                //    int iconType = IconType.SPRow;

                //    if (parameter.IsOutputParameter) { iconType = IconType.SPRowOutput; }

                //    ArrayList aDados = new ArrayList();   

                //    aDados.Add("");
                //    aDados.Add(parameter.Name);
                //    aDados.Add("");
                //    aDados.Add("");
                    
                //    lvwSPParams.Add(aDados, iconType);  
                //    //sp.Name     = parameter.Name;
                //    //sp.DataType = parameter.DataType.Name;
                //    //sp.Length   = parameter.DataType.MaximumLength;
                //    //sp.Colid    = parameter.ID.ToString();
                //    //sp.Output   = parameter.IsOutputParameter;

                //    //switch (sp.DataType.ToLower())
                //    //{
                //    //    case "char":
                //    //    case "nchar":
                //    //    case "nvarchar":
                //    //    case "binary":
                //    //    case "varbinary":
                //    //    case "varchar":
                //    //        {
                //    //            sp.TypeWithLength = sp.DataType + "(" + sp.Length.ToString() + ")";
                //    //            break;
                //    //        }
                //    //    case "numeric":
                //    //        {
                //    //            sp.TypeWithLength = sp.DataType + "(" + sp.Length.ToString() + ",0)";
                //    //            break;
                //    //        }
                //    //    default:
                //    //        {
                //    //            sp.TypeWithLength = sp.DataType;
                //    //            break;
                //    //        }
                //    //}

                //    //if (sp.Output) { iconType = IconType.SPRowOutput; }

                //    //if (Funcoes.FormMain.m_SPShowColumnsDataType)
                //    //{
                //    //    paramName = sp.Name + " (" + sp.TypeWithLength + ")";
                //    //}
                //    //else
                //    //{
                //    //    paramName = sp.Name;
                //    //}

                //    //TreeNode nodeField = new TreeNode(paramName, iconType, iconType);
                //    //nodeField.Tag = sp;

                //    //// adiciona o parâmetro
                //    //tvwDados.SelectedNode.Nodes.Add(nodeField);
                //}
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
        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 14/07/2009 08:53
        * Data de modificação	= 
        **************************************************************/
        private void ListarColunasExcel(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application xl = null;
            Microsoft.Office.Interop.Excel._Workbook wb = null;
            Microsoft.Office.Interop.Excel._Worksheet sheet = null;
            //Microsoft.Office.Interop.Excel.Range oRng = null;

            try
            {

                lvwExcelColumns.Items.Clear();  

                #region inicialização das variaveis
                GC.Collect();

                // Create a new instance of Excel from scratch
                xl          = new Microsoft.Office.Interop.Excel.Application();
                xl.Visible  = false;

                // Add one workbook to the instance of Excel
                //wb = (Microsoft.Office.Interop.Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
                wb = (Microsoft.Office.Interop.Excel._Workbook)xl.Workbooks.Open(fileName, 
                                                                                 0, 
                                                                                 true, 
                                                                                 5,
                                                                                 "",
                                                                                 "",
                                                                                 true, 
                                                                                 Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, 
                                                                                 "\t", 
                                                                                 false,
                                                                                 false,
                                                                                 0, 
                                                                                 false,
                                                                                 Missing.Value,
                                                                                 Missing.Value);
                
                // Get a reference to the one and only worksheet in our workbook
                sheet = (Microsoft.Office.Interop.Excel._Worksheet)wb.ActiveSheet;

                #endregion

                int     colIndex    = 1;
                int     rowIndex    = 1;

                while ( ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowIndex,colIndex]).Value2 != null )
                {

                   string columnValue = ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowIndex, colIndex]).Value2.ToString();
                   
                    ArrayList aDados = new ArrayList();
                    
                    aDados.Add(colIndex);
                    aDados.Add(columnValue.Trim());

                    lvwExcelColumns.Add(aDados); 

                    colIndex++;
                }

                //while(ler)
                //{
                //    // resgata nome da coluna
                //    string valor = sheet.Cells[1, columnIndex];
                    
                //    if(string.IsNullOrEmpty(valor) || valor.Length <= 0){ler = false;continue;}
 
                //    ArrayList aDados = new ArrayList();
                    
                //    aDados.Add(columnIndex);
                //    aDados.Add(valor.Trim());

                //    lvwExcelColumns.Add(aDados);  
                //    ////Dia semana: C11
                //    //sheet.Cells[row, C] = System.Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames[(int)dataAtual.DayOfWeek]; 

                //    //// adiciona uma nova coluna
                //    //sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).Insert(Missing.Value, Missing.Value);
                //    //sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).RowHeight = sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Height;                     
                 
                //    //if(dataAtual.DayOfWeek == DayOfWeek.Saturday ||
                //    //   dataAtual.DayOfWeek == DayOfWeek.Sunday)
                //    //{
                //    //    sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Interior.Color = Color.Gainsboro.ToArgb();
                //    //}

                //    //dataAtual = dataAtual.AddDays(1);

                //    //if(dataAtual <= dtmFinal)
                //    //{
                //    //    // copia os dados para nova coluna
                //    //    sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Copy(sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]));
                //    //    sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).Interior.Color = Color.White.ToArgb();
                //    //}
                //    //else
                //    //{
                //    //    adicionaLinha = false;
                //    //}

                //    columnIndex++;  
                //}

                xl.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComO bject(wb1);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xl);
                //wb1 = null;
                              
                xl = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                try
                {
                    // Repeat xl.Visible and xl.UserControl releases just to be sure
                    // we didn't error out ahead of time.
                    //					xl.Visible = false;
                    xl.UserControl = false;
                }
                catch { }

                // Gracefully exit out and destroy all COM objects to avoid hanging instances
                // of Excel.exe whether our method failed or not.	
                if (sheet != null) { Marshal.ReleaseComObject(sheet); }
                if (wb != null) { Marshal.ReleaseComObject(wb); }
                if (xl != null) { Marshal.ReleaseComObject(xl); }

                sheet           = null;
                wb              = null;
                xl              = null;
                GC.Collect();
            }
        }
        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 14/07/2009 09:49
        * Data de modificação	= 
        **************************************************************/
        private bool ValidacaoExcel()
        {
            try
            {
                if(lvwExcelColumns.SelectedItemCount <= 0)
                {
                    MessageBox.Show("Selecione uma coluna do Excel!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
                return false;
            }
        }
        private bool ValidacaoSoredProcedure()
        {
            try
            {
                if(lvwSPParams.SelectedItemCount <= 0)
                {
                    MessageBox.Show("Selecione um parâmetro da SP!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
                return false;
            }
        }

        private void GerarSQLCommand()
        {
            Microsoft.Office.Interop.Excel.Application xl = null;
            Microsoft.Office.Interop.Excel._Workbook wb = null;
            Microsoft.Office.Interop.Excel._Worksheet sheet = null;
            //Microsoft.Office.Interop.Excel.Range oRng = null;

            StringBuilder sb = new StringBuilder(10000); 

            try
            {
                Funcoes.ShowCursor(this, CursorType.WaitCursor);
                Cursor.Show(); 
  
                string fileName = txtArquivoExcel.Text;
  
                #region inicialização das variaveis
                GC.Collect();

                // Create a new instance of Excel from scratch
                xl          = new Microsoft.Office.Interop.Excel.Application();
                xl.Visible  = false;

                // Add one workbook to the instance of Excel
                //wb = (Microsoft.Office.Interop.Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
                wb = (Microsoft.Office.Interop.Excel._Workbook)xl.Workbooks.Open(fileName, 
                                                                                 0, 
                                                                                 true, 
                                                                                 5,
                                                                                 "",
                                                                                 "",
                                                                                 true, 
                                                                                 Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, 
                                                                                 "\t", 
                                                                                 false,
                                                                                 false,
                                                                                 0, 
                                                                                 false,
                                                                                 Missing.Value,
                                                                                 Missing.Value);
                
                // Get a reference to the one and only worksheet in our workbook
                sheet = (Microsoft.Office.Interop.Excel._Worksheet)wb.ActiveSheet;

                #endregion

                int rowIndex = 2;

                object[] columnArraysValues = new object[lvwExcelColumns.Items.Count+1];  

                while ( ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowIndex, 1]).Value2 != null )
                {
                    columnArraysValues[0] = 0;

                    for (int colIndex = 1; colIndex <= lvwExcelColumns.Items.Count; colIndex++)
                    {
                        object columnValue = ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[rowIndex, colIndex]).Value2;
                            
                        if(columnValue != null)
                        {
                            columnValue = columnValue.ToString().Trim();
                        }

                        columnArraysValues[colIndex] = columnValue;
                    }

                    sb.Append(string.Format(m_maskSP, columnArraysValues) + Environment.NewLine); 

                    rowIndex++;
                }

                Funcoes.FileWrite(Application.StartupPath + @"\sp_sqlCommand.txt", 
                                  sb.ToString(),
                                  true,
                                  true);    

                //while(ler)
                //{
                //    // resgata nome da coluna
                //    string valor = sheet.Cells[1, columnIndex];
                    
                //    if(string.IsNullOrEmpty(valor) || valor.Length <= 0){ler = false;continue;}
 
                //    ArrayList aDados = new ArrayList();
                    
                //    aDados.Add(columnIndex);
                //    aDados.Add(valor.Trim());

                //    lvwExcelColumns.Add(aDados);  
                //    ////Dia semana: C11
                //    //sheet.Cells[row, C] = System.Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames[(int)dataAtual.DayOfWeek]; 

                //    //// adiciona uma nova coluna
                //    //sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).Insert(Missing.Value, Missing.Value);
                //    //sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).RowHeight = sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Height;                     
                 
                //    //if(dataAtual.DayOfWeek == DayOfWeek.Saturday ||
                //    //   dataAtual.DayOfWeek == DayOfWeek.Sunday)
                //    //{
                //    //    sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Interior.Color = Color.Gainsboro.ToArgb();
                //    //}

                //    //dataAtual = dataAtual.AddDays(1);

                //    //if(dataAtual <= dtmFinal)
                //    //{
                //    //    // copia os dados para nova coluna
                //    //    sheet.get_Range(sheet.Cells[row, B], sheet.Cells[row, O]).Copy(sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]));
                //    //    sheet.get_Range(sheet.Cells[row+1, B], sheet.Cells[row+1, O]).Interior.Color = Color.White.ToArgb();
                //    //}
                //    //else
                //    //{
                //    //    adicionaLinha = false;
                //    //}

                //    columnIndex++;  
                //}

                xl.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComO bject(wb1);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xl);
                //wb1 = null;
                              
                xl = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                Cursor.Show(); 

                try
                {
                    // Repeat xl.Visible and xl.UserControl releases just to be sure
                    // we didn't error out ahead of time.
                    //					xl.Visible = false;
                    xl.UserControl = false;
                }
                catch { }

                // Gracefully exit out and destroy all COM objects to avoid hanging instances
                // of Excel.exe whether our method failed or not.	
                if (sheet != null) { Marshal.ReleaseComObject(sheet); }
                if (wb != null) { Marshal.ReleaseComObject(wb); }
                if (xl != null) { Marshal.ReleaseComObject(xl); }

                sheet           = null;
                wb              = null;
                xl              = null;
                GC.Collect();
            }
        }

        #endregion

#region EVENTOS

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter  = "Arquivo Excel (*.xls)|*.xls";
                ofd.Title   = "Selecione o arquivo";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtArquivoExcel.Text = ofd.FileName;

                    ListarColunasExcel(ofd.FileName);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnAplicarValorDefault_Click(object sender, EventArgs e)
        {
            if(!ValidacaoSoredProcedure()){return;}; 

            string valorDefault = txtValorDefault.Text.Trim();
   
            if(valorDefault.ToLower() == "getdate()")
            {
                valorDefault = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");   
            }

            lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.ColunaExcel].Text   = valorDefault;      
            lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.ValorDefault].Text  = valorDefault; 
     
            if(lvwSPParams.SelectedItems[0].Index < lvwSPParams.Items.Count-1)
            {
                int indexSelectedItems = lvwSPParams.SelectedItems[0].Index+1;

                lvwSPParams.Items[indexSelectedItems].Selected = true; 
            }
        }
        private void btnInserirUm_Click(object sender, EventArgs e)
        {
            try
            {
                if(!ValidacaoExcel()){return;}; 
                if(!ValidacaoSoredProcedure()){return;}; 

                lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.ColunaExcel].Text   = lvwExcelColumns.GetSelectedItem(ColumnsExcel.Coluna);
                lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.IndexExcel].Text    = lvwExcelColumns.GetSelectedItem(ColumnsExcel.Index);
                
                if(lvwSPParams.SelectedItems[0].Index < lvwSPParams.Items.Count-1)
                {
                    int indexSelectedItems = lvwSPParams.SelectedItems[0].Index+1;

                    lvwSPParams.Items[indexSelectedItems].Selected = true; 
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnInserirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwSPParams.Items.Count; i++)
                {
                    lvwSPParams.Items[i].SubItems[ColumnsSP.ColunaExcel].Text   = lvwExcelColumns.GetItem(i, ColumnsExcel.Coluna);
                    lvwSPParams.Items[i].SubItems[ColumnsSP.IndexExcel].Text    = lvwExcelColumns.GetItem(i, ColumnsExcel.Index);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnRemoverUm_Click(object sender, EventArgs e)
        {
            try
            {
                if(!ValidacaoSoredProcedure()){return;};

                lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.ColunaExcel].Text   = string.Empty;
                lvwSPParams.SelectedItems[0].SubItems[ColumnsSP.IndexExcel].Text    = string.Empty;
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnRemoverTodos_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvwSPParams.Items.Count; i++)
                {
                    lvwSPParams.Items[i].SubItems[ColumnsSP.ColunaExcel].Text   = string.Empty;
                    lvwSPParams.Items[i].SubItems[ColumnsSP.IndexExcel].Text    = string.Empty;
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnGerarQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //StringBuilder sb = new StringBuilder(10000);

                //m_maskSP = "exec " + m_storedProcedure.Name + " ";

                //int     index   = 0;
                //bool    virgula = false;

                //foreach (StoredProcedureParameter parameter in m_storedProcedure.Parameters)
                //{
                //    string valorParam       = string.Empty;  

                //    string indexExcel       = lvwSPParams.GetItem(index, ColumnsSP.IndexExcel).Trim();
                //    string valorDefault     = lvwSPParams.GetItem(index, ColumnsSP.ValorDefault).Trim();
                //    string colunaExcel      = lvwSPParams.GetItem(index, ColumnsSP.ColunaExcel).Trim();

                //    if(indexExcel.Length > 0)
                //    {
                //        valorParam = "{" + indexExcel + "}";
                //    }
                //    else if(valorDefault.Length > 0)
                //    {
                //        valorParam = colunaExcel;  
                //    }
                //    else
                //    {
                //        valorParam = "null"; 
                //    }

                //    if (virgula) { m_maskSP += ","; }

                //    if (parameter.IsOutputParameter)
                //    {
                //        m_maskSP += "null";
                //    }
                //    else
                //    {
                //        switch (parameter.DataType.SqlDataType)
                //            {
                //                case SqlDataType.BigInt:
                //                case SqlDataType.Binary:
                //                case SqlDataType.Bit:
                //                case SqlDataType.Int:
                //                case SqlDataType.Decimal:
                //                case SqlDataType.Float:
                //                case SqlDataType.Money:
                //                case SqlDataType.Numeric:
                //                case SqlDataType.Real:
                //                case SqlDataType.SmallInt:
                //                case SqlDataType.SmallMoney:
                //                case SqlDataType.TinyInt:
                //                case SqlDataType.UniqueIdentifier:
                //                case SqlDataType.VarBinary:
                //                case SqlDataType.VarBinaryMax:
                //                    {
                //                        m_maskSP += valorParam;
                //                        break;
                //                    }
                //                case SqlDataType.Char:
                //                case SqlDataType.DateTime:
                //                case SqlDataType.Image:
                //                case SqlDataType.NChar:
                //                case SqlDataType.NText:
                //                case SqlDataType.NVarChar:
                //                case SqlDataType.NVarCharMax:
                //                case SqlDataType.None:
                //                case SqlDataType.SmallDateTime:
                //                case SqlDataType.SysName:
                //                case SqlDataType.Text:
                //                case SqlDataType.Timestamp:
                //                case SqlDataType.UserDefinedDataType:
                //                case SqlDataType.UserDefinedType:
                //                case SqlDataType.VarChar:
                //                case SqlDataType.VarCharMax:
                //                case SqlDataType.Variant:
                //                case SqlDataType.Xml:
                //                    {
                //                        if(valorParam != "null")
                //                        {
                //                            m_maskSP += "'" + valorParam + "'";
                //                        }
                //                        else
                //                        {
                //                             m_maskSP += valorParam;
                //                        }
                //                        break;
                //                    }
                //            }
                //    }

                //    index++;
                //    virgula = true;
                //}

                //Thread t = new Thread(new ThreadStart(GerarSQLCommand));

                //t.IsBackground = true;
                //t.Start();
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


#endregion


    }
}
