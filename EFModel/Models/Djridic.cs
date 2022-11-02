using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Djridic
    {
        public Djridic()
        {
            Djjizdy = new HashSet<Djjizdy>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Titul { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string Cislo { get; set; }
        public bool Spol { get; set; }
        public string PracTel { get; set; }
        public string PracDoba { get; set; }
        public int? RelTpZam { get; set; }
        public int? RefRidicSkup { get; set; }
        public int? RefZam { get; set; }
        public int? RefStr { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public SStr RefStrNavigation { get; set; }
        public ICollection<Djjizdy> Djjizdy { get; set; }
    }
}
