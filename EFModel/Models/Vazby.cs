using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Vazby
    {
        public int Id { get; set; }
        public int? RelAgId1 { get; set; }
        public int? RefId1 { get; set; }
        public int? RelAgId2 { get; set; }
        public int? RefId2 { get; set; }
        public int? RelTypVazby { get; set; }
        public DateTime? Datum { get; set; }
        public string Cislo { get; set; }
        public string Stext { get; set; }
        public decimal? Kc { get; set; }
    }
}
