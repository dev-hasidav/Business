using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Client
{
    public class SyncTask
    {
        public Servers server1 { get; set; }
        public Servers server2 { get; set; }
        public List<string> Tables { get; set; }
        public SyncTask()
        {
            Tables = new List<string>();
        }
    }
}
