using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Aducet
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string Popis { get; set; }
        public bool Vychozi { get; set; }
        public string BankaNazev { get; set; }
        public string BankaUlice { get; set; }
        public string BankaObec { get; set; }
        public int? BankaStat { get; set; }

        public Ad RefAgNavigation { get; set; }
    }
}
