using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SUsrAgSpzd
    {
        public int Id { get; set; }
        public string Ucetni { get; set; }
        public int? RelAg { get; set; }
        public int? RelTpGrid { get; set; }
        public int? RelSubId { get; set; }
        public byte[] Settings { get; set; }
    }
}
