using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkrefParamList
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefParam { get; set; }
        public int? RefParamList { get; set; }
        public bool Sel { get; set; }
        public int? OrderFld { get; set; }
    }
}
