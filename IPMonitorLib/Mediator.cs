using IPMonitor.IPReader;
using System;
using System.Configuration;
using System.Timers;

namespace IPMonitor
{
    public class Mediator
    {
        private readonly IPFileReader _fileReader = new IPFileReader();
        private readonly IPFileWriter _fileWriter = new IPFileWriter();
        private readonly IPRemoteReader _remoteReader = new IPRemoteReader();
        private readonly Emailer _emailer = new Emailer();
        private readonly Timer _timer;
        private string _currentIp;

        public Mediator()
        {
            var minutesAsString = ConfigurationManager.AppSettings["minutesBetweenMonitoring"];
            int minutesBetweenMonitoring = Int32.Parse(minutesAsString);

            _timer = new Timer(1000 * 60 * minutesBetweenMonitoring) { AutoReset = true };
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(Object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                var ip = _remoteReader.Read();

                if (_currentIp != ip)
                {
                    _emailer.Send(ip);
                    _fileWriter.Write(ip);
                    _currentIp = ip;
                }
            }
            catch { }
        }

        public void StartMonitoring()
        {
            InitializeMonitoring();
            StartTimedMonitoring();
        }

        private void InitializeMonitoring()
        {
            if (!_fileReader.IsReady)
            {
                _currentIp = _remoteReader.Read();
                _fileWriter.Write(_currentIp);
            }
            else
            {
                _currentIp = _fileReader.Read();
            }
        }

        private void StartTimedMonitoring()
        {
            _timer.Enabled = true;
            _timer.Start();
        }

        public void StopMonitoring()
        {
            _timer.Enabled = false;
            _timer.Stop();
        }
    }
}