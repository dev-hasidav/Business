using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkEuro
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool VypisPriUzav { get; set; }
        public bool SlevyPrirazky { get; set; }
        public bool ProdZapZas { get; set; }
        public bool ProdZlomku { get; set; }
        public bool MnozZvahy { get; set; }
        public bool VratnyObal { get; set; }
        public bool Hhour1 { get; set; }
        public bool Hhour2 { get; set; }
        public bool Hhour3 { get; set; }
        public bool Hhour4 { get; set; }
        public bool PopisPlu { get; set; }
        public int? RelMj { get; set; }
        public int? RelAkce { get; set; }
        public int? RelDpt { get; set; }
        public int? OhranicCif { get; set; }
        public int? MoznostProd { get; set; }
        public int? SpojPlu { get; set; }
        public int? Cena { get; set; }
        public int? Cena2 { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
        public int NullCheckIds { get; set; }
    }
}
