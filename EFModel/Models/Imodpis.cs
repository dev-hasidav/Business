using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Imodpis
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelUzavreno { get; set; }
        public int? Rok { get; set; }
        public DateTime? DatumKho { get; set; }
        public int? RelSkOdp { get; set; }
        public int? ZivotnNm { get; set; }
        public int? RelTpOdp { get; set; }
        public double? Procento { get; set; }
        public decimal? KcOdpis { get; set; }
        public decimal? KcKorekce { get; set; }
        public decimal? KcOdpisCalc { get; set; }
        public decimal? KcZvCeny { get; set; }
        public decimal? KcVstup { get; set; }
        public decimal? KcVstupB { get; set; }
        public decimal? KcZust { get; set; }
        public double? Zcelku { get; set; }

        public Im RefAgNavigation { get; set; }
    }
}
