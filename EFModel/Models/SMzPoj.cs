using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SMzPoj
    {
        public SMzPoj()
        {
            ZamRefNovaPojNavigation = new HashSet<Zam>();
            ZamRefPojNavigation = new HashSet<Zam>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Aucet { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string VarSym { get; set; }
        public string KonstSym { get; set; }
        public string SpecSym { get; set; }
        public string Kod { get; set; }
        public string Cislo1 { get; set; }
        public string Cislo2 { get; set; }
        public string DataBox { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }

        public ICollection<Zam> ZamRefNovaPojNavigation { get; set; }
        public ICollection<Zam> ZamRefPojNavigation { get; set; }
    }
}
