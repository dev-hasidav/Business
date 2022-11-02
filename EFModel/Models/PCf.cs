using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class PCf
    {
        public PCf()
        {
            PCfpol = new HashSet<PCfpol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public DateTime? DatOd { get; set; }
        public bool Predloha { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<PCfpol> PCfpol { get; set; }
    }
}
