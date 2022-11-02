using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Pdb
    {
        public Pdb()
        {
            Pdbprilohy = new HashSet<Pdbprilohy>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RelStavEp { get; set; }
        public int? RelTpPdb { get; set; }
        public int? RelDruhPdb { get; set; }
        public int? Rok { get; set; }
        public int? RelMesic { get; set; }
        public DateTime? DatPod { get; set; }
        public DateTime? DatPrij { get; set; }
        public string Uloha { get; set; }
        public bool ElOdeslano { get; set; }
        public byte[] Data { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<Pdbprilohy> Pdbprilohy { get; set; }
    }
}
