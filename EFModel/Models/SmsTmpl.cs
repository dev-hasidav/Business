using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SmsTmpl
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public int? RefAg { get; set; }
        public int? RelBrana { get; set; }
        public string Recipients { get; set; }
        public string Stext { get; set; }
        public bool Doruceni { get; set; }
        public DateTime? Datum { get; set; }
        public string Creator { get; set; }
    }
}
