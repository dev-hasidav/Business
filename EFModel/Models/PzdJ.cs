using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PzdJ
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelTpJ { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? Status { get; set; }
        public string Firma2 { get; set; }
        public string Ulice2 { get; set; }
        public string Psc2 { get; set; }
        public string Obec2 { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public byte[] Settings { get; set; }
        public string GuidJ { get; set; }
        public bool ShareAd { get; set; }
        public bool AutSynchPzd { get; set; }
        public bool NexportData { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
