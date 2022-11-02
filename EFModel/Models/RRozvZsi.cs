using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RRozvZsi
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? OrderFld { get; set; }
        public bool Minus { get; set; }
        public int? Od { get; set; }
        public int? Do { get; set; }
    }
}
