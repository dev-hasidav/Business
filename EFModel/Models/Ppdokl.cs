using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Ppdokl
    {
        public Ppdokl()
        {
            PpdoklPol = new HashSet<PpdoklPol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public int? RelPredloha { get; set; }
        public bool AutLikv { get; set; }
        public int? RelDruh { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<PpdoklPol> PpdoklPol { get; set; }
    }
}
