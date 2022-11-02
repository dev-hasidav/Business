using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Onzpol
    {
        public Onzpol()
        {
            OnzduchPoj = new HashSet<OnzduchPoj>();
            Onzprilohy = new HashSet<Onzprilohy>();
        }

        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefZam { get; set; }
        public string Prijmeni { get; set; }
        public string Jmeno { get; set; }
        public string Rozena { get; set; }
        public string PrijmeniDalsi { get; set; }
        public string Titul { get; set; }
        public int? RelPohl { get; set; }
        public string RodCisl { get; set; }
        public DateTime? DatNar { get; set; }
        public string MistoNar { get; set; }
        public string StatPris { get; set; }
        public string DuvodNeposlUdaju { get; set; }
        public int? RelTyp { get; set; }
        public DateTime? PlatneOd { get; set; }
        public DateTime? PojisteniOd { get; set; }
        public DateTime? DatVstup { get; set; }
        public DateTime? DatOdch { get; set; }
        public string DdrDuch { get; set; }
        public DateTime? DatDuchodOd { get; set; }
        public int? Ossz { get; set; }
        public string PojKod { get; set; }
        public string DruhZ { get; set; }
        public string SmlSpNosPoj { get; set; }
        public string SoucPoj { get; set; }
        public string PredPoj { get; set; }
        public bool JeMr { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Psc { get; set; }
        public string Obec { get; set; }
        public string Posta { get; set; }
        public string Stat { get; set; }
        public string KonUlice { get; set; }
        public string KonCp { get; set; }
        public string KonPsc { get; set; }
        public string KonObec { get; set; }
        public string StatKonAdr { get; set; }
        public string DruhZamestnani { get; set; }
        public string CizUlice { get; set; }
        public string CizCp { get; set; }
        public string CizPsc { get; set; }
        public string CizObec { get; set; }
        public string CizMisto { get; set; }
        public string CizNositel { get; set; }
        public string CizUlice2 { get; set; }
        public string CizCp2 { get; set; }
        public string CizPostCode { get; set; }
        public string CizObec2 { get; set; }
        public string CizStat { get; set; }
        public string CizCislo { get; set; }
        public bool ZmenaAdr { get; set; }
        public decimal? PrumVydelek { get; set; }
        public bool Nalezi { get; set; }
        public bool Vyplaceno { get; set; }
        public string DuvodUkonceni { get; set; }
        public int? Odstupne1 { get; set; }
        public int? Odstupne2 { get; set; }
        public string DuvodUkonceniSp { get; set; }
        public int? Odchodne { get; set; }
        public int? Odbytne { get; set; }

        public Onz RefAgNavigation { get; set; }
        public ICollection<OnzduchPoj> OnzduchPoj { get; set; }
        public ICollection<Onzprilohy> Onzprilohy { get; set; }
    }
}
