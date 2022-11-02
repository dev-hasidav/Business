using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Funcs
{
    public class Conver
    {
        public static object ConverByteToClass(byte[] bb, Type typ)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bb);
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typ);
            ms.Position = 0;
            object sd = xs.Deserialize(ms);
            return sd;
        }

        public static byte[] ConverClassToByte(object sd)
        {
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(sd.GetType());
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            xs.Serialize(ms, sd);
            ms.Position = 0;
            byte[] bb = ms.ToArray();
            return bb;
        }
    }
}
