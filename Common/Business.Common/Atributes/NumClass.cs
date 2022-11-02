using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Atributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class NumClass : System.Attribute
    {
        public int Number { private set; get; }
        public NumClass(int Number)
        {
            this.Number = Number;
        }
    }
}
