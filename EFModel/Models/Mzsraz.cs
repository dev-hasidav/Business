using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Mzsraz
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefZam { get; set; }
        public int? RefZpSra { get; set; }
        public int? Poradi { get; set; }
        public int? RelMes { get; set; }
        public int? Rok { get; set; }
        public string Stext { get; set; }
        public double? Proc { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcCelkem { get; set; }
        public bool Cela { get; set; }
        public int? RelPk { get; set; }
        public int? RelPlat { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string KonstSym { get; set; }
        public string VarSym { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Ulice { get; set; }
        public string Obec { get; set; }
        public string Psc { get; set; }
        public int? RelFond { get; set; }
        public int? RelZivPj { get; set; }
    }
}
