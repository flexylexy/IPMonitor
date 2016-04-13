using System.IO;

namespace IPMonitor.IPReader
{
    public class IPFileReader : IPFile, IPReader
    {
        public bool IsReady => File.Exists(DataFile);

        public string Read()
        {
            return File.ReadAllText(DataFile);
        }
    }
}