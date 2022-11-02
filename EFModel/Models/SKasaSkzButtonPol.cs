using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaSkzButtonPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? Button { get; set; }
        public string Ids { get; set; }
        public int? RefSkz { get; set; }

        public SKasaSkzButton RefAgNavigation { get; set; }
        public Skz RefSkzNavigation { get; set; }
    }
}
