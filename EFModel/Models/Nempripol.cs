using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Nempripol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? PoradCis { get; set; }
        public int? RokMz { get; set; }
        public int? MesicMz { get; set; }
        public int? RefZampomer { get; set; }
        public int? RefMz { get; set; }
        public int? RefNeprit { get; set; }
        public string CisPotvrz { get; set; }
        public string Poznamka { get; set; }
        public string KodOssz { get; set; }
        public string NazevOssz { get; set; }
        public string DruhDavky { get; set; }
        public string Prijmeni { get; set; }
        public string Jmeno { get; set; }
        public string RodCisl { get; set; }
        public string Vszam { get; set; }
        public string Iczam { get; set; }
        public string JmZam { get; set; }
        public DateTime? ZamOd { get; set; }
        public DateTime? ZamDo { get; set; }
        public int? RelDruhZ { get; set; }
        public DateTime? RozObdOd { get; set; }
        public DateTime? RozObdDo { get; set; }
        public DateTime? DatR1 { get; set; }
        public decimal? KcPrijR1 { get; set; }
        public int? VyldnyR1 { get; set; }
        public DateTime? DatR2 { get; set; }
        public decimal? KcPrijR2 { get; set; }
        public int? VyldnyR2 { get; set; }
        public DateTime? DatR3 { get; set; }
        public decimal? KcPrijR3 { get; set; }
        public int? VyldnyR3 { get; set; }
        public DateTime? DatR4 { get; set; }
        public decimal? KcPrijR4 { get; set; }
        public int? VyldnyR4 { get; set; }
        public DateTime? DatR5 { get; set; }
        public decimal? KcPrijR5 { get; set; }
        public int? VyldnyR5 { get; set; }
        public DateTime? DatR6 { get; set; }
        public decimal? KcPrijR6 { get; set; }
        public int? VyldnyR6 { get; set; }
        public DateTime? DatR7 { get; set; }
        public decimal? KcPrijR7 { get; set; }
        public int? VyldnyR7 { get; set; }
        public DateTime? DatR8 { get; set; }
        public decimal? KcPrijR8 { get; set; }
        public int? VyldnyR8 { get; set; }
        public DateTime? DatR9 { get; set; }
        public decimal? KcPrijR9 { get; set; }
        public int? VyldnyR9 { get; set; }
        public DateTime? DatR10 { get; set; }
        public decimal? KcPrijR10 { get; set; }
        public int? VyldnyR10 { get; set; }
        public DateTime? DatR11 { get; set; }
        public decimal? KcPrijR11 { get; set; }
        public int? VyldnyR11 { get; set; }
        public DateTime? DatR12 { get; set; }
        public decimal? KcPrijR12 { get; set; }
        public int? VyldnyR12 { get; set; }
        public decimal? PravVysPrij { get; set; }
        public float? PocOdHod { get; set; }
        public float? PracDob { get; set; }
        public bool Pracoval { get; set; }
        public decimal? KcPrijMr { get; set; }
        public bool PobiraDuch { get; set; }
        public string DruhDuch { get; set; }
        public bool JeStudent { get; set; }
        public bool SpadaDoPrazd { get; set; }
        public bool VolnPrvZamest { get; set; }
        public bool VolnoBezNahr { get; set; }
        public DateTime? VolnoBezNahrOd { get; set; }
        public DateTime? VolnoBezNahrDo { get; set; }
        public bool NastupujePpm { get; set; }
        public DateTime? NarDitete { get; set; }
        public decimal? NerDvzppm { get; set; }
        public bool PrJinPrace { get; set; }
        public bool Srazka { get; set; }
        public bool Insolvence { get; set; }
        public bool MzdaNaAdresu { get; set; }
        public string AdrObec { get; set; }
        public string AdrUlice { get; set; }
        public string AdrCisloPopis { get; set; }
        public string AdrPsc { get; set; }
        public string Sdeleni { get; set; }
        public string KonPrac { get; set; }
        public string KontTel { get; set; }
        public string KontEmail { get; set; }
        public string MistPod { get; set; }
        public bool Zahranici { get; set; }
        public DateTime? PrevodDatum { get; set; }
        public int? PocetPriloh { get; set; }
        public int? RefStavDp { get; set; }
        public string Err { get; set; }

        public Nempri RefAgNavigation { get; set; }
    }
}
