using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Skz
    {
        public Skz()
        {
            SKasaSkzButtonPol = new HashSet<SKasaSkzButtonPol>();
            SkzBuf = new HashSet<SkzBuf>();
            SkzCn = new HashSet<SkzCn>();
            SkzNc = new HashSet<SkzNc>();
            SkzPoh = new HashSet<SkzPoh>();
            SkzPol = new HashSet<SkzPol>();
            SkzSkupPol = new HashSet<SkzSkupPol>();
            SkzVc = new HashSet<SkzVc>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RelSkTyp { get; set; }
        public int? RefSklad { get; set; }
        public int? RefStruct { get; set; }
        public int? RefSkSkup { get; set; }
        public int? RelDphn { get; set; }
        public int? RelDphp { get; set; }
        public int? RelSkDruh { get; set; }
        public bool Obrat { get; set; }
        public bool Odbyt { get; set; }
        public bool SvazanaZas { get; set; }
        public int? RelSkzVc { get; set; }
        public string Aucet { get; set; }
        public string Vynos { get; set; }
        public string Naklad { get; set; }
        public int? RelTpDphp { get; set; }
        public int? RelTpDphv { get; set; }
        public bool CheckTpDphpdp { get; set; }
        public string Mossdruh { get; set; }
        public string Ids { get; set; }
        public string Ean { get; set; }
        public string Nazev { get; set; }
        public string Nazev1 { get; set; }
        public string Nazev2 { get; set; }
        public string Stext { get; set; }
        public string Stext1 { get; set; }
        public string Stext2 { get; set; }
        public string Mj { get; set; }
        public string Mj2 { get; set; }
        public string Mj3 { get; set; }
        public double? Mj2koef { get; set; }
        public double? Mj3koef { get; set; }
        public double? StavZ { get; set; }
        public double? MinLim { get; set; }
        public double? MinMax { get; set; }
        public double? Hmotnost { get; set; }
        public double? Objem { get; set; }
        public string NazevRp { get; set; }
        public int? RefSkEuro { get; set; }
        public double? Rezer { get; set; }
        public double? ObjedP { get; set; }
        public double? ObjedV { get; set; }
        public double? Reklam { get; set; }
        public double? Servis { get; set; }
        public decimal? NakupC { get; set; }
        public decimal? NakupDph { get; set; }
        public decimal? NakupCm { get; set; }
        public string CmkodNc { get; set; }
        public decimal? Vnakup { get; set; }
        public decimal? ProdejKc { get; set; }
        public decimal? ProdejDph { get; set; }
        public decimal? ProdejCm { get; set; }
        public string CmkodPc { get; set; }
        public int? RelTpFix { get; set; }
        public double? Marze { get; set; }
        public double? Rabat { get; set; }
        public double? ObjMn { get; set; }
        public string ObjNazev { get; set; }
        public int? RefAd { get; set; }
        public string Firma { get; set; }
        public int? Plu { get; set; }
        public bool Iobchod { get; set; }
        public bool MPohoda { get; set; }
        public string Obrazek { get; set; }
        public int? RefRcPr { get; set; }
        public double? MjkoefRcPr { get; set; }
        public string Popis { get; set; }
        public string Popis2 { get; set; }
        public bool FmtPopis { get; set; }
        public bool FmtPopis2 { get; set; }
        public string Vyrobce { get; set; }
        public string ZpravaV { get; set; }
        public string ZpravaP { get; set; }
        public int? RelZaruka { get; set; }
        public int? Zaruka { get; set; }
        public string Mjcn { get; set; }
        public double? MjcnKoef { get; set; }
        public bool EditVyr { get; set; }
        public int? RelTypPolEet { get; set; }
        public string Dicpover { get; set; }
        public int? RefPzdJ { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public bool Novinka { get; set; }
        public bool Doprodej { get; set; }
        public bool Akce { get; set; }
        public bool Doporucujeme { get; set; }
        public bool Sleva { get; set; }
        public bool Priprav { get; set; }
        public string Dodani { get; set; }
        public string Doprava { get; set; }
        public string Ttext { get; set; }
        public bool Template { get; set; }

        public SkCs RefSkSkupNavigation { get; set; }
        public SSklad RefSkladNavigation { get; set; }
        public SkSt RefStructNavigation { get; set; }
        public ICollection<SKasaSkzButtonPol> SKasaSkzButtonPol { get; set; }
        public ICollection<SkzBuf> SkzBuf { get; set; }
        public ICollection<SkzCn> SkzCn { get; set; }
        public ICollection<SkzNc> SkzNc { get; set; }
        public ICollection<SkzPoh> SkzPoh { get; set; }
        public ICollection<SkzPol> SkzPol { get; set; }
        public ICollection<SkzSkupPol> SkzSkupPol { get; set; }
        public ICollection<SkzVc> SkzVc { get; set; }
    }
}
