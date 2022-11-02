using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZaucDoklVaz
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgIdDokl { get; set; }
        public int? RefDoklZauc { get; set; }
        public int? RelAgIdZauc { get; set; }
    }
}
