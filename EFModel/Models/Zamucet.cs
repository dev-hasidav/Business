using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Zamucet
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string Ids { get; set; }
        public string Nazev { get; set; }
        public string TypId { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Obec { get; set; }
        public string Psc { get; set; }
        public string Stat { get; set; }
        public bool Active { get; set; }

        public Zam RefAgNavigation { get; set; }
    }
}
