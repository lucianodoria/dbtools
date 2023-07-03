using System;
using System.Drawing; 
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection; 
using System.Runtime.InteropServices;     

	public enum LIGACAO_TIPO
	{
		Cliente = 0,
		Ligacao = 1,
		Ocorrencia = 3
	}

	public class Funcoes
	{
		public Funcoes(){}

		public static void AdicionarNoListView(ArrayList aDados, ListView objListView)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString());	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}

				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListViewByValor(string sValor, ListView objListView)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(sValor);	
											
				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView(string sValor, ListView objListView, int iIndexItem)
		{
			try
			{
				if(objListView.SelectedItems.Count > 0)
				{
					if(iIndexItem == 0)
					{
						objListView.SelectedItems[0].Text = sValor;
					}
					else
					{
						objListView.SelectedItems[0].SubItems[iIndexItem].Text = sValor;
					}
				}
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView(ArrayList aDados, ListView objListView, int iImageIndex)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString(), iImageIndex);	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}

				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView(ArrayList aDados, ListView objListView, Color forecolor)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString());	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}
                
				lvwItem.ForeColor = forecolor;
				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView(ArrayList aDados, ListView objListView, Color forecolor, int iImageIndex)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString(), iImageIndex);	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}
                
				lvwItem.ForeColor = forecolor;
				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}


		public static void AdicionarNoListView_ByRef(ArrayList aDados, ref ListView objListView)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString());	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}

				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView_ByRef(string sValor, ref ListView objListView, int iIndexItem)
		{
			try
			{
				if(objListView.SelectedItems.Count > 0)
				{
					if(iIndexItem == 0)
					{
						objListView.SelectedItems[0].Text = sValor;
					}
					else
					{
						objListView.SelectedItems[0].SubItems[iIndexItem].Text = sValor;
					}
				}
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}
		public static void AdicionarNoListView_ByRef(ArrayList aDados, ref ListView objListView, int iImageIndex)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString(), iImageIndex);	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}

				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView_ByRef(ArrayList aDados, ref ListView objListView, Color forecolor)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString());	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}
                
				lvwItem.ForeColor = forecolor; 
				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}

		public static void AdicionarNoListView_ByRef(ArrayList aDados, ref ListView objListView, Color forecolor, int iImageIndex)
		{
			try
			{
				ListViewItem lvwItem = new ListViewItem(aDados[0].ToString(), iImageIndex);	
				
				int iTotal = aDados.Count;

				for(int i=1; i < iTotal; i++)
				{
					lvwItem.SubItems.Add(aDados[i].ToString());								
				}
                
				lvwItem.ForeColor = forecolor;
				objListView.Items.Add(lvwItem);
			}
			catch(Exception exc) 
			{
				throw(exc);        	
			}
		}


		public static string PegaDadosLvw(int IndexItem, ListView objListView)
		{
			string Valor = string.Empty;
			
			if(objListView.SelectedItems.Count > 0)
			{
				if(IndexItem == 0)
				{
					Valor = objListView.SelectedItems[0].Text.Trim();   
				}
				else
				{
					Valor = objListView.SelectedItems[0].SubItems[IndexItem].Text.Trim();  
				}
			}

			return Valor;
		}

		public static string PegaDadosLvw(int iIndex, int IndexItem, ListView objListView)
		{
			string Valor = string.Empty;
			
			if(objListView.SelectedItems.Count > 0)
			{
				if(IndexItem == 0)
				{
					Valor = objListView.Items[iIndex].Text.Trim();   
				}
				else
				{
					Valor = objListView.Items[iIndex].SubItems[IndexItem].Text.Trim();  
				}
			}

			return Valor;
		}

		public static string PegaDadosLvw_ByRef(int IndexItem, ref ListView objListView)
		{
			string Valor = string.Empty;
			
			if(objListView.SelectedItems.Count > 0)
			{
				if(IndexItem == 0)
				{
					Valor = objListView.SelectedItems[0].Text.Trim();   
				}
				else
				{
					Valor = objListView.SelectedItems[0].SubItems[IndexItem].Text.Trim();  
				}
			}

			return Valor;
		}

		public static string PegaDadosLvw_ByRef(int iIndex, int IndexItem, ref ListView objListView)
		{
			string Valor = string.Empty;
			
			if(objListView.SelectedItems.Count > 0)
			{
				if(IndexItem == 0)
				{
					Valor = objListView.Items[iIndex].Text.Trim();   
				}
				else
				{
					Valor = objListView.Items[iIndex].SubItems[IndexItem].Text.Trim();  
				}
			}

			return Valor;
		}


		public static bool TextBoxEstaVazio(TextBox txt, bool bMostrarMesageBox)
		{
			if(txt.Text.Trim() == string.Empty)
			{
				if(bMostrarMesageBox == true)
				{
					MessageBox.Show("O campo \"" + txt.AccessibleDescription + "\" não pode ser deixado em branco!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);  
				}

				txt.Focus();
				return true;
			}
			return false; 
		}
		public static bool TextBoxEstaVazio_ByRef(ref TextBox txt, bool bMostrarMesageBox)
		{
			if(txt.Text.Trim() == string.Empty)
			{
				if(bMostrarMesageBox == true)
				{
					MessageBox.Show("O campo \"" + txt.AccessibleDescription + "\" não pode ser deixado em branco!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);  
				}

				txt.Focus();
				return true;
			}
			return false; 
		}

		public static bool ComboBoxEstaVazio(ComboBox cbo, bool bMostrarMesageBox)
		{
			if(cbo.Text.Trim() == string.Empty)
			{
				if(bMostrarMesageBox == true)
				{
					MessageBox.Show("O campo \"" + cbo.AccessibleDescription + "\" não pode ser deixado em branco!", "Em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);  
				}

				cbo.Focus(); 
				return true;
			}
			return false; 
		}
		public static bool ComboBoxEstaVazio_ByRef(ref ComboBox cbo, bool bMostrarMesageBox)
		{
			if(cbo.Text.Trim() == string.Empty)
			{
				if(bMostrarMesageBox == true)
				{
					MessageBox.Show("O campo \"" + cbo.AccessibleDescription + "\" não pode ser deixado em branco!", "Em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);  
				}

				cbo.Focus(); 
				return true;
			}
			return false; 
		}

		public static bool CheckBoxes_Verificar(GroupBox objGroupBox)
		{		
			foreach(Control objControl in objGroupBox.Controls)
			{
				if(objControl is CheckBox)
				{
					CheckBox objCheckBox = objControl as CheckBox;

					string sLabel = objCheckBox.Text;  
					
					if(objCheckBox.Checked)
					{
						return true;
					}
				}
			}
	
			return false;
		}

		
		public static bool RegistroExisteListView(ListView objListView, string Dados, int index)
		{
			for(int i=0; i < objListView.Items.Count; i++)
			{
				if(index == 0)
				{
					if(string.CompareOrdinal(objListView.Items[i].Text, Dados) == 0)
					{
						return true;
					}
				}
				else
				{
					if(string.CompareOrdinal(objListView.Items[i].SubItems[index].Text, Dados) == 0)
					{
						return true;
					}
				}
			} 
			return false;
		}

		public static bool RegistroExisteListView_ByRef(ref ListView objListView, string Dados, int index)
		{
			for(int i=0; i < objListView.Items.Count; i++)
			{
				if(index == 0)
				{
					if(string.CompareOrdinal(objListView.Items[i].Text, Dados) == 0)
					{
						return true;
					}
				}
				else
				{
					if(string.CompareOrdinal(objListView.Items[i].SubItems[index].Text, Dados) == 0)
					{
						return true;
					}
				}
			} 
			return false;
		}

		public static string RemoverCaracteresEspeciais(string sTexto)
		{
			char[] trim = {'=',';', ':', '+', '*', '&', '%',
							  '@', '\"', '!', '#', '$', '\'', '<', 
							  '>', '{', '}', '[', ']', '(', ')', ',', '.'};
			int pos;

			while((pos = sTexto.IndexOfAny(trim)) >= 0)
			{
				sTexto = sTexto.Remove(pos,1); 
			}

			return sTexto;
		}

		public static string Converter_ComPonto(string sValor)
		{
			string Valor = string.Empty;
			
			string Mascara = @"(\d{1,3})"; 

			try
			{
				Regex r = new Regex(Mascara);			

				for(Match m = r.Match(sValor); m.Success; m = m.NextMatch())
				{			
					Valor = "." + m.Value;
				}	
				
				return Valor;
			}
			catch(Exception exc)
			{
				throw(exc);
			}			
		}


		#region EXPORTAR PARA EXCEL
		/**************************************************************
		* Função criada por		= Luciano da Silva Dória
		* Data de criação		= 21/06/2006 13:34:17
		* Data de modificação	= 
		**************************************************************/
		internal static void ExportExcel(ListView objLvw)//, string FileName, bool blnOpenFile)
		{
			System.Collections.Generic.List<int> lstColumns;
           
			try
			{
				CriadorBlocoCodigo.frmShowExcelSelection FormShowExcelSelection = new CriadorBlocoCodigo.frmShowExcelSelection(); 

				FormShowExcelSelection.objListViewPlus = objLvw; 

				FormShowExcelSelection.ShowDialog();
 
				if(FormShowExcelSelection.dialogresult == DialogResult.Cancel)
				{
					return; 
				}
                
				lstColumns = FormShowExcelSelection.lstColumns;  
			}
			catch (Exception exc)
			{
                MessageBox.Show(exc.Message, "Funcoes", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}

			#region Variaveis do Excel
            
			Excel.Application xl		= null;
			Excel._Workbook wb			= null;
			Excel._Worksheet sheet		= null;
			Excel.Range oRng			= null;
            
			#endregion

			try
			{
				#region inicialização das variaveis
				GC.Collect(); 

				// Create a new instance of Excel from scratch
				xl = new Excel.Application();
				xl.Visible = true;
			 
				// Add one workbook to the instance of Excel
				wb = (Excel._Workbook)(xl.Workbooks.Add( Missing.Value ));

				// Get a reference to the one and only worksheet in our workbook
				sheet = (Excel._Worksheet)wb.ActiveSheet;

				#endregion

				int ColumnsCount = lstColumns.Count;

				#region insere os nomes das colunas 
				for (int i = 0; i < ColumnsCount; i++)
				{				
					sheet.Cells[1,i + 1] = objLvw.Columns[lstColumns[i]].Text;
				}
				#endregion

				for (int r=1; r <= objLvw.Items.Count; r++)
				{
					for (int c = 0; c < ColumnsCount; c++)
					{
						sheet.Cells[r + 1, c + 1] = objLvw.Items[r - 1].SubItems[lstColumns[c]].Text; 
					}

					#region Coloca cor no registro de acordo com a cor do registro no grid
					//Colocar cor no registro de acordo com a cor do grid
					int br = (int)objLvw.Items[r-1].SubItems[0].ForeColor.R;  
					int bg = (int)objLvw.Items[r-1].SubItems[0].ForeColor.G; 
					int bb = (int)objLvw.Items[r-1].SubItems[0].ForeColor.B; 
					
					sheet.get_Range(sheet.Cells[r+1,1],sheet.Cells[r+1, ColumnsCount]).Font.Color = Color.FromArgb(bb, bg, br).ToArgb();
					#endregion
				}

				sheet.get_Range("A1", sheet.Cells[1, ColumnsCount]).Interior.Color = Color.DimGray.ToArgb();
				sheet.get_Range("A1", sheet.Cells[1, ColumnsCount]).Font.Color = Color.White.ToArgb();
				sheet.get_Range("A1", sheet.Cells[1, ColumnsCount]).Font.Bold = true;

				#region Alinha os campos

				for (int c = 1; c <= ColumnsCount; c++)
				{				
					switch(objLvw.Columns[lstColumns[c-1]].TextAlign)
					{
						case HorizontalAlignment.Left:
						{
							sheet.get_Range(sheet.Cells[1,c],sheet.Cells[(objLvw.Items.Count + 1),c]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft; 
							break;
						}
						case HorizontalAlignment.Center:
						{
							sheet.get_Range(sheet.Cells[1,c],sheet.Cells[(objLvw.Items.Count + 1),c]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; 
							break;
						}
						case HorizontalAlignment.Right:
						{
							sheet.get_Range(sheet.Cells[1,c],sheet.Cells[(objLvw.Items.Count + 1),c]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight; 
							break;
						}
					}
				}

				#endregion

				//AutoFit columns.
				oRng = sheet.get_Range("A1", sheet.Cells[1, ColumnsCount]);
				oRng.EntireColumn.AutoFit();
				
				//Insere GRID
				sheet.get_Range("A1", sheet.Cells[(objLvw.Items.Count + 1), ColumnsCount]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;   
				
				// Let loose control of the Excel instance
				//				xl.Visible		= false;
				xl.UserControl	= false;
			}
			catch(Exception err) 
			{
				String msg;
				msg = "Error: ";
				msg = String.Concat(msg,err.Message);
				msg = String.Concat(msg," Line: ");
				msg = String.Concat(msg,err.Source); 
				
				MessageBox.Show(msg,"Funcoes",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
				if (sheet !=null)   { Marshal.ReleaseComObject(sheet); }
				if (wb !=null)      { Marshal.ReleaseComObject(wb); }
				if (xl !=null)      { Marshal.ReleaseComObject(xl); }

				sheet=null;
				wb=null;
				xl = null;
				GC.Collect(); 
			}
		}
		
		#endregion

	}
