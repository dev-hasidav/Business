using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class OverDphHist
    {
        public OverDphHist()
        {
            OverDphHistDat = new HashSet<OverDphHistDat>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Dic { get; set; }
        public string Nespolehlivy { get; set; }
        public DateTime? DatNespoleh { get; set; }
        public string VerejneUcty { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }

        public ICollection<OverDphHistDat> OverDphHistDat { get; set; }
    }
}
