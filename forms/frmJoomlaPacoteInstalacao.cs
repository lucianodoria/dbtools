using DBTools.classes;
using MlkPwgen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTools.forms
{
    public partial class frmJoomlaPacoteInstalacao : Form
    {
        private string _ftpRootDoriaTI = "ftp://ftp.doriati.com.br/public_html";
        private JoomlaInstall _joomlaInstall { get; set; }
        private string _projectPath { get; set; }
        private string _pathExtensionSite { get; set; }
        private string _pathExtensionAdmin { get; set; }
        private string _pathComponentsSite { get; set; }
        private string _pathComponentsAdmin { get; set; }
        private string _pathModulesSite { get; set; }
        private string _pathModulesAdmin { get; set; }
        private string _pathTemplatesSite { get; set; }
        private string _pathTemplatesAdmin { get; set; }
        private string _pathLanguagesSite { get; set; }
        private string _pathLanguagesAdmin { get; set; }
        public string _fileNamePackageInstallZip { get; set; }
        public string _fileNamePackageUpdateZip { get; set; }
        public frmJoomlaPacoteInstalacao()
        {
            _joomlaInstall = new JoomlaInstall();

            InitializeComponent();
        }

        private void FrmJoomlaPacoteInstalacao_Load(object sender, EventArgs e)
        {
            inicializarParametros();

            txtComponente.DataBindings.Add("Text", _joomlaInstall, "Name");
            txtVersao.DataBindings.Add("Text", _joomlaInstall, "Version");
            txtDataCriacao.DataBindings.Add("Text", _joomlaInstall, "CreationDate");
            txtDataBaseServer.DataBindings.Add("Text", _joomlaInstall, "DataBaseServer");
            txtDataBaseName.DataBindings.Add("Text", _joomlaInstall, "DataBaseName");
            txtTableExtension.DataBindings.Add("Text", _joomlaInstall, "DBPrefix");
        }
        private void btnSelecionarProjeto_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.SelectedPath = @"K:\DORIATI_GIT";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFileInstall.Text = fbd.SelectedPath;

                inicializarParametros();
            }
        }
        private void inicializarParametros()
        {
            _projectPath = txtFileInstall.Text;

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(JoomlaInstall));
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(_projectPath, "joomlainstall.xml"));

            _joomlaInstall = (JoomlaInstall)reader.Deserialize(file);

            file.Close();

            _joomlaInstall.ProjectPath = _projectPath;

            _joomlaInstall.LoadParams();

            _pathComponentsSite = Path.Combine(_projectPath, "components");
            _pathComponentsAdmin = Path.Combine(_projectPath, "administrator", "components");

            _pathModulesSite = Path.Combine(_projectPath, "modules");
            _pathModulesAdmin = Path.Combine(_projectPath, "administrator", "modules");

            _pathTemplatesSite = Path.Combine(_projectPath, "templates");
            _pathTemplatesAdmin = Path.Combine(_projectPath, "administrator", "templates");

            _pathLanguagesSite = Path.Combine(_projectPath, "language", "pt-BR");
            _pathLanguagesAdmin = Path.Combine(_projectPath, "administrator", "language", "pt-BR");

            if (_joomlaInstall.Type == "component")
            {
                _pathExtensionSite = Path.Combine(_pathComponentsSite, _joomlaInstall.NameExtension);
                _pathExtensionAdmin = Path.Combine(_pathComponentsAdmin, _joomlaInstall.NameExtension);
            }
            else
            {
                _pathExtensionSite = Path.Combine(_pathModulesSite, _joomlaInstall.NameExtension);
                _pathExtensionAdmin = Path.Combine(_pathModulesAdmin, _joomlaInstall.NameExtension);
            }

            dgvModules.DataSource = _joomlaInstall.Modules;
            dgvMenus.DataSource = _joomlaInstall.Menus;
            dgvTables.DataSource = _joomlaInstall.Tables;

            foreach (var item in _joomlaInstall.Modules)
            {
                txtDebug.AppendText(string.Format("Tables: Name: {1} - Upgrade: {2} - Location: {3}{0}", Environment.NewLine, item.Name, item.Upgrade, item.Location));
            }

            foreach (var item in _joomlaInstall.Tables)
            {
                txtDebug.AppendText(string.Format("Tables: Name: {1} - WithData: {2}{0}", Environment.NewLine, item.Name, item.WithData));
            }

            foreach (var item in _joomlaInstall.Menus)
            {
                txtDebug.AppendText(string.Format("Menus: Title: {1} - View: {2}{0}", Environment.NewLine, item.Title, item.View));
            }
        }

        private void BtnDeploy_Click(object sender, EventArgs e)
        {
            //var writer = new System.Xml.Serialization.XmlSerializer(typeof(JoomlaReleaseNotes));
            //var wfile = new System.IO.StreamWriter(@"E:\temp\ReleaseNotesXmlSerializer.xml");

            //JoomlaReleaseNotes joomlaReleaseNotes = new JoomlaReleaseNotes();

            //joomlaReleaseNotes.FolderPath = @"D:\Projetos\Joomla\DGA\Release Notes";

            //BindingList<JNote> notes = new BindingList<JNote>();

            //notes.Add(new JNote()
            //{
            //    Description = "Filtro de Pesquisa na lista de arquivos",
            //    Files = new BindingList<string>() {"001.png","002.png"} 
            //});

            //joomlaReleaseNotes.ReleaseNotes.Add(new JReleaseNote()
            //{
            //    Version = "1.0.17",
            //    Notes = notes
            //});

            //writer.Serialize(wfile, joomlaReleaseNotes);

            //wfile.Close();

            Task.Factory.StartNew(() =>
            {
                CreatePackgeJoomlaInstall();
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }
        private void CreatePackgeJoomlaInstall()
        {
            try
            {
                pbgProgressoPrincipal.Minimum = 0;
                pbgProgressoPrincipal.Maximum = 17;
                pbgProgressoPrincipal.Value = 0;

                string pathFolderRoot = @"K:\temp";

                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                MySqlConnectionClass mySqlConnection = new MySqlConnectionClass();

                mySqlConnection.ServerName = _joomlaInstall.DataBaseServer;
                mySqlConnection.DataBaseName = _joomlaInstall.DataBaseName;
                mySqlConnection.UserName = "root";
                mySqlConnection.Password = "";

                mySqlConnection.Conect();

                string folderDestinyRoot = Path.Combine(pathFolderRoot, _joomlaInstall.Name);
                string folderDestinyVersion = Path.Combine(pathFolderRoot, _joomlaInstall.Name, _joomlaInstall.Version);

                _fileNamePackageInstallZip = string.Format("pkg_{0}_v{1}_install.zip", _joomlaInstall.Name, _joomlaInstall.Version);
                _fileNamePackageUpdateZip = string.Format("pkg_{0}_v{1}_para_v{2}_update.zip", _joomlaInstall.Name, _joomlaInstall.VersionOld, _joomlaInstall.Version);

                //cria pastas
                if (IOClass.DirectoryExists(folderDestinyRoot))
                {
                    IOClass.DeleteDirectorie(folderDestinyRoot);
                }

                pbgProgressoPrincipal.Value = 1;

                if (chkCreateInstallPackage.Checked)
                {
                    CreateJoomlaExtensionInstall(mySqlConnection, pathFolderRoot, folderDestinyVersion);
                }

                if (chkCreateUpdatePackage.Checked)
                {
                    CreateJoomlaExtensionUpdate(mySqlConnection, pathFolderRoot, folderDestinyVersion);
                }

                pbgProgresso.Minimum = 0;
                pbgProgresso.Maximum = 1;
                pbgProgresso.Value = 1;

                Funcoes.ShowCursor(this, CursorType.Default);
                MessageBox.Show("Deploy executado com sucesso!");
            }
            catch (Exception exc)
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                Funcoes.LogError(this.Name, exc, true);
            }
        }
        private void CreateJoomlaExtensionInstall(MySqlConnectionClass mySqlConnection, string pathFolderRoot, string folderDestinyVersion)
        {
            string method = "install";
            string folderDestinyInstall = Path.Combine(folderDestinyVersion, "Instalação");
            string folderDestinyInstallPackages = Path.Combine(folderDestinyInstall, "packages");
            string folderDestinyInstallExtension = Path.Combine(folderDestinyInstallPackages, _joomlaInstall.NameExtension);
            string folderDestinyInstallExtensionSite = Path.Combine(folderDestinyInstallExtension, "site");
            string folderDestinyInstallExtensionAdmin = Path.Combine(folderDestinyInstallExtension, "admin");

            IOClass.CreateDirectorie(folderDestinyInstallExtension);

            #region Cria arquivo pkg.xml
            string xmlPackageJoomla = GerarXMLPackageJoomla(method);

            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstall, "pkg_" + _joomlaInstall.Name + ".xml"), xmlPackageJoomla, true);
            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstall, "index.html"), Templates.Templates.index, true);
            #endregion

            pbgProgressoPrincipal.Value = 2;

            #region Copia Arquivos Site\Admin

            IOClass.DirectorieCopy(_pathExtensionSite, folderDestinyInstallExtensionSite, true, new List<string>() { ".vscode" }, new List<string>(), ref pbgProgresso, ref lblStatusProgresso);
            IOClass.DirectorieCopy(_pathExtensionAdmin, folderDestinyInstallExtensionAdmin, true, new List<string>() { ".vscode" }, new List<string>(), ref pbgProgresso, ref lblStatusProgresso);

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Languages.Count;
            pbgProgresso.Value = 0;

            foreach (var language in _joomlaInstall.Languages)
            {
                pbgProgresso.Value += 1;

                if (language.Location == "site")
                {
                    IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyInstallExtensionSite, "language", "pt-BR", language.Language));
                }
                else
                {
                    IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyInstallExtensionAdmin, "language", "pt-BR", language.Language));
                }
            }
            #endregion

            pbgProgressoPrincipal.Value = 3;

            #region Cria Arquivos MySql Install

            string tablesInstallTemplate = "";
            var lastTableInstall = _joomlaInstall.Tables.Last();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Tables.Count;
            pbgProgresso.Value = 0;

            foreach (var table in _joomlaInstall.Tables)
            {
                pbgProgresso.Value += 1;

                string query = "SHOW CREATE TABLE " + _joomlaInstall.DBPrefix + table.Name;

                DataTable dt = mySqlConnection.Query(query);

                string textQueryCreate = dt.Rows[0][1].ToString();

                //textQueryCreate = textQueryCreate.Replace("CREATE TABLE ", "CREATE TABLE IF NOT EXISTS ");
                textQueryCreate = textQueryCreate.Replace("CHARSET=utf8", "CHARSET=utf8;");
                textQueryCreate = textQueryCreate.Replace("CHARSET=latin1", "CHARSET=utf8;");
                textQueryCreate = textQueryCreate.Replace("COLLATE=utf8_unicode_ci", "");

                tablesInstallTemplate += textQueryCreate + Environment.NewLine;

                if (lastTableInstall != table)
                {
                    tablesInstallTemplate += Environment.NewLine;
                }
            }

            pbgProgressoPrincipal.Value = 4;

            using (MySqlConnection conn = new MySqlConnection(mySqlConnection.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();

                        mb.ExportInfo.RecordDumpTime = false;
                        mb.ExportInfo.AddCreateDatabase = false;
                        mb.ExportInfo.ExportTableStructure = false;
                        mb.ExportInfo.ExportRows = true;
                        mb.ExportInfo.ResetAutoIncrement = false;
                        mb.ExportInfo.SetDocumentHeaders(new List<string>());
                        mb.ExportInfo.SetDocumentFooters(new List<string>());
                        mb.ExportInfo.TablesToBeExportedList = _joomlaInstall.Tables.Where(x => x.WithData == true).Select(p => _joomlaInstall.DBPrefix + p.Name).ToList();
                        mb.ExportToFile(Path.Combine(pathFolderRoot, "install.mysql.utf8.sql"));

                        conn.Close();
                    }
                }
            }

            tablesInstallTemplate += IOClass.ReadFileToEnd(Path.Combine(pathFolderRoot, "install.mysql.utf8.sql"));
            tablesInstallTemplate = tablesInstallTemplate.Replace(_joomlaInstall.DBPrefix, "#_");
            tablesInstallTemplate = tablesInstallTemplate.Replace("ROW_FORMAT=COMPACT", "");

            IOClass.CreateDirectorie(Path.Combine(folderDestinyInstallExtensionAdmin, "sql"));
            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstallExtensionAdmin, "sql", "install.mysql.utf8.sql"), tablesInstallTemplate, true);
            #endregion

            pbgProgressoPrincipal.Value = 5;

            #region Cria Arquivos MySql DROP

            string uninstall_mysql_utf8 = Templates.Templates.uninstall_mysql_utf8;
            string tablesTemplate = "";
            var lastTable = _joomlaInstall.Tables.Last();

            foreach (var table in _joomlaInstall.Tables)
            {
                tablesTemplate += "`#_" + table.Name + "`";

                if (lastTable == table)
                {
                    tablesTemplate += ";";
                }
                else
                {
                    tablesTemplate += "," + Environment.NewLine;
                }
            }

            uninstall_mysql_utf8 = uninstall_mysql_utf8.Replace("{Tables}", tablesTemplate);

            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstallExtensionAdmin, "sql", "uninstall.mysql.utf8.sql"), uninstall_mysql_utf8, true);
            #endregion

            pbgProgressoPrincipal.Value = 6;

            #region Cria arquivo .xml
            string xmlJoomla = GerarXMLJoomla(method, Templates.Templates.JoomlaTemplateXMLScripts, folderDestinyInstallExtensionSite, folderDestinyInstallExtensionAdmin);

            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstallExtension, _joomlaInstall.Name + ".xml"), xmlJoomla, true);
            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstallExtension, "index.html"), Templates.Templates.index, true);
            #endregion

            pbgProgressoPrincipal.Value = 7;

            #region Cria arquivo script.php
            string scriptJoomla = GerarScriptJoomla();

            IOClass.AppendTextInFile(Path.Combine(folderDestinyInstallExtension, "script.php"), scriptJoomla, true);
            #endregion

            pbgProgressoPrincipal.Value = 8;

            #region Copia e Compacta Módulos em ZIP

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Modules.Count;
            pbgProgresso.Value = 0;

            foreach (var module in _joomlaInstall.Modules)
            {
                pbgProgresso.Value += 1;

                string pathModule = module.Location == "site" ? _pathModulesSite : _pathModulesAdmin;

                //copia pasta de módulo para pasta package
                IOClass.DirectorieCopy(Path.Combine(pathModule, module.Name), Path.Combine(folderDestinyInstallPackages, module.Name), true);

                foreach (var language in module.Languages)
                {
                    if (language.Location == "site")
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyInstallPackages, module.Name, "language", "pt-BR", language.Language));
                    }
                    else
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyInstallPackages, module.Name, "language", "pt-BR", language.Language));
                    }
                }

                //atualiza XML do módulo
                updateModule(Path.Combine(folderDestinyInstallPackages, module.Name, string.Format("{0}.xml", module.Name)), method, _joomlaInstall.Version);
            }

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Modules.Count;
            pbgProgresso.Value = 0;

            foreach (var module in _joomlaInstall.Modules)
            {
                pbgProgresso.Value += 1;

                //compacta módulo em Zip
                ZipClass.CompactFolder(Path.Combine(folderDestinyInstallPackages, module.Name), Path.Combine(folderDestinyInstallPackages, $"{module.Name}.zip"));

                //apaga pasta de módulo
                IOClass.DeleteDirectorie(Path.Combine(folderDestinyInstallPackages, module.Name));
            }
            #endregion

            #region Copia e Compacta Templates em ZIP

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Templates.Count;
            pbgProgresso.Value = 0;

            foreach (var template in _joomlaInstall.Templates)
            {
                pbgProgresso.Value += 1;

                string pathTemplate = template.Location == "site" ? _pathTemplatesSite : _pathTemplatesAdmin;

                //copia pasta de template para pasta package
                IOClass.DirectorieCopy(Path.Combine(pathTemplate, template.Name), Path.Combine(folderDestinyInstallPackages, $"tpl_{template.Name}"), true);

                foreach (var language in template.Languages)
                {
                    if (language.Location == "site")
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyInstallPackages, $"tpl_{template.Name}", "language", "pt-BR", language.Language));
                    }
                    else
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyInstallPackages, $"tpl_{template.Name}", "language", "pt-BR", language.Language));
                    }
                }

                //atualiza XML do template
                updateTemplate(Path.Combine(folderDestinyInstallPackages, $"tpl_{template.Name}", "templateDetails.xml"), method, _joomlaInstall.Version);
            }

            #region Convert arquivos para UTF-8
            ConvertFolderToUTF8(folderDestinyInstallExtension);
            #endregion

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Templates.Count;
            pbgProgresso.Value = 0;

            foreach (var template in _joomlaInstall.Templates)
            {
                pbgProgresso.Value += 1;

                //compacta template em Zip
                ZipClass.CompactFolder(Path.Combine(folderDestinyInstallPackages, "tpl_" + template.Name), Path.Combine(folderDestinyInstallPackages, string.Format("tpl_{0}.zip", template.Name)));

                //apaga pasta de template
                IOClass.DeleteDirectorie(Path.Combine(folderDestinyInstallPackages, "tpl_" + template.Name));
            }
            #endregion

            #region Cria Package Zip

            ZipClass.CompactFolder(folderDestinyInstallExtension, Path.Combine(folderDestinyInstallPackages, string.Format("{0}.zip", _joomlaInstall.NameExtension)));
            IOClass.DeleteDirectorie(folderDestinyInstallExtension);

            string pathFilePackageInstallZip = Path.Combine(folderDestinyVersion, _fileNamePackageInstallZip);

            //Cria Package Zip
            ZipClass.CompactFolder(folderDestinyInstall, pathFilePackageInstallZip, false);
            #endregion

            pbgProgressoPrincipal.Value = 9;

            if (chkPublishInstallPackage.Checked)
            {
                #region Publish File FTP
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_joomlaInstall.FTPUsername, _joomlaInstall.FTPPassword);

                    client.UploadFile($"{_ftpRootDoriaTI}/arquivos/{_joomlaInstall.Name}/{_fileNamePackageInstallZip}", WebRequestMethods.Ftp.UploadFile, pathFilePackageInstallZip);
                }
                #endregion
            }

            pbgProgressoPrincipal.Value = 10;
        }
        private void CreateJoomlaExtensionUpdate(MySqlConnectionClass mySqlConnection, string pathFolderRoot, string folderDestinyVersion)
        {
            string method = "upgrade";
            string folderDestinyUpdate = Path.Combine(folderDestinyVersion, "Atualização");
            string folderDestinyUpdatePackages = Path.Combine(folderDestinyUpdate, "packages");
            string folderDestinyUpdateExtension = Path.Combine(folderDestinyUpdatePackages, _joomlaInstall.NameExtension);
            string folderDestinyUpdateExtensionSite = Path.Combine(folderDestinyUpdateExtension, "site");
            string folderDestinyUpdateExtensionAdmin = Path.Combine(folderDestinyUpdateExtension, "admin");

            var modules = _joomlaInstall.Modules.Where(x => x.Upgrade == true).ToList();
            var templates = _joomlaInstall.Templates.Where(x => x.Upgrade == true).ToList();

            IOClass.CreateDirectorie(folderDestinyUpdateExtension);

            #region Cria arquivo pkg.xml
            string xmlPackageJoomla = GerarXMLPackageJoomla(method);

            IOClass.AppendTextInFile(Path.Combine(folderDestinyUpdate, "pkg_" + _joomlaInstall.Name + ".xml"), xmlPackageJoomla, true);
            IOClass.AppendTextInFile(Path.Combine(folderDestinyUpdate, "index.html"), Templates.Templates.index, true);
            #endregion

            pbgProgressoPrincipal.Value = 11;

            #region Copia Arquivos Site\Admin

            IOClass.DirectorieCopy(_pathExtensionSite, folderDestinyUpdateExtensionSite, true, new List<string>() { ".vscode" }, new List<string>(), ref pbgProgresso, ref lblStatusProgresso);
            IOClass.DirectorieCopy(_pathExtensionAdmin, folderDestinyUpdateExtensionAdmin, true, new List<string>() { ".vscode" }, new List<string>(), ref pbgProgresso, ref lblStatusProgresso);

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = _joomlaInstall.Languages.Count;
            pbgProgresso.Value = 0;

            foreach (var language in _joomlaInstall.Languages)
            {
                pbgProgresso.Value += 1;

                if (language.Location == "site")
                {
                    IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyUpdateExtensionSite, "language", "pt-BR", language.Language));
                }
                else
                {
                    IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyUpdateExtensionAdmin, "language", "pt-BR", language.Language));
                }
            }
            #endregion

            pbgProgressoPrincipal.Value = 12;

            #region Cria arquivo .xml
            string xmlJoomla = GerarXMLJoomla(method, string.Empty, folderDestinyUpdateExtensionSite, folderDestinyUpdateExtensionAdmin);

            IOClass.AppendTextInFile(Path.Combine(folderDestinyUpdateExtension, _joomlaInstall.Name + ".xml"), xmlJoomla, true);
            IOClass.AppendTextInFile(Path.Combine(folderDestinyUpdateExtension, "index.html"), Templates.Templates.index, true);
            #endregion

            pbgProgressoPrincipal.Value = 13;

            #region Copia arquivo script.php
            IOClass.CopyTo(Path.Combine(_projectPath, "script.php"), Path.Combine(folderDestinyUpdateExtension, "script.php"));
            #endregion

            pbgProgressoPrincipal.Value = 14;

            #region Copia e Compacta Módulos em ZIP

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = modules.Count;
            pbgProgresso.Value = 0;

            foreach (var module in modules)
            {
                pbgProgresso.Value += 1;

                string pathModule = module.Location == "site" ? _pathModulesSite : _pathModulesAdmin;

                //copia pasta de módulo para pasta package
                IOClass.DirectorieCopy(Path.Combine(pathModule, module.Name), Path.Combine(folderDestinyUpdatePackages, module.Name), true);

                foreach (var language in module.Languages)
                {
                    if (language.Location == "site")
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyUpdatePackages, module.Name, "language", "pt-BR", language.Language));
                    }
                    else
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyUpdatePackages, module.Name, "language", "pt-BR", language.Language));
                    }
                }

                //atualiza XML do módulo
                updateModule(Path.Combine(folderDestinyUpdatePackages, module.Name, string.Format("{0}.xml", module.Name)), method, _joomlaInstall.Version);
            }

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = modules.Count;
            pbgProgresso.Value = 0;

            foreach (var module in modules)
            {
                pbgProgresso.Value += 1;

                //compacta módulo em Zip
                ZipClass.CompactFolder(Path.Combine(folderDestinyUpdatePackages, module.Name), Path.Combine(folderDestinyUpdatePackages, string.Format("{0}.zip", module.Name)));

                //apaga pasta de módulo
                IOClass.DeleteDirectorie(Path.Combine(folderDestinyUpdatePackages, module.Name));
            }

            #endregion

            pbgProgressoPrincipal.Value = 15;

            #region Copia e Compacta Templates em ZIP

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = templates.Count;
            pbgProgresso.Value = 0;

            foreach (var template in templates)
            {
                pbgProgresso.Value += 1;

                string pathTemplate = template.Location == "site" ? _pathTemplatesSite : _pathTemplatesAdmin;

                //copia pasta de template para pasta package
                IOClass.DirectorieCopy(Path.Combine(pathTemplate, template.Name), Path.Combine(folderDestinyUpdatePackages, $"tpl_{template.Name}"), true);

                foreach (var language in template.Languages)
                {
                    if (language.Location == "site")
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesSite, language.Language), Path.Combine(folderDestinyUpdatePackages, $"tpl_{template.Name}", "language", "pt-BR", language.Language));
                    }
                    else
                    {
                        IOClass.CopyTo(Path.Combine(_pathLanguagesAdmin, language.Language), Path.Combine(folderDestinyUpdatePackages, $"tpl_{template.Name}", "language", "pt-BR", language.Language));
                    }
                }

                //atualiza XML do template
                updateTemplate(Path.Combine(folderDestinyUpdatePackages, $"tpl_{template.Name}", "templateDetails.xml"), method, _joomlaInstall.Version);
            }

            #region Convert arquivos para UTF-8
            ConvertFolderToUTF8(folderDestinyUpdateExtension);
            #endregion

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = templates.Count;
            pbgProgresso.Value = 0;

            foreach (var template in templates)
            {
                pbgProgresso.Value += 1;

                //compacta template em Zip
                ZipClass.CompactFolder(Path.Combine(folderDestinyUpdatePackages, "tpl_" + template.Name), Path.Combine(folderDestinyUpdatePackages, string.Format("tpl_{0}.zip", template.Name)));

                //apaga pasta de template
                IOClass.DeleteDirectorie(Path.Combine(folderDestinyUpdatePackages, "tpl_" + template.Name));
            }
            #endregion

            #region Compacta em ZIP
            ZipClass.CompactFolder(folderDestinyUpdateExtension, Path.Combine(folderDestinyUpdatePackages, string.Format("{0}.zip", _joomlaInstall.NameExtension)));
            IOClass.DeleteDirectorie(folderDestinyUpdateExtension);

            string pathFilePackageInstallZip = Path.Combine(folderDestinyVersion, _fileNamePackageUpdateZip);

            ZipClass.CompactFolder(folderDestinyUpdate, pathFilePackageInstallZip, false);
            #endregion

            pbgProgressoPrincipal.Value = 16;

            if (chkPublishUpdatePackage.Checked)
            {
                #region Publish File FTP
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_joomlaInstall.FTPUsername, _joomlaInstall.FTPPassword);

                    client.UploadFile($"{_ftpRootDoriaTI}/arquivos/{_joomlaInstall.Name}/{_fileNamePackageUpdateZip}", WebRequestMethods.Ftp.UploadFile, pathFilePackageInstallZip);
                }
                #endregion
            }

            pbgProgressoPrincipal.Value = 17;
        }
        private void GravaInformacoesNoBancoDoriaTI()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(JoomlaReleaseNotes));
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(_projectPath, "releasenotes.xml"));

            var joomlaReleaseNotes = (JoomlaReleaseNotes)reader.Deserialize(file);

            MySqlConnectionClass mySqlConnection = new MySqlConnectionClass();

            mySqlConnection.ServerName = joomlaReleaseNotes.DataBaseServer;
            mySqlConnection.DataBaseName = joomlaReleaseNotes.DataBaseName;
            mySqlConnection.UserName = joomlaReleaseNotes.DataBaseUsername;
            mySqlConnection.Password = joomlaReleaseNotes.DataBasePassword;

            mySqlConnection.Conect();

            string folderPath = joomlaReleaseNotes.FolderPath;
            string id_pro = joomlaReleaseNotes.CodProduto.ToString();

            var fileNamePackageInstallZip = string.Format("pkg_{0}_v{1}_install.zip", _joomlaInstall.Name, _joomlaInstall.Version);
            var fileNamePackageUpdateZip = string.Format("pkg_{0}_v{1}_para_v{2}_update.zip", _joomlaInstall.Name, _joomlaInstall.VersionOld, _joomlaInstall.Version);

            #region Grava Versão da Extensão

            string queryInsertProdutoVersao = string.Format("INSERT INTO `ha54q_joohostmanager_produtos_versoes_prv` (`descricao_prv`, `id_pro`, `data_prv`) VALUES ('v{0}', {1}, NOW())", _joomlaInstall.Version, id_pro);

            string id_prv = mySqlConnection.QueryCommandInsert(queryInsertProdutoVersao).ToString();

            #endregion

            if (chkCreateInstallPackage.Checked)
            {
                #region Cadastra arquivo de Instalação

                string file_key_pva_install = PasswordGenerator.Generate(length: 20, allowed: Sets.Alphanumerics);
                string queryInsertVersaoArquivoInstalacao = string.Format("INSERT INTO `ha54q_joohostmanager_produtos_versoes_arquivos_pva` (`id_prv`, `descricao_pva`, `link_video_instrucoes_pva`, `file_name_pva`, `file_key_pva`, `id_pqt`) VALUES" +
                                                                          "({0}, 'Instalador v{1}.', '', '{2}', '{3}', 1)", id_prv, _joomlaInstall.Version, fileNamePackageInstallZip, file_key_pva_install);

                mySqlConnection.QueryCommandInsert(queryInsertVersaoArquivoInstalacao).ToString();
                #endregion
            }

            if (chkCreateUpdatePackage.Checked)
            {
                #region Cadastra arquivo de Atualização

                string file_key_pva_update = PasswordGenerator.Generate(length: 20, allowed: Sets.Alphanumerics);
                string queryInsertVersaoArquivoAtualizacao = string.Format("INSERT INTO `ha54q_joohostmanager_produtos_versoes_arquivos_pva` (`id_prv`, `descricao_pva`, `link_video_instrucoes_pva`, `file_name_pva`, `file_key_pva`, `id_pqt`) VALUES" +
                                                                          "({0}, ' da versão v{1} para v{2}.', '', '{3}', '{4}', 2)", id_prv, _joomlaInstall.VersionOld, _joomlaInstall.Version, fileNamePackageUpdateZip, file_key_pva_update);

                mySqlConnection.QueryCommandInsert(queryInsertVersaoArquivoAtualizacao).ToString();
                #endregion
            }

            //if (chkCreateUpdatePackage.Checked)
            //{
            //    #region Cadastra arquivo Quickstart

            //    string file_key_pva_update = PasswordGenerator.Generate(length: 20, allowed: Sets.Alphanumerics);
            //    string queryInsertVersaoArquivoAtualizacao = string.Format("INSERT INTO `ha54q_joohostmanager_produtos_versoes_arquivos_pva` (`id_prv`, `descricao_pva`, `link_video_instrucoes_pva`, `file_name_pva`, `file_key_pva`, `id_pqt`) VALUES" +
            //                                                              "({0}, ' da versão v{1} para v{2}.', '', '{3}', '{4}', 2)", id_prv, _joomlaInstall.VersionOld, _joomlaInstall.Version, fileNamePackageUpdateZip, file_key_pva_update);

            //    mySqlConnection.QueryCommandInsert(queryInsertVersaoArquivoAtualizacao).ToString();
            //    #endregion
            //}

            var releaseNote = joomlaReleaseNotes.ReleaseNotes.Single(x => x.Version == _joomlaInstall.Version);

            #region Create Folder FTP
            //try
            //{
            //    string folderWeb = $"{_ftpRootDoriaTI}/images/doriati/produtos/{_joomlaInstall.Name}/{_joomlaInstall.Version}";

            //    if (WebRequestMethods.Ftp.ListDirectoryDetails.Contains(folderWeb))
            //    {
            //        throw new Exception($"Pasta {folderWeb} já existe!");
            //    }
            //    else
            //    {
            //        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(folderWeb);

            //        request.Credentials = new NetworkCredential(_joomlaInstall.FTPUsername, _joomlaInstall.FTPPassword);
            //        request.Method = WebRequestMethods.Ftp.MakeDirectory;
            //        request.UseBinary = true;
            //        request.KeepAlive = false;

            //        FtpWebResponse ftpResp = (FtpWebResponse)request.GetResponse();

            //        txtDebug.AppendText(ftpResp.StatusDescription.ToString());

            //        ftpResp.Close();
            //    }
            //}
            //catch (WebException webexc)
            //{
            //    txtDebug.AppendText(webexc.Message);
            //    throw new Exception(webexc.Message);
            //}
            //catch (Exception exc)
            //{
            //    txtDebug.AppendText(exc.Message);
            //    throw (exc);
            //}

            #endregion

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = releaseNote.Notes.Count;
            pbgProgresso.Value = 0;

            foreach (var note in releaseNote.Notes)
            {
                string description = note.Description;

                if (note.SugestaoCliente)
                {
                    description += " <strong>Sugerido por cliente</strong>";
                }

                string id_prt = note.Tipo.ToLower() == "dev" ? "1" : "2";

                foreach (var fileName in note.Files)
                {
                    string linkFile = string.Format("https://www.doriati.com.br/images/doriati/produtos/{0}/{1}/{2}", _joomlaInstall.Name, _joomlaInstall.Version, fileName);

                    description += string.Format("<a class=\"jcepopup\" title=\"Detalhes\" type=\"image/png\" href=\"{0}\" target=\"_blank\" data-mediabox=\"title[Detalhe::Detalhe]\">Ver detalhes</a>", linkFile);
                }

                string queryInsertReleaseNote = string.Format("INSERT INTO `ha54q_joohostmanager_produtos_versoes_atualizacoes_pra` (`id_prv`, `data_pra`, `id_prt`, `descricao_pra`) VALUES" +
                                                          "({0}, NOW(), {1}, '{2}')", id_prv, id_prt, description);

                mySqlConnection.QueryCommandInsert(queryInsertReleaseNote);

                //#region Publish File FTP
                //using (WebClient client = new WebClient())
                //{
                //    client.Credentials = new NetworkCredential(_joomlaInstall.FTPUsername, _joomlaInstall.FTPPassword);

                //    foreach (var fileName in note.Files)
                //    {
                //        string pathFile = Path.Combine(folderPath, _joomlaInstall.Version, fileName);

                //        client.UploadFile($"{_ftpRootDoriaTI}/images/doriati/produtos/{_joomlaInstall.Name}/{ _joomlaInstall.Version}/{fileName}", WebRequestMethods.Ftp.UploadFile, pathFile);
                //    }
                //}
                //#endregion

                pbgProgresso.Value += 1;
            }
        }
        private void updateModule(string pathFile, string method, string version)
        {
            string textFile = IOClass.ReadFileToEnd(pathFile);

            textFile = textFile.Replace("{Method}", method);
            textFile = textFile.Replace("{Version}", version);

            IOClass.AppendTextInFile(pathFile, textFile, true);
        }
        private void updateTemplate(string pathFile, string method, string version)
        {
            string textFile = IOClass.ReadFileToEnd(pathFile);

            textFile = textFile.Replace("{Method}", method);
            textFile = textFile.Replace("{Version}", version);

            IOClass.AppendTextInFile(pathFile, textFile, true);
        }
        private string GerarXMLPackageJoomla(string method)
        {
            Dictionary<string, string> paramns = new Dictionary<string, string>();
            string xmlJoomla = Templates.Templates.JoomlaTemplateXMLPackageNew;
            bool upgrade = method == "upgrade" ? true : false;

            paramns.Add("Method", method);
            paramns.Add("Name", _joomlaInstall.Name);
            paramns.Add("NameExtension", _joomlaInstall.NameExtension);
            paramns.Add("Packagename", _joomlaInstall.Name);
            paramns.Add("CreationDate", _joomlaInstall.CreationDate);
            paramns.Add("CopyrightAno", DateTime.Now.Year.ToString());
            paramns.Add("Version", _joomlaInstall.Version);
            paramns.Add("PackageDescription", _joomlaInstall.PackageDescription);

            #region Modules
            string modules = "";

            if (_joomlaInstall.Modules.Any())
            {
                var modulesList = _joomlaInstall.Modules.ToList();

                if (upgrade)
                {
                    modulesList = _joomlaInstall.Modules.Where(x => x.Upgrade == true).ToList();
                }

                if (modulesList.Any())
                {
                    var lastModule = modulesList.Last();

                    foreach (var module in modulesList)
                    {
                        modules += "\t\t<file type=\"module\" id=\"" + module.Name + "\" client=\"" + module.Location + "\">" + module.Name + ".zip</file>";

                        if (lastModule != module)
                        {
                            modules += Environment.NewLine;
                        }
                    }
                }
            }

            paramns.Add("Modules", modules);
            #endregion

            #region Templates
            string templates = "";

            if (_joomlaInstall.Templates.Any())
            {
                var templatesList = _joomlaInstall.Templates.ToList();

                if (upgrade)
                {
                    templatesList = _joomlaInstall.Templates.Where(x => x.Upgrade == true).ToList();
                }

                if (templatesList.Any())
                {
                    var lastTemplate = templatesList.Last();

                    foreach (var template in templatesList)
                    {
                        templates += "\t\t<file type=\"template\" id=\"" + template.Name + "\" client=\"" + template.Location + "\">tpl_" + template.Name + ".zip</file>";

                        if (lastTemplate != template)
                        {
                            templates += Environment.NewLine;
                        }
                    }
                }
            }

            paramns.Add("Templates", templates);
            #endregion

            foreach (var paramn in paramns)
            {
                xmlJoomla = xmlJoomla.Replace("{" + paramn.Key + "}", paramn.Value);
            }

            return xmlJoomla;
        }
        private string GerarXMLJoomla(string method, string scripts, string pathExtensionSite, string pathExtensionAdmin)
        {
            Dictionary<string, string> paramns = new Dictionary<string, string>();
            string xmlJoomla = Templates.Templates.JoomlaTemplateXML;

            paramns.Add("Method", method);
            paramns.Add("Scripts", scripts);
            paramns.Add("Type", _joomlaInstall.Type);
            paramns.Add("NameExtension", _joomlaInstall.NameExtension);
            paramns.Add("NameExtensionUpperCase", _joomlaInstall.NameExtension.ToUpper());
            paramns.Add("CreationDate", _joomlaInstall.CreationDate);
            paramns.Add("CopyrightAno", DateTime.Now.Year.ToString());
            paramns.Add("Version", _joomlaInstall.Version);

            #region Folder/Files Site
            string FilesFolderSite = "";

            var foldersSite = Directory.EnumerateDirectories(pathExtensionSite);

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = foldersSite.Count();
            pbgProgresso.Value = 0;

            foreach (var folder in foldersSite)
            {
                DirectoryInfo directoInfo = new DirectoryInfo(folder);

                FilesFolderSite += "\t<folder>" + directoInfo.Name + "</folder>" + Environment.NewLine;

                pbgProgresso.Value += 1;
            }

            var filesSite = Directory.EnumerateFiles(pathExtensionSite);

            var lastFileSite = filesSite.Last();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = filesSite.Count();
            pbgProgresso.Value = 0;

            foreach (var file in filesSite)
            {
                FilesFolderSite += "\t<filename>" + Path.GetFileName(file) + "</filename>";

                if (lastFileSite != file)
                {
                    FilesFolderSite += Environment.NewLine;
                }

                pbgProgresso.Value += 1;
            }


            #endregion

            #region Folder/Files Admin
            string FilesFolderAdmin = "";

            var foldersAdmin = Directory.EnumerateDirectories(pathExtensionAdmin);

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = foldersAdmin.Count();
            pbgProgresso.Value = 0;

            foreach (var folder in foldersAdmin)
            {
                DirectoryInfo directoInfo = new DirectoryInfo(folder);

                FilesFolderAdmin += "\t\t<folder>" + directoInfo.Name + "</folder>" + Environment.NewLine;

                pbgProgresso.Value += 1;
            }

            var filesAdmin = Directory.EnumerateFiles(pathExtensionAdmin);

            var lastFileAdmin = filesAdmin.Last();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = filesAdmin.Count();
            pbgProgresso.Value = 0;

            foreach (var file in filesAdmin)
            {
                FilesFolderAdmin += "\t\t<filename>" + Path.GetFileName(file) + "</filename>";

                if (lastFileAdmin != file)
                {
                    FilesFolderAdmin += Environment.NewLine;
                }

                pbgProgresso.Value += 1;
            }
            #endregion

            #region Language Site

            string LanguagesSite = "";
            var languagesSite = _joomlaInstall.Languages.Where(x => x.Location == "site");
            var lastLanguagesSite = languagesSite.Last();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = languagesSite.Count();
            pbgProgresso.Value = 0;

            foreach (var language in languagesSite)
            {
                LanguagesSite += "\t<language tag=\"pt-BR\">" + language.Language + "</language>";

                if (lastLanguagesSite != language)
                {
                    LanguagesSite += Environment.NewLine;
                }

                pbgProgresso.Value += 1;
            }

            string LanguagesAdmin = "";
            var languagesAdmin = _joomlaInstall.Languages.Where(x => x.Location == "admin");
            var lastLanguagesAdmin = languagesAdmin.Last();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = languagesAdmin.Count();
            pbgProgresso.Value = 0;

            foreach (var language in languagesAdmin)
            {
                LanguagesAdmin += "\t\t<language tag=\"pt-BR\">" + language.Language + "</language>";

                if (lastLanguagesAdmin != language)
                {
                    LanguagesAdmin += Environment.NewLine;
                }

                pbgProgresso.Value += 1;
            }

            #endregion

            #region Menus

            var jmenu = _joomlaInstall.Menus.Single(x => x.Type == "menu");

            var menu = string.Format("<menu img=\"{0}\">{1}</menu>", jmenu.Image, jmenu.Title);
            string subMenus = "";

            var jmenus = _joomlaInstall.Menus.Where(x => x.Type == "submenu");

            if (jmenus.Any())
            {
                var lastJMenus = jmenus.Last();

                pbgProgresso.Minimum = 0;
                pbgProgresso.Maximum = jmenus.Count();
                pbgProgresso.Value = 0;

                foreach (var submenu in jmenus)
                {
                    subMenus += string.Format("\t\t<menu img=\"{0}\" view=\"{1}\">{2}</menu>", submenu.Image, submenu.View.Replace("&", "&amp;"), submenu.Title);

                    if (lastJMenus != submenu)
                    {
                        subMenus += Environment.NewLine;
                    }

                    pbgProgresso.Value += 1;
                }
            }
            #endregion

            paramns.Add("FilesFolderSite", FilesFolderSite);
            paramns.Add("FilesFolderAdmin", FilesFolderAdmin);
            paramns.Add("LanguagesSite", LanguagesSite);
            paramns.Add("LanguagesAdmin", LanguagesAdmin);
            paramns.Add("Menu", menu);
            paramns.Add("SubMenus", subMenus);

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = paramns.Count();
            pbgProgresso.Value = 0;

            foreach (var paramn in paramns)
            {
                xmlJoomla = xmlJoomla.Replace("{" + paramn.Key + "}", paramn.Value);

                pbgProgresso.Value += 1;
            }

            return xmlJoomla;
        }
        private string GerarScriptJoomla()
        {
            Dictionary<string, string> paramns = new Dictionary<string, string>();
            string scriptJoomla = Templates.Templates.JoomlaScript;

            paramns.Add("Name", _joomlaInstall.Name);
            paramns.Add("NameExtension", _joomlaInstall.NameExtension);
            paramns.Add("CreationDate", _joomlaInstall.CreationDate);
            paramns.Add("CopyrightAno", DateTime.Now.Year.ToString());

            foreach (var paramn in paramns)
            {
                scriptJoomla = scriptJoomla.Replace("{" + paramn.Key + "}", paramn.Value);
            }

            return scriptJoomla;
        }
        private void ConvertFolderToUTF8(string folder)
        {
            File.SetAttributes(folder, FileAttributes.Normal);

            string supportedExtensions = "*.php;*.js;*.html;*.sql";

            var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())).ToList();

            var utf8WithoutBOM = new System.Text.UTF8Encoding(false, true);

            int total = files.Count();

            pbgProgresso.Minimum = 0;
            pbgProgresso.Maximum = total;
            pbgProgresso.Value = 0;

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);

                var content = File.ReadAllLines(file);

                System.IO.File.WriteAllLines(file, content, utf8WithoutBOM);

                pbgProgresso.Value += 1;
                lblStatusProgresso.Text = "Convertendo Arquivos para utf8(Without BOM): " + pbgProgresso.Value.ToString() + " de " + total.ToString();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnReleaseNotes_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Funcoes.ShowCursor(this, CursorType.WaitCursor);

                    GravaInformacoesNoBancoDoriaTI();

                    Funcoes.ShowCursor(this, CursorType.Default);
                    MessageBox.Show("Deploy executado com sucesso!");
                }
                catch (Exception exc)
                {
                    Funcoes.ShowCursor(this, CursorType.Default);
                    Funcoes.LogError(this.Name, exc, true);
                }
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void BtnDeployQuickStart_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                CreatePackgeJoomlaInstallQuickStart();
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void CreatePackgeJoomlaInstallQuickStart()
        {
            //Passo a passo para criar um Pacote QuickStart do JooMob 3

            //1) Copiar a pasta do projeto para TEMP
            //2) Copiar a pasta "installation" para pasta do projeto em TEMP
            //3) Substituir os arquivos pelos da pasta do projeto "porjeto joomla\ArquivosProjeto\QuickStartFiles" para as pastas abaixo:
            //      -"installation\language\pt-BR\pt-BR.ini"
            //      -"installation\view\summary\tmpl\default.php"
            //4) Criar o arquivo "sample_joomob.sql" nas pasta "installation\sql\mysql" sem as tabelas abaixo:
            //  # __usergroups
            //  # __users
            //  # __user_usergroup_map
            //5) Convert arquivos para UTF-8.
            //6) Gerar o arquivo zip sem a pasta principal no formato "{projeto}_v{versão}_QuickStart".Exemplo: "JooMob3_v1.0.17_QuickStart".
            //7) Publish Files via FTP

            try
            {
                pbgProgressoPrincipal.Minimum = 0;
                pbgProgressoPrincipal.Maximum = 7;
                pbgProgressoPrincipal.Value = 0;

                string pathFolderRoot = @"K:\temp\QuickStart";

                string fileNamePackageQuickStartZip = string.Format("{0}_v{1}_QuickStart.zip", _joomlaInstall.Name, _joomlaInstall.Version);
                string folderDestinyRoot = Path.Combine(pathFolderRoot, _joomlaInstall.Name);
                string folderDestinyVersion = Path.Combine(pathFolderRoot, _joomlaInstall.Name, _joomlaInstall.Version);
                string folderDestinyQuickStart = Path.Combine(folderDestinyVersion, "QuickStart");
                string folderDestinyInstallation = Path.Combine(folderDestinyQuickStart, "installation");
                string pathFileNameMySQLDataInstallation = Path.Combine(folderDestinyInstallation, "sql", "mysql", _joomlaInstall.FileNameMySQLDataInstallation);

                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                MySqlConnectionClass mySqlConnection = new MySqlConnectionClass();

                mySqlConnection.ServerName = _joomlaInstall.DataBaseServer;
                mySqlConnection.DataBaseName = _joomlaInstall.DataBaseName;
                mySqlConnection.UserName = "root";
                mySqlConnection.Password = "";

                mySqlConnection.Conect();

                #region 1 - Copiar a pasta do projeto para TEMP

                //cria pasta do projeto\versão\QuickStart
                if (IOClass.DirectoryExists(folderDestinyQuickStart))
                {
                    IOClass.DeleteDirectorie(folderDestinyQuickStart);
                }

                IOClass.DirectorieCopy(_projectPath, folderDestinyQuickStart, true, _joomlaInstall.QuickStartFoldersExclude.ToList(), _joomlaInstall.QuickStartFilesExclude.ToList(), ref pbgProgresso, ref lblStatusProgresso);
                #endregion

                pbgProgressoPrincipal.Value = 1;

                #region 2) Copiar a pasta "installation" para pasta do projeto em TEMP

                IOClass.DirectorieCopy(_joomlaInstall.FolderInstallation, folderDestinyInstallation, true, new List<string>(), new List<string>(), ref pbgProgresso, ref lblStatusProgresso);

                #endregion

                pbgProgressoPrincipal.Value = 2;

                #region 3) Substituir os arquivos pelos da pasta do projeto "porjeto joomla\ArquivosProjeto\QuickStartFiles"

                //installation\language\pt-BR\pt-BR.ini
                IOClass.CopyTo(Path.Combine(_projectPath, "ArquivosProjeto", "QuickStartFiles", "pt-BR.ini"), Path.Combine(folderDestinyInstallation, "language", "pt-BR", "pt-BR.ini"));
                //installation\view\summary\tmpl\default.php
                IOClass.CopyTo(Path.Combine(_projectPath, "ArquivosProjeto", "QuickStartFiles", "default.php"), Path.Combine(folderDestinyInstallation, "view", "summary", "tmpl", "default.php"));

                #endregion

                pbgProgressoPrincipal.Value = 3;

                #region 4) Cria Arquivos MySql do JooMob 3

                using (MySqlConnection conn = new MySqlConnection(mySqlConnection.ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            mb.ExportInfo.RecordDumpTime = false;
                            mb.ExportInfo.AddCreateDatabase = false;
                            mb.ExportInfo.ExportTableStructure = true;
                            mb.ExportInfo.ExportRows = true;
                            mb.ExportInfo.ResetAutoIncrement = false;
                            mb.ExportInfo.ExportEvents = false;
                            mb.ExportInfo.ExportFunctions = false;
                            mb.ExportInfo.ExportProcedures = false;
                            mb.ExportInfo.GetTotalRowsMode = GetTotalRowsMethod.Skip;
                            mb.ExportInfo.SetDocumentHeaders(new List<string>());
                            mb.ExportInfo.SetDocumentFooters(new List<string>());
                            mb.ExportInfo.ExcludeTables = new List<string>()
                        {
                            _joomlaInstall.DBPrefix  + "_usergroups",
                            _joomlaInstall.DBPrefix  + "_users",
                            _joomlaInstall.DBPrefix  + "_user_usergroup_map"
                        };
                            mb.ExportToFile(pathFileNameMySQLDataInstallation);

                            conn.Close();
                        }
                    }
                }

                string sqlDataString = IOClass.ReadFileToEnd(pathFileNameMySQLDataInstallation);
                sqlDataString = sqlDataString.Replace(_joomlaInstall.DBPrefix, "#_");

                IOClass.AppendTextInFile(pathFileNameMySQLDataInstallation, sqlDataString, true);

                #endregion

                pbgProgressoPrincipal.Value = 4;

                #region 5) Convert arquivos para UTF-8

                //ConvertFolderToUTF8(folderDestinyQuickStart);
                //ConvertFolderToUTF8(folderDestinyInstallExtension);

                #endregion

                pbgProgressoPrincipal.Value = 5;

                #region 6) Gerar o arquivo zip sem a pasta principal no formato "{projeto}_v{versão}_QuickStart".Exemplo: "JooMob3_v1.0.17_QuickStart".

                string pathFilePackageInstallZip = Path.Combine(folderDestinyVersion, fileNamePackageQuickStartZip);

                //Cria Package Zip
                ZipClass.CompactFolder(folderDestinyQuickStart, pathFilePackageInstallZip, false);

                #endregion

                pbgProgressoPrincipal.Value = 6;

                #region 7) Publish File FTP
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(_joomlaInstall.FTPUsername, _joomlaInstall.FTPPassword);

                    client.UploadFile($"{_ftpRootDoriaTI}/arquivos/{_joomlaInstall.Name}/{fileNamePackageQuickStartZip}", WebRequestMethods.Ftp.UploadFile, pathFilePackageInstallZip);
                }
                #endregion

                pbgProgressoPrincipal.Value = 7;

                pbgProgresso.Minimum = 0;
                pbgProgresso.Maximum = 1;
                pbgProgresso.Value = 1;

                Funcoes.ShowCursor(this, CursorType.Default);
                MessageBox.Show("Deploy do QuickStart executado com sucesso!");
            }
            catch (Exception exc)
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                Funcoes.LogError(this.Name, exc, true);
            }
        }
    }
}
