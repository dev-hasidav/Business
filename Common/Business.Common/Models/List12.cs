using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [System.Diagnostics.DebuggerDisplay("Id: {Id}, Id1: {Id1}, Name: {Name}, Name1: {Name1}, ")]
    [Serializable]
    public class List12
    {
        public int Id { set; get; }
        public int Id1 { set; get; }
        public string Name { set; get; }
        public string Name1 { set; get; }

    }
}
