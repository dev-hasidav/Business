using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Eetprofil
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? Provozovna { get; set; }
        public string Zarizeni { get; set; }
        public byte[] Settings { get; set; }
        public bool ZjednRezim { get; set; }
        public int? Timeout { get; set; }
        public int? PocetPokusu { get; set; }
        public bool NewDeniedByUser { get; set; }
        public bool AutoPrintOnSave { get; set; }
        public bool RezimPover { get; set; }
        public string Dicpover { get; set; }
        public int? RefPzdJ { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
