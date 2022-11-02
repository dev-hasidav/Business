using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSkladD
    {
        public int Id { get; set; }
        public string UsIds { get; set; }
        public int? RefSklad { get; set; }
    }
}
