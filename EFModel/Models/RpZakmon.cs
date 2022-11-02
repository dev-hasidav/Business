using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RpZakmon
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefZak { get; set; }
        public string CisloZak { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatZdPln { get; set; }
        public DateTime? DatSplat { get; set; }
        public int? RelMesic { get; set; }
        public int? Rok { get; set; }
        public int? OrderAg { get; set; }
        public int? RelZakAgId { get; set; }
        public int? RelRealAgId { get; set; }
        public int? RefId { get; set; }
        public int? RefPolId { get; set; }
        public string Cislo { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }
        public string Ico { get; set; }
        public int? RefStruct { get; set; }
        public string Kod { get; set; }
        public string Ean { get; set; }
        public string Vcislo { get; set; }
        public string Nazev { get; set; }
        public string Stext { get; set; }
        public int? RelDruhOper { get; set; }
        public int? RefSkzPoh { get; set; }
        public int? RelOp { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public decimal? KcJedn { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public decimal? KcNaklad { get; set; }
        public decimal? KcVynos { get; set; }
        public decimal? KcPlanNakladu { get; set; }
        public decimal? KcPlanVynosu { get; set; }
        public decimal? KcOstatni { get; set; }
        public decimal? KcVnc { get; set; }
        public decimal? KcOceneni { get; set; }
        public decimal? Vnakup { get; set; }
        public decimal? KcZisk { get; set; }
        public decimal? KcCzisk { get; set; }
        public double? StavZ { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public int? RelPolTyp { get; set; }
        public int? RefSkz { get; set; }
        public int? RefSkz0 { get; set; }
        public int? RelPolAgId { get; set; }
        public string ParSym { get; set; }
        public string VarSym { get; set; }
        public string Oznacil { get; set; }
        public string Pozn { get; set; }
        public string PoznPol { get; set; }
        public string Zdroj { get; set; }
        public DateTime? PlZahaj { get; set; }
        public DateTime? PlPredani { get; set; }
        public DateTime? Zahajeni { get; set; }
        public DateTime? Predani { get; set; }
        public int? RefStav { get; set; }
        public int? RelReklStav { get; set; }
        public int? RelServStav { get; set; }
        public int? OrderFld { get; set; }
    }
}
