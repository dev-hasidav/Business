using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Lmdun
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Kc { get; set; }
        public int? RelPk { get; set; }
        public int? RelUd { get; set; }

        public Lm RefAgNavigation { get; set; }
    }
}
