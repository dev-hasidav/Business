using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SCkurspol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Kod { get; set; }
        public string Zeme { get; set; }
        public int? Mnozstvi { get; set; }
        public double? Nbs { get; set; }

        public SCkurs RefAgNavigation { get; set; }
    }
}
