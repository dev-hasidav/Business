using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Atributes;

namespace Business
{
    [Serializable]
    [NumClass(24)]
    public class InfoRem
    {
        public string NameServerOrIp { set; get; }
        public int Port { set; get; } = 43242;
    }
}
