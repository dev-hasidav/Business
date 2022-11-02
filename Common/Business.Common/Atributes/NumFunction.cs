using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Atributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class NumFunction : System.Attribute
    {
        public int Number { private set; get; }
        public NumFunction(int Number)
        {
            this.Number = Number;
        }
    }
}
