using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Adcn
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgId { get; set; }
        public string Kod { get; set; }
        public string Nazev { get; set; }
        public int? RefPol { get; set; }
        public int? RefStruct { get; set; }
        public float? Sleva { get; set; }
        public decimal? Cena { get; set; }
        public bool Sdph { get; set; }
        public float? SlevaPc { get; set; }
        public decimal? CenaPc { get; set; }
        public int? RefCm { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
    }
}
