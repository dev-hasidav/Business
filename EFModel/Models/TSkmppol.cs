using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TSkmppol
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? RefSkz1 { get; set; }
        public int? RefStruct { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId { get; set; }
        public string Stext { get; set; }
        public string Kod { get; set; }
        public string Vcislo { get; set; }
        public string Pozn { get; set; }
        public int? SkzVc { get; set; }
        public double? Mnozstvi { get; set; }
        public decimal? VncpohV { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public TSkmp RefAgNavigation { get; set; }
    }
}
