using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Atributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class NumError : System.Attribute
    {
        public int Number { set; get; }
        public NumError(int Number)
        {
            this.Number = Number;

        }
    }
}
