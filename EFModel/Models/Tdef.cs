using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Tdef
    {
        public int Id { get; set; }
        public string Ucetni { get; set; }
        public int? Typ { get; set; }
        public int? RelSubId { get; set; }
        public int? RelT { get; set; }
    }
}
