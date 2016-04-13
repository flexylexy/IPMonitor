using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IPMonitor
{
    public class Emailer
    {
        private readonly string _fromAddress = ConfigurationManager.AppSettings["fromAddress"];
        private readonly string _toAddress = ConfigurationManager.AppSettings["toAddress"];
        private readonly string _siteUrl = ConfigurationManager.AppSettings["siteUrl"];

        public void Send(string content)
        {
            Task.Run(() =>
            {
                try
                {
                    var message = new MailMessage(_fromAddress, _toAddress)
                    {
                        Body = $"New IP for { _siteUrl }: " + content,
                        Subject = "Change of IP",
                        Priority = MailPriority.High
                    };

                    new SmtpClient().Send(message);
                }
                catch (Exception e)
                {
                    EventLog.WriteEntry("IPMonitor", "Content: content\r\n\r\nException: " + e, EventLogEntryType.Error);
                }
            });
        }
    }
}