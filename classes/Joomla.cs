using System;
using System.ComponentModel;

namespace DBTools
{
    [Serializable]
    public class JoomlaInstall : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _nameExtension;
        public string NameExtension
        {
            get { return _nameExtension; }
            set
            {
                _nameExtension = value;
                OnPropertyChanged("NameExtension");
            }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        private string _version;
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged("Version");
            }
        }
        private string _versionOld;
        public string VersionOld
        {
            get { return _versionOld; }
            set
            {
                _versionOld = value;
                OnPropertyChanged("VersionOld");
            }
        }
        private string _creationDate;
        public string CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }
        private string _dataBaseServer;
        public string DataBaseServer
        {
            get { return _dataBaseServer; }
            set
            {
                _dataBaseServer = value;
                OnPropertyChanged("DataBaseServer");
            }
        }
        private string _dataBaseName;
        public string DataBaseName
        {
            get { return _dataBaseName; }
            set
            {
                _dataBaseName = value;
                OnPropertyChanged("DataBaseName");
            }
        }
        private string _projectPath;
        public string ProjectPath
        {
            get { return _projectPath; }
            set
            {
                _projectPath = value;
                OnPropertyChanged("ProjectPath");
            }
        }
        private string _deployPath;
        public string DeployPath
        {
            get { return _deployPath; }
            set
            {
                _deployPath = value;
                OnPropertyChanged("DeployPath");
            }
        }
        private string _dBPrefix;
        public string DBPrefix
        {
            get { return _dBPrefix; }
            set
            {
                _dBPrefix = value;
                OnPropertyChanged("DBPrefix");
            }
        }
        private string _packageDescription;
        public string PackageDescription
        {
            get { return _packageDescription; }
            set
            {
                _packageDescription = value;
                OnPropertyChanged("PackageDescription");
            }
        }
        private string _ftpUsername;
        public string FTPUsername
        {
            get { return _ftpUsername; }
            set
            {
                _ftpUsername = value;
                OnPropertyChanged("FTPUsername");
            }
        }
        private string _ftpPassword;
        public string FTPPassword
        {
            get { return _ftpPassword; }
            set
            {
                _ftpPassword = value;
                OnPropertyChanged("FTPPassword");
            }
        }
        private string _folderInstallation;
        public string FolderInstallation
        {
            get { return _folderInstallation; }
            set
            {
                _folderInstallation = value;
                OnPropertyChanged("FolderInstallation");
            }
        }
        private string _fileNameMySQLDataInstallation;
        public string FileNameMySQLDataInstallation
        {
            get { return _fileNameMySQLDataInstallation; }
            set
            {
                _fileNameMySQLDataInstallation = value;
                OnPropertyChanged("FileNameMySQLDataInstallation");
            }
        }



        public BindingList<JModule> Modules;
        public BindingList<JTemplate> Templates;
        public BindingList<JTable> Tables;
        public BindingList<JMenu> Menus;
        public BindingList<JLanguage> Languages;

        public BindingList<string> QuickStartFoldersExclude;
        public BindingList<string> QuickStartFilesExclude;

        public JoomlaInstall()
        {
            this.Modules = new BindingList<JModule>();
            this.Templates = new BindingList<JTemplate>();
            this.Tables = new BindingList<JTable>();
            this.Menus = new BindingList<JMenu>();
            this.Languages = new BindingList<JLanguage>();
            this.QuickStartFoldersExclude = new BindingList<string>();
            this.QuickStartFilesExclude = new BindingList<string>();
        }
        public void LoadParams()
        {
            foreach (JModule module in this.Modules)
            {
                Console.WriteLine($"Name: {module.Name} - Upgrade: {module.Upgrade} - Location {module.Location}.");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [Serializable]
    public class JModule : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private bool _upgrade;
        public bool Upgrade
        {
            get { return _upgrade; }
            set
            {
                _upgrade = value;
                OnPropertyChanged("Upgrade");
            }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        public BindingList<JLanguage> Languages;
        public JModule()
        {
            this.Languages = new BindingList<JLanguage>();
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [Serializable]
    public class JTemplate : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private bool _upgrade;
        public bool Upgrade
        {
            get { return _upgrade; }
            set
            {
                _upgrade = value;
                OnPropertyChanged("Upgrade");
            }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        public BindingList<JLanguage> Languages;
        public JTemplate()
        {
            this.Languages = new BindingList<JLanguage>();
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [Serializable]
    public class JTable : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private bool _withData;
        public bool WithData
        {
            get { return _withData; }
            set
            {
                _withData = value;
                OnPropertyChanged("WithData");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [Serializable]
    public class JMenu : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        private string _view;
        public string View
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class JLanguage : INotifyPropertyChanged
    {
        private string _language;
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class JoomlaReleaseNotes : INotifyPropertyChanged
    {
        private string _folderPath;
        public string FolderPath
        {
            get { return _folderPath; }
            set
            {
                _folderPath = value;
                OnPropertyChanged("FolderPath");
            }
        }
        private int _codProduto;
        public int CodProduto
        {
            get { return _codProduto; }
            set
            {
                _codProduto = value;
                OnPropertyChanged("CodProduto");
            }
        }
        private string _dataBaseServer;
        public string DataBaseServer
        {
            get { return _dataBaseServer; }
            set
            {
                _dataBaseServer = value;
                OnPropertyChanged("DataBaseServer");
            }
        }
        private string _dataBaseName;
        public string DataBaseName
        {
            get { return _dataBaseName; }
            set
            {
                _dataBaseName = value;
                OnPropertyChanged("DataBaseName");
            }
        }
        private string _dataBaseUsername;
        public string DataBaseUsername
        {
            get { return _dataBaseUsername; }
            set
            {
                _dataBaseUsername = value;
                OnPropertyChanged("DataBaseUsername");
            }
        }
        private string _dataBasePassword;
        public string DataBasePassword
        {
            get { return _dataBasePassword; }
            set
            {
                _dataBasePassword = value;
                OnPropertyChanged("DataBasePassword");
            }
        }

        public BindingList<JReleaseNote> ReleaseNotes;

        public JoomlaReleaseNotes()
        {
            this.ReleaseNotes = new BindingList<JReleaseNote>();
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class JReleaseNote : INotifyPropertyChanged
    {
        private string _version;
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged("Version");
            }
        }
        public BindingList<JNote> Notes;

        public JReleaseNote()
        {
            this.Notes = new BindingList<JNote>();
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [Serializable]
    public class JNote : INotifyPropertyChanged
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                OnPropertyChanged("Tipo");
            }
        }
        private bool _sugestaoCliente;
        public bool SugestaoCliente
        {
            get { return _sugestaoCliente; }
            set
            {
                _sugestaoCliente = value;
                OnPropertyChanged("SugestaoCliente");
            }
        }
        public BindingList<string> Files;

        public JNote()
        {
            this.Files = new BindingList<string>();
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
