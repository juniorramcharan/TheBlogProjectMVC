using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProjectMVC.ViewModels
{
    public class MailSettings
    {

        //To configure and use an SMTP Server from Google for Example

        public string Mail { get; set; }
        public string  DisaplayName { get; set; }

        public string  Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }
    }
}
