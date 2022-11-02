using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZampSra
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? DatOd { get; set; }
        public DateTime? DatDo { get; set; }
        public string Stext { get; set; }
        public bool Cela { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcSraz { get; set; }
        public double? Proc { get; set; }
        public string Rozhod { get; set; }
        public int? RelDrSra { get; set; }
        public int? RelPlat { get; set; }
        public int? RelPk { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string KonstSym { get; set; }
        public string VarSym { get; set; }
        public string Adresa { get; set; }
        public int? RelFond { get; set; }
        public int? RelZivPj { get; set; }
        public int? OrderFld { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Zam RefAgNavigation { get; set; }
    }
}
