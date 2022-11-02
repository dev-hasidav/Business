using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphevdpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RefIdsrc { get; set; }
        public int? RefPolSrc { get; set; }
        public string Cislo { get; set; }
        public string Stext { get; set; }
        public DateTime? DatZdPln { get; set; }
        public string Dic { get; set; }
        public int? RefKodyPredmPln { get; set; }
        public int? RefSkz { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? RozsahPln { get; set; }
        public string Mjpln { get; set; }
        public decimal? Kc { get; set; }
        public int? RelSzDph { get; set; }
        public int? RefTpDph { get; set; }
        public int? OrderFld { get; set; }

        public Dphevd RefAgNavigation { get; set; }
    }
}
