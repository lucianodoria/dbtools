using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using DBTools.classes;
using DBTools.classes.ObjectsClass; 

namespace DBTools.forms
{
    public partial class frmPesquisa : Form
    {
        private SqlObjectsClass m_so;
        private string m_textFind = string.Empty;

        public string TextFind
        {
            get { return m_textFind; }
            set { m_textFind = value; }
        }

        public frmPesquisa(SqlObjectsClass so)
        {
            InitializeComponent();
            
            m_so = so;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            lvwPesquisa.ExportToExcel();  
        }

        private void frmPesquisa_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
 
            Thread t = new Thread(new ThreadStart(Pesquisar));
            
            t.IsBackground = true;
            t.Start(); 
        }

        /**************************************************************
        * Função criada por		= Luciano da Silva Dória
        * Data de criação		= 03/05/2007 10:16
        * Data de modificação	= 
        **************************************************************/
        public void Pesquisar()
        {
            StoredProcedures sps;

            try
            {
                btnExportarExcel.Enabled = false;
 
                Funcoes.ShowCursor(this, CursorType.WaitCursor);  

                if(m_so.StoredProceduresCache.Count > 0)
                {
                    sps = m_so.StoredProceduresCache;
                }
                else
                {
                    sps = m_so.GetStoredProcedures();
                }

                pgbPesquisa.Minimum = 0;
                pgbPesquisa.Maximum = sps.Count - 1;
                pgbPesquisa.Value   = 0;

                for (int i = 0; i < sps.Count; i++)
                {
                    int     id      = sps[i].Id;
                    string  name    = sps[i].Name;
                    string  text    = m_so.GetText(sps[i]);

                    Regex regKeywords = new Regex(@"--.*\b" + m_textFind + @"\b|\b" + m_textFind + @"\b|@" + m_textFind + @"\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    Match regMatch;

                    bool    exist       = false;
                    int     count       = 0;
                    string spText = text; 

                    for (regMatch = regKeywords.Match(spText); regMatch.Success; regMatch = regMatch.NextMatch())
                    {
                         //verifica se o texto selecionado não faz parte de um comentário
                        if (regMatch.Value.Contains("--") == false && regMatch.Value.Substring(0,1) != "@")
                        {
                            exist = true;
                            count++;
                        }
                    }

                    if (exist)
                    {
                        #region Existe
                        List<string> list = new List<string>();

                        list.Add(name);
                        list.Add(count.ToString());
                        list.Add(spText);

                        lvwPesquisa.Add(list);
                        #endregion
                    }

                    pgbPesquisa.Value = i;
                    Application.DoEvents();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message + "\n\n\nStackTrace: " + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                pgbPesquisa.Value           = 0;
                Funcoes.ShowCursor(this, CursorType.Default); 
                btnExportarExcel.Enabled    = true;
                lblTotal.Text = lvwPesquisa.Items.Count.ToString();    
            }
        }
        private void lvwPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                forms.frmVisualizarSPView formVisualizar = new frmVisualizarSPView(ShowSyntaxLanguage.SqlServer2K5,
                                                                                   lvwPesquisa.GetSelectedItem(2), 
                                                                                   m_textFind);
  
                formVisualizar.Text                 = "Visualizar SP: " + lvwPesquisa.GetSelectedItem(0);
                
                formVisualizar.ShowDialog();

                this.Activate(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\n" +
                                exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}