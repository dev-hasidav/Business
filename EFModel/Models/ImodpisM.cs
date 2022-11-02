using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ImodpisM
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelUzavreno { get; set; }
        public DateTime? Mesic { get; set; }
        public decimal? KcOdpisM { get; set; }
        public decimal? KcOdpis { get; set; }
        public decimal? KcKorekce { get; set; }
        public double? Zcelku { get; set; }
        public decimal? KcOdpisCalc { get; set; }
        public decimal? KcZustatek { get; set; }
        public decimal? KcVyrazeno { get; set; }

        public Im RefAgNavigation { get; set; }
    }
}
