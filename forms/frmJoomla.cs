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
    public partial class frmJoomla : Form
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
            public const int NoWrap = 12;
            public const int Width = 13;
	    }

        private DBTools.classes.ObjectsClass.Table m_table;
        private DBTools.classes.ObjectsClass.Columns m_columns; 
        private SqlObjectsClass m_so;
        private string m_ROOT_PATH;
        private string m_component;
        private bool m_publishedColumn = false;
        private DataTable m_dtConfigExtensao;
        
        private Dictionary<string, string> m_FieldType = new Dictionary<string,string>(); 

        public frmJoomla(DBTools.classes.ObjectsClass.Table table, SqlObjectsClass so)
        {
            InitializeComponent();

            txtFieldXML.Document.Clear(); 
            txtFieldXML.Document.Text = "";

            lvwColunas.ColumnsWidthLoad();

            Fireball.CodeEditor.SyntaxFiles.CodeEditorSyntaxLoader.SetSyntax(txtFieldXML, Fireball.CodeEditor.SyntaxFiles.SyntaxLanguage.XML);

            loadFieldTypeXML();
            loadConfigExtensaoFile();

            m_so    = so;
            m_table = table;
            m_columns = m_so.GetColumns(m_table);
        }

        public void configuracoes_aplicar()
        {
            m_component = txtcomponent_name.Text.Trim();
            txtAdminComponentPath.Text = txtAdminComponentPathTemplate.Text; 
  
            m_ROOT_PATH = Application.StartupPath + @"\" + txtConfigPathTemplate.Text + @"\";

            string newPath = Application.StartupPath + @"\" + m_table.Name.ToLower().Substring(6) + @"\"; 

            if(IOClass.DirectoryExists(newPath))
            {
                IOClass.DeleteDirectorie(newPath);    
            }

            IOClass.DirectorieCopy(m_ROOT_PATH, newPath, false);

            m_ROOT_PATH = newPath; 

            txtTableName.Text = m_table.Name.ToLower().Substring(6); 
            txtPK.Text = "";

            #region Columns Grid
            Color foreColor = Color.Black;  

            foreach (DBTools.classes.ObjectsClass.Column column in m_columns)
            {
                int iconType    = DBTools.forms.frmTablesRowsCount.IconType.Blank;
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
                    iconType    = DBTools.forms.frmTablesRowsCount.IconType.PK;
                    foreColor   = Color.DarkGoldenrod;
                    txtPK.Text  = column.Name; 
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
                    if(space){columnNameNormalized += " ";}

                    columnNameNormalized += name.ToUpperFirstChar();
     
                    space = true;
                }
                
                aDados.Add(columnNameNormalized);
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
  
                aDados.Add(GetDataTypeFormField(column));
                aDados.Add(" ");
                aDados.Add(" ");
                aDados.Add(" ");
                aDados.Add("center");
                aDados.Add("True");
                aDados.Add("10%");

                if(column.Name.ToLower() == "published")
                {
                    m_publishedColumn = true;
                }

                lvwColunas.Add(aDados, foreColor, iconType);

                lvwColunas.Items[lvwColunas.ItemCount-1].Tag = column;   
            }

            lblTotalColunas.Text = m_table.RowCount.ToString();
            #endregion

            #region Define o XML dos campos

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                string fieldType = lvwColunas.GetItem(i, ColumnsColumn.FieldType);

                DBTools.classes.ObjectsClass.Column column = (DBTools.classes.ObjectsClass.Column)lvwColunas.Items[i].Tag; 

                lvwColunas.Items[i].SubItems[ColumnsColumn.XML].Text = replaceFields(m_FieldType[fieldType], column);
            }

            #endregion

            string[] typeArray = txtTableName.Text.Replace(txtTableNameTextReplace.Text.Trim(),"").Split('_');
            string type = "";
            string title = "";

            for (int i = 0; i < (typeArray.Count()-1); i++)
            {
                type += typeArray[i].ToUpperFirstChar();
                title += "_" + typeArray[i].ToUpper();
            }

            txtPrefix.Text = txtConfigPrefix.Text.Trim();
            txtType.Text = type;
            txtTypeEdit.Text = type;
            txtTextPrefix.Text = m_component.ToUpper() + type.ToUpper();
            txtTextPrefixEdit.Text = txtTextPrefix.Text;

            loadConfigFile();
        }

        private void frmJoomla_Load(object sender, EventArgs e)
        {
        
        }

        
        private void loadConfigExtensaoFile()
        {
            string fileName = Application.StartupPath + "\\xmls\\config_extensao.xml";
            
            m_dtConfigExtensao = new DataTable("Config");
 
            if(System.IO.File.Exists(fileName) == false)
            {
                m_dtConfigExtensao.Columns.Add("ComponentName");
                m_dtConfigExtensao.Columns.Add("ConfigPathTemplate");
                m_dtConfigExtensao.Columns.Add("TableNameTextReplace");
                m_dtConfigExtensao.Columns.Add("ConfigPrefix");
                m_dtConfigExtensao.Columns.Add("AdminComponentPathTemplate");
            }
            else
            {
                m_dtConfigExtensao.ReadXml(fileName);
            }

            for (int i = 0; i < m_dtConfigExtensao.Rows.Count; i++)
            {
                cboExtensao.Items.Add(m_dtConfigExtensao.Rows[i]["ComponentName"].ToString()); 
            }
        }

        private void cboExtensao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string componentName = cboExtensao.SelectedItem.ToString(); 

            DataRow[] dr = m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName));  

            if(dr.Length > 0)
            {
                txtcomponent_name.Text          = dr[0]["ComponentName"].ToString();  
                txtConfigPathTemplate.Text      = dr[0]["ConfigPathTemplate"].ToString();  
                txtTableNameTextReplace.Text    = dr[0]["TableNameTextReplace"].ToString();  
                txtConfigPrefix.Text            = dr[0]["ConfigPrefix"].ToString();
                txtAdminComponentPathTemplate.Text = dr[0]["AdminComponentPathTemplate"].ToString(); 
            }
        }

        private void btnSalvarExtensao_Click(object sender, EventArgs e)
        {
            string fileName = Application.StartupPath + "\\xmls\\config_extensao.xml";

            string componentName = txtcomponent_name.Text.Trim();

            DataRow[] dr = m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName));

            if (dr.Length <= 0)
            {
                object[] row = {componentName, 
                               txtConfigPathTemplate.Text.Trim(),
                               txtTableNameTextReplace.Text.Trim(),
                               txtConfigPrefix.Text.Trim(),
                               txtAdminComponentPathTemplate.Text.Trim()};

                m_dtConfigExtensao.Rows.Add(row);
            }
            else
            {
                m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ComponentName"] = componentName;
                m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigPathTemplate"] = txtConfigPathTemplate.Text.Trim();
                m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["TableNameTextReplace"] = txtTableNameTextReplace.Text.Trim();
                m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["ConfigPrefix"] = txtConfigPrefix.Text.Trim();
                m_dtConfigExtensao.Select(string.Format("ComponentName Like '{0}'", componentName))[0]["AdminComponentPathTemplate"] = txtAdminComponentPathTemplate.Text.Trim();
            }

            m_dtConfigExtensao.WriteXml(fileName, XmlWriteMode.WriteSchema);

            cboExtensao.Items.Clear(); 

            for (int i = 0; i < m_dtConfigExtensao.Rows.Count; i++)
            {
                cboExtensao.Items.Add(m_dtConfigExtensao.Rows[i]["ComponentName"].ToString()); 
            }

            cboExtensao.SelectedIndex = cboExtensao.FindString(componentName); 

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            pgbMain.Minimum = 0;
            pgbMain.Maximum = 8;
            pgbMain.Value = 0; 

            saveConfigFile();
            pgbMain.Value = 1;

            createTable();
            pgbMain.Value = 2;

            createController();
            pgbMain.Value = 3;

            createModels();
            pgbMain.Value = 4;

            createForms();
            pgbMain.Value = 5;

            createViewEdit();
            pgbMain.Value = 6;

            createViewShow();
            pgbMain.Value = 7;

            copyFilesToAdminComponent();
            pgbMain.Value = 8;

            MessageBox.Show("Arquivos criados!");
        }

        private void loadFieldTypeXML()
        {
           #region Field Type XML
            m_FieldType.Add("Money", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"addon\"{0}" + 
                                                "default=\"\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "size=\"[size]\"{0}" + 
                                                "maxlength=\"[maxlength]\"{0}" + 
                                                "text_left=\"R$\"{0}" +
                                                "style=\"text-align: right;width: 80px;\"{0}" + 
                                                "class=\"priceFormat\"{0}/>",
                                                Environment.NewLine));

            m_FieldType.Add("Text", string.Format("<field{0}" +
                                                "name=\"[name]\"{0}" +
                                                "type=\"text\"{0}" +
                                                "default=\"\"{0}" +
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "size=\"[size]\"{0}" +
                                                "maxlength=\"[maxlength]\"{0}/>",
                                                Environment.NewLine));

            m_FieldType.Add("Color", string.Format("<field{0}" + 
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

            m_FieldType.Add("Datepicker", string.Format("<field{0}" + 
                                                    "name=\"[name]\"{0}" + 
                                                    "type=\"datepicker\"{0}" + 
                                                    "default=\"\"{0}" + 
                                                    "label=\"[label]\"{0}" + 
                                                    "description=\"\"{0}" + 
                                                    "required=\"[required]\"{0}" +
                                                    "dateFormat=\"dd/mm/yy\"{0}" +
                                                    "mask=\"99/99/9999\"{0}/>",
                                                    Environment.NewLine));

            m_FieldType.Add("PrimaryKey", string.Format("<field{0}" + 
                                                        "name=\"[name]\"{0}" + 
                                                        "type=\"text\"{0}" + 
                                                        "default=\"0\"{0}" + 
                                                        "readonly=\"true\"{0}" +
                                                        "required=\"[required]\"{0}" +
                                                        "class=\"readonly\"{0}" + 
                                                        "label=\"JGLOBAL_FIELD_ID_LABEL\"{0}" + 
                                                        "description=\"JGLOBAL_FIELD_ID_DESC\"{0}/>",
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

            m_FieldType.Add("Radio", string.Format("<field{0}" + 
                                            "name=\"[name]\"{0}" + 
                                            "type=\"radio\"{0}" +
                                            "default=\"0\"{0}" +
                                            "required=\"[required]\"{0}" +
                                            "class=\"btn-group btn-group-yesno\"{0}" +
                                            "label=\"[label]\"{0}" +
                                            "description=\"Status\" >{0}" + 
                                            "<option value=\"1\">JYES</option>{0}" + 
                                            "<option value=\"0\">JNO</option>{0}" + 
                                            "</field>",
                                            Environment.NewLine));

            m_FieldType.Add("Integer", string.Format("<field{0}" + 
                                            "name=\"[name]\"{0}" + 
                                            "type=\"integer\"{0}" +
                                            "default=\"0\"{0}" +
                                            "required=\"[required]\"{0}" +
                                            "label=\"[label]\"{0}" +
                                            "description=\"\"{0}" + 
                                            "first=\"1\"{0}" + 
                                            "last=\"10\"{0}" + 
                                            "step=\"1\"{0}" + 
                                             "/>",
                                            Environment.NewLine));

            m_FieldType.Add("Email", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"email\"{0}" +
                                                "class=\"inputbox\"{0}" +
                                                "default=\"\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "size=\"[size]\"{0}" + 
                                                "validate=\"email\"{0}/>",
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

            m_FieldType.Add("CheckBox", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"checkbox\"{0}" +
                                                "default=\"0\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "value=\"1\"{0}/>",
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
                                                Environment.NewLine));

            m_FieldType.Add("SQL (Dropdown)", string.Format("<field{0}" + 
                                                "name=\"[name]\"{0}" + 
                                                "type=\"sql\"{0}" +
                                                "default=\"0\"{0}" + 
                                                "label=\"[label]\"{0}" +
                                                "description=\"\"{0}" +
                                                "required=\"[required]\"{0}" +
                                                "key_field=\"[key_field]\"{0}" +
                                                "value_field=\"[value_field]\"{0}" +
                                                "query=\"[query]\"{0}/>",
                                                Environment.NewLine));

            foreach (var item in m_FieldType)
            {
                cboFieldTypes.Items.Add(item.Key);
            }

            #endregion
        }

        private void loadConfigFile()
        {
            string fileName = Application.StartupPath + "\\xmls\\" + txtTableName.Text + ".xml";
            
            if(System.IO.File.Exists(fileName) == false){return;}

            DataTable dt = new DataTable("Config");
 
            dt.ReadXml(fileName);

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                string name = lvwColunas.GetItem(i, ColumnsColumn.Name);

                DataRow[] dr = dt.Select(string.Format("Name Like '{0}'", name));  

                if(dr.Length > 0)
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
            {}
        }

        private void copyFilesToAdminComponent()
        {
            string adminPath = txtAdminComponentPath.Text;
            string adminPathDBTools = m_ROOT_PATH + @"admin\" + m_component;
 
            string[] files = System.IO.Directory.GetFiles(adminPathDBTools, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (var fileName in files)
            {
               string destFileName = fileName.Replace(adminPathDBTools, adminPath);
  
                IOClass.CopyTo(fileName, destFileName);
            }
        }

        private string replace(string pathFile)
        {
            Dictionary<string, string> replacesFields = new Dictionary<string,string>(); 
            string output = IOClass.ReadFileToEnd(pathFile);
            
            replacesFields.Add("{PREFIX}", txtPrefix.Text);
            replacesFields.Add("{PREFIX_LOWER}", txtPrefix.Text.ToLower());
            replacesFields.Add("{TYPE}", txtType.Text);
            replacesFields.Add("{TYPE_EDIT}", txtTypeEdit.Text);
            replacesFields.Add("{TYPE_LOWER}", txtType.Text.ToLower());
            replacesFields.Add("{TYPE_EDIT_LOWER}", txtTypeEdit.Text.ToLower());
            replacesFields.Add("{TYPE_UPPER}", txtType.Text.ToUpper());
            replacesFields.Add("{TYPE_EDIT_UPPER}", txtTypeEdit.Text.ToUpper());
            replacesFields.Add("{TABLE_NAME}", txtTableName.Text);
            replacesFields.Add("{PK}", txtPK.Text);
            replacesFields.Add("{TEXT_PREFIX}", txtTextPrefix.Text);
            replacesFields.Add("{TEXT_PREFIX_EDIT}", txtTextPrefixEdit.Text);
            replacesFields.Add("{COMPONENT}", m_component);
            replacesFields.Add("{COMPONENT_UPPER}", m_component.ToUpper());
            replacesFields.Add("{ORDER_BY_DEFAULT}", txtOrderByDefault.Text);
            replacesFields.Add("{SEARCH_TEXT}", txtSearchText.Text);
            replacesFields.Add("{TITLE_SHOW}", txtTitle.Text);
            replacesFields.Add("{TITLE_EDIT}", txtTitleEdit.Text);
            replacesFields.Add("{TITLE_NEW}", txtTitleNew.Text);
            replacesFields.Add("{ROWS_COUNT}", m_columns.Count.ToString());
            replacesFields.Add("{ROWS_COUNT_PAGINATION}", (m_columns.Count + 1).ToString());
                                  
            //replacesFields.Add("{IMAGE_TITLE}", ???????);

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
            Dictionary<string, string> replacesFields = new Dictionary<string,string>(); 
            
            replacesFields.Add("{PREFIX}", txtPrefix.Text);
            replacesFields.Add("{PREFIX_LOWER}", txtPrefix.Text.ToLower());
            replacesFields.Add("{TYPE}", txtType.Text);
            replacesFields.Add("{TYPE_EDIT}", txtTypeEdit.Text);
            replacesFields.Add("{TYPE_LOWER}", txtType.Text.ToLower());
            replacesFields.Add("{TYPE_EDIT_LOWER}", txtTypeEdit.Text.ToLower());
            replacesFields.Add("{TYPE_UPPER}", txtType.Text.ToUpper());
            replacesFields.Add("{TYPE_EDIT_UPPER}", txtTypeEdit.Text.ToUpper());
            replacesFields.Add("{TABLE_NAME}", txtTableName.Text);
            replacesFields.Add("{PK}", txtPK.Text);
            replacesFields.Add("{TEXT_PREFIX}", txtTextPrefix.Text);
            replacesFields.Add("{TEXT_PREFIX_EDIT}", txtTextPrefixEdit.Text);
            replacesFields.Add("{COMPONENT}", m_component);
            replacesFields.Add("{COMPONENT_UPPER}", m_component.ToUpper());
            replacesFields.Add("{ORDER_BY_DEFAULT}", txtOrderByDefault.Text);
            replacesFields.Add("{SEARCH_TEXT}", txtSearchText.Text);
            replacesFields.Add("{TITLE_SHOW}", txtTitle.Text);
            replacesFields.Add("{TITLE_EDIT}", txtTitleEdit.Text);
            replacesFields.Add("{TITLE_NEW}", txtTitleNew.Text);
            replacesFields.Add("{ROWS_COUNT}", m_columns.Count.ToString());
            replacesFields.Add("{ROWS_COUNT_PAGINATION}", (m_columns.Count + 1).ToString());
                                  
            //replacesFields.Add("{IMAGE_TITLE}", ???????);

            foreach (var item in replacesFields)
            {
                output = output.Replace(item.Key, item.Value); 
            }

            return output;
        }

        private void createTable()
        {
            string pathFile = m_ROOT_PATH + @"admin\" + m_component + @"\tables\table.php";
            string pathNewFile = m_ROOT_PATH + @"admin\" + m_component + @"\tables\" + txtTypeEdit.Text.ToLower() + ".php";
            string vars = "";

            string textFile = replace(pathFile);

            foreach (DBTools.classes.ObjectsClass.Column column in m_columns)
            {
                vars += string.Format("    var ${0} = null;{1}", column.Name, Environment.NewLine);
            }

            textFile = textFile.Replace("{VARS}", vars);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }

        private void createController()
        {
            string pathFileEdit = m_ROOT_PATH + @"admin\" + m_component + @"\controllers\edit.php";
            string pathFileShow = m_ROOT_PATH + @"admin\" + m_component + @"\controllers\show.php";
            string pathNewFileEdit = m_ROOT_PATH + @"admin\" + m_component + @"\controllers\" + txtTypeEdit.Text.ToLower() + ".php";
            string pathNewFileShow = m_ROOT_PATH + @"admin\" + m_component + @"\controllers\" + txtType.Text.ToLower() + ".php";
              
            string textEdit = replace(pathFileEdit);
            string textShow = replace(pathFileShow);

            IOClass.AppendTextInFile(pathNewFileEdit, textEdit, true);
            IOClass.AppendTextInFile(pathNewFileShow, textShow, true);
        }

        private void createModels()
        {
            string pathFileEdit = m_ROOT_PATH + @"admin\" + m_component + @"\models\edit.php";
            string pathFileShow = m_ROOT_PATH + @"admin\" + m_component + @"\models\show.php";
            string pathNewFileEdit = m_ROOT_PATH + @"admin\" + m_component + @"\models\" + txtTypeEdit.Text.ToLower() + ".php";
            string pathNewFileShow = m_ROOT_PATH + @"admin\" + m_component + @"\models\" + txtType.Text.ToLower() + ".php";
              
            string textEdit = replace(pathFileEdit);
            string textShow = replace(pathFileShow);

            string filter_fields = "";
            string getState = "";
            List<string> rowsDateType = new List<string>();
            
            for (int i = 0; i < m_columns.Count; i++)
            {
                if(i == (m_columns.Count-1))
                {
                    filter_fields += string.Format("'{0}', 'a.{0}'", m_columns[i].Name);
                    getState += string.Format("'a.{0} AS {0}'", m_columns[i].Name);
                }
                else
                {
                    filter_fields += string.Format("'{0}', 'a.{0}',{1}", m_columns[i].Name, Environment.NewLine);
                    getState += string.Format("'a.{0} AS {0}, ' .{1}", m_columns[i].Name, Environment.NewLine);
                }

                if(m_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.DateTime ||
                    m_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.DateTime2 ||
                    m_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Date)
                {
                    if (m_columns[i].Name != txtDateCreate.Text && m_columns[i].Name != txtDateUpdate.Text)
                    {
                        rowsDateType.Add(string.Format("$table->{0} = date(implode(\"-\", array_reverse(explode(\"/\", $table->{0}))));", m_columns[i].Name));
                    }
                }

                if (m_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Decimal ||
                    m_columns[i].DataType.SqlDataType == classes.ObjectsClass.SqlDataType.Numeric)
                {
                    if (m_columns[i].Name != txtDateCreate.Text && m_columns[i].Name != txtDateUpdate.Text)
                    {
                        rowsDateType.Add(string.Format("$table->{0} = str_replace('.','', $table->{0});", m_columns[i].Name));
                        rowsDateType.Add(string.Format("$table->{0} = str_replace(',','.', $table->{0});", m_columns[i].Name));
                    }
                }
            }

            string rowsQueryJoins = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if(lvwColunas.GetItem(i, ColumnsColumn.FieldType) == "SQL (Dropdown)")
                {
                     rowsQueryJoins += string.Format("{1}{0}", 
                                                     Environment.NewLine,
                                                     lvwColunas.GetItem(i, ColumnsColumn.QueryJoin)); 
                }
            }

            if(rowsQueryJoins.Length > 0)
            {
                textShow = textShow.Replace("{QUERY_JOINS}", rowsQueryJoins);
            }
            else
            {
                textShow = textShow.Replace("{QUERY_JOINS}", string.Empty);
            }

            #region Update or Create Rows

            string create_update = "";

            if (txtUserCreate.Text.Trim().Length > 0 || txtDateCreate.Text.Trim().Length > 0)
            {
                
                create_update += string.Format("$date = JFactory::getDate();{0}", Environment.NewLine);
                create_update += string.Format("$user = JFactory::getUser();{0}{0}", Environment.NewLine);

                // create
                create_update += string.Format("if (empty($table->{0})){1}", txtPK.Text, Environment.NewLine);
                create_update += "{" + Environment.NewLine;

                if (txtUserCreate.Text.Trim().Length > 0)
                {
                    create_update += string.Format("$table->{0} = $user->id;{1}", txtUserCreate.Text.Trim(), Environment.NewLine);
                }

                if (txtDateCreate.Text.Trim().Length > 0)
                {
                    create_update += string.Format("$table->{0} = $date->toSql(); {1}", txtDateCreate.Text.Trim(), Environment.NewLine);
                }

                create_update += "}" + Environment.NewLine;

                if (txtUserUpdate.Text.Trim().Length > 0 || txtDateUpdate.Text.Trim().Length > 0)
                {
                    // update
                    create_update += string.Format("{0}else{0}", Environment.NewLine);
                    create_update += "{" + Environment.NewLine;

                    if (txtUserUpdate.Text.Trim().Length > 0)
                    {
                        create_update += string.Format("$table->{0} = $user->id;{1}", txtUserUpdate.Text.Trim(), Environment.NewLine);
                    }

                    if (txtDateUpdate.Text.Trim().Length > 0)
                    {
                        create_update += string.Format("$table->{0} = $date->toSql(); {1}", txtDateUpdate.Text.Trim(), Environment.NewLine);
                    }
   
                    create_update += "}" + Environment.NewLine;
                }
            }

            if (create_update.Trim().Length > 0)
            {
                textEdit = textEdit.Replace("{CREATE_UPDATE_ROWS}", create_update);
            }
            else
            {
                textEdit = textEdit.Replace("{CREATE_UPDATE_ROWS}", string.Empty);
            }

            #endregion

            if (rowsDateType.Count > 0)
            {
                string rows = "";

                foreach (var row in rowsDateType)
	            {
		            rows += string.Format("{0}{1}", row, Environment.NewLine); 
	            }

                textEdit = textEdit.Replace("{CONVERTDATEROW_PREPARETABLE}", rows);
            }
            else
            {
                textEdit = textEdit.Replace("{CONVERTDATEROW_PREPARETABLE}", string.Empty);
            }

            textShow = textShow.Replace("{FILTER_FIELDS}", filter_fields);
            textShow = textShow.Replace("{LIST_QUERY}", getState);

            if(m_publishedColumn)
            {
                textShow = textShow.Replace("{MODEL_SHOW_PUBLISHED}", "if (is_numeric($state))" + Environment.NewLine +
                                            "{" + Environment.NewLine +
                                            "$query->where('a.published = ' . (int) $state);" + Environment.NewLine +
                                            "}" + Environment.NewLine +
                                            "elseif ($state === '')" + Environment.NewLine +
                                            "{" + Environment.NewLine +
                                            "$query->where('(a.published IN (0, 1))');" + Environment.NewLine +
                                            "}" + Environment.NewLine);
            }
            else
            {
                textShow = textShow.Replace("{MODEL_SHOW_PUBLISHED}", string.Empty);
            }

            IOClass.AppendTextInFile(pathNewFileEdit, textEdit, true);
            IOClass.AppendTextInFile(pathNewFileShow, textShow, true);
        }

        private void createForms()
        {
            string pathFile = m_ROOT_PATH + @"admin\" + m_component + @"\models\forms\forms.xml";
            string pathNewFile = m_ROOT_PATH + @"admin\" + m_component + @"\models\forms\" + txtTypeEdit.Text.ToLower() + ".xml";
            string fields = "";

            string textFile = replace(pathFile);

            for (int i = 0; i < lvwColunas.ItemCount; i++)
            {
                string field = string.Format("{0}{1}", lvwColunas.GetItem(i, ColumnsColumn.XML), Environment.NewLine);

                fields += field;
            }

            textFile = textFile.Replace("{FIELDS}", fields);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);
        }

        private void createViewEdit()
        {
            IOClass.DirectorieMove(m_ROOT_PATH + @"admin\" + m_component + @"\views\edit", m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtTypeEdit.Text.ToLower(), true);

            string pathFile     = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtTypeEdit.Text.ToLower() + @"\edit.php";
            string pathNewFile  = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtTypeEdit.Text.ToLower() + @"\view.html.php";

            string pathFileTmpl     = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtTypeEdit.Text.ToLower() + @"\tmpl\edit.php";
            string pathNewFileTmpl  = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtTypeEdit.Text.ToLower() + @"\tmpl\edit.php";

            #region view

            string textFile = replace(pathFile);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);

            #endregion

            #region view

            string textFileTmpl = replace(pathFileTmpl);
            string fields = "";

            foreach (DBTools.classes.ObjectsClass.Column column in m_columns)
            {
                if(column.IsPrimaryKey == false)
                {
                    fields += string.Format("<div class=\"control-group\">{1}" + 
                                            "<div class=\"control-label\">{1}" +
                                            "<?php echo $this->form->getLabel('{0}'); ?>{1}" +
                                            "</div>{1}" +
                                            "<div class=\"controls\">{1}" +
                                            "<?php echo $this->form->getInput('{0}'); ?>{1}" +
                                            "</div>{1}" + 
                                            "</div>{1}", column.Name, Environment.NewLine);
                }
            }

            textFileTmpl = textFileTmpl.Replace("{FIELDS}", fields);

            IOClass.AppendTextInFile(pathNewFileTmpl, textFileTmpl, true);

            #endregion
        }

        private void createViewShow()
        {
            IOClass.DirectorieMove(m_ROOT_PATH + @"admin\" + m_component + @"\views\show", m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtType.Text.ToLower(), true);

            string pathFile     = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtType.Text.ToLower() + @"\show.php";
            string pathNewFile  = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtType.Text.ToLower() + @"\view.html.php";

            string pathFileTmpl     = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtType.Text.ToLower() + @"\tmpl\show.php";
            string pathNewFileTmpl  = m_ROOT_PATH + @"admin\" + m_component + @"\views\" + txtType.Text.ToLower() + @"\tmpl\default.php";

            #region view

            string textFile = replace(pathFile);

            if(m_publishedColumn)
            {

                textFile = textFile.Replace("{TOOLBAR_PUBLISH}", "if ($canDo->get('core.edit.state'))" + Environment.NewLine +
                                                                "{" + Environment.NewLine +
                                                                "JToolbarHelper::publish('{TYPE_LOWER}.publish', 'JTOOLBAR_PUBLISH', true);" + Environment.NewLine +
                                                                "JToolbarHelper::unpublish('{TYPE_LOWER}.unpublish', 'JTOOLBAR_UNPUBLISH', true);" + Environment.NewLine +
                                                                "JToolbarHelper::divider();" + Environment.NewLine +
                                                                "}" + Environment.NewLine);
            }
            else
            {
                textFile = textFile.Replace("{TOOLBAR_PUBLISH}", "");
            }

            textFile = replaceOnly(textFile);

            IOClass.AppendTextInFile(pathNewFile, textFile, true);

            #endregion

            #region view

            string textFileTmpl = replace(pathFileTmpl);
            string table_theads = "";
            string table_rows = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
			{
                if(lvwColunas.Items[i].Checked == false){continue;} 

                bool pk             = lvwColunas.Items[i].ForeColor == Color.DarkGoldenrod ? true: false;   
                string columnName   = lvwColunas.GetItem(i, ColumnsColumn.Name);
                string fieldLabel   = lvwColunas.GetItem(i, ColumnsColumn.FieldLabel);
                string fieldType    = lvwColunas.GetItem(i, ColumnsColumn.FieldType);
                string keyValue     = lvwColunas.GetItem(i, ColumnsColumn.KeyValue);
                string align        = lvwColunas.GetItem(i, ColumnsColumn.Align);
                string nowrap       = lvwColunas.GetItem(i, ColumnsColumn.NoWrap).ToBoolean() ? "nowrap " : "";
                string width        = lvwColunas.GetItem(i, ColumnsColumn.Width).Trim().Length > 0 ? string.Format("width=\"{0}\"", lvwColunas.GetItem(i, ColumnsColumn.Width).Trim()) : "";
 
			    if(pk == false && columnName.ToLower() != "published")
                {
                    table_theads += string.Format("<th {5} class=\"{4}{3}\">{2}" +
                                                  "<?php echo JHtml::_('grid.sort', '{1}', 'a.{0}', $listDirn, $listOrder); ?>{2}" +
                                                  "</th>{2}",
                                                  columnName,
                                                  fieldLabel,
                                                  Environment.NewLine,
                                                  align,
                                                  nowrap,
                                                  width);

                    switch (fieldType)
                    {
                        case "SQL (Dropdown)":
                            {
                                table_rows += string.Format("<td class=\"{3}{2}\">{1}" +
                                                            "<a href=\"<?php echo $link; ?>\"><?php echo $item->{0}; ?></a>{1}" +
                                                            "</td>{1}",
                                                            keyValue,
                                                            Environment.NewLine,
                                                            align,
                                                            nowrap);
                                break;
                            }
                        case "Money":
                            {
                                table_rows += string.Format("<td class=\"{3}{2}\">{1}" +
                                                            "<a href=\"<?php echo $link; ?>\"><?php echo utils_convertReal($item->{0}); ?></a>{1}" +
                                                            "</td>{1}",
                                                            columnName,
                                                            Environment.NewLine,
                                                            align,
                                                            nowrap);
                                break;
                            }
                        case "Datepicker":
                            {
                                table_rows += string.Format("<td class=\"{3}{2}\">{1}" +
                                                            "<a href=\"<?php echo $link; ?>\"><?php echo utils_getDate($item->{0}); ?></a>{1}" +
                                                            "</td>{1}",
                                                            columnName,
                                                            Environment.NewLine,
                                                            align,
                                                            nowrap);
                                break;
                            }
                        default:
                            {
                                table_rows += string.Format("<td class=\"{3}{2}\">{1}" +
                                                            "<a href=\"<?php echo $link; ?>\"><?php echo $item->{0}; ?></a>{1}" +
                                                            "</td>{1}",
                                                            columnName,
                                                            Environment.NewLine,
                                                            align,
                                                            nowrap);
                                break;
                            }
                    }
                }
			}

            textFileTmpl = textFileTmpl.Replace("{TABLE_THEADS}", table_theads);
            textFileTmpl = textFileTmpl.Replace("{TABLE_ROWS}", table_rows);

            if(m_publishedColumn)
            {
                textFileTmpl = textFileTmpl.Replace("{VIEW_SHOW_THEADS_PUBLISHED}", string.Format("{0}<th width=\"1%\" class=\"nowrap center\">{0}" +
                                                                                                "<?php echo JHtml::_('grid.sort', 'JSTATUS', 'a.published', $listDirn, $listOrder); ?>{0}" +
                                                                                                "</th>{0}", Environment.NewLine));

                textFileTmpl = textFileTmpl.Replace("{VIEW_SHOW_ROWS_PUBLISHED}", string.Format("{0}<td class=\"center\">{0}" +
                                                                                                "<?php echo JHtml::_('jgrid.published', $item->published, $i, '{1}.', $canChange); ?>{0}" +
                                                                                                "</td>{0}", Environment.NewLine, txtType.Text.ToLower()));
            }
            else
            {
                textFileTmpl = textFileTmpl.Replace("{VIEW_SHOW_THEADS_PUBLISHED}", string.Empty); 
                textFileTmpl = textFileTmpl.Replace("{VIEW_SHOW_ROWS_PUBLISHED}", string.Empty); 
            }

            textFileTmpl = replaceOnly(textFileTmpl);

            IOClass.AppendTextInFile(pathNewFileTmpl, textFileTmpl, true);

            #endregion
        }

        private void lvwColunas_DoubleClick(object sender, EventArgs e)
        {
            txtOrderByDefault.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Name);
        }

        private void cboFieldTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fieldTypeCombo   = cboFieldTypes.SelectedItem.ToString();
            string xmlText          = m_FieldType[fieldTypeCombo];

            string fieldTypeColumn  = lvwColunas.GetSelectedItem(ColumnsColumn.FieldType);
            string xmlTextColumn = lvwColunas.GetSelectedItem(ColumnsColumn.XML);

            if(fieldTypeColumn == fieldTypeCombo && xmlTextColumn.Trim().Length > 0)
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
            Dictionary<string, string> replacesFields = new Dictionary<string,string>(); 
            
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
             if(lvwColunas.SelectedItemCount > 0)
            {
                 string document = txtFieldXML.Document.Text;
 
                document = document.Replace("[label]", txtFieldLabel.Text);

                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.FieldLabel].Text = txtFieldLabel.Text;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.FieldType].Text = cboFieldTypes.SelectedItem.ToString();
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.XML].Text = document;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.Align].Text = cboAlign.SelectedItem.ToString();
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.NoWrap].Text = chknowrap.Checked.ToString();
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.Width].Text = txtWidth.Text;

                txtFieldXML.Document.Text = document; 
            }
        }

        private void lvwColunas_Click(object sender, EventArgs e)
        {
            if(lvwColunas.SelectedItemCount > 0)
            {
                string fieldType = lvwColunas.GetSelectedItem(ColumnsColumn.FieldType);
                string align = lvwColunas.GetSelectedItem(ColumnsColumn.Align);

                int index = cboFieldTypes.FindStringExact(fieldType);

                cboFieldTypes.SelectedIndex = index;
                cboFieldTypes_SelectedIndexChanged(null, null);

                int indexAlign = cboAlign.FindStringExact(align);

                cboAlign.SelectedIndex = indexAlign;

                chknowrap.Checked = lvwColunas.GetSelectedItem(ColumnsColumn.NoWrap).ToBoolean(); 

                txtFieldLabel.Text = lvwColunas.GetSelectedItem(ColumnsColumn.FieldLabel);
                txtWidth.Text = lvwColunas.GetSelectedItem(ColumnsColumn.Width);
            }
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

        private void btnQuerySQL_Click(object sender, EventArgs e)
        {
            frmSQLKeyValue formSQLKeyValue = new frmSQLKeyValue(ref m_so);
 
            if(formSQLKeyValue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string document = txtFieldXML.Document.Text;
 
                document = document.Replace("[key_field]", formSQLKeyValue.KeyField);
                document = document.Replace("[value_field]", formSQLKeyValue.ValueField);
                document = document.Replace("[query]", formSQLKeyValue.Query);

                string queryJoin = string.Empty;

                if(formSQLKeyValue.IsTableUser)
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

                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.KeyValue].Text  = formSQLKeyValue.ValueField;
                lvwColunas.SelectedItems[0].SubItems[ColumnsColumn.QueryJoin].Text = queryJoin;   

                txtFieldXML.Document.Text = document; 
            }
        }

        private void btnRefreshXML_Click(object sender, EventArgs e)
        {
            if(lvwColunas.IsSelectedItem)
            {
                string fieldTypeCombo   = cboFieldTypes.SelectedItem.ToString();
                string xmlText          = m_FieldType[fieldTypeCombo];

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

            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtAdminComponentPath.Text = fbd.SelectedPath;
            }
        }

        private void btnResgatarCamposTipoData_Click(object sender, EventArgs e)
        {
            string rows = "";

            for (int i = 0; i < lvwColunas.Items.Count; i++)
            {
                if(lvwColunas.GetItem(i, ColumnsColumn.FieldType) == "Datepicker")
                {
                    rows += string.Format("{0}{1}", lvwColunas.GetItem(i, ColumnsColumn.Name), Environment.NewLine);  
                }
            }

            if(string.IsNullOrEmpty(rows) == false)
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
    }
}
