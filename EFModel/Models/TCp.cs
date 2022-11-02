using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TCp
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefCin { get; set; }
        public int? RefStr { get; set; }
        public string CisloZak { get; set; }
        public string Labels { get; set; }
        public string Cislo { get; set; }
        public int? RelCr { get; set; }
        public int? RefRidic { get; set; }
        public int? RelTpZam { get; set; }
        public int? RelGlxSkupSaz { get; set; }
        public double? Proc1 { get; set; }
        public double? Proc2 { get; set; }
        public double? Proc3 { get; set; }
        public double? ZvStrav { get; set; }
        public double? Kapesne { get; set; }
        public int? RelTypCp { get; set; }
        public int? RelZpDpr { get; set; }
        public int? RefVoz { get; set; }
        public bool CenyPhm { get; set; }
        public double? SpotrPru { get; set; }
        public int? RelTypVoz { get; set; }
        public int? RelDrVoz { get; set; }
        public int? RelPhm { get; set; }
        public double? ProcPhm { get; set; }
        public DateTime? DatOd { get; set; }
        public string CasOdj { get; set; }
        public string CasPrj { get; set; }
        public DateTime? DatDo { get; set; }
        public string Odjezd { get; set; }
        public string Cil { get; set; }
        public string Prijezd { get; set; }
        public string Ucel { get; set; }
        public string OstZam { get; set; }
        public DateTime? DatVyuct { get; set; }
        public DateTime? DatZauct { get; set; }
        public bool Vyuctov { get; set; }
        public bool Polozky { get; set; }
        public bool UcZal { get; set; }
        public bool UcNahr { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public bool Lock1 { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Ttext { get; set; }

        public Djvoz RefVozNavigation { get; set; }
    }
}
