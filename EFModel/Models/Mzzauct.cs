using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Mzzauct
    {
        public int Id { get; set; }
        public int? RelMes { get; set; }
        public int? Rok { get; set; }
        public decimal? KcDanUpZ { get; set; }
        public decimal? KcDanUpS { get; set; }
        public bool Ponizovat { get; set; }
    }
}
