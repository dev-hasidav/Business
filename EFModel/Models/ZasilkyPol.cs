using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class ZasilkyPol
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? OrderFld { get; set; }
        public string Cislo { get; set; }
        public int? RelStavOz { get; set; }
        public string StavOz { get; set; }
        public int? RelTermDoruc { get; set; }
        public int? RelSluzbaNakl { get; set; }
        public int? RelSluzbaVykl { get; set; }
        public int? RelForUhOz { get; set; }
        public string Druh { get; set; }
        public string Sluzby { get; set; }
        public string DruhObalu { get; set; }
        public decimal? Cena { get; set; }
        public decimal? Dobirka { get; set; }
        public int? RefCm { get; set; }
        public string VarSym { get; set; }
        public string VarSymPk { get; set; }
        public double? Hmotnost { get; set; }
        public int? RefUcet { get; set; }
        public string ParovaciIds { get; set; }
        public string Obsah { get; set; }
        public string PodavatelId { get; set; }
        public int? DruhSk { get; set; }
        public int? ZpusobUhrady { get; set; }
        public int? Trida { get; set; }
        public decimal? Pojisteni { get; set; }
        public decimal? Postovne { get; set; }
        public int? PocetKusu { get; set; }
        public int? DobaUlozeni { get; set; }
        public int? DruhPpp { get; set; }
        public int? Obal { get; set; }
        public string ObsahSk { get; set; }
        public string JmenoZpet { get; set; }
        public string UliceZpet { get; set; }
        public string ObecZpet { get; set; }
        public string Psczpet { get; set; }
        public int? RelTypDoruceni { get; set; }
        public string PobockaId { get; set; }
        public string Odesilatel { get; set; }
        public int? VelikostX { get; set; }
        public int? VelikostY { get; set; }
        public int? VelikostZ { get; set; }
        public double? Objem { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Zasilky RefAgNavigation { get; set; }
    }
}
