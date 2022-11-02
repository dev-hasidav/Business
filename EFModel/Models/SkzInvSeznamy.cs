using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzInvSeznamy
    {
        public SkzInvSeznamy()
        {
            SkzInvSeznamyPol = new HashSet<SkzInvSeznamyPol>();
        }

        public int Id { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public bool Polozky { get; set; }
        public int? RefSklad { get; set; }
        public DateTime? Datum { get; set; }
        public string Stext { get; set; }
        public bool Prenes { get; set; }
        public bool PrenesCast { get; set; }
        public bool Vyrizeno { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<SkzInvSeznamyPol> SkzInvSeznamyPol { get; set; }
    }
}
