using DBTools.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBTools.forms
{
    public partial class frmJoomlaKnockout : Form
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
            public const int XML = 8;
            public const int KeyValue = 9;
            public const int QueryJoin = 10;
            public const int Align = 11;
            public const int ColumnSize = 12;
            public const int Width = 13;
        }

        private DBTools.classes.ObjectsClass.Table _table { get; set; }
        private DBTools.classes.ObjectsClass.Columns _columns { get; set; }
        private SqlObjectsClass _so;
        private string _rootPath { get; set; }
        private string _component { get; set; }
        private DataTable _dtConfigExtensao { get; set; }
        private string _type { get; set; }
        private string _configPrefix { get; set; }
        private string _prefixTableSigla { get; set; }
        private string _dataBaseName { get; set; }

        private string _posfixTableSigla { get; set; }
        private string _typeMaiuscula { get; set; }
        private string _tableNameTextReplace { get; set; }
        private string _configPathTemplate { get; set; }
        private Dictionary<string, string> _fieldType = new Dictionary<string, string>();

        public frmJoomlaKnockout(DBTools.classes.ObjectsClass.Table table, SqlObjectsClass so)
        {
            InitializeComponent();

            txtFieldXML.Document.Clear();
            txtFieldXML.Document.Text = "";

            lvwColunas.ColumnsWidthLoad();

            Fireball.CodeEditor.SyntaxFiles.CodeEditorSyntaxLoader.SetSyntax(txtFieldXML, Fireball.CodeEditor.SyntaxFiles.SyntaxLanguage.XML);

            loadFieldTypeXML();
            loadConfigExtensaoFile();

            _so = so;
            _table = table;
            _columns = _so.GetColumns(_table);
            _rootPath = Path.Combine(Application.StartupPath, "Templates_temp", "joomla_knockout");
        }

        public void configuracoes_aplicar()
        {
            try
            {
                _component = txtcomponent_name.Text.Trim();
                _prefixTableSigla = txtConfigPrefixTable.Text;
                _dataBaseName = txtConfigDataBaseName.Text;
                _configPrefix = txtConfigPrefix.Text;
                txtPrefixTableSigla.Text = _prefixTableSigla;
                txtAdminComponentPath.Text = txtAdminComponentPathTemplate.Text;

                txtTableName.Text = _table.Name.ToLower().Substring(6);

                txtPK.Text = "";

                #region Cópia pasta dos Scripts

                string sourceDir = Path.Combine(Application.StartupPath, "Templates");
                string destDir = Path.Combine(Application.StartupPath, "templates_temp");

                if (IOClass.DirectoryExists(destDir))
                {
                    IOClass.DeleteDirectorie(destDir);
                }

                IOClass.DirectorieCopy(sourceDir, destDir, true);

                #endregion

                #region Columns Grid
                Color foreColor = Color.Black;

                foreach (DBTools.classes.ObjectsClass.Column column in _columns)
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
                        txtPK.Text = column.Name;
                    }


                    ArrayList aDados = new ArrayList();

                    aDados.Add("");
                    aDados.Add(column.Identity ? "Sim" : "");
                    aDados.Add(column.Name);

                    string[] nameNormalize = column.Name.Split('_');
                    string columnNameNormalized = "";
                    bool space = false;

                    foreach (var name in nameNormalize)
                    {
                        if (space) { columnNameNormalized += " "; }

                        columnNameNormalized += name.ToUpperFirstChar();

                        space = true;
                    }

                    aDados.Add(columnNameNormalized);
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

                    aDados.Add(GetDataTypeFormField(column));
                    aDados.Add(" ");
                    aDados.Add(" ");
                    aDados.Add(" ");
                    aDados.Add("text-align-left");
                    aDados.Add("col-md-1");
                    aDados.Add("10%");

                    lvwColunas.Add(aDados, foreColor, iconType);

                    lvwColunas.Items[lvwColunas.ItemCount - 1].Tag = column;
                }

                lblTotalColunas.Text = _table.RowCount.ToString();
                #endregion

                #region Define o XML dos campos

                for (int i = 0; i < lvwColunas.Items.Count; i++)
                {
                    string fieldType = lvwColunas.GetItem(i, ColumnsColumn.FieldType);

                    DBTools.classes.ObjectsClass.Column column = (DBTools.classes.ObjectsClass.Column)lvwColunas.Items[i].Tag;

                    lvwColunas.Items[i].SubItems[ColumnsColumn.XML].Text = replaceFields(_fieldType[fieldType], column);
                }

                #endregion

                string[] typeArray = txtTableName.Text.Replace(txtTableNameTextReplace.Text.Trim(), "").Split('_');
                string type = "";
                string title = "";

                for (int i = 0; i < (typeArray.Count() - 1); i++)
                {
                    type += typeArray[i].ToUpperFirstChar();
                    title += "_" + typeArray[i].ToUpper();
                }

                _type = type;

                loadConfigFile();
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void frmJoomla_Load(object sender, EventArgs e)
        {

        }

        private void loadConfigExtensaoFile()
        {
            string fileName = Application.StartupPath + "\\xmls\\config_extensao.xml";

            _dtConfigExtensao = new DataTable("Config");

            if (System.IO.File.Exists(fileName) == false)
            {
                _dtConfigExtensao.Columns.Add("ComponentName");
                _dtConfigExtensao.Columns.Add("ConfigPathTemplate");
                _dtConfigExtensao.Columns.Add("TableNameTextReplace");
                _dtConfigExtensao.Columns.Add("ConfigPrefix");
                _dtConfigExtensao.Columns.Add("AdminComponentPathTemplate");
                _dtConfigExtensao.Columns.Add("ConfigPrefixTable");
            }
            else
            {
                _dtConfigExtensao.ReadXml(fileName);
            }

            for (int i = 0; i < _dtConfigExtensao.Rows.Count; i++)
            {
                cboExtensao.Items.Add(_dtConfigExtensao.Rows[i]["ComponentName"].ToString());
            }
        }

        private void cboExtensao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string componentName = cboExtensao.SelectedItem.ToString();

            DataRow[] dr = _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName));

            if (dr.Length > 0)
            {
                txtcomponent_name.Text = dr[0]["ComponentName"].ToString();
                txtConfigPathTemplate.Text = dr[0]["ConfigPathTemplate"].ToString();
                txtTableNameTextReplace.Text = dr[0]["TableNameTextReplace"].ToString();
                txtConfigPrefix.Text = dr[0]["ConfigPrefix"].ToString();
                txtConfigPrefixTable.Text = dr[0]["ConfigPrefixTable"].ToString();
                txtConfigDataBaseName.Text = dr[0]["ConfigDataBaseName"].ToString();
                txtAdminComponentPathTemplate.Text = dr[0]["AdminComponentPathTemplate"].ToString();
            }
        }

        private void btnSalvarExtensao_Click(object sender, EventArgs e)
        {
            string fileName = Application.StartupPath + "\\xmls\\config_extensao.xml";

            string componentName = txtcomponent_name.Text.Trim();

            DataRow[] dr = _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName));

            if (dr.Length <= 0)
            {
                object[] row = {componentName,
                               txtConfigPathTemplate.Text.Trim(),
                               txtTableNameTextReplace.Text.Trim(),
                               txtConfigPrefix.Text.Trim(),
                               txtAdminComponentPathTemplate.Text.Trim(),
                               txtConfigPrefixTable.Text.Trim(),
                               txtConfigDataBaseName.Text.Trim()};

                _dtConfigExtensao.Rows.Add(row);
            }
            else
            {
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ComponentName"] = componentName;
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigPathTemplate"] = txtConfigPathTemplate.Text.Trim();
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["TableNameTextReplace"] = txtTableNameTextReplace.Text.Trim();
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigPrefix"] = txtConfigPrefix.Text.Trim();
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["AdminComponentPathTemplate"] = txtAdminComponentPathTemplate.Text.Trim();
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigPrefixTable"] = txtConfigPrefixTable.Text.Trim();
                _dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigDataBaseName"] = txtConfigDataBaseName.Text.Trim();
            }

            _dtConfigExtensao.WriteXml(fileName, XmlWriteMode.WriteSchema);

            cboExtensao.Items.Clear();

            for (int i = 0; i < _dtConfigExtensao.Rows.Count; i++)
            {
                cboExtensao.Items.Add(_dtConfigExtensao.Rows[i]["ComponentName"].ToString());
            }

            cboExtensao.SelectedIndex = cboExtensao.FindString(componentName);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prefixTableSigla.Trim().Length == 0)
                {
                    MessageBox.Show("Informe o prefixo da tabela!");
                    return;
                }

                if (txtPosfixTableSigla.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Informe o posfixo da tabela!");
                    return;
                }

                if (txtConfigDataBaseName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Informe o banco de dados!");
                    return;
                }

                _posfixTableSigla = txtPosfixTableSigla.Text;
                _dataBaseName = txtConfigDataBaseName.Text;
                _type = txtType.Text;
                _typeMaiuscula = txtTypeMaiuscula.Text.ToUpper();
                _tableNameTextReplace = txtTableNameTextReplace.Text.Trim();
                _configPathTemplate = txtConfigPathTemplate.Text.Trim();

                pgbMain.Minimum = 0;
                pgbMain.Maximum = 10;
                pgbMain.Value = 0;

                saveConfigFile();
                pgbMain.Value = 1;

                if (chkCreateEntity.Checked)
                {
                    createEntity();
                }

                pgbMain.Value = 2;

                if (chkCreateFilterEntity.Checked)
                {
                    createFilterEntity();
                }
                pgbMain.Value = 3;

                if (chkCreateTable.Checked)
                {
                    createTable();
                }
                pgbMain.Value = 4;

                if (chkCreateController.Checked)
                {
                    createController();
                }
                pgbMain.Value = 5;

                if (chkCreateBusiness.Checked)
                {
                    createBusiness();
                }
                pgbMain.Value = 6;

                if (chkCreateView.Checked)
                {
                    createView();
                }
                pgbMain.Value = 7;

                if (chkCreateIndexModelView.Checked)
                {
                    createIndexModelView();
                }
                pgbMain.Value = 8;

                copyFilesToAdminComponent();
                pgbMain.Value = 9;

                // Cópia para memória os script dos Módulos
                StringBuilder stbScripts = new StringBuilder();

                if (chkCadastrarModuloAcaoBanco.Checked)
                {
                    string id_mod = "0";

                    string query = string.Format("SELECT id_mod + 1 As id_mod FROM {2}.{0}_{1}modulos_mod ORDER BY id_mod DESC LIMIT 1", _prefixTableSigla, _tableNameTextReplace, _dataBaseName);

                    try
                    {
                        DataTable dtModulo = _so.Query(query);

                        id_mod = dtModulo.Rows[0][0].ToString();

                        string queryInsertModulo = string.Format("INSERT INTO {5}.{1}_{3}modulos_mod (`id_mod`, `nome_mod`, `sigla_mod`) VALUES ({4}, '{0}', 'TRAD_{2}');", txtTitle.Text, _prefixTableSigla, txtTypeMaiuscula.Text.ToUpper(), _tableNameTextReplace, id_mod, _dataBaseName);

                        _so.Open();
                        _so.QueryCommand(queryInsertModulo);

                        string queryInsertModulosAcoes = string.Format("INSERT INTO {5}.{2}_{3}modulos_acoes_mac (`id_mod`, `id_acs`, `sigla_mac`) VALUES{1}" +
                                                        "({4}, 1, '{0}_ACESSO'),{1}" +
                                                        "({4}, 2, '{0}_CRIAR'),{1}" +
                                                        "({4}, 3, '{0}_EDITAR'),{1}" +
                                                        "({4}, 4, '{0}_EXCLUIR');", txtTypeMaiuscula.Text.ToUpper(), Environment.NewLine, _prefixTableSigla, _tableNameTextReplace, id_mod, _dataBaseName);
                        _so.Open();
                        _so.QueryCommand(queryInsertModulosAcoes);
                    }
                    catch (Exception exc)
                    {
                        Funcoes.LogError(this.Name, exc);
                    }

                    stbScripts.Append(string.Format("INSERT INTO `{1}_{3}modulos_mod` (`id_mod`, `nome_mod`, `sigla_mod`) VALUES ({4}, '{0}', 'TRAD_{2}');", txtTitle.Text, _prefixTableSigla, txtTypeMaiuscula.Text.ToUpper(), _tableNameTextReplace, id_mod));
                    stbScripts.Append(Environment.NewLine);
                    stbScripts.Append(Environment.NewLine);
                    stbScripts.Append(string.Format("INSERT INTO `{2}_{3}modulos_acoes_mac` (`id_mod`, `id_acs`, `sigla_mac`) VALUES{1}" +
                                                    "({4}, 1, '{0}_ACESSO'),{1}" +
                                                    "({4}, 2, '{0}_CRIAR'),{1}" +
                                                    "({4}, 3, '{0}_EDITAR'),{1}" +
                                                    "({4}, 4, '{0}_EXCLUIR');", txtTypeMaiuscula.Text.ToUpper(), Environment.NewLine, _prefixTableSigla, _tableNameTextReplace, id_mod));
                    stbScripts.Append(Environment.NewLine);
                    stbScripts.Append(Environment.NewLine);
                }

                stbScripts.Append(string.Format("define('{2}_VIEW_{0}', '{3}');{1}", txtTypeMaiuscula.Text.ToUpper(), Environment.NewLine, _configPrefix.ToUpper(), _type.ToLower()));
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(string.Format("define('{2}_PERMISSAO_{0}_ACESSO', '{0}_ACESSO');{1}" +
                                                "define('{2}_PERMISSAO_{0}_CRIAR', '{0}_CRIAR');{1}" +
                                                "define('{2}_PERMISSAO_{0}_EDITAR', '{0}_EDITAR');{1}" +
                                                "define('{2}_PERMISSAO_{0}_EXCLUIR', '{0}_EXCLUIR');", _typeMaiuscula, Environment.NewLine, _configPrefix.ToUpper()));
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(string.Format("\"{1}\" => \"{0}\"", txtTypeMaiuscula.Text.ToUpper(), _type.ToLower()));
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append("case '" + _type.ToLower() + "': {" + Environment.NewLine +
                                "       $parte1_sigla_mac = '" + txtTypeMaiuscula.Text.ToUpper() + "';" + Environment.NewLine +
                                "       break;" + Environment.NewLine +
                                "   }");
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(Environment.NewLine);
                stbScripts.Append(string.Format("<?php if($userClass->Permission({2}_PERMISSAO_{0}_ACESSO)):?>{1}" +
                                                "<li <?php echo $view == {2}_VIEW_{0} ? 'class=\"active\"' : '' ;?>>{1}" +
                                                "   <a href=\"<?php echo JRoute::_('index.php?option=com_{4}&view='.{2}_VIEW_{0});?>\">{1}" +
                                                "       <i class=\"fa fa-list-alt\"></i>{1}" +
                                                "       <span>{3}</span>{1}" +
                                                "   </a>{1}" +
                                                "</li>{1}" +
                                                "<?php endif;?>{1}", _typeMaiuscula, Environment.NewLine, _configPrefix.ToUpper(), txtTitle.Text, _configPrefix.ToLower()));

                txtScripts.Text = stbScripts.ToString();

                Clipboard.SetText(stbScripts.ToString());

                pgbMain.Value = 10;
                tabControlJoomla.SelectedIndex = 1;
                MessageBox.Show("Arquivos criados!");
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }

        private void loadFieldTypeXML()
        {
            #region Field Type XML

            _fieldType.Add("PrimaryKey", "<input type=\"text\" class=\"form-control\" maxlength=\"[maxlength]\" data-bind=\"value: [name]\" data-rule-required=\"[required]\" data-msg-required=\"\">");
            _fieldType.Add("Money", "<?php echo JHtmlPlus::MoneyControl('[name]', true, [required], '');?>");
            _fieldType.Add("Text", "<?php echo JHtmlPlus::TextBoxControl('[name]',[maxlength], null, '[name]', [required], '', false, 'text')?>");
            _fieldType.Add("Datepicker", "<?php echo JHtmlPlus::DatepickerControl('[name]', [required], '');?>");
            _fieldType.Add("SelectListaNumeros", "<?php echo JHtmlPlus::SelectListaNumeros('[name]', 1, 10, 1, 'SelectList[name]');?>");
            _fieldType.Add("Radio", "<?php echo JHtmlPlus::BooleanControl('[name]'); ?>");
            _fieldType.Add("CheckBox", "<?php echo JHtmlPlus::BooleanControl('[name]'); ?>");
            _fieldType.Add("SQL (Dropdown)", "<?php echo JHtmlPlus::Select???????('[name]','[name]', 'Selecione...')?>");
            _fieldType.Add("Integer", "<?php echo JHtmlPlus::NumberControl('[name]',[maxlength], null, '[name]', [required], '')?>");
            _fieldType.Add("Email", "<?php echo JHtmlPlus::EmailControl('[name]', null, '[name]', [required], '', false)?>");
            _fieldType.Add("EqualTo", "<?php echo JHtmlPlus::EqualToControl('[name]',[maxlength], null, '[name]', [required], '', false, 'id to', 'As informações não batem')?>");
            _fieldType.Add("Mask", "<?php echo JHtmlPlus::MaskControl('mask?', '[name]',null, '[name]', [required], '')?>");
            _fieldType.Add("Textarea", "<?php echo JHtmlPlus::TextAreaBoxControl('[name]', [maxlength], '[name]', [required], '')?>");

            /*m_FieldType.Add("Color", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"color\"{0}" + 
                                                "default=\"\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}/>",
                                                Environment.NewLine));

            
            m_FieldType.Add("Calendar", string.Format("<field{0}" + 
                                                    "name=\"[name]\"{0}" + 
                                                    "type=\"calendar\"{0}" + 
                                                    "default=\"\"{0}" + 
                                                    "label=\"[label]\"{0}" + 
                                                    "description=\"\"{0}" + 
                                                    "required=\"[required]\"{0}" +
                                                    "format=\"%d-%m-%Y\"{0}/>",
                                                    Environment.NewLine));

            m_FieldType.Add("Published", string.Format("<field{0}" + 
                                            "name=\"[name]\"{0}" + 
                                            "type=\"list\"{0}" +
                                            "default=\"1\"{0}" +
                                            "class=\"inputbox\"{0}" +
                                            "required=\"[required]\"{0}" +
                                            "label=\"JSTATUS\"{0}" +
                                            "description=\"Status\" >{0}" + 
                                            "<option value=\"1\">JPUBLISHED</option>{0}" + 
                                            "<option value=\"0\">JUNPUBLISHED</option>{0}" + 
                                            "</field>",
                                            Environment.NewLine));

            m_FieldType.Add("Textarea", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"textarea\"{0}" +
                                                "class=\"inputbox\"{0}" +
                                                "default=\"\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "rows=\"5\"{0}" + 
                                                "cols=\"10\"{0}/>",
                                                Environment.NewLine));

            m_FieldType.Add("Editor", string.Format("<field{0}" +
                                                "name=\"[name]\"{0}" +
                                                "label=\"[label]\"{0}" +
                                                "type=\"editor\"{0}" +
                                                "class=\"inputbox\"{0}" +
                                                "width=\"300\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "filter=\"safehtml\"{0}/>",
                                                Environment.NewLine));

            m_FieldType.Add("List (Dropdown)", string.Format("<field{0}" + 
                                            "name=\"[name]\"{0}" + 
                                            "type=\"list\"{0}" +
                                            "default=\"1\"{0}" +
                                            "class=\"inputbox\"{0}" +
                                            "required=\"[required]\"{0}" +
                                            "label=\"[label]\"{0}" +
                                            "description=\"\" >{0}" + 
                                            "<option value=\"1\">List 1</option>{0}" + 
                                            "<option value=\"0\">List 2</option>{0}" + 
                                            "</field>",
                                            Environment.NewLine));

            m_FieldType.Add("Media", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"media\"{0}" +
                                                "directory=\"images\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}/>",
                                                Environment.NewLine));

            m_FieldType.Add("URL", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"url\"{0}" +
                                                "size=\"20\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}/>",
                                                Environment.NewLine));*/

            foreach (var item in _fieldType)
            {
                cboFieldTypes.Items.Add(item.Key);
            }

            #endregion
        }

        private void loadConfigFile()
        {
            string fileName = Application.StartupPath + "\\xmls\\" + txtTableName.Text + ".xml";

            if (System.IO.File.Exists(fileName) == false) { return; }

            DataTable dt = new DataTable("Config");

            dt.ReadXml(fileName);

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                string name = lvwColunas.GetItem(i, ColumnsColumn.Name);

                DataRow[] dr = dt.Select(string.Format("Name Like '{0}'", name));

                if (dr.Length > 0)
                {
                    lvwColunas.Items[i].SubItems[ColumnsColumn.FieldLabel].Text = dr[0]["Label"].ToString();
                    lvwColunas.Items[i].SubItems[ColumnsColumn.FieldType].Text = dr[0]["Type"].ToString();
                    lvwColunas.Items[i].SubItems[ColumnsColumn.XML].Text = dr[0]["XML"].ToString();
                    lvwColunas.Items[i].SubItems[ColumnsColumn.KeyValue].Text = dr[0]["KeyValue"].ToString();
                    lvwColunas.Items[i].SubItems[ColumnsColumn.QueryJoin].Text = dr[0]["QueryJoin"].ToString();
                }
            }

            dt.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        private void saveConfigFile()
        {
            DataTable dt = new DataTable("Config");

            dt.Columns.Add("Name");
            dt.Columns.Add("Label");
            dt.Columns.Add("Type");
            dt.Columns.Add("XML");
            dt.Columns.Add("KeyValue");
            dt.Columns.Add("QueryJoin");

            try
            {
                for (int i = 0; i < lvwColunas.Items.Count; i++)
                {
                    object[] row = {lvwColunas.GetItem(i, ColumnsColumn.Name),
                                    lvwColunas.GetItem(i, ColumnsColumn.FieldLabel),
                                    lvwColunas.GetItem(i, ColumnsColumn.FieldType),
                                    lvwColunas.GetItem(i, ColumnsColumn.XML),
                                    lvwColunas.GetItem(i, ColumnsColumn.KeyValue),
                                    lvwColunas.GetItem(i, ColumnsColumn.QueryJoin)};

                    dt.Rows.Add(row);
                }

                string fileName = Application.StartupPath + "\\xmls\\" + txtTableName.Text + ".xml";

                dt.WriteXml(fileName, XmlWriteMode.WriteSchema);
            }
            catch
            { }
        }

        private void copyFilesToAdminComponent()
        {
            string adminPath = txtAdminComponentPath.Text;
            string adminPathDBTools = _rootPath + @"\admin\component" + "_" + _configPathTemplate;

            List<string> filesNamesIgnore = new List<string>();

            if (!chkCreateEntity.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\entity\entity.php");
            }

            if (!chkCreateFilterEntity.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\entity\filter\filter.php");
            }

            if (!chkCreateTable.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\tables\table.php");
            }

            if (!chkCreateController.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\controllers\controllers.php");
            }

            if (!chkCreateBusiness.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\business\businessBasic.php");
            }

            if (!chkCreateView.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\views\view" + @"\view.html.php");
                filesNamesIgnore.Add(adminPathDBTools + @"\views\view" + @"\tmpl\temp.php");
            }

            if (!chkCreateIndexModelView.Checked)
            {
                filesNamesIgnore.Add(adminPathDBTools + @"\assets\js\ViewModels\ViewModel\ViewModel.js");
            }

            string[] files = System.IO.Directory.GetFiles(adminPathDBTools, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (var fileName in files)
            {
                if (filesNamesIgnore.Contains(fileName))
                {
                    continue;
                }

                string destFileName = fileName.Replace(adminPathDBTools, adminPath);

                IOClass.CopyTo(fileName, destFileName);
            }
        }

        private string replace(string pathFile)
        {
            Dictionary<string, string> replacesFields = new Dictionary<string, string>();
            string output = IOClass.ReadFileToEnd(pathFile);

            replacesFields.Add("{PREFIX}", txtConfigPrefix.Text);
            replacesFields.Add("{PREFIX_LOWER}", txtConfigPrefix.Text.ToLower());
            replacesFields.Add("{PREFIX_UPPER}", txtConfigPrefix.Text.ToUpper());
            replacesFields.Add("{TABLE_SIGLA}", _prefixTableSigla);
            replacesFields.Add("{TABLE_POSFIXO_SIGLA}", _posfixTableSigla);
            replacesFields.Add("{TYPE}", _type);
            replacesFields.Add("{TYPE_EDIT}", _type);
            replacesFields.Add("{TYPE_LOWER}", _type.ToLower());
            replacesFields.Add("{TYPE_EDIT_LOWER}", _type.ToLower());
            replacesFields.Add("{TYPE_UPPER}", _type.ToUpper());
            replacesFields.Add("{TYPE_EDIT_UPPER}", _type.ToUpper());
            replacesFields.Add("{TABLE_NAME}", txtTableName.Text);
            replacesFields.Add("{PK}", txtPK.Text);
            replacesFields.Add("{COMPONENT}", _component);
            replacesFields.Add("{COMPONENT_UPPER}", _component.ToUpper());
            replacesFields.Add("{ORDER_BY_DEFAULT}", txtOrderByDefault.Text);
            replacesFields.Add("{SEARCH_TEXT}", txtSearchText.Text);
            replacesFields.Add("{TITLE}", txtTitle.Text);
            replacesFields.Add("{ROWS_COUNT}", _columns.Count.ToString());
            replacesFields.Add("{ROWS_COUNT_PAGINATION}", (_columns.Count + 1).ToString());
            replacesFields.Add("{FIELD_FOCO}", txtFieldFoco.Text);

            foreach (var item in replacesFields)
            {
                output = output.Replace(item.Key, item.Value);
            }

            //apaga arquivo
            IOClass.DeleteFile(pathFile);

            return output;
        }

        private string replaceOnly(string output)
        {
            Dictionary<string, string> replacesFields = new Dictionary<string, string>();

            replacesFields.Add("{PREFIX}", txtConfigPrefix.Text);
            replacesFields.Add("{PREFIX_LOWER}", txtConfigPrefix.Text.ToLower());
            replacesFields.Add("{TABLE_SIGLA}", _prefixTableSigla);
            replacesFields.Add("{TYPE}", _type);
            replacesFields.Add("{TYPE_LOWER}", _type.ToLower());
            replacesFields.Add("{TYPE_UPPER}", _type.ToUpper());
            replacesFields.Add("{TYPE_EDIT_UPPER}", _type.ToUpper());
            replacesFields.Add("{TABLE_NAME}", txtTableName.Text);
            replacesFields.Add("{PK}", txtPK.Text);
            replacesFields.Add("{COMPONENT}", _component);
            replacesFields.Add("{COMPONENT_UPPER}", _component.ToUpper());
            replacesFields.Add("{ORDER_BY_DEFAULT}", txtOrderByDefault.Text);
            replacesFields.Add("{SEARCH_TEXT}", txtSearchText.Text);
            replacesFields.Add("{TITLE}", txtTitle.Text);
            replacesFields.Add("{ROWS_COUNT}", _columns.Count.ToString());
            replacesFields.Add("{ROWS_COUNT_PAGINATION}", (_columns.Count + 1).ToString());
            replacesFields.Add("{FIELD_FOCO}", txtFieldFoco.Text);

            //replacesFields.Add("{IMAGE_TITLE}", ???????);

            foreach (var item in replacesFields)
            {
                output = output.Replace(item.Key, item.Value);
            }

            return output;
        }

        private void createEntity()
        {
            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\entity\entity.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\entity\" + _type.ToLower() + ".php";
            string vars = "";

            string textFile = replace(pathFile);

            foreach (DBTools.classes.ObjectsClass.Column column in _columns)
            {
                vars += string.Format("\tvar ${0} = null;{1}", column.Name, Environment.NewLine);
            }

            textFile = textFile.Replace("{VARS}", vars);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }
        private void createFilterEntity()
        {
            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\entity\filter\filter.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\entity\filter\" + _type.ToLower() + ".php";
            string vars = "";

            string textFile = replace(pathFile);

            foreach (DBTools.classes.ObjectsClass.Column column in _columns)
            {
                vars += string.Format("\tvar ${0} = null;{1}", column.Name, Environment.NewLine);
            }

            textFile = textFile.Replace("{VARS}", vars);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }

        private void createTable()
        {
            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\tables\table.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\tables\" + _type.ToLower() + ".php";
            string vars = "";

            string textFile = replace(pathFile);

            foreach (DBTools.classes.ObjectsClass.Column column in _columns)
            {
                vars += string.Format("\tvar ${0} = null;{1}", column.Name, Environment.NewLine);
            }

            textFile = textFile.Replace("{VARS}", vars);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }

        private void createController()
        {
            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\controllers\controllers.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\controllers\" + _type.ToLower() + ".php";

            string text = replace(pathFile);

            IOClass.AppendTextInFile(pathNewFile, text, true);
        }

        private void createBusiness()
        {
            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\business\businessBasic.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\business\" + _type.ToLower() + ".php";

            string textEdit = replace(pathFile);

            string filter_fields = "";
            string savefields = "";
            string selectFields = "";
            List<string> rowsConvertsType = new List<string>();

            #region Update or Create Rows

            string date_create_update = "";
            string date_create_update_row = "";
            string user_create_update = "";
            string user_create_update_row = "";

            if (txtDateCreate.Text.Trim().Length > 0)
            {
                date_create_update = string.Format("$date = JFactory::getDate();{0}", Environment.NewLine);
                date_create_update += string.Format("$dateNow = $date->toSql();{0}", Environment.NewLine);
                date_create_update_row = string.Format("$row->{0} = $dateNow;{1}", txtDateCreate.Text.Trim(), Environment.NewLine);

                textEdit = textEdit.Replace("{DATE_CREATE_UPDATE}", date_create_update);
            }
            else
            {
                textEdit = textEdit.Replace("{DATE_CREATE_UPDATE}", string.Empty);
            }

            if (txtUserCreate.Text.Trim().Length > 0)
            {
                user_create_update = string.Format("$user = JFactory::getUser();{0}", Environment.NewLine);
                user_create_update_row = string.Format("$row->{0} = $userClass->CodigoUsuario;{1}", txtUserCreate.Text.Trim(), Environment.NewLine);

                textEdit = textEdit.Replace("{USER_CREATE_UPDATE}", user_create_update);
            }
            else
            {
                textEdit = textEdit.Replace("{USER_CREATE_UPDATE}", string.Empty);
            }

            #endregion

            for (int i = 0; i < _columns.Count; i++)
            {
                if (!_columns[i].IsPrimaryKey)
                {
                    filter_fields += "\t\tif($filtro->" + _columns[i].Name + " != null && strlen($filtro->" + _columns[i].Name + ") > 0)" + Environment.NewLine +
                                     "\t\t{" + Environment.NewLine +
                                     "\t\t\t$query->where(\"" + _posfixTableSigla + "." + _columns[i].Name + GetDataTypeFormFilterFormField(_columns[i]) + "\");" + Environment.NewLine +
                                     "\t\t}" + Environment.NewLine + Environment.NewLine;
                }

                if (i == (_columns.Count - 1))
                {
                    selectFields += string.Format("'{1}.{0} AS {0}'", _columns[i].Name, _posfixTableSigla);

                    if (txtPK.Text.Trim() == _columns[i].Name)
                    {
                        continue;
                    }

                    if (txtDateCreate.Text.Trim() == _columns[i].Name)
                    {
                        savefields += date_create_update_row;
                    }
                    else if (txtUserCreate.Text.Trim() == _columns[i].Name)
                    {
                        savefields += user_create_update_row;
                    }
                    else
                    {
                        savefields += string.Format("$row->{0} = $entity->{0};{1}", _columns[i].Name, Environment.NewLine);
                    }
                }
                else
                {
                    selectFields += string.Format("'{1}.{0} AS {0}, ' .{2}", _columns[i].Name, _posfixTableSigla, Environment.NewLine);

                    if (txtPK.Text.Trim() == _columns[i].Name)
                    {
                        continue;
                    }

                    if (txtDateCreate.Text.Trim() == _columns[i].Name)
                    {
                        savefields += date_create_update_row;
                    }
                    else if (txtUserCreate.Text.Trim() == _columns[i].Name)
                    {
                        savefields += user_create_update_row;
                    }
                    else
                    {
                        savefields += string.Format("$row->{0} = $entity->{0};{1}", _columns[i].Name, Environment.NewLine);
                    }
                }

                //if (_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.DateTime ||
                //    _columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.DateTime2 ||
                //    _columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Date)
                //{
                //    if (_columns[i].Name != txtDateCreate.Text && _columns[i].Name != txtDateUpdate.Text)
                //    {
                //        rowsConvertsType.Add(string.Format("$entity->{0} = date(implode(\"-\", array_reverse(explode(\"/\", $entity->{0}))));", _columns[i].Name));
                //    }
                //}

                if (_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Decimal ||
                    _columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Numeric)
                {
                    if (_columns[i].Name != txtDateCreate.Text && _columns[i].Name != txtDateUpdate.Text)
                    {
                        rowsConvertsType.Add(string.Format("$entity->{0} = utils_convertRealToDecimal($entity->{0});", _columns[i].Name));
                    }
                }
            }

            string rowsQueryJoins = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if (lvwColunas.GetItem(i, ColumnsColumn.FieldType) == "SQL (Dropdown)")
                {
                    rowsQueryJoins += string.Format("{1}{0}",
                                                    Environment.NewLine,
                                                    lvwColunas.GetItem(i, ColumnsColumn.QueryJoin));
                }
            }

            if (rowsQueryJoins.Length > 0)
            {
                if (txtUserCreate.Text.Length > 0)
                {
                    rowsQueryJoins += string.Format("// Usuário que cadastrou{0}" +
                                                    "$query->join('LEFT', '#__{3}usuarios_usu AS usu ON usu.id_usu = {1}.{2}');{0}{0}" +
                                                    "$query->select('pes.nome_razao_social_pes AS nome_razao_social_usuario_cadastro'){0}" +
                                                    "->join('LEFT', '#__{3}pessoas_pes AS pes ON pes.id_pes = usu.id_pes');",
                                                    Environment.NewLine,
                                                    _posfixTableSigla,
                                                    txtUserCreate.Text,
                                                    _tableNameTextReplace);
                }

                textEdit = textEdit.Replace("{QUERY_JOINS}", rowsQueryJoins);
            }
            else
            {
                textEdit = textEdit.Replace("{QUERY_JOINS}", string.Empty);
            }

            if (rowsConvertsType.Count > 0)
            {
                string rows = "";

                foreach (var row in rowsConvertsType)
                {
                    rows += string.Format("{0}{1}", row, Environment.NewLine);
                }

                textEdit = textEdit.Replace("{CONVERTDATEROW_PREPARETABLE}", rows);
            }
            else
            {
                textEdit = textEdit.Replace("{CONVERTDATEROW_PREPARETABLE}", string.Empty);
            }

            savefields += string.Format("{0}", Environment.NewLine);

            textEdit = textEdit.Replace("{FILTER_FIELDS}", filter_fields);
            textEdit = textEdit.Replace("{SAVE_FIELDS}", savefields);
            textEdit = textEdit.Replace("{SELECT_FIELDS}", selectFields);

            IOClass.AppendTextInFile(pathNewFile, textEdit, true);
        }

        private void createView()
        {
            IOClass.DirectorieMove(_rootPath + @"\admin\component_" + _configPathTemplate + @"\views\view", _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower(), true);

            string pathFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\view.html.php";
            string pathNewFile = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\view.html.php";

            string pathFileTmpl = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\tmpl\temp.php";
            string pathNewFileTmpl = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\tmpl\default.php";

            string pathFileTmplModalAdicionar = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\tmpl\temp_modal_adicionar.php";
            string pathNewFileTmplModalAdicionar = _rootPath + @"\admin\component_" + _configPathTemplate + @"\views\" + _type.ToLower() + @"\tmpl\modal_adicionar.php";

            #region view

            string textFile = replace(pathFile);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);

            #endregion

            #region view

            string textFileTmpl = replace(pathFileTmpl);
            string textFileTmplModalAdicionar = replace(pathFileTmplModalAdicionar);
            string fields = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if (lvwColunas.Items[i].Checked == false) { continue; }

                bool pk = lvwColunas.Items[i].ForeColor == Color.DarkGoldenrod ? true : false;
                string fieldName = lvwColunas.GetItem(i, ColumnsColumn.Name);
                bool fieldNull = lvwColunas.GetItem(i, ColumnsColumn.Nulls) == "null" ? true : false;
                string fieldValue = lvwColunas.GetItem(i, ColumnsColumn.XML);
                string fieldLabel = lvwColunas.GetItem(i, ColumnsColumn.FieldLabel);

                if (pk == false)
                {
                    fields += string.Format("\t\t\t\t\t<div class=\"form-group\">{0}" +
                                            "\t\t\t\t\t\t<label for=\"{4}\"{3}>{1}:</label>{0}" +
                                            "\t\t\t\t\t\t{2}{0}" +
                                            "\t\t\t\t\t</div>{0}",
                                            Environment.NewLine,
                                            fieldLabel,
                                            fieldValue,
                                            fieldNull ? "" : " class=\"label-obrigatorio\"",
                                            fieldName
                                            );
                }
            }

            textFileTmplModalAdicionar = textFileTmplModalAdicionar.Replace("{FIELDS}", Environment.NewLine + fields);

            IOClass.AppendTextInFile(pathNewFileTmpl, textFileTmpl, true);
            IOClass.AppendTextInFile(pathNewFileTmplModalAdicionar, textFileTmplModalAdicionar, true);

            #endregion
        }

        private void createIndexModelView()
        {
            string pathFolder = _rootPath + @"\admin\component_" + _configPathTemplate + @"\assets\js\ViewModels\ViewModel";
            string pathFolderNew = _rootPath + @"\admin\component_" + _configPathTemplate + @"\assets\js\ViewModels\" + _type;

            IOClass.DirectorieMove(pathFolder, pathFolderNew, true);

            string pathFile = pathFolderNew + @"\ViewModel.js";
            string pathNewFile = pathFolderNew + @"\IndexViewModel.js";

            string textFile = replace(pathFile);
            string fields = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if (lvwColunas.Items[i].Checked == false) { continue; }

                string fieldType = lvwColunas.GetItem(i, ColumnsColumn.FieldType);
                string fieldName = lvwColunas.GetItem(i, ColumnsColumn.Name);
                string fieldLabel = lvwColunas.GetItem(i, ColumnsColumn.FieldLabel);
                string fieldAlign = lvwColunas.GetItem(i, ColumnsColumn.Align);
                string fielColumnSize = lvwColunas.GetItem(i, ColumnsColumn.ColumnSize);
                string fieldValue = "'" + fieldName + "'";

                switch (fieldType)
                {
                    case "Money":
                        {
                            fieldValue = "function (item) { return 'R$ ' + item." + fieldName + ".formatMoney(); }";
                            break;
                        }
                    case "Datepicker":
                        {
                            fieldValue = "function (item) { return self.FormatarData(item." + fieldName + "); }";
                            break;
                        }
                    case "CheckBox":
                        {
                            fieldValue = "function (item) { return item." + fieldName + " == 1 ? 'Sim':'Não';}";
                            break;
                        }
                    default:
                        {
                            if (fieldName == txtUserCreate.Text.Trim())
                            {
                                fieldValue = "'nome_razao_social_usuario_cadastro'";
                            }
                            else
                            {
                                fieldValue = "'" + fieldName + "'";
                            }
                            break;
                        }
                }

                fields += "\t\t\t\t{ headerText: '" + fieldLabel + "', rowText: " + fieldValue + ", rowType: 'text', HeaderCssClass: '" + fieldAlign + "', CssClass: '" + fieldAlign + " vertical-align-middle " + fielColumnSize + "' }," + Environment.NewLine;

            }
            //
            textFile = textFile.Replace("{FIELD_FOCO}", "???????????");
            textFile = textFile.Replace("{FIELDS_COLUMNS}", fields);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }

        private void lvwColunas_DoubleClick(object sender, EventArgs e)
        {
            txtFieldFoco.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name);
            txtOrderByDefault.Text = txtFieldFoco.Text;
            txtSearchText.Text = txtFieldFoco.Text;
        }

        private void cboFieldTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fieldTypeCombo = cboFieldTypes.SelectedItem.ToString();
            string xmlText = _fieldType[fieldTypeCombo];

            string fieldTypeColumn = lvwColunas.GetSelectedItem(ColumnsColumn.FieldType);
            string xmlTextColumn = lvwColunas.GetSelectedItem(ColumnsColumn.XML);

            if (fieldTypeColumn == fieldTypeCombo && xmlTextColumn.Trim().Length > 0)
            {
                xmlText = xmlTextColumn;
            }
            else
            {
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.FieldType].Text = fieldTypeCombo;
            }

            DBTools.classes.ObjectsClass.Column column = (DBTools.classes.ObjectsClass.Column)lvwColunas.SelectedItems[0].Tag;

            xmlText = replaceFields(xmlText, column);

            txtFieldXML.Document.Clear();
            txtFieldXML.Document.Text = xmlText;

            btnQuerySQL.Visible = fieldTypeCombo == "SQL (Dropdown)" ? true : false;
        }
        private string replaceFields(string text, DBTools.classes.ObjectsClass.Column column)
        {
            Dictionary<string, string> replacesFields = new Dictionary<string, string>();

            replacesFields.Add("[name]", column.Name);
            replacesFields.Add("[size]", column.DataType.MaximumLength.ToString());
            replacesFields.Add("[maxlength]", column.DataType.MaximumLength.ToString());
            replacesFields.Add("[required]", column.Nullable ? "false" : "true");

            foreach (var item in replacesFields)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text;
        }

        private void btnSalvarXMLFieldtype_Click(object sender, EventArgs e)
        {
            if (lvwColunas.SelectedItemCount > 0)
            {
                string document = txtFieldXML.Document.Text;

                document = document.Replace("[label]", txtFieldLabel.Text);

                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.FieldLabel].Text = txtFieldLabel.Text;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.FieldType].Text = cboFieldTypes.SelectedItem.ToString();
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.XML].Text = document;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.Align].Text = cboAlign.SelectedItem.ToString();
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.ColumnSize].Text = cboColumnSize.SelectedItem.ToString();

                txtFieldXML.Document.Text = document;
            }
        }

        private void lvwColunas_Click(object sender, EventArgs e)
        {
            if (lvwColunas.SelectedItemCount > 0)
            {
                string fieldType = lvwColunas.GetSelectedItem(ColumnsColumn.FieldType);
                string align = lvwColunas.GetSelectedItem(ColumnsColumn.Align);
                string columnSize = lvwColunas.GetSelectedItem(ColumnsColumn.ColumnSize);

                int index = cboFieldTypes.FindStringExact(fieldType);

                cboFieldTypes.SelectedIndex = index;
                cboFieldTypes_SelectedIndexChanged(null, null);

                int indexAlign = cboAlign.FindStringExact(align);

                cboAlign.SelectedIndex = indexAlign;

                int indexColumnSize = cboColumnSize.FindStringExact(columnSize);

                cboColumnSize.SelectedIndex = indexColumnSize;

                txtFieldLabel.Text = lvwColunas.GetSelectedItem(ColumnsColumn.FieldLabel);
            }
        }

        private string GetDataTypeFormFilterFormField(DBTools.classes.ObjectsClass.Column column)
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
                        fieldType = " LIKE '%$filtro->" + column.Name + "%'";
                        break;
                    }
                case DBTools.classes.ObjectsClass.SqlDataType.SmallDateTime:
                case DBTools.classes.ObjectsClass.SqlDataType.Date:
                case DBTools.classes.ObjectsClass.SqlDataType.Time:
                case DBTools.classes.ObjectsClass.SqlDataType.DateTimeOffset:
                case DBTools.classes.ObjectsClass.SqlDataType.DateTime2:
                case DBTools.classes.ObjectsClass.SqlDataType.DateTime:
                    {
                        fieldType = " = '$filtro->" + column.Name + "'";
                        break;
                    }
                case DBTools.classes.ObjectsClass.SqlDataType.Decimal:
                case DBTools.classes.ObjectsClass.SqlDataType.Numeric:
                    {
                        fieldType = " = $filtro->" + column.Name;
                        break;
                    }
                default:
                    {
                        fieldType = " = $filtro->" + column.Name;
                        break;
                    }
            }

            return fieldType;

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
                case DBTools.classes.ObjectsClass.SqlDataType.TinyInt:
                case DBTools.classes.ObjectsClass.SqlDataType.Bit:
                    {
                        fieldType = "CheckBox";
                        break;
                    }
                default:
                    {
                        fieldType = "Text";
                        break;
                    }
            }

            if (column.IsPrimaryKey)
            {
                fieldType = "PrimaryKey";
            }

            if (column.Name.ToLower() == "published")
            {
                fieldType = "CheckBox";
            }

            return fieldType;

        }

        private void btnQuerySQL_Click(object sender, EventArgs e)
        {
            frmSQLKeyValue formSQLKeyValue = new frmSQLKeyValue(ref _so);

            if (formSQLKeyValue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string document = txtFieldXML.Document.Text;

                document = document.Replace("[key_field]", formSQLKeyValue.KeyField);
                document = document.Replace("[value_field]", formSQLKeyValue.ValueField);
                document = document.Replace("[query]", formSQLKeyValue.Query);

                string queryJoin = string.Empty;

                if (formSQLKeyValue.IsTableUser)
                {
                    queryJoin = string.Format("$query->select('usu.name AS name_usu'){0}" +
                                              "->join('LEFT', '#__users AS usu ON a.id_usu = usu.id');{0}",
                                              Environment.NewLine);
                }
                else
                {
                    queryJoin = string.Format("$query->select('{4}.{2} AS {2}'){0}" +
                                                "->join('LEFT', '{3} AS {4} ON a.{1} = {4}.{1}');{0}",
                                                Environment.NewLine,
                                                formSQLKeyValue.KeyField,
                                                formSQLKeyValue.ValueField,
                                                formSQLKeyValue.TableName,
                                                formSQLKeyValue.TablePrefix);
                }

                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.KeyValue].Text = formSQLKeyValue.ValueField;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.QueryJoin].Text = queryJoin;

                txtFieldXML.Document.Text = document;
            }
        }

        private void btnRefreshXML_Click(object sender, EventArgs e)
        {
            if (lvwColunas.IsSelectedItem)
            {
                string fieldTypeCombo = cboFieldTypes.SelectedItem.ToString();
                string xmlText = _fieldType[fieldTypeCombo];

                DBTools.classes.ObjectsClass.Column column = (DBTools.classes.ObjectsClass.Column)lvwColunas.SelectedItems[0].Tag;

                xmlText = replaceFields(xmlText, column);

                txtFieldXML.Document.Clear();
                txtFieldXML.Document.Text = xmlText;
            }
        }

        private void frmJoomla_FormClosing(object sender, FormClosingEventArgs e)
        {
            lvwColunas.ColumnsWidthSave();
        }

        private void txtFieldTitle_Enter(object sender, EventArgs e)
        {
            txtFieldLabel.SelectAll();
        }

        private void btnAdminComponentPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtAdminComponentPath.Text = fbd.SelectedPath;
            }
        }

        private void btnResgatarCamposTipoData_Click(object sender, EventArgs e)
        {
            string rows = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if (lvwColunas.GetItem(i, ColumnsColumn.FieldType) == "Datepicker")
                {
                    rows += string.Format("{0}{1}", lvwColunas.GetItem(i, ColumnsColumn.Name), Environment.NewLine);
                }
            }

            if (string.IsNullOrEmpty(rows) == false)
            {
                Clipboard.SetText(rows);
            }

            MessageBox.Show("Dados copiados!");
        }

        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            configuracoes_aplicar();
            MessageBox.Show("Aplicado com sucesso!");
            tabControlJoomla.SelectedIndex = 0;
        }

        private void btnAdminComponentPathTemplate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtAdminComponentPathTemplate.Text = fbd.SelectedPath;
            }
        }

        private void btnUserCreate_Click(object sender, EventArgs e)
        {
            setValueGrid(txtUserCreate);
        }

        private void btnDateCreate_Click(object sender, EventArgs e)
        {
            setValueGrid(txtDateCreate);
        }

        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            setValueGrid(txtUserUpdate);
        }

        private void btnDateUpdate_Click(object sender, EventArgs e)
        {
            setValueGrid(txtDateUpdate);
        }

        private void setValueGrid(object control)
        {
            TextBox txt = control as TextBox;

            txt.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name);
        }

        private void BtnSalvarConfigurações_Click(object sender, EventArgs e)
        {
            try
            {
                saveConfigFile();

                MessageBox.Show("Salvo com sucesso!");
            }
            catch (Exception exc)
            {
                Funcoes.LogError(this.Name, exc);
            }
        }
    }
}
