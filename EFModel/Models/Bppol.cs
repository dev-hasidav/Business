using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Bppol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgH { get; set; }
        public int? RelIdh { get; set; }
        public string Cislo { get; set; }
        public string Firma { get; set; }
        public string Dic { get; set; }
        public string Icdph { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string KonstSym { get; set; }
        public string SpecSym { get; set; }
        public string VarSym { get; set; }
        public decimal? Kc { get; set; }
        public decimal? Cm { get; set; }
        public bool BpVrac { get; set; }
        public int? OrderFld { get; set; }
        public int? RelPoplTp { get; set; }
        public int? RefPoplUcet { get; set; }
        public string PlatTitul { get; set; }
        public int? RefAd { get; set; }
        public int? RefCm { get; set; }
        public bool Cizozemec { get; set; }
        public string PrijNazev { get; set; }
        public string PrijUlice { get; set; }
        public string PrijObec { get; set; }
        public int? PrijStat { get; set; }
        public string BankaNazev { get; set; }
        public string BankaUlice { get; set; }
        public string BankaObec { get; set; }
        public int? BankaStat { get; set; }
        public string DuvodPlatby { get; set; }

        public Bp RefAgNavigation { get; set; }
    }
}
