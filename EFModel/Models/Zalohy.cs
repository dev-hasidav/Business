using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Zalohy
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public string Soubor { get; set; }
        public int? Pozice { get; set; }
        public int? RelTpVytv { get; set; }
        public int? RelTpZal { get; set; }
        public int? RefIdzal { get; set; }
        public string Creator { get; set; }
    }
}
