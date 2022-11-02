using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SPlatidlaPol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public double? Hodnota { get; set; }
        public bool Mince { get; set; }

        public SPlatidla RefAgNavigation { get; set; }
    }
}
