using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzInvVc
    {
        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefInvPol { get; set; }
        public int? RefSkz { get; set; }
        public int? RelAgId { get; set; }
        public int? RefDokl { get; set; }
        public int? RelSkTyp { get; set; }
        public int? RelSkDruh { get; set; }
        public string Aucet { get; set; }
        public int? RelZcTp { get; set; }
        public int? RefStruct { get; set; }
        public int? RefSklad { get; set; }
        public int? RelSkzVc { get; set; }
        public string Ids { get; set; }
        public string Ean { get; set; }
        public string Nazev { get; set; }
        public string Stext { get; set; }
        public string Mj { get; set; }
        public string Vcislo { get; set; }
        public double? StavZ { get; set; }
        public double? StavZsk { get; set; }
        public double? StavZroz { get; set; }
        public decimal? Vnakup { get; set; }
        public decimal? VnakupC { get; set; }
        public int? Plu { get; set; }
        public string Pozn { get; set; }
        public bool Audit { get; set; }
        public bool Prenes { get; set; }
        public bool PrenesInvSpol { get; set; }
        public bool Zauct { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public SkzInvLst RefAgNavigation { get; set; }
    }
}
