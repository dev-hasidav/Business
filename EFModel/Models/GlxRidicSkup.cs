using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class GlxRidicSkup
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Skupina { get; set; }
        public int? RelGlxSkupSaz { get; set; }
        public double? Proc1 { get; set; }
        public double? Proc2 { get; set; }
        public double? Proc3 { get; set; }
        public decimal? Sazba1 { get; set; }
        public decimal? Sazba2 { get; set; }
        public decimal? Sazba3 { get; set; }
        public double? Zvyseni { get; set; }
        public double? Kapesne { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckSkupina { get; set; }
    }
}
