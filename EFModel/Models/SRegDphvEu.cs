using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SRegDphvEu
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Dic { get; set; }
        public DateTime? PlatceOd { get; set; }
        public DateTime? PlatceDo { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Utvar { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
