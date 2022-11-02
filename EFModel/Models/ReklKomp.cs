using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ReklKomp
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public string Stext { get; set; }
        public string Pozn { get; set; }
        public string Vcislo { get; set; }
        public string Kod { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public Rekl RefAgNavigation { get; set; }
    }
}
