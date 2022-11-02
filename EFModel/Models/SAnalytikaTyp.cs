using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SAnalytikaTyp
    {
        public int? RefOper { get; set; }
        public int Id { get; set; }
        public int? Dph { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string RadekPd { get; set; }
        public string RadekPv { get; set; }
        public int? PriVyd { get; set; }
        public int? PenNaCeste { get; set; }
        public int? DanNedan { get; set; }
        public bool SelDphobrat { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PlatneDo { get; set; }
    }
}
