using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTools.forms
{
    public partial class frmFunction : Crom.Controls.DockableToolWindow
    {
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

        public frmFunction()
        {
            InitializeComponent();
        }

        #region FORM

        private void frmFunction_Load(object sender, EventArgs e)
        {

        }
        private void frmFunction_FormClosing(object sender, FormClosingEventArgs e)
        {
            Funcoes.FormMain.mnuExibirFuncoes.Enabled = true;
        }

        #endregion

        #region FUNÇÕES ESPECIAIS


        #endregion

        #region EVENTOS DE OBJETOS

        private void btnVariaveis_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = Funcoes.TrataVariveis(txtOrigem.Lines[i].Trim());

                        txtDestino.AppendText(sLine + ";" + Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnCopiarClipboard_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetDataObject(txtDestino.Text);
            txtDestino.Clear();
        }
        private void btnStruct_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;

                txtDestino.AppendText("public struct NOME_AQUI" + Environment.NewLine);
                txtDestino.AppendText("{" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string[] line = txtOrigem.Lines[i].Trim().Split(' ');

                        string dataType = Funcoes.ConvertDataTypeDBToCSharp(line[1]);

                        txtDestino.AppendText("	public " + dataType + " " + line[0] + ";" + Environment.NewLine);
                    }
                }

                txtDestino.AppendText("}");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnStoredProcedure_Click(object sender, System.EventArgs e)
        {
            List<string> listOutput = new List<string>();
            List<string> listOutputDataType = new List<string>();
            StringBuilder sbDestino = new StringBuilder();

            try
            {
                txtDestino.Clear();

                string sMethod = string.Empty;
                string parametros = "";

                if (Funcoes.FormMain.FormServerExplorer.VerificaSeTreeViewEstaSelecionada())
                {
                    NodeTag nodeTag = (NodeTag)Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Tag;

                    StoredProcedure sp = nodeTag.Tag as StoredProcedure;

                    sMethod = sp.Schema.ToLower() + "." + sp.Name.ToUpper();
                }

                for (int i = 0; i < Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Nodes.Count; i++)
                {
                    if (Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Nodes[i].ImageIndex == IconType.SPRowOutput)
                    {
                        listOutput.Add(Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Nodes[i].Text.Replace("@", ""));
                    }
                }

                bool virgula = false;

                if (chkSeparadoVirgula.Checked)
                {
                    #region Separado por virgula
                    string[] Dados = txtOrigem.Text.Trim().Split(',');

                    for (int i = 0; i < Dados.Length; i++)
                    {
                        if (Dados[i].Trim().Length > 0)
                        {
                            string sLine = Dados[i].Trim().Replace("@", "");
                            string[] dados = sLine.Split(' ');

                            bool exist = false;

                            for (int r = 0; r < listOutput.Count; r++)
                            {
                                if (listOutput[r].ToLower() == dados[1].ToLower())
                                {
                                    exist = true;
                                    continue;
                                }
                            }

                            if (exist) { continue; }

                            if (virgula)
                            {
                                parametros += "," + Environment.NewLine;
                            }

                            parametros += sLine;

                            virgula = true;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Não está separador por virgula
                    int iTotalLines = txtOrigem.Lines.Length;

                    virgula = false;

                    for (int i = 0; i < iTotalLines; i++)
                    {
                        if (txtOrigem.Lines[i].Trim().Length > 0)
                        {
                            string sLine = txtOrigem.Lines[i].Trim().Replace("@", "");
                            string[] dados = sLine.Split(' ');

                            bool exist = false;

                            for (int r = 0; r < listOutput.Count; r++)
                            {
                                if (listOutput[r].ToLower() == dados[1].ToLower())
                                {
                                    exist = true;
                                    continue;
                                }
                            }

                            if (exist) { continue; }

                            if (virgula)
                            {
                                parametros += "," + Environment.NewLine;
                            }

                            parametros += sLine;

                            virgula = true;
                        }
                    }
                    #endregion
                }

                sbDestino.Append("\t\t/**************************************************************" + Environment.NewLine);
                sbDestino.Append("\t\t* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
                sbDestino.Append("\t\t* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
                sbDestino.Append("\t\t* Data de modificação	=" + Environment.NewLine);
                sbDestino.Append("\t\t**************************************************************/" + Environment.NewLine);

                sbDestino.Append("\t\tinternal {@IDT@} " + sMethod.ToLower().Replace("dbo.", "") + "(" + parametros + ")" + Environment.NewLine);
                sbDestino.Append("\t\t{" + Environment.NewLine);
                sbDestino.Append("\t\t\ttry" + Environment.NewLine);
                sbDestino.Append("\t\t\t{" + Environment.NewLine);
                sbDestino.Append("\t\t\t\tSqlCommand sqlCommand = new SqlCommand(\"" + sMethod + "\", Conn);" + Environment.NewLine);
                sbDestino.Append("\t\t\t\tsqlCommand.CommandType = CommandType.StoredProcedure;" + Environment.NewLine + Environment.NewLine);

                if (chkSeparadoVirgula.Checked)
                {
                    #region separado por virgula

                    string[] Dados = txtOrigem.Text.Trim().Split(',');

                    for (int i = 0; i < Dados.Length; i++)
                    {
                        if (Dados[i].Trim().Length > 0)
                        {
                            string sLine = Dados[i].Trim().Replace("@", "");
                            string[] dados = sLine.Split(' ');

                            bool exist = false;

                            for (int r = 0; r < listOutput.Count; r++)
                            {
                                if (listOutput[r].ToLower() == dados[1].ToLower())
                                {
                                    listOutputDataType.Add(dados[0]);
                                    exist = true;
                                    break;
                                }
                            }

                            if (exist)
                            {
                                sbDestino.Append(Environment.NewLine + "\t\t\t\tsqlCommand.Parameters.AddWithValue(\"@" + dados[1] + "\", SqlDbType." + Funcoes.getSQLDataTypeConvert(dados[0]) + ");" + Environment.NewLine);
                                sbDestino.Append("\t\t\t\tsqlCommand.Parameters[\"@" + dados[1] + "\"].Direction = ParameterDirection.Output;" + Environment.NewLine);

                                if (i != (Dados.Length - 1))
                                {
                                    sbDestino.Append(Environment.NewLine);
                                }
                            }
                            else
                            {
                                sbDestino.Append("\t\t\t\tsqlCommand.Parameters.AddWithValue(\"@" + dados[1] + "\", " + dados[1] + ");" + Environment.NewLine);
                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Eseparado por linhas

                    int iTotalLines = txtOrigem.Lines.Length;

                    for (int i = 0; i < iTotalLines; i++)
                    {
                        if (txtOrigem.Lines[i].Trim().Length > 0)
                        {
                            string sLine = txtOrigem.Lines[i].Trim().Replace("@", "");
                            string[] dados = sLine.Split(' ');

                            bool exist = false;

                            for (int r = 0; r < listOutput.Count; r++)
                            {
                                if (listOutput[r].ToLower() == dados[1].ToLower())
                                {
                                    listOutputDataType.Add(dados[0]);
                                    exist = true;
                                    break;
                                }
                            }

                            if (exist)
                            {
                                sbDestino.Append(Environment.NewLine + "\t\t\t\tsqlCommand.Parameters.AddWithValue(\"@" + dados[1] + "\", SqlDbType." + Funcoes.getSQLDataTypeConvert(dados[0]) + ");" + Environment.NewLine);
                                sbDestino.Append("\t\t\t\tsqlCommand.Parameters[\"@" + dados[1] + "\"].Direction = ParameterDirection.Output;" + Environment.NewLine);

                                if (i != (iTotalLines - 1))
                                {
                                    sbDestino.Append(Environment.NewLine);
                                }
                            }
                            else
                            {
                                sbDestino.Append("\t\t\t\tsqlCommand.Parameters.AddWithValue(\"@" + dados[1] + "\", " + dados[1] + ");" + Environment.NewLine);
                            }
                        }
                    }

                    #endregion
                }

                sbDestino.Append(Environment.NewLine + "\t\t\t\tExecuteSP(ref sqlCommand);" + Environment.NewLine);

                for (int r = 0; r < listOutput.Count; r++)
                {
                    sbDestino = sbDestino.Replace("{@IDT@}", listOutputDataType[r]);
                    sbDestino.Append(Environment.NewLine + "\t\t\t\treturn Convert." + Funcoes.GetDataTypeConvert(listOutputDataType[r]) + "(sqlCommand.Parameters[\"@" + listOutput[r] + "\"].Value);" + Environment.NewLine);
                }

                if (listOutput.Count <= 0)
                {
                    sbDestino = sbDestino.Replace("{@IDT@}", "void");
                }

                sbDestino.Append("\t\t\t}" + Environment.NewLine);
                sbDestino.Append("\t\t\tcatch(Exception exc)" + Environment.NewLine);
                sbDestino.Append("\t\t\t{" + Environment.NewLine);
                sbDestino.Append("\t\t\t\tthrow(exc);" + Environment.NewLine);
                sbDestino.Append("\t\t\t}" + Environment.NewLine);
                sbDestino.Append("\t\t}");

                txtDestino.Text = sbDestino.ToString();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n" + exc.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnStoredProcedureOut_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            ArrayList aDados = new ArrayList();

            int iTotalLines = txtOrigem.Lines.Length;

            txtDestino.AppendText("public nome StoredProcedure()" + Environment.NewLine);
            txtDestino.AppendText("{" + Environment.NewLine);
            txtDestino.AppendText("		SqlCommand sqlCommand = new SqlCommand(\"SP_?\", Conn);" + Environment.NewLine);
            txtDestino.AppendText("		sqlCommand.CommandType = CommandType.StoredProcedure;" + Environment.NewLine + Environment.NewLine);

            for (int i = 0; i < iTotalLines; i++)
            {
                if (txtOrigem.Lines[i].Trim().Length > 0)
                {
                    string sLine = Funcoes.TrataVariveisNome(txtOrigem.Lines[i].Trim());
                    aDados.Add(sLine);

                    txtDestino.AppendText("		sqlCommand.Parameters.AddWithValue(\"@" + sLine + "\", SqlDbType.Text);" + Environment.NewLine);
                    txtDestino.AppendText("		sqlCommand.Parameters[\"@" + sLine + "\"].Direction = ParameterDirection.Output;" + Environment.NewLine + Environment.NewLine);
                }
            }

            txtDestino.AppendText("		ExecuteSP(ref sqlCommand);" + Environment.NewLine);


            for (int i = 0; i < aDados.Count; i++)
            {
                txtDestino.AppendText("		nome." + aDados[i].ToString() + " = sqlCommand.Parameters[\"@" + aDados[i].ToString() + "\"].Value.ToString();" + Environment.NewLine);
            }

            txtDestino.AppendText(Environment.NewLine);
            txtDestino.AppendText("		return nome;" + Environment.NewLine);
            txtDestino.AppendText("}");

            //			sqlCommand.Parameters.AddWithValue("@osNumber", SqlDbType.BigInt);
            //			sqlCommand.Parameters["@osNumber"].Direction = ParameterDirection.Output; 
            //  
            //			sqlCommand.ExecuteNonQuery();
            //			
            //			return Convert.ToInt64(sqlCommand.Parameters["@osNumber"].Value);

        }
        private void btnSeparadoVirgula_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            if (chkSeparadoVirgula.Checked)
            {
                string[] Dados = txtOrigem.Text.Trim().Split(',');

                for (int i = 0; i < Dados.Length; i++)
                {
                    if (chkAdicionarN.Checked)
                    {
                        txtDestino.AppendText("//" + i.ToString() + " - ");
                    }

                    txtDestino.AppendText(Dados[i].Trim() + Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (chkAdicionarN.Checked)
                    {
                        txtDestino.AppendText("//" + i.ToString() + " - ");
                    }

                    txtDestino.AppendText(txtOrigem.Lines[i].Trim() + Environment.NewLine);
                }
            }
        }
        private void btnCriarCamposDataSet_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            txtDestino.AppendText("for( int i = 0; i < dt.Rows.Count; i++)" + Environment.NewLine);
            txtDestino.AppendText("{" + Environment.NewLine);
            txtDestino.AppendText("		ArrayList aDados = new ArrayList();" + Environment.NewLine + Environment.NewLine);

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = "		aDados.Add(dt.Rows[i][\"" + Dados[i].Trim() + "\"]);";

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = "		aDados.Add(dt.Rows[i][\"" + sLine + "\"]);";

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }

            txtDestino.AppendText("}");

        }
        private void btnCriarColunasListview_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            #region Variaveis
            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    txtDestino.AppendText("private System.Windows.Forms.ColumnHeader clh" + Dados[i].Trim() + ";");
                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        txtDestino.AppendText("private System.Windows.Forms.ColumnHeader clh" + sLine + ";");
                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }

            #endregion

            txtDestino.AppendText(Environment.NewLine);
            txtDestino.AppendText(Environment.NewLine);

            #region Declaracao

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    txtDestino.AppendText("this.clh" + Dados[i].Trim() + " = new System.Windows.Forms.ColumnHeader();");
                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        txtDestino.AppendText("this.clh" + sLine + " = new System.Windows.Forms.ColumnHeader();");

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
            #endregion

            txtDestino.AppendText(Environment.NewLine);
            txtDestino.AppendText(Environment.NewLine);

            #region Campos
            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    if (i == (Dados.Length - 1))
                    {
                        txtDestino.AppendText("this.clh" + Dados[i].Trim() + "});");

                    }
                    else
                    {
                        txtDestino.AppendText("this.clh" + Dados[i].Trim() + ",");
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();
                        txtDestino.AppendText("		aDados.Add(dt.Rows[i][\"" + sLine + "\"]);");

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("this." + sLine + "});");

                        }
                        else
                        {
                            txtDestino.AppendText("this." + sLine + ",");
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
            #endregion

            txtDestino.AppendText(Environment.NewLine);
            txtDestino.AppendText(Environment.NewLine);

            #region Propriedades
            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    txtDestino.AppendText("//" + Environment.NewLine);
                    txtDestino.AppendText("//clh" + Dados[i].Trim() + Environment.NewLine);
                    txtDestino.AppendText("//" + Environment.NewLine);
                    txtDestino.AppendText("this.clh" + Dados[i].Trim() + ".Text = \"" + Dados[i].Trim() + "\";" + Environment.NewLine);
                    txtDestino.AppendText("this.clh" + Dados[i].Trim() + ".Width = 80;" + Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        txtDestino.AppendText("//" + Environment.NewLine);
                        txtDestino.AppendText("//clh" + sLine.Trim() + Environment.NewLine);
                        txtDestino.AppendText("//" + Environment.NewLine);
                        txtDestino.AppendText("this.clh" + sLine + ".Text = \"" + sLine + "\";" + Environment.NewLine);
                        txtDestino.AppendText("this.clh" + sLine + ".Width = 80;" + Environment.NewLine);
                    }
                }
            }
            #endregion

        }
        private void btnGerarDoHTML_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();
                        sLine = sLine.Replace("\"", "\\\"");

                        string sValor = "sb.Append(\"" + sLine + "\" + Environment.NewLine);";

                        txtDestino.AppendText(sValor + Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnGerarEnum_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                StringBuilder sbEnum = new StringBuilder();

                sbEnum.Append("\t\tprivate enum HD_");
                sbEnum.Append("\n\t\t{");

                List<string> listLinesLabel = new List<string>();
                List<string> listLinesValue = new List<string>();

                for (int i = 0; i < txtOrigem.Lines.Length; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string enumName = "";
                        string enumNameTemp = Funcoes.ReplaceCharactersForEnum(txtOrigem.Lines[i].Trim());

                        string[] enumNameArray = enumNameTemp.Split(' ');

                        for (int r = 0; r < enumNameArray.Length; r++)
                        {
                            if (enumNameArray[r].Length > 1)
                            {
                                enumName += enumNameArray[r].Substring(0, 1).ToUpper() + enumNameArray[r].Substring(1, enumNameArray[r].Length - 1).ToLower();
                            }
                            else
                            {
                                enumName += enumNameArray[r].Substring(0, 1).ToUpper();
                            }
                        }

                        listLinesLabel.Add(enumName);

                        if (chkInserirNumerosEnums.Checked)
                        {
                            listLinesValue.Add(i.ToString());
                        }
                        else
                        {
                            listLinesValue.Add("");
                        }
                    }
                }

                List<string> lines = Funcoes.NormalizeWithTab(listLinesLabel, listLinesValue, chkInserirNumerosEnums.Checked ? "= " : "");

                for (int i = 0; i < lines.Count; i++)
                {
                    if (chkInserirEnumsStructs.Checked)
                    {
                        sbEnum.Append("\n\t\t\t/// <summary>");
                        sbEnum.Append("\n\t\t\t/// " + i.ToString());
                        sbEnum.Append("\n\t\t\t/// </summary>");
                    }

                    sbEnum.Append("\n\t\t\t" + lines[i].Trim());

                    if (i < (lines.Count - 1)) { sbEnum.Append(","); }
                }

                sbEnum.Append("\n\t\t}");

                forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
                                                                                                 sbEnum.ToString());

                formVisualizar.Text = "Visualizar - Enum";

                formVisualizar.ShowDialog();
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
        private void btnToUpper_Click(object sender, System.EventArgs e)
        {
            string strTexto = txtOrigem.Text;
            txtDestino.Text = strTexto.ToUpper();
        }
        private void btnToLower_Click(object sender, System.EventArgs e)
        {
            string strTexto = txtOrigem.Text;
            txtDestino.Text = strTexto.ToLower();
        }
        private void btnPegarNomeCamposXML_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        int intIndexF = sLine.IndexOf("\"", 0);
                        int intIndexL = sLine.IndexOf("\"", intIndexF + 1);

                        string sValor = sLine.Substring(intIndexF + 1, intIndexL - (intIndexF + 1));

                        txtDestino.AppendText(sValor + Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnTesteDebugError_Click(object sender, System.EventArgs e)
        {
            //"WHEN " - inicio
            //THEN - apagar
            try
            {
                txtDestino.Clear();

                string strTemp = string.Empty;

                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        if (sLine.Substring(0, 4) == "WHEN")
                        {
                            strTemp = sLine.Replace("WHEN", "");
                            strTemp = strTemp.Replace("THEN", "");

                            txtDestino.AppendText(strTemp.Trim() + "#");
                        }

                        if (sLine.Substring(0, 9) == "p_sqlCode")
                        {
                            strTemp = sLine.Replace("p_sqlCode", "");
                            strTemp = strTemp.Replace(":=", "");
                            strTemp = strTemp.Replace(";", "");

                            txtDestino.AppendText(strTemp.Trim() + "#");
                        }

                        if (sLine.Substring(0, 15) == "p_sqlErrMessage")
                        {
                            strTemp = sLine.Replace("p_sqlErrMessage", "");
                            strTemp = strTemp.Replace(":=", "");
                            strTemp = strTemp.Replace(";", "");
                            strTemp = strTemp.Replace("'", "");

                            txtDestino.AppendText(strTemp.Trim() + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //private void btnDesconectar_Click(object sender, System.EventArgs e)
        //{
        //    m_conexao.Fechar();

        //    cmdOK.Enabled = true;
        //    btnDesconectar.Enabled = false;
        //}
        //private void btnAtualizar_Click(object sender, System.EventArgs e)
        //{
        //    string queryTabela = "";
        //    string queryView = "";
        //    string querySP = "";

        //    try
        //    {
        //        Funcoes.FormMain.FormServerExplorer.tvwDados.Nodes.Clear();
        //        m_aItem.Clear();

        //        //Define_SyntaxHighlighting();

        //        TreeNode nodeSQLServer = new TreeNode(Funcoes.FormMain.server, 0, 0);

        //        nodeSQLServer.Tag = 0;
        //        Funcoes.FormMain.FormServerExplorer.tvwDados.Nodes.Add(nodeSQLServer);

        //        TreeNode nodeDB = new TreeNode(Funcoes.FormMain.database, 1, 1);

        //        nodeDB.Tag = 0;
        //        nodeSQLServer.Nodes.Add(nodeDB);

        //        if (chkNaoVisualizarTabelasDoSistema.Checked)
        //        {
        //            queryTabela = "  AND userstat=1";
        //        }

        //        ListarTable(nodeDB, "select name, id from sysobjects where xtype='U' " + queryTabela,
        //            2,
        //            3,
        //            4,
        //            "Tabelas",
        //            "TABLE");

        //        if (chkNaoVisualizarViewsDoSistema.Checked)
        //        {
        //            queryView = "  AND userstat=0";// AND name LIKE 'VW_%'";
        //        }

        //        if (chkNaoVisualizarViewsDoSistema.Checked)
        //        {
        //            queryView += " AND name LIKE 'VW_%'";
        //        }

        //        ListarTable(nodeDB, "select name, id from sysobjects where xtype='V' " + queryView,
        //            2,
        //            5,
        //            4,
        //            "Views",
        //            "VIEW");

        //        if (chkNaoVisualizarSPsDoSistema.Checked)
        //        {
        //            querySP = " AND userstat=0";//AND name LIKE 'SP_%'
        //        }

        //        ListarTable(nodeDB, "select name, id from sysobjects where xtype='P'" + querySP,
        //            2,
        //            6,
        //            7,
        //            "Stored Procedures",
        //            "SP");
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    finally
        //    {
        //        btnAtualizar.Enabled = true;
        //        tbcMain.SelectedIndex = 1;
        //    }
        //}

        private void btnTotalCaracteres_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtOrigem.Clear();

                int lngTotal = int.Parse(txtTotalCaracteres.Text.Trim());

                string strCarater = string.Empty;

                txtOrigem.AppendText(strCarater.PadLeft(lngTotal, '@'));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtOrigem_TextChanged(object sender, System.EventArgs e)
        {
            lblTotalCaracteres.Text = $"Carecteres: {txtOrigem.Text.Length}";
            lblTotalLinhasOrigem.Text = $"Linhas: {txtOrigem.Lines.Length}";
        }
        private void btnQuebraLinha_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                string strTexto = txtOrigem.Text;
                int qtd_caracter = int.Parse(txtQuebraTotal.Text.Trim());
                int iTotal = txtOrigem.Text.Length;

                for (int i = qtd_caracter; i < strTexto.Length; i += qtd_caracter)
                {
                    strTexto = strTexto.Insert(i, Environment.NewLine);
                    //iTotal+=2;
                }

                txtDestino.Text = strTexto;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDestino_TextChanged(object sender, System.EventArgs e)
        {
            lblStatusProgressoDestino.Text = "Carecteres: " + txtDestino.Text.Length.ToString();
        }
        private void btnCriarCamposDataSetComTextBox_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = "txt" + Dados[i].Trim() + ".Text = dt.Rows[0][\"" + Dados[i].Trim() + "\"].ToString();";

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = "txt" + sLine + ".Text = dt.Rows[0][\"" + sLine + "\"].ToString();";

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        private void btnCriarCamposVariavelDataTable_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = Funcoes.TrataVariveisBD(Dados[i].Trim());

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = Funcoes.TrataVariveisBD(sLine);

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        private void btnCriarCamposTextVariavel_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = "txt" + Dados[i].Trim() + ".Text = " + Dados[i].Trim() + ";";

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = "txt" + sLine + ".Text = " + sLine + ";";

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        private void txtOrigem_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                // Handle the Drag effect when the listbox is entered
                if (e.Data.GetDataPresent(DataFormats.Text))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtOrigem_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                //  Get the string from the data that was dragged
                string s = (string)e.Data.GetData("Text");

                s = s.Substring(s.IndexOf(":") + 1).Trim();


                // Drop the string in the listbox
                txtOrigem.AppendText(s);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnRemoverCarateres_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string[] sLine = txtOrigem.Lines[i].Trim().Split('.');

                        for (int p = 1; p < sLine.Length; p++)
                        {
                            txtDestino.AppendText(sLine[p]);

                            if (p < (sLine.Length - 1))
                            {
                                txtDestino.AppendText(".");
                            }
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            txtDestino.AppendText("		ArrayList aDados = new ArrayList();" + Environment.NewLine + Environment.NewLine);

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = "		aDados.Add(" + Dados[i].Trim() + ");";

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = "		aDados.Add(" + sLine + ");";

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            txtDestino.Clear();

            string[] Dados = txtOrigem.Text.Trim().Split(',');

            if (chkSeparadoVirgula.Checked)
            {
                for (int i = 0; i < Dados.Length; i++)
                {
                    string sValor = "string " + Dados[i].Trim() + " = dt.Rows[0][\"" + Dados[i].Trim() + "\"].ToString();";

                    txtDestino.AppendText(sValor);

                    if (chkAdicionarN.Checked)
                    {
                        sValor = "		//" + i.ToString();
                        txtDestino.AppendText(sValor);
                    }

                    txtDestino.AppendText(Environment.NewLine);
                }
            }
            else
            {
                int iTotalLines = txtOrigem.Lines.Length;

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim();

                        string sValor = "string " + sLine + " = dt.Rows[0][\"" + sLine + "\"].ToString();";

                        txtDestino.AppendText(sValor);

                        if (chkAdicionarN.Checked)
                        {
                            sValor = "		//" + i.ToString();
                            txtDestino.AppendText(sValor);
                        }

                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        private void button3_Click(object sender, System.EventArgs e)
        {

            //			ALTER PROCEDURE dbo.SP_COMANDO_INSERIR
            //			@cod_cmd int,
            //			@id_agt bigint,
            //			@message_cmd text
            //			AS
            //			BEGIN
            //			--varivel data
            //			declare @data_cmd datetime
            //
            //			set @data_cmd = getdate()
            //
            //			-- insere comando				
            //			insert into comando values (
            //			@cod_cmd,
            //			1,
            //			@id_agt,
            //			@message_cmd,
            //			@data_cmd
            //			)
            //			END
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;
                string sMethod = string.Empty;

                if (Funcoes.FormMain.FormServerExplorer.VerificaSeTreeViewEstaSelecionada())
                {
                    sMethod = Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Text;
                }

                txtDestino.AppendText("ALTER PROCEDURE dbo.SP_" + sMethod.ToUpper() + "_INSERIR" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim().Replace(",", "");

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("@" + sLine + " text" + Environment.NewLine);
                        }
                        else
                        {
                            txtDestino.AppendText("@" + sLine + " text," + Environment.NewLine);
                        }
                    }
                }

                txtDestino.AppendText("AS" + Environment.NewLine);
                txtDestino.AppendText("BEGIN" + Environment.NewLine);
                txtDestino.AppendText("insert into " + sMethod.ToLower() + " values (" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sLine = txtOrigem.Lines[i].Trim().Replace(",", "");

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("@" + sLine + Environment.NewLine);
                        }
                        else
                        {
                            txtDestino.AppendText("@" + sLine + "," + Environment.NewLine);
                        }
                    }
                }

                txtDestino.AppendText(")" + Environment.NewLine);
                txtDestino.AppendText("END");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button4_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;
                string sMethod = string.Empty;

                if (Funcoes.FormMain.FormServerExplorer.VerificaSeTreeViewEstaSelecionada())
                {
                    sMethod = Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Text;
                }
                txtDestino.AppendText("/**************************************************************" + Environment.NewLine);
                txtDestino.AppendText("* Função criada por		= Luciano da Silva Dória" + Environment.NewLine);
                txtDestino.AppendText("* Data de criação		= " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine);
                txtDestino.AppendText("* Data de modificação	=" + Environment.NewLine);
                txtDestino.AppendText("**************************************************************/" + Environment.NewLine);

                txtDestino.AppendText("CREATE PROCEDURE dbo.SP_" + sMethod.ToUpper() + "_INSERIR" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string sValor = txtOrigem.Lines[i].Trim().Replace(",", "").ToLower();

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("@" + sValor + Environment.NewLine);
                        }
                        else
                        {
                            txtDestino.AppendText("@" + sValor + "," + Environment.NewLine);
                        }
                    }
                }

                txtDestino.AppendText("AS" + Environment.NewLine);
                txtDestino.AppendText("BEGIN" + Environment.NewLine);
                txtDestino.AppendText("insert into " + sMethod.ToLower() + " values (" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string[] sLine = txtOrigem.Lines[i].Trim().Replace(",", "").Split(' ');

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("@" + sLine[0].ToLower() + Environment.NewLine);
                        }
                        else
                        {
                            txtDestino.AppendText("@" + sLine[0].ToLower() + "," + Environment.NewLine);
                        }
                    }
                }

                txtDestino.AppendText(")" + Environment.NewLine);
                txtDestino.AppendText("END");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnGerarStruct_Click(object sender, System.EventArgs e)
        {
            try
            {
                StringBuilder sbStruct = new StringBuilder();

                txtDestino.Clear();

                sbStruct.Append("\t\tprivate struct Columns_____");
                sbStruct.Append("\n\t\t{");

                List<string> listLinesLabel = new List<string>();
                List<string> listLinesValue = new List<string>();

                for (int i = 0; i < txtOrigem.Lines.Length; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        listLinesLabel.Add("public const int " + txtOrigem.Lines[i].Trim());
                        listLinesValue.Add(i.ToString());
                    }
                }

                List<string> lines = Funcoes.NormalizeWithTab(listLinesLabel, listLinesValue, "= ");

                for (int i = 0; i < lines.Count; i++)
                {
                    if (chkInserirEnumsStructs.Checked)
                    {
                        sbStruct.Append("\n\t\t\t/// <summary>");
                        sbStruct.Append("\n\t\t\t/// " + i.ToString());
                        sbStruct.Append("\n\t\t\t/// </summary>");
                    }

                    sbStruct.Append("\n\t\t\t" + lines[i] + ";");
                }

                sbStruct.Append("\n\t\t}");

                forms.frmVisualizarSPView formVisualizar = new DBTools.forms.frmVisualizarSPView(ShowSyntaxLanguage.CSharp,
                                                                                                 sbStruct.ToString());

                formVisualizar.Text = "Visualizar - Struct const";

                formVisualizar.ShowDialog();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                txtDestino.Clear();

                int iTotalLines = txtOrigem.Lines.Length;
                string sMethod = string.Empty;

                if (Funcoes.FormMain.FormServerExplorer.VerificaSeTreeViewEstaSelecionada())
                {
                    sMethod = Funcoes.FormMain.FormServerExplorer.tvwDados.SelectedNode.Text;
                }

                txtDestino.AppendText("insert into " + sMethod.ToLower() + " values (" + Environment.NewLine);

                for (int i = 0; i < iTotalLines; i++)
                {
                    if (txtOrigem.Lines[i].Trim().Length > 0)
                    {
                        string[] sLine = txtOrigem.Lines[i].Trim().Replace(",", "").Split(' ');

                        if (i == (iTotalLines - 1))
                        {
                            txtDestino.AppendText("@" + sLine[0].ToLower() + Environment.NewLine);
                        }
                        else
                        {
                            txtDestino.AppendText("@" + sLine[0].ToLower() + "," + Environment.NewLine);
                        }
                    }
                }

                txtDestino.AppendText(")" + Environment.NewLine);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnStringFormat_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //List<string[]> linesArgs = new List<string[]>();

                try
                {
                    toolStrip1.Enabled = false;
                    txtOrigem.Enabled = false;
                    txtDestino.Enabled = false;
                    Funcoes.ShowCursor(this, CursorType.WaitCursor);


                    StringBuilder sb = new StringBuilder();
                    string maskFormat = txtDestino.Text.Trim();

                    txtDestino.Clear();

                    int totalLines = txtOrigem.Lines.Length;
                    bool addIndexLine = false;

                    int indexLine = 0;
                    string indexLineMask = "";

                    if (maskFormat.Contains("{N0}"))
                    {
                        indexLine = 0;
                        addIndexLine = true;
                        indexLineMask = "{N0}";
                    }

                    if (maskFormat.Contains("{N1}"))
                    {
                        indexLine = 1;
                        addIndexLine = true;
                        indexLineMask = "{N1}";
                    }

                    //pgbStatus.Maximum = totalLines - 1;
                    //pgbStatus.Value = 0;
                    //lblStatusProgressoDestino.Text = "Criando cache...";

                    //for (int i = 0; i < totalLines; i++)
                    //{
                    //    if (txtOrigem.Lines[i].Trim().Length > 0)
                    //    {
                    //        var args = txtOrigem.Lines[i].Trim().Split(txtCharSplit.Text.ToCharArray()).ToList();

                    //        for (int c = 0; c < args.Count; c++)
                    //        {
                    //            args[c] = args[c].Trim();
                    //        }

                    //        linesArgs.Add(args.ToArray());
                    //    }

                    //    pgbStatus.Value = i;
                    //    lblStatusProgressoDestino.Text = $"Criando cache...{i} de {pgbStatus.Maximum}";
                    //}
                    pgbStatus.Minimum = 0;
                    pgbStatus.Maximum = totalLines - 1;
                    pgbStatus.Value = 0;

                    for (int i = 0; i < totalLines; i++)
                    {
                        var args = txtOrigem.Lines[i].Trim().Split(txtCharSplit.Text.ToCharArray());

                        for (int c = 0; c < args.Length; c++)
                        {
                            args[c] = args[c].Trim();
                        }

                        var line = string.Format(maskFormat, args);

                        if (addIndexLine) { line = line.Replace(indexLineMask, indexLine.ToString()); }

                        sb.AppendLine(line);

                        indexLine++;


                        pgbStatus.Value = i;
                        lblStatusProgressoDestino.Text = $"Processando {i+1} de {pgbStatus.Maximum+1}";
                    }

                    txtDestino.Text = sb.ToString();
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
                    Funcoes.ShowCursor(this, CursorType.Default);
                    toolStrip1.Enabled = true;
                    txtOrigem.Enabled = true;
                    txtDestino.Enabled = true;
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void btnLerArquivoXML_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();

            //try
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();

            //    if (ofd.ShowDialog(this) == DialogResult.Cancel) { return; }

            //    dt.Columns.Add("Cidade");
            //    dt.Columns.Add("UF");

            //    XmlTextReader xmltr = new XmlTextReader(ofd.FileName);

            //    StringBuilder sb = new StringBuilder();

            //    bool nome = false;
            //    bool uf = false;

            //    string[] rows = new string[2];
            //    int count = 0;

            //    while (xmltr.Read())
            //    {
            //        Application.DoEvents();
            //        switch (xmltr.NodeType)
            //        {
            //            case XmlNodeType.Element: //Display beginning of element.
            //                {
            //                    //Console.Write("<" + xmltr.Name);

            //                    //if(xmltr.HasAttributes)//If attributes exist
            //                    //{
            //                    //    while(xmltr.MoveToNextAttribute())
            //                    //    {
            //                    //        //Display attribute name and value.
            //                    //        sb.Append(xmltr.Name + "='" + xmltr.Value + "'");
            //                    //        Console.Write(xmltr.Name + "='" + xmltr.Value + "'");
            //                    //    }
            //                    //}

            //                    if (xmltr.Name == "ReferenceName")
            //                    {
            //                        nome = true;
            //                    }
            //                    else if (xmltr.Name == "Uf")
            //                    {
            //                        uf = true;
            //                    }
            //                    else
            //                    {
            //                        nome = false;
            //                        uf = false;
            //                    }

            //                    //Console.Write(">" + Environment.NewLine);
            //                    break;
            //                }
            //            case XmlNodeType.Text: //Display the text in each element.
            //                {
            //                    if (nome)
            //                    {
            //                        sb.Append("'" + xmltr.Value.ToUpper() + "'");
            //                        rows[0] = xmltr.Value.ToUpper();
            //                    }
            //                    else if (uf)
            //                    {
            //                        sb.Append(",'" + xmltr.Value.ToUpper() + "'" + Environment.NewLine);

            //                        rows[1] = xmltr.Value.ToUpper();

            //                        dt.Rows.Add(rows);
            //                        count++;
            //                    }

            //                    //Console.WriteLine(xmltr.Value);
            //                    break;
            //                }
            //            //case XmlNodeType.EndElement: //Display end of element.
            //            //{
            //            //    //sb.Append("</" + xmltr.Name);
            //            //    //sb.Append(">");

            //            //    //fim = (xmltr.Name == "Reference" ? true:false);

            //            //    //Console.Write("</" + xmltr.Name);
            //            //    //Console.Write(">" + Environment.NewLine); 
            //            //    break;
            //            //}
            //        }
            //    }

            //    sb.Append(Environment.NewLine);
            //    sb.Append(Environment.NewLine);
            //    sb.Append("Total = " + count.ToString());

            //    Clipboard.SetText(sb.ToString());

            //    MessageBox.Show("Executado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    drResultados.DataSource = dt.DefaultView;

            //    lvwListViewPlus.Items.Clear();
            //    lvwResultado.Items.Clear();
            //    lvwResultado.Columns.Clear();
            //    lvwResultado.Sorter = false;

            //    int totalColumns = dt.Columns.Count;

            //    for (int i = 0; i < totalColumns; i++)
            //    {
            //        ArrayList aDados = new ArrayList();

            //        int intID = i + 1;

            //        aDados.Add(intID.ToString());
            //        aDados.Add(dt.Columns[i].Caption);
            //        aDados.Add(dt.Columns[i].DataType.Name);

            //        lvwListViewPlus.Add(aDados);
            //        lvwResultado.Columns.Add(dt.Columns[i].Caption, 120);
            //    }

            //    if (chkResultadoNoListview.Checked)
            //    {
            //        lvwResultado.Sorter = false;
            //        lvwResultado.Add(ref dt);
            //        lvwResultado.Sorter = true;
            //    }

            //    txtResultado.Text = "(" + dt.Rows.Count.ToString() + " row(s) affected)";
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Erro: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private void btnRemoverAcentos_Click(object sender, EventArgs e)
        {
            char[] CAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç".ToCharArray();
            char[] SAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc".ToCharArray();

            try
            {
                btnRemoverAcentos.Enabled = false;

                string text = txtOrigem.Text.Trim();

                for (int i = 0; i < CAcentos.Length; i++)
                {
                    text = text.Replace(CAcentos[i], SAcentos[i]);
                }

                txtDestino.Text = text;
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
                btnRemoverAcentos.Enabled = true;
            }
        }
        private void btnLimparOrigem_Click(object sender, EventArgs e)
        {
            txtOrigem.Clear();
        }
        private void btnLimparDestino_Click(object sender, EventArgs e)
        {
            txtDestino.Clear();
        }
        private void btnSepararCamposPorVirgula_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Funcoes.ShowCursor(this, CursorType.WaitCursor);

                    txtDestino.Clear();

                    string destino = string.Join(",", txtOrigem.Lines);

                    txtDestino.Text = destino;
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
                    Funcoes.ShowCursor(this, CursorType.Default);
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        #endregion

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            tabFuncoes.SelectedIndex = 0;
        }

        private void btnCopiarClipboardOrigem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtOrigem.Text);
        }

        private void btnSubstituirTexto_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtOrigem.Text;

                txtOrigem.Text = text.Replace(txtOrigemTexto.Text, txtOrigemTextoSubstituir.Text);
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void btnSubstituirLimpar_Click(object sender, EventArgs e)
        {
            txtOrigemTexto.Clear();
            txtOrigemTextoSubstituir.Clear();
        }

        private void btnConverterParaLista_Click(object sender, EventArgs e)
        {
            try
            {
                toolStrip1.Enabled = false;
                txtOrigem.Enabled = false;
                txtDestino.Enabled = false;
                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                string maskFormat = txtDestino.Text.Trim();

                txtDestino.Clear();

                if (txtOrigem.Lines[0].Trim().Length > 0)
                {
                    string[] columns = txtOrigem.Lines[0].Trim().Split(txtCharSplit.Text.ToCharArray());

                    for (int p = 0; p < columns.Length; p++)
                    {
                        txtDestino.AppendText(columns[p].Trim());
                        txtDestino.AppendText(Environment.NewLine);
                    }
                }
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
            finally
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                toolStrip1.Enabled = true;
                txtOrigem.Enabled = true;
                txtDestino.Enabled = true;
            }
        }

        private void BtnSepararCamposPorVirgulaComString_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Funcoes.ShowCursor(this, CursorType.WaitCursor);

                    txtDestino.Clear();

                    string destino = "\'" + string.Join("\', \'", txtOrigem.Lines) + "\'";

                    txtDestino.Text = destino;
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
                    Funcoes.ShowCursor(this, CursorType.Default);
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void btnReplaceValueClipBoard_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {

                try
                {
                    toolStrip1.Enabled = false;
                    txtOrigem.Enabled = false;
                    txtDestino.Enabled = false;
                    Funcoes.ShowCursor(this, CursorType.WaitCursor);

                    string texto = txtDestino.Text;

                    int totalLines = txtOrigem.Lines.Length;
                    int totalLinesDestino = txtDestino.Lines.Length;
                    List<string> linhasDestino = new List<string>();

                    for (int i = 0; i < txtDestino.Lines.Length; i++)
                    {
                        linhasDestino.Add(txtDestino.Lines[i]);
                    }

                    txtDestino.Clear();

                    for (int i = 0; i < totalLines; i++)
                    {
                        if (txtOrigem.Lines[i].Trim().Length > 0)
                        {
                            //tb_sgb_pessoa_trabalho_remuneracao.FL_TRABALHOU_SEMANA_PASSADA = tb_cef_08_dados_pessoa.FL_TRABALHOU_SEMANA_PASSADA.ToBooleanNullable(1);

                            string[] text = txtOrigem.Lines[i].Trim().Split(txtCharSplit.Text.ToCharArray());

                            foreach (var linhaDestino in linhasDestino)
                            {
                                string appendText = "";

                                if (linhaDestino.Trim().Length > 0)
                                {
                                    //tb_sgb_pessoa_trabalho_remuneracao.FL_TRABALHOU_SEMANA_PASSADA = tb_cef_08_dados_pessoa.FL_TRABALHOU_SEMANA_PASSADA.ToBooleanNullable(1);

                                    var linhaDestinoArray = txtDestino.Lines[0].Trim().Split('=').ToList();
                                    string linha = linhaDestinoArray[0] + " = ";

                                    if (linhaDestinoArray.Count > 1)
                                    {
                                        string textoSubstituido = linhaDestinoArray[1].Replace(text[0].Trim(), text[1].Trim());
                                        var linhaArrayPonto = textoSubstituido.Trim().Split('.').ToList();

                                        linha += linhaArrayPonto[0] + "." + linhaArrayPonto[1];
                                    }
                                }

                                txtDestino.AppendText(appendText + Environment.NewLine);
                            }
                        }
                    }

                    tabFuncoes.SelectedIndex = 0;

                    MessageBox.Show("Substituição feita com sucesso!");
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
                    Funcoes.ShowCursor(this, CursorType.Default);
                    toolStrip1.Enabled = true;
                    txtOrigem.Enabled = true;
                    txtDestino.Enabled = true;
                }
            }
, CancellationToken.None,
TaskCreationOptions.LongRunning,
TaskScheduler.Default);
        }

        private void btnNormalizarCPF_Click(object sender, EventArgs e)
        {
            if (dpbColunaCPF.SelectedItem == null)
            {
                MessageBox.Show("Informe a coluna aonde está o CPF!");
                return;
            }

            Task.Factory.StartNew(() =>
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    txtOrigem.Enabled = false;
                    btnNormalizarCPF.Enabled = false;

                    int totalLines = txtOrigem.Lines.Length;
                    int columnIndexCpf = dpbColunaCPF.SelectedItem.ToInt32();
                    var charSplitArray = txtCharSplit.Text.ToCharArray();
                    var charSplit = txtCharSplit.Text;
                    char tab = '\u0009';

                    pgbStatus.Minimum = 0;
                    pgbStatus.Maximum = totalLines - 1;
                    pgbStatus.Value = 0;
                    lblStatusProgressoDestino.Text = "Criando cache...";

                    for (int i = 0; i < totalLines; i++)
                    {
                        if (txtOrigem.Lines[i].Trim().Length > 0)
                        {
                            var args = txtOrigem.Lines[i].Trim().Split(charSplitArray).ToList();

                            for (int c = 0; c < args.Count; c++)
                            {
                                args[c] = args[c].Trim();
                            }

                            args[columnIndexCpf] = args[columnIndexCpf].PadLeft(11, '0');

                            sb.AppendLine(string.Join(charSplit, args));
                        }

                        pgbStatus.Value = i;
                        lblStatusProgressoDestino.Text = $"Normalizando CPF {(i + 1)} de {(pgbStatus.Maximum + 1)}";
                    }

                    txtOrigem.Text = sb.ToString();
                }
                catch (Exception exc)
                {

                    Funcoes.LogError(this.Name, exc);
                }
                finally
                {
                    txtOrigem.Enabled = true;
                    btnNormalizarCPF.Enabled = true;
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void btnRemoverLinhasBranco_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    txtOrigem.Enabled = false;
                    btnRemoverLinhasBranco.Enabled = false;

                    String newText = String.Empty;
                    List<String> lines = txtOrigem.Lines.ToList();

                    int totalLines = lines.Count;

                    pgbStatus.Minimum = 0;
                    pgbStatus.Maximum = totalLines - 1;
                    pgbStatus.Value = 0;
                    lblStatusProgressoDestino.Text = "Removendo linhas em branco...";

                    int index = 0;

                    for (int i = totalLines - 1; i >= 0; i--)
                    {
                        if (lines[i].Trim().Length <= 0)
                        {
                            lines.RemoveAt(i);
                        }

                        pgbStatus.Value = index;
                        lblStatusProgressoDestino.Text = $"Removendo linhas em branco {(i + 1)} de {(pgbStatus.Maximum + 1)}";

                        index++;
                    }

                    txtOrigem.Text = string.Join(Environment.NewLine, lines);
                }
                catch (Exception exc)
                {

                    Funcoes.LogError(this.Name, exc);
                }
                finally
                {
                    txtOrigem.Enabled = true;
                    btnRemoverLinhasBranco.Enabled = true;
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }
    }
}