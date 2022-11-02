using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaOdlozPhpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? RelSkTyp { get; set; }
        public int? RefundId { get; set; }
        public bool PolSleva { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string StextRp { get; set; }
        public string Pozn { get; set; }
        public double? Mnozstvi { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public decimal? KcJedn { get; set; }
        public bool Sdph { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public double? Sleva { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public int? IdcnZ { get; set; }
        public string Vcislo { get; set; }
        public int? SkzVc { get; set; }
        public int? RelZaruka { get; set; }
        public int? Zaruka { get; set; }
        public int? RefRcPr { get; set; }
        public string StextRcPr { get; set; }
        public decimal? KcRcPr { get; set; }
        public string MjrcPr { get; set; }
        public double? MjkoefRcPr { get; set; }
        public int? RelTypPolEet { get; set; }
        public string Dicpover { get; set; }

        public SKasaOdlozPh RefAgNavigation { get; set; }
    }
}
