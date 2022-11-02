using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SMzZivPj
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string KonstSym { get; set; }
        public string VarSym { get; set; }
        public string SpecSym { get; set; }
        public bool Sumarizace { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
