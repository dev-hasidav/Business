using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Mzdoklad
    {
        public int Id { get; set; }
        public int? RelMes { get; set; }
        public int? Rok { get; set; }
        public int? RelAg { get; set; }
        public int? RelId { get; set; }
    }
}
