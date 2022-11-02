using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class MphHist
    {
        public MphHist()
        {
            MphHistPol = new HashSet<MphHistPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public DateTime? Datum { get; set; }
        public string Ids { get; set; }
        public string Usr { get; set; }
        public string Station { get; set; }
        public string Aplikace { get; set; }
        public string SrcName { get; set; }
        public string DstName { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<MphHistPol> MphHistPol { get; set; }
    }
}
