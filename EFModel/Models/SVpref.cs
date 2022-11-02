using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SVpref
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefPrm { get; set; }
        public string Nazev { get; set; }
        public bool AgOpen { get; set; }
        public int? RelUl { get; set; }

        public SVppol RefAgNavigation { get; set; }
    }
}
