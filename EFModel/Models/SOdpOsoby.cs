using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SOdpOsoby
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Prijmeni { get; set; }
        public string Jmeno { get; set; }
        public string Titul { get; set; }
        public string Funkce { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime? DatOdch { get; set; }
        public int? RefPzdJ { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
    }
}
