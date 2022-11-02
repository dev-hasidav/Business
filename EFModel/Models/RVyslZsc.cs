using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RVyslZsc
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? OrderFld { get; set; }
        public int? Soucet { get; set; }
        public bool Minus { get; set; }
        public int? Od { get; set; }
        public int? Do { get; set; }
        public int? Priznak { get; set; }
    }
}
