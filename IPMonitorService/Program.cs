using System.ServiceProcess;

namespace IPMonitor
{
    static class Program
    {
        static void Main()
        {
            ServiceBase.Run(new IPMonitorService());
        }
    }
}