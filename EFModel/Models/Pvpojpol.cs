using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Pvpojpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelTyp { get; set; }
        public decimal? Castka { get; set; }

        public Pvpoj RefAgNavigation { get; set; }
    }
}
