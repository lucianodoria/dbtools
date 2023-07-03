using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
/// <summary>
/// Classe responsável pela manipulação de arquivo
/// </summary>
public static class IOClass
{
    /// <summary>
    /// Retorna uma lista de diretórios com o caminho completo
    /// </summary>
    /// <param name="path">Diretório a pesquisar</param>
    /// <returns>Lista de arquivos</returns>
    public static string[] GetListDirectories(string path)
    {
        try
        {
            return Directory.GetDirectories(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Retorna uma lista de arquivos com o caminho completo
    /// </summary>
    /// <param name="path">diretório a pesquisar</param>
    /// <param name="searchPattern">parametros de consulta. Ex.: *.*, *.txt</param>
    /// <returns>Lista de arquivos</returns>
    public static string[] GetListFiles(string path, string searchPattern)
    {
        try
        {
            return Directory.GetFiles(path, searchPattern);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Renomeia o arquivo
    /// </summary>
    /// <param name="filename">Caminho completo do arquivo.</param>
    /// <param name="newfilename">Novo nome do arquivo(somente nome)</param>
    public static void Rename(string filename, string newfilename)
    {
        try
        {
            FileInfo info = new FileInfo(filename);

            info.MoveTo(info.DirectoryName + @"\" + newfilename);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Move o arquivo
    /// </summary>
    /// <param name="filename">origem do arquivo.</param>
    /// <param name="destFileName">Destino do arquivo.</param>
    public static void MoveTo(string filename, string destFileName)
    {
        try
        {
            FileInfo info = new FileInfo(filename);

            info.MoveTo(destFileName);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Copia o arquivo
    /// </summary>
    /// <param name="filename">Caminho do arquivo.</param>
    /// <param name="destFileName">Destino do arquivo.</param>
    public static void CopyTo(string filename, string destFileName)
    {
        try
        {
            FileInfo info = new FileInfo(filename);

            string directoryDest = GetDirectory(destFileName);

            if (DirectoryExists(directoryDest) == false)
            {
                CreateDirectorie(directoryDest);
            }

            info.CopyTo(destFileName, true);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Apaga arquivo
    /// </summary>
    /// <param name="filename">Caminho do arquivo.</param>
    public static void DeleteFile(string filename)
    {
        try
        {
            File.Delete(filename);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Cria um diretorio.
    /// </summary>
    /// <param name="path">Caminho do novo diretório</param>
    public static void CreateDirectorie(string path)
    {
        try
        {
            Directory.CreateDirectory(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Apaga um diretorio.
    /// </summary>
    /// <param name="path">Caminho do diretório</param>
    public static void DeleteDirectorie(string path)
    {
        try
        {
            Directory.Delete(path, true);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Pega o nome do diretório
    /// </summary>
    /// <param name="path">Caminho</param>
    /// <returns></returns>
    public static string GetDirectory(string path)
    {
        try
        {
            return Path.GetDirectoryName(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Pega o nome do diretório pai do caminho
    /// </summary>
    /// <param name="path">Caminho</param>
    /// <returns></returns>
    public static string GetDirectoryName(string path)
    {
        try
        {
            string[] strDiretorio = path.Split('\\');

            return strDiretorio[strDiretorio.Length - 1];
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Move uma pasta de lugar
    /// </summary>
    /// <param name="sourceDirName">Caminho da pasta de origem</param>
    /// <param name="destDirName">Caminho da pasta de destino</param>
    public static void DirectorieMove(string sourceDirName, string destDirName, bool overwrite)
    {
        try
        {
            if (DirectoryExists(destDirName) && overwrite)
            {
                Directory.Delete(destDirName);
            }

            Directory.Move(sourceDirName, destDirName);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Copia uma pasta
    /// </summary>
    /// <param name="sourceDirName">Caminho da pasta de origem</param>
    /// <param name="destDirName">Caminho da pasta de destino</param>
    /// <param name="overwrite">Sobresquever caso o caminho da pasta de destino existir</param>
    public static void DirectorieCopy(string sourceDirName, string destDirName, bool overwrite)
    {
        try
        {
            Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(sourceDirName, destDirName, overwrite);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static void DirectorieCopy(string sourceDirName, string destDirName, bool overwrite, List<string> excludeFolders, List<string> excludeFiles, ref ProgressBar pbgProgresso, ref Label lblStatusProgresso)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        var listFolders = dir.GetDirectories().ToList();
        var files = dir.GetFiles().ToList();

        pbgProgresso.Minimum = 0;
        pbgProgresso.Maximum = listFolders.Count + files.Count;
        pbgProgresso.Value = 0;

        foreach (var folder in listFolders)
        {
            if (!excludeFolders.Contains(folder.Name))
            {
                lblStatusProgresso.Text = "Copiando pasta " + folder.Name + "...";
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(folder.FullName, Path.Combine(destDirName, folder.Name), overwrite);
            }

            pbgProgresso.Value += 1;
        }

        // Get the files in the directory and copy them to the new location.

        foreach (var file in files)
        {
            if (!excludeFiles.Contains(file.Name))
            {
                string temppath = Path.Combine(destDirName, file.Name);

                lblStatusProgresso.Text = "Copiando arquivo " + file.Name + "...";
                file.CopyTo(temppath, true);
            }

            pbgProgresso.Value += 1;
        }
    }
    /// <summary>
    /// Verifica se o diretório existe
    /// </summary>
    /// <param name="path">Caminho</param>
    /// <returns></returns>
    public static bool DirectoryExists(string path)
    {
        try
        {

            return Directory.Exists(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Pega o nome do arquivo com extenção.
    /// </summary>
    /// <param name="path">caminho</param>
    /// <returns></returns>
    public static string GetFileName(string path)
    {
        try
        {
            return Path.GetFileName(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Pega o nome do arquivo sem extenção.
    /// </summary>
    /// <param name="path">caminho</param>
    /// <returns></returns>
    public static string GetFileNameWithoutExtension(string path)
    {
        try
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Pega a extenção do arquivo.
    /// </summary>
    /// <param name="path">caminho do arquivo</param>
    /// <returns></returns>
    public static string GetExtension(string path)
    {
        try
        {
            return Path.GetExtension(path);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static string ReadFileToEnd(string path)
    {
        try
        {
            TextReader file = File.OpenText(path);

            string result = file.ReadToEnd();

            file.Close();

            return result;
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Adiciona um texto ao arquivo ou cria um novo caso ele não exista. 
    /// </summary>
    /// <param name="pahtFile">Caminho do arquivo.</param>
    /// <param name="text">Texto a inserir ou adicionar.</param>
    /// <param name="overWrite">[True], se deseja sobresquever o arquivo ou [False] se deseja apenas adicionar o texto ao arquivo.</param>
    public static void AppendTextInFile(string pahtFile, string text, bool overWrite)
    {
        try
        {
            //DLLFuncoes.Funcoes func = new DLLFuncoes.Funcoes();

            //func.GravarNoArquivo(pahtFile, text, overWrite);

            using (StreamWriter sw = new StreamWriter(File.Open(pahtFile, FileMode.Create), Encoding.UTF8))
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
}
