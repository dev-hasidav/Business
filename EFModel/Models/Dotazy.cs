using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Dotazy
    {
        public int Id { get; set; }
        public int? RelAg { get; set; }
        public int? RelSubId { get; set; }
        public bool UsrSel { get; set; }
        public string User { get; set; }
        public string Filter { get; set; }
        public string Sort { get; set; }
        public string SortRef { get; set; }
        public string Popis { get; set; }
    }
}
