using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzSkupPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? OrderFld { get; set; }

        public SkzSkup RefAgNavigation { get; set; }
        public Skz RefSkzNavigation { get; set; }
    }
}
