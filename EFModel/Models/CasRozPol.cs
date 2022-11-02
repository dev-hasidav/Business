using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class CasRozPol
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefAg { get; set; }
        public int? RelUzavreno { get; set; }
        public int? Rok { get; set; }
        public DateTime? DatumKo { get; set; }
        public int? RelPerCasRoz { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcKorekce { get; set; }
        public decimal? KcUplat { get; set; }
        public decimal? KcZustatek { get; set; }
        public int? RelPk { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public CasRoz RefAgNavigation { get; set; }
    }
}
