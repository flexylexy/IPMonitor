using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.ServiceProcess;

namespace IPMonitor
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private readonly string _siteUrl = ConfigurationManager.AppSettings["siteUrl"];

        public ProjectInstaller()
        {
            var process = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };

            var service = new ServiceInstaller
            {
                DisplayName = "IP Monitor",
                ServiceName = "IP Monitor",
                Description = $"Monitors the dynamic IP address of { _siteUrl }."
            };

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}