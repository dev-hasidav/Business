using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RefPolToPol
    {
        public int Id { get; set; }
        public int? RelAgId { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId1 { get; set; }
        public int? RefPol1 { get; set; }
        public double? Mnozstvi { get; set; }
    }
}
