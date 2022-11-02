using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class KasaHist
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefSender { get; set; }
        public DateTime? Datum { get; set; }
        public int? RefRecip { get; set; }
        public int? PackNum { get; set; }
        public int? PackNumF { get; set; }
        public string MKasaGuid { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
    }
}
