using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Adhist
    {
        public Adhist()
        {
            AdhistVaz = new HashSet<AdhistVaz>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RelAgId { get; set; }
        public int? RefAd { get; set; }
        public int? RefAddoc { get; set; }
        public int? RefEmail { get; set; }
        public int? RefDataBox { get; set; }
        public int? RefSms { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? Termin { get; set; }
        public string Akce { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Klic { get; set; }
        public int? RefStr { get; set; }
        public int? RefCin { get; set; }
        public string CisloZak { get; set; }
        public string Ostatni { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Dopis { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Firma { get; set; }
        public string Jmeno { get; set; }

        public ICollection<AdhistVaz> AdhistVaz { get; set; }
    }
}
