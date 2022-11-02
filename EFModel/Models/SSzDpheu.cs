using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSzDpheu
    {
        public SSzDpheu()
        {
            SSzDpheupol = new HashSet<SSzDpheupol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public int? RefCm { get; set; }
        public int? RelZpVypDph { get; set; }
        public string Aucet1 { get; set; }
        public string Aucet2 { get; set; }
        public string Aucet3 { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SSzDpheupol> SSzDpheupol { get; set; }
    }
}
