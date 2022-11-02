using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Lm
    {
        public Lm()
        {
            Lmdun = new HashSet<Lmdun>();
            Lmspl = new HashSet<Lmspl>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RelCr { get; set; }
        public int? RelTpLm { get; set; }
        public string Cislo { get; set; }
        public string VarSym { get; set; }
        public string Stext { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string SpecSym { get; set; }
        public string KonstSym { get; set; }
        public DateTime? DatSmlouvy { get; set; }
        public DateTime? DatZar { get; set; }
        public DateTime? DatKonec { get; set; }
        public DateTime? DatVyr { get; set; }
        public DateTime? DatSpl { get; set; }
        public int? Zahrnout { get; set; }
        public int? RefImmist { get; set; }
        public int? RefImclen { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public byte? Status { get; set; }
        public byte? Podnikani { get; set; }
        public decimal? Limit { get; set; }
        public int? Pocet { get; set; }
        public DateTime? DatPrvni { get; set; }
        public DateTime? DatDruha { get; set; }
        public bool FixDph { get; set; }
        public bool Prevod { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<Lmdun> Lmdun { get; set; }
        public ICollection<Lmspl> Lmspl { get; set; }
    }
}
