using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Mznahr
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefZampDov { get; set; }
        public DateTime? DatZac { get; set; }
        public DateTime? DatKon { get; set; }
        public float? HodZac { get; set; }
        public float? HodKon { get; set; }
        public int? DnyPrac { get; set; }
        public int? DnyKal { get; set; }
        public int? RelDrNahr { get; set; }
        public bool PrumActual { get; set; }
        public decimal? KcPrum { get; set; }
        public decimal? KcUpr { get; set; }
        public float? HodNahr { get; set; }
        public float? HodNahr4 { get; set; }
        public float? Sazba3 { get; set; }
        public float? Sazba4 { get; set; }
        public float? Kraceni { get; set; }
        public string Cislo { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcPrispKarantena { get; set; }
        public bool NeniPrispKarantena { get; set; }
        public bool Rucne { get; set; }

        public Mz RefAgNavigation { get; set; }
    }
}
