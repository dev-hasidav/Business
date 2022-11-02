using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Iobchod
    {
        public Iobchod()
        {
            IobchodPol = new HashSet<IobchodPol>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RelIobchod { get; set; }
        public string NazevObchod { get; set; }
        public byte[] Settings { get; set; }
        public DateTime? DatFtp { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public ICollection<IobchodPol> IobchodPol { get; set; }
    }
}
