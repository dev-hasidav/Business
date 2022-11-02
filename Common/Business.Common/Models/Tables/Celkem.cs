using Business.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Tables
{
    [NumClass(72)]
    [Serializable]
    public class Celkems
    {
        public decimal Kc0 { set; get; }
        public decimal Kc1 { set; get; }
        public decimal KcDPH1 { set; get; }
        public decimal Kc2 { set; get; }
        public decimal KcDPH2 { set; get; }
        public decimal Kc3 { set; get; }
        public decimal KcDPH3 { set; get; }
        public decimal KcCelkem { set; get; }
    }
}
