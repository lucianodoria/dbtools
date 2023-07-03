using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DBTools.forms
{
    public partial class frmJoomlaXMLToScript : Form
    {
        public frmJoomlaXMLToScript()
        {
            InitializeComponent();
        }

        private void BtnGerarScript_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                CreateScriptImportJoomla();
            }
            , CancellationToken.None,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }

        private void CreateScriptImportJoomla()
        {
            try
            {
                string fileName =txtFileXML.Text;

                Funcoes.ShowCursor(this, CursorType.WaitCursor);

                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(SITE));
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);

                var site = (SITE)reader.Deserialize(file);


                // Loading from a file, you can also load from a stream
                //var xml = XDocument.Load(file);

                //var parts = from part in xml.Descendants("result").First().Descendants("geometry").Descendants("location")
                //            select new
                //            {
                //                Latitude = part.Element("lat").Value,
                //                Longitude = part.Element("lng").Value
                //            };

                //    // Query the data and write out a subset of contacts
                //    var query = from c in xml.Root.Descendants("CATEGORIAS");
                ////where (int)c.Attribute("id") < 4
                ////select c.Element("firstName").Value + " " +
                ////       c.Element("lastName").Value;


                //foreach (string name in query)
                //{
                //    Console.WriteLine("Contact's Full Name: {0}", name);
                //}


                //MySqlConnectionClass mySqlConnection = new MySqlConnectionClass();

                //mySqlConnection.ServerName = _joomlaInstall.DataBaseServer;
                //mySqlConnection.DataBaseName = _joomlaInstall.DataBaseName;
                //mySqlConnection.UserName = "root";
                //mySqlConnection.Password = "";

                //mySqlConnection.Conect();

                //string folderDestinyRoot = Path.Combine(pathFolderRoot, _joomlaInstall.Name);
                //string folderDestinyVersion = Path.Combine(pathFolderRoot, _joomlaInstall.Name, _joomlaInstall.Version);

                //_fileNamePackageInstallZip = string.Format("pkg_{0}_v{1}_install.zip", _joomlaInstall.Name, _joomlaInstall.Version);
                //_fileNamePackageUpdateZip = string.Format("pkg_{0}_v{1}_para_v{2}_update.zip", _joomlaInstall.Name, _joomlaInstall.VersionOld, _joomlaInstall.Version);

                //cria pastas
                //if (IOClass.DirectoryExists(folderDestinyRoot))
                //{
                //    //IOClass.DeleteDirectorie(folderDestinyRoot);
                //}

                //CreateJoomlaExtensionInstall(mySqlConnection, pathFolderRoot, folderDestinyVersion);
                //CreateJoomlaExtensionUpdate(mySqlConnection, pathFolderRoot, folderDestinyVersion);
                //GravaInformacoesNoBancoDoriaTI();

                Funcoes.ShowCursor(this, CursorType.Default);
                MessageBox.Show("Deploy executado com sucesso!");
            }
            catch (Exception exc)
            {
                Funcoes.ShowCursor(this, CursorType.Default);
                Funcoes.LogError(this.Name, exc, true);
            }
        }
    }
}
