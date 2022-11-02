using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ReklPredm
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? RefSkz0 { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId { get; set; }
        public string Stext { get; set; }
        public string Pozn { get; set; }
        public string Kod { get; set; }
        public string Vcislo { get; set; }
        public int? SkzVc { get; set; }
        public double? Mnozstvi { get; set; }
        public double? Prenes { get; set; }
        public string Mj { get; set; }
        public double? Mjkoef { get; set; }
        public decimal? KcJedn { get; set; }
        public double? Sleva { get; set; }
        public int? RelSzDph { get; set; }
        public double? ProcentoDph { get; set; }
        public bool Sdph { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDph { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public int? RelZaruka { get; set; }
        public int? Zaruka { get; set; }
        public DateTime? DatExp { get; set; }
        public string VadaPopis { get; set; }
        public string StavPrij { get; set; }
        public string NahrDily { get; set; }
        public string ZpReseni { get; set; }
        public string Soucasti { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public Rekl RefAgNavigation { get; set; }
    }
}
