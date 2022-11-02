using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Nempri
    {
        public Nempri()
        {
            Nempripol = new HashSet<Nempripol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefStavDp { get; set; }
        public DateTime? DatPod { get; set; }
        public DateTime? DatPrij { get; set; }
        public string Stext { get; set; }
        public string Uloha { get; set; }
        public string RespPoint { get; set; }
        public bool ElOdeslano { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public bool Lock { get; set; }
        public bool Lock1 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<Nempripol> Nempripol { get; set; }
    }
}
