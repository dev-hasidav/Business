using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SVpul
    {
        public SVpul()
        {
            SVpulpol = new HashSet<SVpulpol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? UsrAgId { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool UseConstId { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SVpulpol> SVpulpol { get; set; }
    }
}
