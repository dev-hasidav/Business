using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class KasaEetprofil
    {
        public int Id { get; set; }
        public int? RefKasa { get; set; }
        public int? RefEetprofil { get; set; }
    }
}
