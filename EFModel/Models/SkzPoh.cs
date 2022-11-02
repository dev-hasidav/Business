using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzPoh
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RefSkz { get; set; }
        public int? RefUd { get; set; }
        public double? Mjvyr { get; set; }
        public int? RelIdv { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
        public int? RelOp { get; set; }
        public DateTime? Datum { get; set; }
        public double? PohPmj { get; set; }
        public decimal? PohKc { get; set; }
        public decimal? KcCelkem { get; set; }
        public decimal? KcOceneni { get; set; }
        public decimal? Vnakup { get; set; }
        public double? StavZ { get; set; }
        public int? OrderFld { get; set; }
        public string SkUmd { get; set; }
        public string SkUd { get; set; }
        public string Cislo { get; set; }
        public int? RefAd { get; set; }
        public int? RefAddod { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Ico { get; set; }
        public string Obec { get; set; }
        public int? RefZeme { get; set; }
        public string Firma2 { get; set; }
        public string Jmeno2 { get; set; }
        public string Obec2 { get; set; }
        public int? RefZeme2 { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public int? RefUcet { get; set; }
        public string Vcislo { get; set; }
        public int? RefRcPr { get; set; }
        public string StextRcPr { get; set; }
        public decimal? KcRcPr { get; set; }
        public string MjrcPr { get; set; }
        public double? MjkoefRcPr { get; set; }
        public int? PolSkzVc { get; set; }
        public DateTime? DatExp { get; set; }
        public int? Zaruka { get; set; }
        public int? RelZaruka { get; set; }
        public string Oznacil { get; set; }

        public Skz RefSkzNavigation { get; set; }
    }
}
