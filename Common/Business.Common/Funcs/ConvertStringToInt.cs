using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Funcs
{
    public class ConvertStringToInt
    {
        public static int StringOdooToInt(string Value)
        {
            int n1 = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
            System.Text.RegularExpressions.Match mt = rg.Match(Value);
            if (mt.Success)
            {
                n1 = int.Parse(mt.Value);
            }
            return n1;
        }
        public static decimal StringOdooToDecimal(string Value)
        {
            decimal n1 = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"\d+");
            System.Text.RegularExpressions.Match mt = rg.Match(Value);
            if (mt.Success)
            {
                n1 = decimal.Parse(mt.Value);
            }
            return n1;
        }
    }
}
