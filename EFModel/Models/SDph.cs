using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SDph
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public bool Vydaj { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? RefTpDph { get; set; }
        public string Popis { get; set; }
        public bool Nabizet { get; set; }
        public string KodSh { get; set; }
        public int? RefKodyPredmPln { get; set; }
        public string VymDphText { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PlatneDo { get; set; }
        public string Radky { get; set; }
        public int? RelVlivKhdph { get; set; }
        public string KodKhdph { get; set; }
        public bool RatioKhdph { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }
    }
}
