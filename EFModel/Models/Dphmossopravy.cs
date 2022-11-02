using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dphmossopravy
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Zeme { get; set; }
        public decimal? Amount { get; set; }
        public int? RelObMoss { get; set; }
        public int? Rok { get; set; }

        public Dphmoss RefAgNavigation { get; set; }
    }
}
