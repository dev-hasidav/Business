using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PzdHist
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelTpHist { get; set; }
        public int? Sender { get; set; }
        public DateTime? Datum { get; set; }
        public int? Recip { get; set; }
        public int? Status { get; set; }
        public int? PackNum { get; set; }
        public int? PackNumF { get; set; }
        public bool Kolize { get; set; }
        public string Log { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
    }
}
