using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkRefSvazany
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Soubor { get; set; }
        public string Popis { get; set; }
        public int? OrderFld { get; set; }
    }
}
