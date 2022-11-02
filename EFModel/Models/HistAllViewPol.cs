using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class HistAllViewPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelZmTyp { get; set; }
        public int? TabId { get; set; }
        public string Log { get; set; }

        public HistAllView RefAgNavigation { get; set; }
    }
}
