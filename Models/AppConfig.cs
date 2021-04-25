using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigDemo.Models
{
    public class ConnectionString
    {
        public string DBConnection1 { get; set; }
        public string DBConnection2 { get; set; }
    }

    public class AppConfig
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public Guid SingleFileID { get; set; }
        public string SingleFilePackageName { get; set; }
        public string SingleFileJobName { get; set; }

        public string AppMode { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public string FromEmail { get; set; }
    }
}
