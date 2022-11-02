using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TSkpppol
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? RefSkz0 { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId { get; set; }
        public int? RefParentZ { get; set; }
        public string Stext { get; set; }
        public string Pozn { get; set; }
        public string Kod { get; set; }
        public string Vcislo { get; set; }
        public int? SkzVc { get; set; }
        public double? Mnozstvi { get; set; }
        public double? Prenes { get; set; }
        public double? PrenesBfr { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public decimal? KcJedn { get; set; }
        public double? Sleva { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public bool Sdph { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public decimal? KcVnakl { get; set; }
        public int? RelTpVnakl { get; set; }
        public decimal? CmJedn { get; set; }
        public decimal? Cm { get; set; }
        public decimal? CmDph { get; set; }
        public int? RelPk { get; set; }
        public bool Pdp { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public string Aucet { get; set; }
        public DateTime? DatExp { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public TSkpp RefAgNavigation { get; set; }
    }
}
