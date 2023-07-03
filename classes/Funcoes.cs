using System;
using System.Drawing; 
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection; 
using System.Runtime.InteropServices; 
using System.Data;
using System.Xml;
using System.IO;
using System.Diagnostics;
using forms;
using System.Text;
using System.Data.SqlClient;
using DBTools.classes;
using DBTools.classes.ObjectsClass;     

namespace DBTools
{
    public class AdvancedCursors
    {
      [DllImport("User32.dll")]
      private static extern IntPtr LoadCursorFromFile(String str);

      public static Cursor Create(string filename)
      {
        IntPtr hCursor = LoadCursorFromFile(filename);
        
        if (!IntPtr.Zero.Equals(hCursor))
        {
          return new Cursor(hCursor);
        }
        else
        {
          throw new Exception("Could not create cursor from file " + filename);
        }
      }
    }

    public enum CursorType
    {
        WaitCursor,
        Default,
        WaitCursorArrow
    }
    public enum MoveType
    {
        Up,
        Down
    }

	public class Funcoes
	{
        public static frmMain FormMain = null;
        public static DBTools.forms.frmServerExplorer FormServerExplorer = null;

		public Funcoes(){}
        /**************************************************************
        * FunÁ„o criada por		= Luciano da Silva DÛria
        * Data de criaÁ„o		= 04/12/2007 14:50
        * Data de modificaÁ„o	= 
        **************************************************************/
        public static void ShowCursor(Form form, CursorType cursorType)
        {
            try
            {
                switch (cursorType)
                {
                    case CursorType.WaitCursor:
                        {
                            form.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, @"cursor\aero_busy.ani"));
                            break;
                        }
                    case CursorType.WaitCursorArrow:
                        {
                            form.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, @"cursor\aero_working.ani"));
                            break;
                        }
                    case CursorType.Default:
                        {
                            form.Cursor = Cursors.Default;  
                            break;
                        }
                }
            }
            catch
            {
                form.Cursor = Cursors.WaitCursor;  
            }
        }
        internal static string ReplaceAccents(string text)
        {
            char[] CAcentos = "ƒ≈¡¬¿√‰·‚‡„… À»ÈÍÎËÕŒœÃÌÓÔÏ÷”‘“’ˆÛÙÚı‹⁄€¸˙˚˘«Á".ToCharArray();
            char[] SAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc".ToCharArray();

            try
            {
                for (int i = 0; i < CAcentos.Length; i++)
                {
                    text = text.Replace(CAcentos[i], SAcentos[i]);
                }

                return text;
	        }
	        catch (Exception exc)
	        {
		        throw(exc);
	        }
        }
        /// <summary>
        /// Tira caracteres invalidos para enum.
        /// </summary>
        /// <param name="text">Texto a verificar</param>
        /// <returns>Texto sem caracteres inv·lidos</returns>
        internal static string ReplaceCharactersForEnum(string text)
        {
            text = RemoverAcentos(text);

            char[] charValid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

            try
            {
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    bool igual = false;

                    for (int c = 0; c < charValid.Length; c++)
                    {
                        if (text[i] == charValid[c])
                        {
                            igual = true;
                            continue;
                        }
                    }

                    if (igual == false)
                    {
                        text = text.Remove(i, 1);
                    }
                }

                return text;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
        public static string RemoverAcentos(string AccentText)
        {
            char[] CAcentos = "ƒ≈¡¬¿√‰·‚‡„… À»ÈÍÎËÕŒœÃÌÓÔÏ÷”‘“’ˆÛÙÚı‹⁄€¸˙˚˘«Á".ToCharArray();
            char[] SAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc".ToCharArray();

            try
            {
                string text = AccentText;

                for (int i = 0; i < CAcentos.Length; i++)
                {
                    text = text.Replace(CAcentos[i], SAcentos[i]);
                }

                return text;
            }
            catch (Exception exc)
            {
                throw(exc); 
            }
        }
        /**************************************************************
        * FunÁ„o criada por		= Luciano da Silva DÛria
        * Data de criaÁ„o		= 28/11/2007 22:39
        * Data de modificaÁ„o	= 
        **************************************************************/
        public static void ListViewMoveRow(ref LucianoDoria.Forms.ListViewPlus.ListViewPlus objListViewPlus, MoveType moveType)
        {
            try
            {
                if(moveType == MoveType.Up)
                {
                    #region Up
                    
                    if (objListViewPlus.SelectedItemCount <= 0)
                    {
                        MessageBox.Show("Selecione um campo primeiro!", objListViewPlus.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if(objListViewPlus.SelectedItems[0].Index > 0)
                    {
                        int index = objListViewPlus.SelectedItems[0].Index;
                        
                        List<string>    columnsOrigem   = new List<string>();
                        List<string>    columnsDestino  = new List<string>();
                        int             columnsCount    = objListViewPlus.Columns.Count;
  
                        for (int i = 0; i < columnsCount; i++)
                        {
                            columnsOrigem.Add(objListViewPlus.GetItem(index, i));
                            columnsDestino.Add(objListViewPlus.GetItem(index-1, i));
                        }

                        for (int i = 0; i < columnsCount; i++)
                        {
                            objListViewPlus.Items[index-1].SubItems[i].Text = columnsOrigem[i];
                            objListViewPlus.Items[index].SubItems[i].Text   = columnsDestino[i];
                        }
                        
                        objListViewPlus.Items[index].Selected   = false;
                        objListViewPlus.Items[index-1].Selected = true; 
                    }

                    #endregion
                }
                else
                {
                    #region Down
                    
                    if (objListViewPlus.SelectedItemCount <= 0)
                    {
                        MessageBox.Show("Selecione um campo primeiro!", objListViewPlus.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (objListViewPlus.SelectedItems[0].Index < objListViewPlus.Items.Count-1)
                    {
                        int index = objListViewPlus.SelectedItems[0].Index;
                        
                        List<string>    columnsOrigem   = new List<string>();
                        List<string>    columnsDestino  = new List<string>();
                        int             columnsCount    = objListViewPlus.Columns.Count;
  
                        for (int i = 0; i < columnsCount; i++)
                        {
                            columnsOrigem.Add(objListViewPlus.GetItem(index, i));
                            columnsDestino.Add(objListViewPlus.GetItem(index+1, i));
                        }

                        for (int i = 0; i < columnsCount; i++)
                        {
                            objListViewPlus.Items[index+1].SubItems[i].Text = columnsOrigem[i];
                            objListViewPlus.Items[index].SubItems[i].Text   = columnsDestino[i];
                        }
                        
                        objListViewPlus.Items[index].Selected   = false;
                        objListViewPlus.Items[index+1].Selected = true; 
                    }
                    #endregion
                }
            }
            catch (Exception exc)
            {
                throw(exc); 
            }
        }
        /**************************************************************
        * FunÁ„o criada por		= Luciano da Silva DÛria
        * Data de criaÁ„o		= 28/11/2007 22:23
        * Data de modificaÁ„o	= 
        **************************************************************/
        /// <summary>
        /// Retorna o formato de documentaÁ„o default de uma SP no DPT.
        /// </summary>
        /// <returns>Texto com a documentaÁ„o default</returns>
        public static string GetSPDocument()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("--***************************************************************************" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* DescriÁ„o: <descriÁ„o do objeto>" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* Criada em:  " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine);
                sb.Append("--* Desenvolvido por: Luciano da Silva DÛria" + Environment.NewLine);
                sb.Append("--* Alterado por: <nome do respons·vel pela alteraÁ„o do objeto>" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* Release notes:" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* ??/??/???? - <descriÁ„o da alteraÁ„o>" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* ??/??/???? - BUG FIX: <descriÁ„o do bug fix>" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--* ??/??/???? - <descriÁ„o da alteraÁ„o>" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--*" + Environment.NewLine);
                sb.Append("--***************************************************************************" + Environment.NewLine);
                
                return sb.ToString(); 
            }
            catch (Exception exc)
            {
                throw(exc); 
            }
        }
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
        /// <summary>
        /// Executa um arquivo.
        /// </summary>
        /// <param name="pathFile">Caminho completo do arquivo a ser executado.</param>
        /// <param name="arguments">Argumentos de inicializaÁ„o do arquivo.</param>
        internal static void ExecuteFile(string pathFile, string arguments)
        {
            try
            {
                Process proc = new Process();

                proc.StartInfo.FileName = pathFile;
                proc.StartInfo.Arguments = " " + arguments;
                proc.Start();
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }

		public static bool TextBoxEstaVazio(TextBox txt, bool bMostrarMesageBox)
		{
			if(txt.Text.Trim() == string.Empty)
			{
				if(bMostrarMesageBox == true)
				{
					MessageBox.Show("O campo \"" + txt.AccessibleDescription + "\" n„o pode ser deixado em branco!", "AtenÁ„o", MessageBoxButtons.OK, MessageBoxIcon.Information);  
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
					MessageBox.Show("O campo \"" + txt.AccessibleDescription + "\" n„o pode ser deixado em branco!", "AtenÁ„o", MessageBoxButtons.OK, MessageBoxIcon.Information);  
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
					MessageBox.Show("O campo \"" + cbo.AccessibleDescription + "\" n„o pode ser deixado em branco!", "Em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);  
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
					MessageBox.Show("O campo \"" + cbo.AccessibleDescription + "\" n„o pode ser deixado em branco!", "Em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);  
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

        public static string GetDataType(Microsoft.SqlServer.Management.Smo.Column column)
        {
            switch (column.DataType.Name.ToLower())
            {
                case "char":
                case "nchar":
                case "nvarchar":
                case "binary":
                case "varbinary":
                case "varchar":
                    {
                        return column.DataType.Name + "(" + column.DataType.MaximumLength.ToString() + ")";
                    }
                case "numeric":
                    {
                        return column.DataType.Name + " " + column.DataType.MaximumLength.ToString() + "(" + column.DataType.NumericPrecision.ToString() + "," + column.DataType.NumericScale.ToString() + " )";
                    }
                default:
                    {
                        return column.DataType.Name;
                    }
            }
        }
        public static string GetDataType(Column column)
        {
            switch (column.DataType.Name.ToLower())
            {
                case "char":
                case "nchar":
                case "nvarchar":
                case "binary":
                case "varbinary":
                case "varchar":
                    {
                        return column.DataType.Name + "(" + column.DataType.MaximumLength.ToString() + ")";
                    }
                case "numeric":
                    {
                        return column.DataType.Name + " " + column.DataType.MaximumLength.ToString() + "(" + column.DataType.NumericPrecision.ToString() + "," + column.DataType.NumericScale.ToString() + " )";
                    }
                default:
                    {
                        return column.DataType.Name;
                    }
            }
        }
        public static string GetDataType(string datatype, int length)
        {
            switch (datatype.ToLower())
            {
                case "char":
                case "nchar":
                case "nvarchar":
                case "binary":
                case "varbinary":
                case "varchar":
                case "numeric":
                    {
                        return datatype + "(" + length.ToString() + ")";
                    }
                default:
                    {
                        return datatype;
                    }
            }
        }
        public static string GetDataTypeConvert(string dataType)
        {
            string Tipo = string.Empty;

            switch (dataType.ToLower())
            {
                case "bigint":
                case "int64":
                case "long":
                    {

                        Tipo = "ToInt64";
                        break;
                    }
                case "int":
                case "int32":
                case "numeric":
                    {
                        Tipo = "ToInt32";
                        break;
                    }
                case "decimal":
                    {
                        Tipo = "ToDecimal";
                        break;
                    }
                case "boolean":
                case "bool":
                case "bit":
                    {
                        Tipo = "ToBoolean";
                        break;
                    }
                case "short":
                case "int16":
                case "smallint":
                case "tinyint":
                case "byte":
                    {
                        Tipo = "ToInt16";
                        break;
                    }
                case "char":
                case "varchar":
                case "nvarchar":
                case "text":
                case "string":
                    {
                        Tipo = "ToString";
                        break;
                    }
                case "datetime":
                    {
                        Tipo = "ToDateTime";
                        break;
                    }
            }

            return Tipo;
        }
        public static string GetDataTypeSQLToCSharp(string dataType)
        {
            string typeValue = string.Empty;

            switch (dataType.ToLower())
            {
                case "bigint":
                case "int64":
                case "long":
                    {

                        typeValue = "Int64";
                        break;
                    }
                case "int":
                case "int32":
                    {
                        typeValue = "Int32";
                        break;
                    }
                case "numeric":
                case "decimal":
                    {
                        typeValue = "Decimal";
                        break;
                    }
                case "boolean":
                case "bool":
                case "bit":
                    {
                        typeValue = "Boolean";
                        break;
                    }
                case "short":
                case "int16":
                case "smallint":
                case "tinyint":
                case "byte":
                    {
                        typeValue = "Int16";
                        break;
                    }
                case "varchar":
                case "nvarchar":
                case "text":
                case "string":
                    {
                        typeValue = "String";
                        break;
                    }
                case "datetime":
                    {
                        typeValue = "DateTime";
                        break;
                    }
            }

            return typeValue;
        }
        public static string getSQLDataTypeConvert(string dataType)
        {
            string type = string.Empty;

            switch (dataType.ToLower())
            {
                case "bigint":
                case "int64":
                case "long":
                    {
                        type = "BigInt";
                        break;
                    }
                case "int":
                case "int32":
                case "numeric":
                    {
                        type = "Int";
                        break;
                    }
                case "decimal":
                    {
                        type = "Decimal";
                        break;
                    }
                case "boolean":
                case "bool":
                case "bit":
                    {
                        type = "Bit";
                        break;
                    }
                case "short":
                case "int16":
                case "smallint":
                case "byte":
                    {
                        type = "SmallInt";
                        break;
                    }
                case "tinyint":
                    {
                        type = "TinyInt";
                        break;
                    }
                case "char":
                    {
                        type = "Char";
                        break;
                    }
                case "nvarchar":
                    {
                        type = "NVarChar";
                        break;
                    }
                case "varchar":
                    {
                        type = "Varchar";
                        break;
                    }
                case "text":
                case "string":
                    {
                        type = "Text";
                        break;
                    }
                case "datetime":
                    {
                        type = "DateTime";
                        break;
                    }
            }

            return type;
        }
        public static string RetornaValorComTipo(string valorParam, SqlDataType sqlDataType)
        {
            string result = valorParam;
 
            switch (sqlDataType)
            {
                case SqlDataType.Bit:
                    {
                        if(valorParam.ToLower()  == "true" ||
                           valorParam.ToLower()  == "false")
                        {
                            result = valorParam.ToLower() == "true" ? "1" : "0"; 
                        }
                        else
                        {
                            result = valorParam; 
                        }
                        break;
                    }
                case SqlDataType.BigInt:
                case SqlDataType.Binary:
                case SqlDataType.Int:
                case SqlDataType.Decimal:
                case SqlDataType.Float:
                case SqlDataType.Money:
                case SqlDataType.Numeric:
                case SqlDataType.Real:
                case SqlDataType.SmallInt:
                case SqlDataType.SmallMoney:
                case SqlDataType.TinyInt:
                case SqlDataType.UniqueIdentifier:
                case SqlDataType.VarBinary:
                case SqlDataType.VarBinaryMax:
                    {
                        result = valorParam;
                        break;
                    }
                case SqlDataType.Char:
                case SqlDataType.DateTime:
                case SqlDataType.Image:
                case SqlDataType.NChar:
                case SqlDataType.NText:
                case SqlDataType.NVarChar:
                case SqlDataType.NVarCharMax:
                case SqlDataType.None:
                case SqlDataType.SmallDateTime:
                case SqlDataType.SysName:
                case SqlDataType.Text:
                case SqlDataType.Timestamp:
                case SqlDataType.UserDefinedDataType:
                case SqlDataType.UserDefinedType:
                case SqlDataType.VarChar:
                case SqlDataType.VarCharMax:
                case SqlDataType.Variant:
                case SqlDataType.Xml:
                    {
                        result = "'" + valorParam + "'";
                        break;
                    }
            }

            return result;
        }
        public static string TrataVariveis(string sLine)
        {
            string Line = sLine.Replace("@", "");

            Line = Line.Replace(",", "");

            string[] Dados = Line.Split(' ');

            string Tipo_Dados = ConvertDataTypeDBToCSharp(Dados[1]);

            return Tipo_Dados + " " + Dados[0];
        }
        public static string TrataVariveisBD(string sLine)
        {
            string Line = sLine.Replace("@", "");

            Line = Line.Replace(",", "");

            string[] Dados = Line.Split(' ');

            string Tipo_Dados = ConvertDataTypeDBToCSharp(Dados[1]);
            string Tipo_DadosNATIVO = Funcoes.GetDataTypeConvert(Dados[1]);

            string sValor = Tipo_Dados + " " + Dados[0] + " = Convert." + Tipo_DadosNATIVO + "(dt.Rows[i][\"" + Dados[0] + "\"]);";

            return sValor;
        }
        public static string TrataVariveisBDSP(string sLine)
        {
            string Line = sLine.Replace("@", "");

            Line = Line.Replace(",", "");

            string[] Dados = Line.Split(' ');

            string Tipo_DadosNATIVO = Funcoes.VerificaTipoDadosNATIVO_BD(Dados[1]);

            string sValor = Dados[0] + " " + Tipo_DadosNATIVO;

            return sValor;
        }
        public static string TrataVariveisNome(string sLine)
        {
            string Line = sLine.Replace("@", "");

            Line = Line.Replace(",", "");

            string[] Dados = Line.Split(' ');

            string Tipo_Dados = ConvertDataTypeDBToCSharp(Dados[1]);

            return Dados[0];
        }
        public static string ConvertDataTypeDBToCSharp(string dataType)
        {
            string dataTypeCSharp = string.Empty;

            switch (dataType.ToLower())
            {
                case "bigint":
                case "int64":
                    {
                        dataTypeCSharp = "long";
                        break;
                    }
                case "int":
                case "int32":
                    {
                        dataTypeCSharp = "int";
                        break;
                    }
                case "numeric":
                case "decimal":
                case "real":
                case "money":
                    {
                        dataTypeCSharp = "decimal";
                        break;
                    }
                case "boolean":
                case "bit":
                    {
                        dataTypeCSharp = "bool";
                        break;
                    }
                case "int16":
                case "smallint":
                case "tinyint":
                case "byte":
                    {
                        dataTypeCSharp = "short";
                        break;
                    }
                case "char":
                case "varchar":
                case "nchar":
                case "nvarchar":
                case "ntext":
                case "text":
                case "string":
                    {
                        dataTypeCSharp = "string";
                        break;
                    }
                case "date":
                case "datetime":
                case "smalldatetime":
                    {
                        dataTypeCSharp = "DateTime";
                        break;
                    }
                case "void":
                    {
                        dataTypeCSharp = "void";
                        break;
                    }
                default:
                    {
                        dataTypeCSharp = dataType;
                        break;
                    }
            }

            return dataTypeCSharp;
        }
        public static string PegaTipoDadosCSharp(int cod)
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
                            tipoDado = "string";
                            break;
                        }
                    case 36:// uniqueidentifier
                        {
                            tipoDado = "?";
                            break;
                        }
                    case 48:// tinyint
                        {
                            tipoDado = "long";
                            break;
                        }
                    case 52:// smallint
                        {
                            tipoDado = "short";
                            break;
                        }
                    case 56:// int
                        {
                            tipoDado = "int";
                            break;
                        }
                    case 61:// datetime
                    case 58:// smalldatetime
                        {
                            tipoDado = "DateTime";
                            break;
                        }
                    case 59:// real
                    case 60:// money
                    case 106:// decimal
                    case 122:// smallmoney
                        {
                            tipoDado = "Double";
                            break;
                        }
                    case 62:// float
                        {
                            tipoDado = "float";
                            break;
                        }
                    case 98:// sql_variant
                        {
                            tipoDado = "?";
                            break;
                        }
                    case 104:// bit
                        {
                            tipoDado = "bool";
                            break;
                        }
                    case 108:// numeric
                    case 127:// bigint
                        {
                            tipoDado = "long";
                            break;
                        }
                    case 165:// varbinary
                    case 173:// binary
                        {
                            tipoDado = "Byte";
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
        public static string VerificaTipoDadosNATIVO_BD(string Dados)
        {
            string Tipo = string.Empty;

            switch (Dados.ToLower())
            {
                case "int64":
                    {

                        Tipo = "bigint";
                        break;
                    }
                case "int32":
                    {
                        Tipo = "int";
                        break;
                    }
                case "boolean":
                    {
                        Tipo = "bit";
                        break;
                    }
                case "int16":
                    {
                        Tipo = "smallint";
                        break;
                    }
                case "string":
                    {
                        Tipo = "text";
                        break;
                    }
                case "datetime":
                    {
                        Tipo = "dateTime";
                        break;
                    }
            }

            return Tipo;
        }

        /**************************************************************
        * FunÁ„o criada por		= Luciano da Silva DÛria
        * Data de criaÁ„o		= 03/12/2007 08:30
        * Data de modificaÁ„o	= 
        **************************************************************/
        public static void FileWrite(string fileName, string text, bool overriderFile, bool runFile)
        {
            try
            {
                DLLFuncoes.Funcoes func = new DLLFuncoes.Funcoes();  

                func.GravarNoArquivo(fileName, text, overriderFile);
    
                if(runFile)
                {
                    Process p = new Process();
 
                    p.StartInfo.FileName = fileName;
                    p.Start(); 
                }
            }
            catch (Exception exc)
            {
                throw(exc); 
            }
        }
        public static List<string> NormalizeWithTab(string linesLabel, string linesValue, string charSplit)
        {
            List<string> listLinesLabel = new List<string>(); 
            List<string> listLinesValue = new List<string>(); 
            
            listLinesLabel.Add(linesLabel);
            listLinesValue.Add(linesValue); 

            return NormalizeWithTab(listLinesLabel, listLinesValue, charSplit);
        }
        public static List<string> NormalizeWithTab(List<string> listLinesLabel, List<string> listLinesValue, string charSplit)
        {
            int             countMaxChar    = 0;
            int             countChar       = 0;
            List<string>    listReturnText  = new List<string>(); 
 
            try
            {
                for (int i = 0; i < listLinesLabel.Count; i++)
                {
                    if(listLinesLabel[i].Trim().Length > countMaxChar)
                    {
                        countMaxChar    = listLinesLabel[i].Trim().Length; 
                    }
                }

                countChar   = countMaxChar/4;
                countChar++;

                for (int i = 0; i < listLinesLabel.Count; i++)
                {
                    string label = Normalize(listLinesLabel[i], countChar);

                    listReturnText.Add(label + charSplit + listLinesValue[i]);
                }

                return listReturnText;
            }
			catch(Exception exc)
			{
                throw(exc); 
			}
        }
        
        private static string Normalize(string listLinesLabel, int countMaxChar)
        {
            string label   = listLinesLabel;
           
            int countChar = listLinesLabel.Length/4;

            while (countChar < countMaxChar)
            {
                label += "\t";
                countChar++;
            }
           
            return label;
        }
        public static string GetSiglaFromName(string name)
        {
            try
            {
                string[]    nameArray   = name.Trim().Split(' ');
                string      nameTemp    = nameArray[0].Trim();

                for (int i = 1; i < nameArray.Length; i++)
                {
                    if(nameArray[i].Trim().Length > 3)
                    {
                        nameTemp += " " + nameArray[i].Trim().Substring(0, 1) + ".";
                    }
                }

                return nameTemp;
            }
            catch (Exception exc)
            {
                throw(exc); 
            }
        }
        internal static void ActvButton(ref Button button)
        {
            try
            {
                if(button.Enabled == true)
                {
                    button.AccessibleName   = button.Text;
                    button.Text		        = "Aguarde !!!";
                    button.FlatStyle	    = FlatStyle.Flat;
                    button.Enabled	        = false;
                    button.Refresh();

                    ShowCursor(button.FindForm(), CursorType.WaitCursor);     
                }
                else
                {
				    button.Text			    = button.AccessibleName;
				    button.FlatStyle		= FlatStyle.Standard;
				    button.Enabled		    = true;
				    button.Refresh();

                    ShowCursor(button.FindForm(), CursorType.Default);
                }
            }
            catch (Exception exc)
            {
                LogError("Funcoes", exc);
            }
        }

        public static string RepeatString(string text, int repeatCount)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < repeatCount; i++)
                {
                    sb.Append(text); 
                }

                return sb.ToString();
            }
            catch (Exception exc)
            {
                LogError("Funcoes", exc);
                throw(exc); 
            }
        }
        /// <summary>
        /// Retorna o nome da tabela para ser usado nas queries do Joomla.
        /// <para>Exc: 'rdeft_teste' retorna '#__teste'.</para>
        /// </summary>
        /// <param name="name">Nome da tabela</param>
        /// <returns>#__?</returns>
        public static string JoomlaGetTableNameSystem(string name)
        {
            try
            {
                return "#__" + name.Substring(6);
            }
            catch (Exception exc)
            {
                LogError("Funcoes", exc);
                throw(exc); 
            }
        }

        #region EXPORT TO HTML
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLvw"></param>
        /// <returns></returns>
        internal static string ExportToHTML(LucianoDoria.Forms.ListViewPlus.ListViewPlus objLvw)
        {
            return ExportToHTML(objLvw, string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLvw"></param>
        /// <param name="TextPos"></param>
        /// <returns></returns>
        internal static string ExportToHTML(LucianoDoria.Forms.ListViewPlus.ListViewPlus objLvw, string TextPos)
        {
            List<int> lstColumns;

            try
            {
                List<string> listColumnsNames = new List<string>();

                for (int i = 0; i < objLvw.Columns.Count; i++)
                {
                    listColumnsNames.Add(objLvw.Columns[i].Text);
                }

                frmShowExcelSelection FormShowExcelSelection = new frmShowExcelSelection(listColumnsNames);

                FormShowExcelSelection.ShowDialog();

                if (FormShowExcelSelection.Dialogresult == DialogResult.Cancel)
                {
                    return "";
                }

                lstColumns = FormShowExcelSelection.ListColumns;
            }
            catch (Exception exc)
            {
                Funcoes.LogError("Funcoes", exc);
                return "";
            }

            try
            {
                int Columnwidth = 0;
                Color forecolor = Color.Black;
                List<string> columnsAlign = new List<string>();
                int ColumnsCount = lstColumns.Count;
                StringBuilder sb = new StringBuilder();

                #region Pega a soma do tamanho de todas colunas
                for (int i = 0; i < ColumnsCount; i++)
                {
                    Columnwidth += (objLvw.Columns[lstColumns[i]].Width + 10);
                }
                #endregion

                sb.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">" + Environment.NewLine);
                sb.Append("<html>" + Environment.NewLine);
                sb.Append("<head>" + Environment.NewLine);
                sb.Append("<title></title>" + Environment.NewLine);
                sb.Append("</head>" + Environment.NewLine);
                sb.Append("<body leftmargin=\"0\" rightmargin=\"0\" bottommargin=\"0\" topmargin=\"0\" marginwidth=\"0\" marginheight=\"0\">" + Environment.NewLine);
                sb.Append("<P>" + Environment.NewLine);
                sb.Append("<TABLE id=\"Table12\" height=\"32\" width=\"" + Columnwidth.ToString() + "\" bordercolordark=\"#f1f1f1\" bordercolorlight=\"#f1f1f1\" cellspacing=\"0\" cellpadding=\"2\" border=\"1\">" + Environment.NewLine);

                #region Insere os nomes das colunas

                sb.Append("<TR>" + Environment.NewLine);

                for (int i = 0; i < ColumnsCount; i++)
                {
                    int width = objLvw.Columns[lstColumns[i]].Width + 10;
                    string columnName = objLvw.Columns[lstColumns[i]].Text;
                    string align = string.Empty;

                    switch (objLvw.Columns[lstColumns[i]].TextAlign)
                    {
                        case HorizontalAlignment.Center:
                            {
                                align = "center";
                                break;
                            }
                        case HorizontalAlignment.Left:
                            {
                                align = "left";
                                break;
                            }
                        case HorizontalAlignment.Right:
                            {
                                align = "right";
                                break;
                            }
                        default:
                            {
                                align = "left";
                                break;
                            }
                    }

                    sb.Append("<TD width=\"" + width.ToString() + "\" bgColor=\"#3399ff\" height=\"19\">" + Environment.NewLine);
                    sb.Append("<P align=\"" + align + "\"><FONT class=\"estilo2\" color=\"#ffffff\"><STRONG>" + columnName + "</STRONG></FONT></P>" + Environment.NewLine);
                    sb.Append("</TD>" + Environment.NewLine);

                    columnsAlign.Add(align);
                }

                sb.Append("</TR>" + Environment.NewLine);

                #endregion

                #region Preencher com os valore do grid

                for (int r = 0; r < objLvw.Items.Count; r++)
                {
                    sb.Append("<TR>" + Environment.NewLine);

                    forecolor = objLvw.Items[r].ForeColor;

                    for (int c = 0; c < ColumnsCount; c++)
                    {
                        string rowValue = objLvw.GetItem(r, lstColumns[c]);
                        //
                        //Campo
                        //
                        sb.Append("<TD>" + Environment.NewLine);
                        sb.Append("<P align=\"" + columnsAlign[c] + "\"><FONT class=\"estilo1\" color=\"" + forecolor.Name + "\">" + rowValue + "</FONT></P>" + Environment.NewLine);
                        sb.Append("</TD>" + Environment.NewLine);
                    }

                    sb.Append("</TR>" + Environment.NewLine);
                }

                #endregion

                sb.Append("</TABLE>" + Environment.NewLine);

                sb.Append("</P>" + Environment.NewLine);
                sb.Append("<BR>" + TextPos + Environment.NewLine);
                sb.Append("</P>" + Environment.NewLine);

                sb.Append("</body>" + Environment.NewLine);
                sb.Append("</html>" + Environment.NewLine);

                return sb.ToString();
            }
            catch (Exception exc)
            {
                Funcoes.LogError("Funcoes", exc);
                return "";
            }
        }

        #endregion

#region LOG OF ERROR
        private static void logOfError(object objExceptionGeneric,
                                       string objeto)
		{ 
            string filename = Application.StartupPath + @"\LogDeErro.txt";
            string methodName = string.Empty;
 
            try
			{         
                StringBuilder sb = new StringBuilder();
               
                methodName = getMethodName(); 

                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")); 
                sb.Append(Environment.NewLine + "******************************************************");
                sb.Append(Environment.NewLine + "* Vers„o:\t" + FormMain._TEXT_FORM);
                sb.Append(Environment.NewLine + "* Objeto:\t" + objeto);
                sb.Append(Environment.NewLine + "* MÈtodo:\t" + methodName);
                sb.Append(Environment.NewLine + "* Usu·rio: " + Environment.UserName);
                
                
                if(objExceptionGeneric is Microsoft.SqlServer.Management.Smo.SmoException)
                {
                    Microsoft.SqlServer.Management.Smo.SmoException objSmoException = objExceptionGeneric as Microsoft.SqlServer.Management.Smo.SmoException; 

                    sb.Append(Environment.NewLine + "* SmoExceptionType: " + objSmoException.SmoExceptionType.ToString());
                    sb.Append(Environment.NewLine + "* Message: " + objSmoException.InnerException.InnerException.Message.ToString());
                    sb.Append(Environment.NewLine + "* Source:\t" + objSmoException.Source);
                    sb.Append(Environment.NewLine + "* StackTrace: " + objSmoException.StackTrace);
                    sb.Append(Environment.NewLine + "* TargetSite: " + objSmoException.TargetSite);
                }
                else if(objExceptionGeneric is SqlException)
                {
                    SqlException objSqlException = objExceptionGeneric as SqlException; 

                    
                    sb.Append(Environment.NewLine + "* Message: " + objSqlException.InnerException.InnerException.Message.ToString());
                    sb.Append(Environment.NewLine + "* ErrorCode: " + objSqlException.ErrorCode.ToString());
                    sb.Append(Environment.NewLine + "* LineNumber: " + objSqlException.LineNumber.ToString());
                    sb.Append(Environment.NewLine + "* Number:\t" + objSqlException.Number.ToString());
                    sb.Append(Environment.NewLine + "* Procedure: " + objSqlException.Procedure);
                    sb.Append(Environment.NewLine + "* Source:\t" + objSqlException.Source);
                    sb.Append(Environment.NewLine + "* StackTrace: " + objSqlException.StackTrace);
                    sb.Append(Environment.NewLine + "* TargetSite: " + objSqlException.TargetSite);
                }
                else if(objExceptionGeneric is Exception)
                {
                    Exception objException = objExceptionGeneric as Exception; 

                    sb.Append(Environment.NewLine + "* Message: " + objException.Message);
                    sb.Append(Environment.NewLine + "* Source:\t" + objException.Source);
                    sb.Append(Environment.NewLine + "* StackTrace: " + objException.StackTrace);
                    sb.Append(Environment.NewLine + "* TargetSite: " + objException.TargetSite);
                }

                sb.Append(Environment.NewLine + "******************************************************");

                IOClass.AppendTextInFile(filename, sb.ToString(), false);
     
                string eventoLog = "DBTools"; 

                if(!EventLog.SourceExists(eventoLog))
                {
                    System.Diagnostics.EventLog.CreateEventSource(eventoLog, "Application");
                }

                //registra o erro no event log
                EventLog log = new EventLog("Application", ".", eventoLog);

                log.WriteEntry(sb.ToString(), EventLogEntryType.Error);
			}
			catch
			{
			}
	    }
        /// <summary>
        /// Faz o tratamento de erro.
        /// </summary>
        /// <param name="objName">Nome do objeto\classe.</param>
        /// <param name="objException">Objeto System.Exception.</param>
        /// <param name="message">Mensagem a ser visualizada no alerta.</param>
        internal static void LogError(string objName, Exception objException)
        {
            LogError(objName, objException, true);
        }
        internal static void LogError(string objName, Microsoft.SqlServer.Management.Smo.SmoException objException)
        {
            LogError(objName, objException, true);
        }
        internal static void LogError(string objName, SqlException objException)
        {
            LogError(objName, objException, true);
        }
        /// <summary>
        /// Faz o tratamento de erro.
        /// </summary>
        /// <param name="objName">Nome do objeto\classe.</param>
        /// <param name="objException">Objeto System.Exception.</param>
        /// <param name="message">Mensagem a ser visualizada no alerta.</param>
        /// <param name="showMessageBox">Se deseja que mostre uma mensagem de alerta.</param>
        internal static void LogError(string objName, Exception objException, bool showMessageBox)
        {
            if (showMessageBox)
            {
                string messageErro = "Message: " + objException.Message;

                MessageBox.Show(messageErro, "Ocorreu um Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            logOfError(objException, objName);
        }
        internal static void LogError(string objName, Microsoft.SqlServer.Management.Smo.SmoException objSmoException, bool showMessageBox)
        {
            if (showMessageBox)
            {
                string messageErro = "SmoExceptionType: " + objSmoException.SmoExceptionType.ToString() +
                                    "\n\nMessage: " + objSmoException.InnerException.InnerException.Message.ToString();

                MessageBox.Show(messageErro, "Ocorreu um Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            logOfError(objSmoException, objName);
        }
        internal static void LogError(string objName, SqlException objSqlException, bool showMessageBox)
        {
            if (showMessageBox)
            {
                string messageErro = "ErrorCode: " + objSqlException.ErrorCode.ToString() +
                                     "\nLineNumber: " + objSqlException.LineNumber.ToString() + 
                                     "\nNumber: " + objSqlException.Number.ToString() +
                                     "\nProcedure: " + objSqlException.Procedure +
                                     "\n\nMessage: " + objSqlException.Message.ToString() +
                                     "\n\nStackTrace: " + objSqlException.StackTrace.ToString();

                MessageBox.Show(messageErro, "Ocorreu um Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            logOfError(objSqlException, objName);
        }
        /// <summary>
        /// Retorna o nome do mÈtodo que gerou a Exception.
        /// </summary>
        /// <returns>Nome do mÈtodo</returns>
        private static string getMethodName()
        {
            try
            {
                StackFrame method = new StackFrame(4);
                return method.GetMethod().Name;
            }
            catch
            {
                return "";
            }
        }

        #endregion
	}
}
