using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SPlatidla
    {
        public SPlatidla()
        {
            SPlatidlaPol = new HashSet<SPlatidlaPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public string Symbol { get; set; }
        public bool Vychozi { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SPlatidlaPol> SPlatidlaPol { get; set; }
    }
}
