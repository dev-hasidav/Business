using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkRefOdkazy
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Url { get; set; }
        public string Popis { get; set; }
        public int? OrderFld { get; set; }
    }
}
