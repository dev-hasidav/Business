using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Verze
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public string Nazev { get; set; }
        public string TypeDb { get; set; }
        public string Verze1 { get; set; }
        public string VerzeKasa { get; set; }
        public string VerzeGlx { get; set; }
        public string VerzeMzdy { get; set; }
        public string Lc { get; set; }
        public string Release { get; set; }
        public string Nser { get; set; }
    }
}
