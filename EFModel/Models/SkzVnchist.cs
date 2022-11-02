using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVnchist
    {
        public int Id { get; set; }
        public decimal? Vnc { get; set; }
        public int? RefSkz { get; set; }
        public DateTime? DatCreate { get; set; }
    }
}
