using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class RefAdskup
    {
        public int Id { get; set; }
        public int? RefSkup { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId { get; set; }
    }
}
