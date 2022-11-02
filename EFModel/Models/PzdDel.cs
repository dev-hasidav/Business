using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PzdDel
    {
        public int Id { get; set; }
        public string SrcTable { get; set; }
        public int? RelSrcAg { get; set; }
        public int? PzdAut { get; set; }
        public int? PzdId { get; set; }
        public int? PzdStat { get; set; }
        public string Ucetni { get; set; }
    }
}
