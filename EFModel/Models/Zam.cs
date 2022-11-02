using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Zam
    {
        public Zam()
        {
            Eneschop = new HashSet<Eneschop>();
            Mz = new HashSet<Mz>();
            ZampDet = new HashSet<ZampDet>();
            ZampDov = new HashSet<ZampDov>();
            ZampSra = new HashSet<ZampSra>();
            Zamucet = new HashSet<Zamucet>();
            ZamzivPoj = new HashSet<ZamzivPoj>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public int? RelCr { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Rozena { get; set; }
        public string PrijmeniDalsi { get; set; }
        public string Titul { get; set; }
        public int? RelPohl { get; set; }
        public DateTime? DatNar { get; set; }
        public string RodCisl { get; set; }
        public bool ShowRc { get; set; }
        public string OsCislo { get; set; }
        public string Cop { get; set; }
        public string MistoNar { get; set; }
        public string Narodn { get; set; }
        public string StatPris { get; set; }
        public string Cizinec { get; set; }
        public string CizCisPojZp { get; set; }
        public string CizCisPojSp { get; set; }
        public string CizUlice { get; set; }
        public string CizCp { get; set; }
        public string CizObec { get; set; }
        public string CizPsc { get; set; }
        public string CizMisto { get; set; }
        public string CizDokladTyp { get; set; }
        public string CizDokladStat { get; set; }
        public string CizStatNar { get; set; }
        public string CizNositel { get; set; }
        public string CizUlice2 { get; set; }
        public string CizCp2 { get; set; }
        public string CizObec2 { get; set; }
        public string CizPostCode { get; set; }
        public string CizStat { get; set; }
        public string CizCislo { get; set; }
        public string Vzdelani { get; set; }
        public string Obecne { get; set; }
        public int? RelStav { get; set; }
        public bool Spolec { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Obec { get; set; }
        public string Psc { get; set; }
        public string KonUlice { get; set; }
        public string KonCp { get; set; }
        public string KonObec { get; set; }
        public string KonPsc { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int? RefMist { get; set; }
        public int? RefStr { get; set; }
        public string PracDobZ { get; set; }
        public string PracDobK { get; set; }
        public string Zarazeni { get; set; }
        public string Ucet { get; set; }
        public string KodBanky { get; set; }
        public string VarSym { get; set; }
        public string SpecSym { get; set; }
        public int? RelVypl { get; set; }
        public int? RelVyplZ { get; set; }
        public int? RelDruhZ { get; set; }
        public int? RelDruhZold { get; set; }
        public int? RelDruhZ2011 { get; set; }
        public int? RelSkZarucMzda { get; set; }
        public DateTime? DatNast { get; set; }
        public DateTime? DatVstup { get; set; }
        public DateTime? DatOdchUrc { get; set; }
        public DateTime? DatOdch { get; set; }
        public int? OdpracR { get; set; }
        public int? OdpracD { get; set; }
        public bool MzdaOdch { get; set; }
        public float? Duvazek { get; set; }
        public double? Tuvazek { get; set; }
        public float? TydenDni { get; set; }
        public int? RelDruhM { get; set; }
        public decimal? KcSzM { get; set; }
        public decimal? KcOsOhod { get; set; }
        public decimal? KcZaloha { get; set; }
        public decimal? KcCastH { get; set; }
        public float? Premie { get; set; }
        public decimal? KcPremie { get; set; }
        public float? DovStara { get; set; }
        public float? DovNar { get; set; }
        public float? DovPrech { get; set; }
        public float? DovCerp { get; set; }
        public float? DovProplac { get; set; }
        public bool JeDovNarok { get; set; }
        public bool JeDovRucni { get; set; }
        public bool JeDovRucni2 { get; set; }
        public double? DovTyd { get; set; }
        public double? DovTyd2 { get; set; }
        public double? DovNarHod { get; set; }
        public double? DovNarHod2 { get; set; }
        public double? DovStaraDny { get; set; }
        public double? DovStaraHod { get; set; }
        public double? DovKracHod { get; set; }
        public double? DovKracHod2 { get; set; }
        public double? DovCerpDny { get; set; }
        public double? DovCerpDny2 { get; set; }
        public double? DovCerpHod { get; set; }
        public double? DovCerpHod2 { get; set; }
        public double? DovZbyvHod { get; set; }
        public double? DovZbyvHod2 { get; set; }
        public int? RefPoj { get; set; }
        public int? RefStavDp { get; set; }
        public string TypEldp { get; set; }
        public string Posta { get; set; }
        public string PredPoj { get; set; }
        public string SoucPoj { get; set; }
        public int? RefFond { get; set; }
        public string VarPf { get; set; }
        public string SpecPf { get; set; }
        public decimal? KcPfond { get; set; }
        public decimal? KcPfmax { get; set; }
        public double? ProcPf { get; set; }
        public decimal? KcPrumL { get; set; }
        public decimal? KcVvzl { get; set; }
        public bool RocZuct { get; set; }
        public bool GlxRidic { get; set; }
        public decimal? KcDanUrz { get; set; }
        public decimal? KcPreplDanRz { get; set; }
        public decimal? KcDoplDanBonRz { get; set; }
        public int? RelMesRz { get; set; }
        public string DpredZam { get; set; }
        public bool JeStudent { get; set; }
        public string Stat { get; set; }
        public string StatKonAdr { get; set; }
        public string DdrDuch { get; set; }
        public decimal? KcDhrPre { get; set; }
        public int? DzapocR { get; set; }
        public int? DzapocD { get; set; }
        public string Dsdeleni { get; set; }
        public string Dsdel2 { get; set; }
        public int? RelOdstupne { get; set; }
        public string DuvodUkonceni { get; set; }
        public int? RelUkonc { get; set; }
        public string Dduvod { get; set; }
        public bool JeSmluvni { get; set; }
        public string SmlSpNosPoj { get; set; }
        public string SmlZamIc { get; set; }
        public DateTime? SmlDatZac { get; set; }
        public DateTime? SmlDatKon { get; set; }
        public string Dkvalif { get; set; }
        public string DjinSdel { get; set; }
        public DateTime? DatDuchodOd { get; set; }
        public DateTime? DatDuchVekOd { get; set; }
        public DateTime? DatDuchodPrizOd { get; set; }
        public bool Nerezident { get; set; }
        public string DicTyp { get; set; }
        public string Dic { get; set; }
        public decimal? KcZahrPoj { get; set; }
        public bool ZmenaPoj { get; set; }
        public DateTime? ZmenaPojDatum { get; set; }
        public int? RefNovaPoj { get; set; }
        public string Heslo { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckOsCislo { get; set; }
        public DateTime? VprDatumPovol { get; set; }
        public int? RefVprOrganOp { get; set; }
        public int? RefVprKkov { get; set; }
        public int? RefVprPrIsco { get; set; }
        public int? RefVprCisIsco { get; set; }
        public int? RefVprZarIsco { get; set; }
        public string VprJcpovol { get; set; }
        public int? RefVprKontOsoba { get; set; }
        public int? RefVprTelKontOs { get; set; }
        public int? RefVprEmailKontO { get; set; }
        public string VprMzdaSlovy { get; set; }
        public DateTime? VprDodatekPs { get; set; }
        public string VprPobocka { get; set; }
        public int? VprUvazek { get; set; }
        public decimal? VprNahrZaOp { get; set; }
        public string VprVozidlo { get; set; }

        public SMzPoj RefNovaPojNavigation { get; set; }
        public SMzPoj RefPojNavigation { get; set; }
        public SStr RefStrNavigation { get; set; }
        public ICollection<Eneschop> Eneschop { get; set; }
        public ICollection<Mz> Mz { get; set; }
        public ICollection<ZampDet> ZampDet { get; set; }
        public ICollection<ZampDov> ZampDov { get; set; }
        public ICollection<ZampSra> ZampSra { get; set; }
        public ICollection<Zamucet> Zamucet { get; set; }
        public ICollection<ZamzivPoj> ZamzivPoj { get; set; }
    }
}
