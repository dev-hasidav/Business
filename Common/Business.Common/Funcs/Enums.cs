using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Funcs
{
    public class EnumsFn
    {
        public static List<string> GetCollectionEnum(Type enm)
        {
            List<string> li = new List<string>();
            if (enm.IsEnum)
            {
                string[] ss = enm.GetEnumNames();
                if (ss != null)
                {
                    foreach (string item in ss)
                    {
                        li.Add(item);
                    }
                }
            }
            return li;
        }
        public static int GetIdEnum(Type enm, string Name)
        {
            int Num = 0;
            if (enm.IsEnum)
            {
                foreach (object item in enm.GetEnumValues())
                {
                    if (item.ToString().CompareTo(Name) != 0) continue;
                    Num = (int)item;
                    break;
                }
            }
            return Num;
        }
    }
}
