using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools.classes
{
    public static class ZipClass
    {
        public static void CompactFolder(string folder, string zipFilePath, bool includeBaseDirectory = true)
        {
            try
            {
                if (File.Exists(zipFilePath))
                {
                    IOClass.DeleteFile(zipFilePath);
                }

                //using (ZipArchive zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
                //{
                //    //zip.CreateEntry(folderName + "/");

                //    zip.CreateEntry(folder, CompressionLevel.Optimal);
                //}

                ZipFile.CreateFromDirectory(folder, zipFilePath, CompressionLevel.Optimal, includeBaseDirectory);
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}
