using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Hwhist
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelHwTp { get; set; }
        public int? RelEvTp { get; set; }
        public byte[] Settings { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
        public int? Stav { get; set; }
    }
}
