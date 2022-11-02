using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Eldppol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? Rok { get; set; }
        public string TypEldp { get; set; }
        public string Prijmeni { get; set; }
        public string Jmeno { get; set; }
        public string Titul { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Obec { get; set; }
        public string Posta { get; set; }
        public string Psc { get; set; }
        public string Stat { get; set; }
        public string RodCisl { get; set; }
        public DateTime? DatNar { get; set; }
        public string Rozena { get; set; }
        public string MistoNar { get; set; }
        public DateTime? DatOpr { get; set; }
        public int? RefZampomer1 { get; set; }
        public string Kod1 { get; set; }
        public string Mr1 { get; set; }
        public DateTime? DatOd1 { get; set; }
        public DateTime? DatDo1 { get; set; }
        public int? Dny1 { get; set; }
        public bool Mes1R1 { get; set; }
        public bool Mes2R1 { get; set; }
        public bool Mes3R1 { get; set; }
        public bool Mes4R1 { get; set; }
        public bool Mes5R1 { get; set; }
        public bool Mes6R1 { get; set; }
        public bool Mes7R1 { get; set; }
        public bool Mes8R1 { get; set; }
        public bool Mes9R1 { get; set; }
        public bool Mes10R1 { get; set; }
        public bool Mes11R1 { get; set; }
        public bool Mes12R1 { get; set; }
        public bool Mes112r1 { get; set; }
        public int? VylDoby1 { get; set; }
        public decimal? VymZakl1 { get; set; }
        public int? DobyOdec1 { get; set; }
        public int? RefZampomer2 { get; set; }
        public string Kod2 { get; set; }
        public string Mr2 { get; set; }
        public DateTime? DatOd2 { get; set; }
        public DateTime? DatDo2 { get; set; }
        public int? Dny2 { get; set; }
        public bool Mes1R2 { get; set; }
        public bool Mes2R2 { get; set; }
        public bool Mes3R2 { get; set; }
        public bool Mes4R2 { get; set; }
        public bool Mes5R2 { get; set; }
        public bool Mes6R2 { get; set; }
        public bool Mes7R2 { get; set; }
        public bool Mes8R2 { get; set; }
        public bool Mes9R2 { get; set; }
        public bool Mes10R2 { get; set; }
        public bool Mes11R2 { get; set; }
        public bool Mes12R2 { get; set; }
        public bool Mes112r2 { get; set; }
        public int? VylDoby2 { get; set; }
        public decimal? VymZakl2 { get; set; }
        public int? DobyOdec2 { get; set; }
        public int? RefZampomer3 { get; set; }
        public string Kod3 { get; set; }
        public string Mr3 { get; set; }
        public DateTime? DatOd3 { get; set; }
        public DateTime? DatDo3 { get; set; }
        public int? Dny3 { get; set; }
        public bool Mes1R3 { get; set; }
        public bool Mes2R3 { get; set; }
        public bool Mes3R3 { get; set; }
        public bool Mes4R3 { get; set; }
        public bool Mes5R3 { get; set; }
        public bool Mes6R3 { get; set; }
        public bool Mes7R3 { get; set; }
        public bool Mes8R3 { get; set; }
        public bool Mes9R3 { get; set; }
        public bool Mes10R3 { get; set; }
        public bool Mes11R3 { get; set; }
        public bool Mes12R3 { get; set; }
        public bool Mes112r3 { get; set; }
        public int? VylDoby3 { get; set; }
        public decimal? VymZakl3 { get; set; }
        public int? DobyOdec3 { get; set; }
        public string Druh1 { get; set; }
        public DateTime? DatOdD1 { get; set; }
        public DateTime? DatDoD1 { get; set; }
        public string Druh2 { get; set; }
        public DateTime? DatOdD2 { get; set; }
        public DateTime? DatDoD2 { get; set; }
        public DateTime? DatOdVco { get; set; }
        public int? RefStavDp { get; set; }
        public string Err { get; set; }

        public Eldp RefAgNavigation { get; set; }
    }
}
