using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TAducet
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
        public string Ttext { get; set; }

        public TAd RefAgNavigation { get; set; }
    }
}
