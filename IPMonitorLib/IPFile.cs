using System;
using System.IO;

namespace IPMonitor
{
    public abstract class IPFile
    {
        private const string DataFolderName = "IPMonitor";
        private const string DataFileName = "ip";

        private static string DataFolder { get; }
        protected static string DataFile { get; }

        static IPFile()
        {
            var folderBase = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            DataFolder = Path.Combine(folderBase, DataFolderName);
            DataFile = Path.Combine(DataFolder, DataFileName);
        }

        protected IPFile()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }
    }
}