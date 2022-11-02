using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSkladCn
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkSkup { get; set; }
        public bool Pouzit { get; set; }
    }
}
