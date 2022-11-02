using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SmsSent
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RelBrana { get; set; }
        public string Recipients { get; set; }
        public string Stext { get; set; }
        public string State { get; set; }
        public bool Doruceni { get; set; }
        public string GoSmsLink { get; set; }
        public DateTime? Datum { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
