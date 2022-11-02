using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SVp
    {
        public SVp()
        {
            SVppol = new HashSet<SVppol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelVptb { get; set; }
        public int? UsrAgId { get; set; }
        public string Ids { get; set; }
        public string Nazev { get; set; }
        public string TabMain { get; set; }
        public string TabItem { get; set; }
        public int? RelCr { get; set; }
        public bool Items { get; set; }
        public bool Templates { get; set; }
        public bool Documents { get; set; }
        public bool List { get; set; }
        public string ListIds { get; set; }
        public string ListStext { get; set; }
        public string Code { get; set; }
        public byte[] Settings { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<SVppol> SVppol { get; set; }
    }
}
