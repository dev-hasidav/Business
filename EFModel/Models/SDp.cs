using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SDp
    {
        public int Id { get; set; }
        public int? IdDp { get; set; }
        public string Ids { get; set; }
        public short? Vypocet { get; set; }
        public double? Pausal { get; set; }
        public short? Paragraf { get; set; }
        public short? RokOd { get; set; }
        public short? RokDo { get; set; }
    }
}
