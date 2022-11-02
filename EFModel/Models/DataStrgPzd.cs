using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class DataStrgPzd
    {
        public int Id { get; set; }
        public int? DataId { get; set; }
        public byte[] Settings { get; set; }
        public int? RefAg { get; set; }
        public string Ucetni { get; set; }
    }
}
