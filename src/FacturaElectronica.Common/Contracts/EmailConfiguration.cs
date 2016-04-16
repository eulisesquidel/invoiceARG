using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturaElectronica.Common.Contracts
{
    public class EmailConfiguration
    {
        public string Subject { get; set; }
        public string BodyPathHtml { get; set; }
        public string From { get; set; }
        public string ReplayTo { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }       
        public string  MailUserName { get; set; }   
        public string MailPassword { get; set; }   
        public bool MailEnableSSL { get; set; }
        public bool MailDefaultCredentials { get; set; }   
    }
}
