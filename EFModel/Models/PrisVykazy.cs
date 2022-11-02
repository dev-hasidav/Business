using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PrisVykazy
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? Rok { get; set; }
        public int? RelTp { get; set; }
        public DateTime? DatSestav { get; set; }
        public int? Tisice { get; set; }
        public byte[] Data { get; set; }
        public int NullCheckRefAg { get; set; }
    }
}
