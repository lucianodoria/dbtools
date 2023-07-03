using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Fireball.CodeEditor.SyntaxFiles;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace DBTools.forms
{
    public enum FormType
    {
        StoredProcedureCreate,
        StoredProcedureEdit,
        ViewCreate,
        ViewEdit
    }
    public enum ShowSyntaxLanguage
    {
        SqlServer2K5,
        CSharp
    }
    public partial class frmVisualizarSPView : Form
    {          
        public frmVisualizarSPView(ShowSyntaxLanguage showSyntaxLanguage, string codeText)
        {
            InitializeForm(showSyntaxLanguage, codeText, string.Empty, null);
        }
        public frmVisualizarSPView(ShowSyntaxLanguage showSyntaxLanguage, string codeText, FormType formType)
        {
            InitializeForm(showSyntaxLanguage, codeText, string.Empty, formType);
        }
         public frmVisualizarSPView(ShowSyntaxLanguage showSyntaxLanguage, string codeText, string textFind)
        {
            InitializeForm(showSyntaxLanguage, codeText, textFind, null);
        }
        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 03/08/2009 11:21
        * Data de modificação	= 
        **************************************************************/
        private void InitializeForm(ShowSyntaxLanguage showSyntaxLanguage, string codeText, string textFind, FormType? formType)
        {
            InitializeComponent();

            try
            {
                SyntaxLanguage syntaxLanguage = new SyntaxLanguage();

                switch (showSyntaxLanguage)
                {
                    case ShowSyntaxLanguage.SqlServer2K5:
                        {
                            syntaxLanguage = SyntaxLanguage.SqlServer2K5;  
                            break;
                        }
                    case ShowSyntaxLanguage.CSharp:
                        {
                            syntaxLanguage = SyntaxLanguage.CSharp;  
                            break;
                        }
                }

                Fireball.CodeEditor.SyntaxFiles.CodeEditorSyntaxLoader.SetSyntax(txtText, syntaxLanguage);

                if(formType.HasValue)
                {
                    switch (formType.Value)
                    {
                        case FormType.StoredProcedureCreate:
                            {
                                btnExecutar.Visible             = true;
                                btnCheckSyntax.Visible          = true;
                                txtText.ReadOnly                = false;
                                break;
                            }
                        case FormType.StoredProcedureEdit:
                            {
                                btnExecutar.Visible             = true;
                                btnCheckSyntax.Visible          = true;
                                txtText.ReadOnly                = false;
                                codeText                        = codeText.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
                                codeText                        = codeText.Replace("create PROCEDURE", "ALTER PROCEDURE");
                                break;
                            }
                        case FormType.ViewCreate:
                            break;
                    }
                }

                txtText.Document.Clear(); 
                txtText.Document.Text = codeText;

                if (textFind.Length > 0)
                {
                    ProcessRegex(textFind);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void ProcessRegex(string textFind)
        {
            Regex regKeywords = new Regex(@"--.*\b" + textFind + @"\b|\b" + textFind + @"\b|@" + textFind + @"\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;

            //string texto = txtText.Document.Text;//.Replace(Environment.NewLine, "\n");

            for (int i = 0; i < txtText.Document.Lines.Length; i++)
            {
                regMatch = regKeywords.Match(txtText.Document.Lines[i]);

                if(regMatch.Success)
                {
                    txtText.GotoLine(i); 
                    txtText.Caret.CurrentRow.Breakpoint = true;
                }
            }

            txtText.GotoLine(0); 

            txtText.Selection.SelStart      = 0;
            txtText.Selection.SelLength     = 0;
        }
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtText.Document.Text);    
        }
        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.FormMain.SqlSmoTools.ExecuteNonQuery(txtText.Document.Text);

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
        private void btnCheckSyntax_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.FormMain.SqlSmoTools.ExecuteNonQuery(txtText.Document.Text, Microsoft.SqlServer.Management.Common.ExecutionTypes.ParseOnly);

                MessageBox.Show("Syntax OK!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}