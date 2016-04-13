using System.IO;

namespace IPMonitor
{
    public class IPFileWriter : IPFile
    {
        public void Write(string ipAddress)
        {
            File.WriteAllText(DataFile, ipAddress);
        }
    }
}