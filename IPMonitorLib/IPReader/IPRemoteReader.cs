using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace IPMonitor.IPReader
{
    public class IPRemoteReader : IPReader
    {
        private readonly string _serviceUrl = ConfigurationManager.AppSettings["serviceUrl"];

        public string Read()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_serviceUrl);
                var response = request.GetResponse();

                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("IPMonitor", $"Exception while querying { _serviceUrl }: " + e, EventLogEntryType.Error);
                throw;
            }
        }
    }
}