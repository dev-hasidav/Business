using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dmpohyb
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelTpPohDm { get; set; }
        public DateTime? Datum { get; set; }
        public int? Pocet { get; set; }
        public decimal? KcJedn { get; set; }
        public decimal? Kc { get; set; }
        public string Pozn { get; set; }

        public Dm RefAgNavigation { get; set; }
    }
}
