using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class KasaFormUh
    {
        public int Id { get; set; }
        public int? RefKasa { get; set; }
        public int? RefFormUh { get; set; }
    }
}
