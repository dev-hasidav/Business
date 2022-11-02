using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable]
    public enum TypeServers
    {
        None = 0, MsSql = 1, PostgreSQL = 2, Odoo = 4, PohodaXml = 8
    }
}
