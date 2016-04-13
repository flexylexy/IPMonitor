using System.Threading;

namespace IPMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Mediator().StartMonitoring();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}