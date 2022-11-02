using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;
using OdooRpc.CoreCLR.Client.Models;

namespace Business
{
    [Serializable]
    [NumClass(25)]
    public class InfoOdoo
    {
        public string NameServerOrIp { set; get; }
        public int Port { set; get; } = 80;
        public string Base { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
    }
}
