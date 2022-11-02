using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Hzupnpracoval
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefPol { get; set; }
        public DateTime? PracovalOd { get; set; }
        public DateTime? PracovalDo { get; set; }

        public Hzupn RefAgNavigation { get; set; }
    }
}
