using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class MzzivPoj
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefZamzivPoj { get; set; }
        public decimal? KcPoj { get; set; }
        public bool BezNaroku { get; set; }

        public Mz RefAgNavigation { get; set; }
    }
}
