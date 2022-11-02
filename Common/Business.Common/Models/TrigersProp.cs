using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.Models
{
    [Serializable]
    public class TrigersProp
    {
        public DateTime DateCreateCrl { set; get; } = DateTime.Now;
        public byte[] CreateCrl { set; get; } = { 0x11, 0x02 };
        public byte[] CreateFuncOdoo { set; get; } = { 0x11, 0x02 };
        public byte[] ChangeSqlDml { set; get; } = { 0x11, 0x02 };
        public byte[] ChangeOdooDml { set; get; } = { 0x11, 0x02 };
    }
}
