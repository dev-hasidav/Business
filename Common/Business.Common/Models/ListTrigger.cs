using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    [Serializable]
    public class ListTrigger
    {
        public string NameTrigger { set; get; }
        public string NameBase { set; get; }
        public string NameTable { set; get; }
        public bool IsRemote { set; get; }
        public Task Tsk { set; get; }
        public Servers Srv { set; get; }

    }
}
