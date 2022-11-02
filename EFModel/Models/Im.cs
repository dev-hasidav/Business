using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Im
    {
        public Im()
        {
            Imodpis = new HashSet<Imodpis>();
            ImodpisM = new HashSet<ImodpisM>();
            Impohyb = new HashSet<Impohyb>();
            Impredm = new HashSet<Impredm>();
            Imuodpis = new HashSet<Imuodpis>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public int? RelCr { get; set; }
        public string ParSym { get; set; }
        public int? RelTpIm { get; set; }
        public int? RelSkOdp { get; set; }
        public decimal? UcZust { get; set; }
        public int? RelPoDatum { get; set; }
        public int? RelTpOdp { get; set; }
        public int? RelTpLik { get; set; }
        public int? RelZpVyr { get; set; }
        public int? RelZpPor { get; set; }
        public string Vyuziti { get; set; }
        public int? RefImo { get; set; }
        public double? Zivotnost { get; set; }
        public int? RefImmist { get; set; }
        public int? RefImclen { get; set; }
        public bool Sel { get; set; }
        public string Labels { get; set; }
        public bool Prevod { get; set; }
        public bool Upraveno { get; set; }
        public bool Uzavreno { get; set; }
        public string Cislo { get; set; }
        public string Stext { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatZar { get; set; }
        public DateTime? DatLikv { get; set; }
        public decimal? Kc { get; set; }
        public decimal? KcDanova { get; set; }
        public decimal? KcZv { get; set; }
        public decimal? KcOdeps { get; set; }
        public decimal? KcLikv { get; set; }
        public decimal? KcZust { get; set; }
        public decimal? KcZustUcetni { get; set; }
        public bool ZauctLikv { get; set; }
        public double? Vyuzito { get; set; }
        public short? RokZvys { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public string Pozn2 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCislo { get; set; }

        public ICollection<Imodpis> Imodpis { get; set; }
        public ICollection<ImodpisM> ImodpisM { get; set; }
        public ICollection<Impohyb> Impohyb { get; set; }
        public ICollection<Impredm> Impredm { get; set; }
        public ICollection<Imuodpis> Imuodpis { get; set; }
    }
}
