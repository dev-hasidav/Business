using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZampDet
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public int? RelOdpoc { get; set; }
        public string Stext { get; set; }
        public string RodCisl { get; set; }
        public decimal? KcOdec { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Zam RefAgNavigation { get; set; }
    }
}
