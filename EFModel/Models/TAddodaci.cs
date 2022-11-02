using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TAddodaci
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Firma2 { get; set; }
        public string Utvar2 { get; set; }
        public string Jmeno2 { get; set; }
        public string Ulice2 { get; set; }
        public string Psc2 { get; set; }
        public string Obec2 { get; set; }
        public int? RefZeme2 { get; set; }
        public string Tel2 { get; set; }
        public string Email2 { get; set; }
        public bool Vychozi { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Ttext { get; set; }
    }
}
