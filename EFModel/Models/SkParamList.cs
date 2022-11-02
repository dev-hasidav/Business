using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkParamList
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public int? OrderFld { get; set; }
    }
}
