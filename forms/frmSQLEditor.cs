using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using System.Threading;
using System.Data.SqlClient;
using DBTools.classes;

namespace DBTools.forms
{
    public partial class frmSQLEditor : Crom.Controls.DockableToolWindow
    {
        private enum Tipo
        {
            COPIAR = 0,
            ENUMERAR = 1
        }

        private string      m_fileName = string.Empty; 
        private Database    m_dataBase;
        private string      m_dataBaseName = string.Empty;

        internal string DataBaseName
        {
            get { return m_dataBaseName; }
            set { m_dataBaseName = value; }
        } 

        public Database DataBase
        {
            get { return m_dataBase; }
            set { m_dataBase = value; }
        }

        public frmSQLEditor()
        {
            InitializeComponent();

            //txtQuery.AutoComplete.RegisterImages(imgIcon);
            ScintillaNet.AutoCompleteIDE autoComplete = new ScintillaNet.AutoCompleteIDE(txtQuery);
  
            autoComplete.RegisterImages(imgAutoComplete);

            toolStrip1.Items.Insert(14,new ToolStripControlHost(chkMultline));  
        }

#region FORM

        private void frmSQLEditor_Load(object sender, EventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
 
                txtQuery.AutoComplete.ListString = ""; 

                lvwResultado.Sorter = false;
                txtQuery.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtQuery_DragEnter);
                txtQuery.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtQuery_DragDrop);
                
                txtQuery.Text = "";
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
        private void frmSQLEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Funcoes.FormMain.mnuExibirSQLEditor.Enabled = true; 
        }

#endregion

#region FUNÇÕES ESPECIAIS

        private void Converter(Tipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                for (int i = 0; i < lvwColunas.Items.Count; i++)
                {
                    if (lvwColunas.Items[i].Checked)
                    {
                        string strNome = lvwColunas.Items[i].SubItems[1].Text;
                        string strTipo = lvwColunas.Items[i].SubItems[2].Text;

                        switch (tipo)
                        {
                            case Tipo.COPIAR:
                                {
                                    #region COPAIR

                                    sb.Append(strNome);

                                    if (chkIncluirTipo.Checked)
                                    {
                                        sb.Append(" ");
                                        sb.Append(strTipo);
                                    }

                                    sb.Append(Environment.NewLine);

                                    break;
                                    #endregion
                                }
                            case Tipo.ENUMERAR:
                                {
                                    #region ENUMERAR

                                    sb.Append(strNome);

                                    if (chkIncluirTipo.Checked)
                                    {
                                        sb.Append(" ");
                                        sb.Append(strTipo);
                                    }

                                    sb.Append(Environment.NewLine);

                                    break;
                                    #endregion
                                }
                        }

                    }
                }

                Clipboard.SetDataObject(sb.ToString(), true);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private string getTableName()
        {
            try
            {
                string selText = "";
                int pos = txtQuery.CurrentPos;

                txtQuery.CurrentPos = pos - 1;
                txtQuery.NativeInterface.WordLeftExtend();

                txtQuery.NativeInterface.GetSelText(out selText);

                string ret_val = selText.Substring(0, selText.Length);

                txtQuery.CurrentPos = pos;

                return ret_val;
            }
            catch
            {
                return string.Empty;
            }
        }
        private bool isCommand(string command)
        {
            try
            {
                string selText = "";
                int pos = txtQuery.CurrentPos;

                txtQuery.CurrentPos = pos - 1;
                txtQuery.NativeInterface.WordLeftExtend();

                txtQuery.NativeInterface.GetSelText(out selText);

                string ret_val = selText.Substring(0, selText.Length);

                txtQuery.CurrentPos = pos;

                return ret_val.Trim().ToLower() == command.ToLower() ? true : false;
            }
            catch
            {
                return false;
            }
        }
        private string getCommand()
        {
            try
            {
                string selText = "";
                int pos = txtQuery.CurrentPos;

                txtQuery.CurrentPos = pos - 1;
                txtQuery.NativeInterface.WordLeftExtend();

                txtQuery.NativeInterface.GetSelText(out selText);

                string ret_val = selText.Substring(0, selText.Length);

                txtQuery.CurrentPos = pos;

                return ret_val;
            }
            catch
            {
                return string.Empty;
            }
        }
        private List<string> GetAutoCompleteValues(string name)
        {
            List<string> list = new List<string>();

            list = Funcoes.FormMain.FormServerExplorer.m_autoComplete.GetList(m_dataBaseName, name);    

           return list;
        }
        private List<string> GetAutoCompleteObjectsTypes(List<AutoCompleteClass.ObjectType> objectTypes)
        {
            List<string> list = new List<string>();

            list = Funcoes.FormMain.FormServerExplorer.m_autoComplete.GetListObjectsTypes(m_dataBaseName, objectTypes);    

           return list;
        }
        internal void SetAutoCompleteDefault()
        {
            List<string> list = new List<string>();

            list = Funcoes.FormMain.FormServerExplorer.m_autoComplete.GetObjectsDB(m_dataBaseName); 
  
            txtQuery.AutoComplete.List = list;
        }

#endregion

#region EVENTOS DE OBJETOS

        private void txtQuery_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }       
        private void txtQuery_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

        }
        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { btnRunComando_Click(null, null); }
        }
        private void txtQuery_CharAdded(object sender, ScintillaNet.CharAddedEventArgs e)
        {
            try
            {
                if (e.Ch == '.')
                {
                    string tableName = getTableName();

                    List<string> list = GetAutoCompleteValues(tableName);

                    if(list.Count > 0)
                    {
                        txtQuery.AutoComplete.Show(0, list);
                        
                        SetAutoCompleteDefault();
                    }
                }

                if (e.Ch == (char)Keys.Space)
                {
                    string command = getCommand();

                    List<AutoCompleteClass.ObjectType> objectsTypes = new List<AutoCompleteClass.ObjectType>(); 

                    switch (command)
                    {
                        case "from":
                        case "where":
                        case "join":
                        case "on":
                            {
                                objectsTypes.Add(AutoCompleteClass.ObjectType.Table);
                                objectsTypes.Add(AutoCompleteClass.ObjectType.View);  
                                break;
                            }
                        case "exec":
                        case "execute":
                            {
                                objectsTypes.Add(AutoCompleteClass.ObjectType.StoredProcedure); 
                                break;
                            }
                        case "top":
                            {
                                List<string> textList = new List<string>(); 
 
                                textList.Add("5");
                                textList.Add("10");
                                textList.Add("20");
                                textList.Add("50");
                                textList.Add("100");
                                textList.Add("1000");
                                textList.Add("5000");
                                textList.Add("10000");

                                txtQuery.AutoComplete.Show(0, textList);
                        
                                SetAutoCompleteDefault();
                                return;
                            }
                        case "in":
                        case "values":
                            {
                                txtQuery.AppendText("()");
                                txtQuery.CurrentPos = txtQuery.CurrentPos + 1;
                                SetAutoCompleteDefault();
                                break;
                            }
                    }

                    if(objectsTypes.Count > 0)
                    {
                        List<string> list = GetAutoCompleteObjectsTypes(objectsTypes);

                        if(list.Count > 0)
                        {
                            txtQuery.AutoComplete.Show(0, list);
                        
                            SetAutoCompleteDefault();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void btnExportarParaExcel_Click(object sender, EventArgs e)
        {
            try
            {
                btnExportarParaExcel.Enabled = false;

                lvwResultado.ExportToExcel();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                btnExportarParaExcel.Enabled = true;
            }
        }
        private void btnApagarTexto_Click(object sender, System.EventArgs e)
        {
            txtQuery.Text = string.Empty;
            txtResultado.Clear();
  
            drResultados.DataSource = null;
            lvwColunas.Items.Clear();
            lvwResultado.Items.Clear();
            lvwResultado.Columns.Clear();
        }
        private void btnRunComando_Click(object sender, System.EventArgs e)
        {
            btnRunComando.Enabled = false;

            Funcoes.ShowCursor(this, CursorType.WaitCursor);

            try
            {
                string sqlCommand = string.Empty;

                if(txtQuery.Selection.Text.Trim().Length > 5)
                {
                    sqlCommand = txtQuery.Selection.Text.Trim();
                }
                else
                {
                    sqlCommand = txtQuery.Text.Trim();
                }

                if (sqlCommand.Trim().Length <= 0)
                {
                    return;
                }

                if(sqlCommand.ToLower().Contains("select "))
                {
                    drResultados.DataSource = null;
                    
                    //DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(sqlCommand);
                    DataTable dt = Funcoes.FormServerExplorer.m_so.Query(sqlCommand);

                    drResultados.DataSource = dt.DefaultView;

                    lvwColunas.Items.Clear();
                    lvwResultado.Items.Clear();
                    lvwResultado.Columns.Clear();
                    cboColunas.Items.Clear(); 
                    lvwResultado.Sorter = false;

                    int totalColumns = dt.Columns.Count;

                    for (int i = 0; i < totalColumns; i++)
                    {
                        ArrayList aDados = new ArrayList();

                        int intID = i + 1;

                        aDados.Add(intID.ToString());
                        aDados.Add(dt.Columns[i].Caption);
                        aDados.Add(dt.Columns[i].DataType.Name);

                        lvwColunas.Add(aDados);
                        lvwResultado.Columns.Add(dt.Columns[i].Caption, 120);
                        cboColunas.Items.Add(dt.Columns[i].Caption);  
                    }

                    lvwResultado.Add(ref dt);

                    txtResultado.Text = "(" + dt.Rows.Count.ToString() + " row(s) affected)";
                }
                else
                {
                    Funcoes.FormMain.SqlSmoTools.ExecuteNonQuery(sqlCommand);
                    //Funcoes.FormMain.SqlSmoTools.Query(sqlCommand);

                    txtResultado.Text = "Executado!";
                }
                //dt.TableName = "Reference";
                //dt.WriteXml(Application.StartupPath + @"\Reference.xml", XmlWriteMode.WriteSchema);     
            }
            catch(SmoException  exc)
            {
                string messageErro = "SmoExceptionType: " + exc.SmoExceptionType.ToString() +
                                     "\n\nMessage: " + exc.InnerException.InnerException.Message.ToString();

                 txtResultado.Text = messageErro.Replace("\n", Environment.NewLine); 

                Funcoes.LogError(this.Name, exc); 
            }
            catch (System.Data.SqlClient.SqlException exc)
            {
                string messageErro = "ErrorCode: " + exc.ErrorCode.ToString() +
                                     "\nLineNumber: " + exc.LineNumber.ToString() + 
                                     "\nNumber: " + exc.Number.ToString() +
                                     "\nProcedure: " + exc.Procedure +
                                     "\n\nMessage: " + exc.Message.ToString() +
                                     "\n\nStackTrace: " + exc.StackTrace.ToString();

                txtResultado.Text = messageErro.Replace("\n", Environment.NewLine);

                Funcoes.LogError(this.Name, exc);  
            }
            catch (Exception exc)
            {
                txtResultado.Text = exc.Message.Replace("\n", Environment.NewLine);

                Funcoes.LogError(this.Name, exc);           
            }
            finally
            {
                btnRunComando.Enabled = true;
                
                Funcoes.ShowCursor(this, CursorType.Default);
            }
        }
        private void btnCopiarCampos_Click(object sender, System.EventArgs e)
        {
            try
            {
                Converter(Tipo.COPIAR);
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
        private void chkMarcarTodas_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                bool bMarcado = chkMarcarTodas.Checked;

                for (int i = 0; i < lvwColunas.Items.Count; i++)
                {
                    lvwColunas.Items[i].Checked = bMarcado;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnExportarHtml_Click(object sender, EventArgs e)
        {
            try
            {
                string arquivo  = Application.StartupPath + @"\temp.html"; 
                string texthtml = Funcoes.ExportToHTML(lvwResultado);

                DLLFuncoes.Funcoes func = new DLLFuncoes.Funcoes();

                func.GravarNoArquivo(arquivo, texthtml, true);

                if (File.Exists(arquivo))
                {
                    Funcoes.ExecuteFile(arquivo, "");
                }
                else
                {
                    MessageBox.Show("Arquivo não foi criado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

#endregion

        private void objects_btnSearch_Click(object sender, EventArgs e)
        {
            lvwObjects.Items.Clear();
 
            bool bAnd = false;

            StringBuilder query = new StringBuilder();
 
            query.Append("SELECT dbo.sysobjects.name, dbo.sysobjects.xtype, dbo.sysusers.name AS owner, ");
            query.Append(" dbo.sysobjects.uid, dbo.sysobjects.crdate, dbo.sysobjects.id ");
            query.Append(" FROM dbo.sysobjects LEFT OUTER JOIN ");
            query.Append(" dbo.sysusers ON dbo.sysobjects.uid = dbo.sysusers.uid ");
            query.Append(" WHERE ");

            query.Append("(");
            // TABLEs
            if(objects_chkTables.Checked)
            {
                query.Append(" dbo.sysobjects.xtype='U' ");
                
                bAnd = true;
            }
            // VIEWS
            if(objects_chkViews.Checked)
            {
                if(bAnd){query.Append(" OR ");}
 
                query.Append(" dbo.sysobjects.xtype='V' ");
                
                bAnd = true;
            }
            // SPs
            if(objects_chkSPs.Checked)
            {
                if(bAnd){query.Append(" OR ");}
 
                query.Append(" dbo.sysobjects.xtype='P' ");
                
                bAnd = true;
            }
            query.Append(")");

            if(bAnd == false)
            {
                query.Replace("(", ""); 
                query.Replace(")", ""); 
            }
            // Name
            if(objects_chkName.Checked)
            {
                if(bAnd){query.Append(" AND ");}
 
                query.Append(" dbo.sysobjects.name LIKE '%" + objects_txtName.Text.Trim() + "%'");
                
                bAnd = true;
            }
            // Date
            if(objects_chkCreateDate.Checked)
            {
                if(bAnd){query.Append(" AND ");}
 
                query.Append(objects_DateControl.GetDateSQLQuery("dbo.sysobjects.crdate"));
            }

            if(bAnd == false)
            {
                query.Replace("WHERE", ""); 
            }

            try
            {
                lvwObjects.Sorter = false;

                DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    string type_desc = "";
                    int iconType = -1;
                    string xtype = dt.Rows[i]["xtype"].ToString().Trim();

                    switch (xtype)
                    {
                        case "U":
                            {
                                iconType    = 0;
                                type_desc   = "Table";
                                break;
                            }
                        case "V":
                            {
                                iconType    = 1;
                                type_desc   = "View";
                                break;
                            }
                        case "P":
                            {
                                iconType    = 2;
                                type_desc   = "SP";
                                break;
                            }
                        default:
                            {
                                iconType    = -1;
                                type_desc   = "? = " + xtype;
                                break;
                            }
                    }

                    aDados.Add(dt.Rows[i]["name"]);
                    aDados.Add(dt.Rows[i]["owner"]);
                    aDados.Add(Convert.ToDateTime(dt.Rows[i]["crdate"]).ToString("dd/MM/yyyy HH:mm:ss"));
                    aDados.Add(type_desc);
                    aDados.Add(dt.Rows[i]["id"]);

                    lvwObjects.Add(aDados, iconType);
                }               
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
            finally
            {
                Objects_lblTotal.Text = lvwObjects.Items.Count.ToString();
                lvwObjects.Sorter = true;
            }
        }
        private void objects_chkName_CheckedChanged(object sender, EventArgs e)
        {
            objects_txtName.Enabled = objects_chkName.Checked; 
        }
        private void objects_chkCreateDate_CheckedChanged(object sender, EventArgs e)
        {
            objects_DateControl.Enabled = objects_chkCreateDate.Checked;   
        }
        private void Objects_btnExportarExcel_Click(object sender, EventArgs e)
        {
            lvwObjects.ExportToExcel(Objects_btnExportarExcel); 
        }
        private void objects_txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return){objects_btnSearch_Click(null, null);}  
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter  = "Arquivos de consulta (*.sql, *.txt)|*.sql;*.txt";
                ofd.Title   = "Selecione o arquivo a ser aberto";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    m_fileName = ofd.FileName; 
 
                    txtQuery.Text = IOClass.ReadFileToEnd(m_fileName);
                }
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
        private void btnSalvarTextoEmArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(m_fileName))
                {
                    Funcoes.FileWrite(m_fileName, txtQuery.Text, true, false);
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
 
                    sfd.Filter  = "Arquivos de consulta (*.sql)|*.sql";
                    sfd.Title   = "Salvar arquivo";

                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        m_fileName = sfd.FileName;

                        Funcoes.FileWrite(m_fileName, txtQuery.Text, true, false);
                    }
                }
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
        private void btnSalvaArquivoComo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter  = "Arquivos de consulta (*.sql)|*.sql";
                sfd.Title   = "Salvar arquivo como";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    m_fileName = sfd.FileName;

                    Funcoes.FileWrite(m_fileName, txtQuery.Text, true, false);
                }
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
        private void btnRunComandoSPDataTable_Click(object sender, EventArgs e)
        {
            btnRunComandoSPDataTable.Enabled = false;
            Funcoes.ShowCursor(this, CursorType.WaitCursor);

            DataTable dt = new DataTable("Tabela");
            DataTable dtTemp;

            try
            {
                drResultados.DataSource = null;

                lvwColunas.Items.Clear();
                lvwResultado.Items.Clear();
                lvwResultado.Columns.Clear();
                lvwResultado.Sorter = false;

                List<string> sqlCommand = new List<string>();

                if (txtQuery.Text.Trim().Length <= 0)
                {
                    return;
                }

                if(chkMultline.Checked)
                {
                    for (int l = 0; l < txtQuery.Lines.Count; l++)
                    {
                        if(txtQuery.Lines[l].Text.Trim().Length > 0)
                        {
                            sqlCommand.Add(txtQuery.Lines[l].Text.Trim());
                        }
                    }
                }
                else
                {
                    if(txtQuery.Selection.Text.Trim().Length > 5)
                    {
                        sqlCommand.Add(txtQuery.Selection.Text.Trim());
                    }
                    else
                    {
                        sqlCommand.Add(txtQuery.Text.Trim());
                    } 
                }

                if(sqlCommand.Count > 1)
                {
                    dt = Funcoes.FormMain.SqlSmoTools.Query(sqlCommand[0]);
                    
                    dt.Rows.Clear();
  
                    foreach (string sql in sqlCommand)
                    {
                        dtTemp = Funcoes.FormMain.SqlSmoTools.Query(sql);

                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            dt.ImportRow(dtTemp.Rows[i]);    
                        }   
                    }
                }
                else
                {
                    dt = Funcoes.FormMain.SqlSmoTools.Query(sqlCommand[0]);
                }

                drResultados.DataSource = dt.DefaultView;

                int totalColumns = dt.Columns.Count;

                for (int i = 0; i < totalColumns; i++)
                {
                    ArrayList aDados = new ArrayList();

                    int intID = i + 1;

                    aDados.Add(intID.ToString());
                    aDados.Add(dt.Columns[i].Caption);
                    aDados.Add(dt.Columns[i].DataType.Name);

                    lvwColunas.Add(aDados);
                    lvwResultado.Columns.Add(dt.Columns[i].Caption, 120);
                }

                lvwResultado.Add(ref dt);

                txtResultado.Text = "(" + dt.Rows.Count.ToString() + " row(s) affected)";
            }
            catch(SmoException  smoExc)
            {
                string messageErro = "SmoExceptionType: " + smoExc.SmoExceptionType.ToString() +
                                     "\n\nMessage: " + smoExc.InnerException.InnerException.Message.ToString();

                 txtResultado.Text = messageErro.Replace("\n", Environment.NewLine); 

                MessageBox.Show(messageErro, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Data.SqlClient.SqlException sqlExc)
            {
                string messageErro = "ErrorCode: " + sqlExc.ErrorCode.ToString() +
                                     "\nLineNumber: " + sqlExc.LineNumber.ToString() + 
                                     "\nNumber: " + sqlExc.Number.ToString() +
                                     "\nProcedure: " + sqlExc.Procedure +
                                     "\n\nMessage: " + sqlExc.Message.ToString() +
                                     "\n\nStackTrace: " + sqlExc.StackTrace.ToString();

                txtResultado.Text = messageErro.Replace("\n", Environment.NewLine);

                MessageBox.Show(messageErro, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exc)
            {
                txtResultado.Text = exc.Message.Replace("\n", Environment.NewLine);

                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                btnRunComandoSPDataTable.Enabled = true;
                //btnRunComandoSPDataTable.Refresh();
                Funcoes.ShowCursor(this, CursorType.Default);
                //lvwResultado.Sorter = true;
            }
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            chkMultline.Checked = !chkMultline.Checked;  
        }
        private void chkSorterOrder_CheckedChanged(object sender, EventArgs e)
        {
            lvwResultado.Sorter = chkSorterOrder.Checked;  
        }
        private void btnSearchNOTIN_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread(new ThreadStart(SearchNOTIN));

                t.IsBackground = true;
                t.Start();
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
        private void SearchNOTIN()
        {
            lvwObjects.Items.Clear();
 
            StringBuilder query = new StringBuilder();
 
            query.Append("SELECT dbo.sysobjects.name, dbo.sysobjects.xtype, dbo.sysusers.name AS owner, ");
            query.Append(" dbo.sysobjects.uid, dbo.sysobjects.crdate, dbo.sysobjects.id ");
            query.Append(" FROM dbo.sysobjects LEFT OUTER JOIN ");
            query.Append(" dbo.sysusers ON dbo.sysobjects.uid = dbo.sysusers.uid ");
            query.Append(" WHERE dbo.sysobjects.xtype IN ('U','V','P') AND ");
            query.Append(" dbo.sysobjects.name NOT IN (");

            try
            {
                Funcoes.ActvButton(ref btnSearchNOTIN);
                Funcoes.ActvButton(ref objects_btnSearch);

                lvwObjects.Sorter = false;
                bool virgula = false;

                string[] arrayLines = Clipboard.GetText().Trim().Split(',');//,  StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < arrayLines.Length; i++)
                {
                    if(virgula){query.Append(",");}

                    query.Append("'" + arrayLines[i] + "'");

                    virgula = true;
                }

                query.Append(")");

                DataTable dt = Funcoes.FormMain.SqlSmoTools.Query(query.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArrayList aDados = new ArrayList();

                    string type_desc = "";
                    int iconType = -1;
                    string xtype = dt.Rows[i]["xtype"].ToString().Trim();

                    switch (xtype)
                    {
                        case "U":
                            {
                                iconType    = 0;
                                type_desc   = "Table";
                                break;
                            }
                        case "V":
                            {
                                iconType    = 1;
                                type_desc   = "View";
                                break;
                            }
                        case "P":
                            {
                                iconType    = 2;
                                type_desc   = "SP";
                                break;
                            }
                        default:
                            {
                                iconType    = -1;
                                type_desc   = "? = " + xtype;
                                break;
                            }
                    }

                    aDados.Add(dt.Rows[i]["name"]);
                    aDados.Add(dt.Rows[i]["owner"]);
                    aDados.Add(Convert.ToDateTime(dt.Rows[i]["crdate"]).ToString("dd/MM/yyyy HH:mm:ss"));
                    aDados.Add(type_desc);
                    aDados.Add(dt.Rows[i]["id"]);

                    lvwObjects.Add(aDados, iconType);
                }               
            }
            catch(SmoException  smoExc)
            {
                string messageErro = "SmoExceptionType: " + smoExc.SmoExceptionType.ToString() +
                                     "\n\nMessage: " + smoExc.InnerException.InnerException.Message.ToString();

                txtResultado.Text = messageErro.Replace("\n", Environment.NewLine); 

                Funcoes.LogError(this.Name, smoExc);
            }
            catch (SqlException sqlExc)
            {
                string messageErro = "ErrorCode: " + sqlExc.ErrorCode.ToString() +
                                     "\nLineNumber: " + sqlExc.LineNumber.ToString() + 
                                     "\nNumber: " + sqlExc.Number.ToString() +
                                     "\nProcedure: " + sqlExc.Procedure +
                                     "\n\nMessage: " + sqlExc.Message.ToString() +
                                     "\n\nStackTrace: " + sqlExc.StackTrace.ToString();

                txtResultado.Text = messageErro.Replace("\n", Environment.NewLine);

                Funcoes.LogError(this.Name, sqlExc);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Objects_lblTotal.Text = lvwObjects.Items.Count.ToString();
                lvwObjects.Sorter = true;

                Funcoes.ActvButton(ref btnSearchNOTIN);
                Funcoes.ActvButton(ref objects_btnSearch);
            }
        }

        private void btnAplicarCor_Click(object sender, EventArgs e)
        {
            try
            {
                int columnIndex = cboColunas.SelectedIndex;

                for (int i = 0; i < lvwResultado.Items.Count; i++)
                {
                    Color foreColor = Color.FromName(lvwResultado.GetItem(i, columnIndex));

                    lvwResultado.Items[i].ForeColor = foreColor;  
                }

                lvwResultado.Invalidate();

                MessageBox.Show("Coloração das linhas Executado!");
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnExportarExcelColunas_Click(object sender, EventArgs e)
        {
            try
            {
                lvwColunas.ExportToExcel(); 
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
        private void btnComment_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            if(button.Tag.ToString() == "1")
            {
                txtQuery.Lexing.LineComment();   
            }
            else
            {
                txtQuery.Lexing.LineUncomment();
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                string text = string.Empty;

                if (txtQuery.Selection.Text.Length > 0)
                {
                    text = txtQuery.Selection.Text;
                }
                else
                {
                    text = txtQuery.Text;
                }

                Clipboard.SetText(text);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }  
        }

        private void btnColarTexto_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuery.NativeInterface.Paste();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }  
        }

        private void btnOutIndent_Click(object sender, EventArgs e)
        {
            int indentation = txtQuery.NativeInterface.GetIndent();

            indent(-indentation);
        }

        private void btnIndent_Click(object sender, EventArgs e)
        {
            int indentation = txtQuery.NativeInterface.GetIndent();

            indent(indentation);
        }
        private void indent(int indentation)
        {
            try
            {
                if(txtQuery.Selection.Range.IsMultiLine)
                {
                    for (int i = txtQuery.Selection.Range.StartingLine.Number; i <= txtQuery.Selection.Range.EndingLine.Number; i++)
                    {
                        int lineIndentation = txtQuery.NativeInterface.GetLineIndentation(i);

                        txtQuery.NativeInterface.SetLineIndentation(i, lineIndentation + indentation);
                    }
                }
                else
                {
                    int lineNumber      = txtQuery.Lines.Current.Number;  
                    int lineIndentation = txtQuery.NativeInterface.GetLineIndentation(lineNumber);

                    txtQuery.NativeInterface.SetLineIndentation(lineNumber, lineIndentation + indentation);
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }  
        }

    }
}