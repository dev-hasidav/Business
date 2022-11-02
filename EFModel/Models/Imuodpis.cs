using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Imuodpis
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelUzavreno { get; set; }
        public DateTime? Mesic { get; set; }
        public int? RefImo { get; set; }
        public double? Zivotnost { get; set; }
        public decimal? KcVstup { get; set; }
        public double? Procento { get; set; }
        public decimal? KcOdpis { get; set; }
        public decimal? KcKorekce { get; set; }
        public decimal? KcOdpisCalc { get; set; }
        public decimal? KcZustatek { get; set; }

        public Im RefAgNavigation { get; set; }
    }
}
