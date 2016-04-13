using System.ComponentModel;

namespace IPMonitor
{
    partial class IPMonitorService
    {
        private IContainer _components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            _components = new Container();
            ServiceName = "IP Monitor";
        }
    }
}