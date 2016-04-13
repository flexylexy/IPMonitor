using System.ServiceProcess;

namespace IPMonitor
{
    public partial class IPMonitorService : ServiceBase
    {
        private readonly Mediator _mediator = new Mediator();

        public IPMonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _mediator.StartMonitoring();
        }

        protected override void OnStop()
        {
            _mediator.StopMonitoring();
        }
    }
}