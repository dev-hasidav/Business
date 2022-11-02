using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    [NumClass(26)]
    public class InfoPostgre
    {
        public string NameServerOrIp { set; get; }
        public int Port { set; get; } = 5432;
        public string User { set; get; }
        public string Password { set; get; }
        public string Base { set; get; }
        public bool IntegratedSecurity { set; get; } = false;
        public bool UseSslStream { set; get; } = false;
    }
}
