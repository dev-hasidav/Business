using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Onz
    {
        public Onz()
        {
            Onzpol = new HashSet<Onzpol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelStavDp { get; set; }
        public DateTime? DatPod { get; set; }
        public DateTime? DatPrij { get; set; }
        public string Stext { get; set; }
        public string Uloha { get; set; }
        public bool ElOdeslano { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<Onzpol> Onzpol { get; set; }
    }
}
