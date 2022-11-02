using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class POs
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ucet { get; set; }
        public string Nazev { get; set; }
        public int? RelDruhU { get; set; }
        public int? RelTypU { get; set; }
        public int? RelTypCn { get; set; }
        public bool Saldo { get; set; }
        public short? Radek { get; set; }
        public short? RadekP { get; set; }
        public short? RadekZ { get; set; }
        public short? RadekZp { get; set; }
        public short? Radek2 { get; set; }
        public short? Radek2Z { get; set; }
        public short? Radek3 { get; set; }
        public short? Radek4 { get; set; }
        public short? Radek5 { get; set; }
        public short? Radek5P { get; set; }
        public short? Radek6 { get; set; }
        public short? Radek6P { get; set; }
        public short? Radek7 { get; set; }
        public short? Radek7P { get; set; }
        public bool Korekce { get; set; }
        public bool Minus { get; set; }
        public bool CistyObrat { get; set; }
        public string UcelZnak { get; set; }
        public string Odpa { get; set; }
        public string Pol { get; set; }
        public string Zj { get; set; }
        public string Orj { get; set; }
        public string Org { get; set; }
        public bool Pouzit { get; set; }
        public bool ObratDph { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckUcet { get; set; }
    }
}
