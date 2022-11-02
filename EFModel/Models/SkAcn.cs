using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkAcn
    {
        public SkAcn()
        {
            SkAcnAd = new HashSet<SkAcnAd>();
            SkAcnPol = new HashSet<SkAcnPol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public double? Sleva { get; set; }
        public int? RefSkCeny { get; set; }
        public bool UseZkr { get; set; }
        public int? RelTpZkr { get; set; }
        public string Skupina { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SkAcnAd> SkAcnAd { get; set; }
        public ICollection<SkAcnPol> SkAcnPol { get; set; }
    }
}
