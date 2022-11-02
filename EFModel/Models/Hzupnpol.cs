using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Hzupnpol
    {
        public int Id { get; set; }
        public int? RefAg { get; set; }
        public int? RefZam { get; set; }
        public int? RefNeprit { get; set; }
        public int? RefStavDp { get; set; }
        public int? PoradCis { get; set; }
        public int? RokMz { get; set; }
        public int? MesicMz { get; set; }
        public bool Zahranicni { get; set; }
        public string CisloPotvrzeni { get; set; }
        public string KodOssz { get; set; }
        public string NazevOssz { get; set; }
        public DateTime? DatumVystaveni { get; set; }
        public bool OpravnePodani { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Titul { get; set; }
        public string RodCisl { get; set; }
        public DateTime? DatNar { get; set; }
        public string JmZam { get; set; }
        public string Iczam { get; set; }
        public string Vszam { get; set; }
        public bool NavratDoPrace { get; set; }
        public string DuvodNavratuDoPrace { get; set; }
        public DateTime? DatumNavratuDoPrace { get; set; }
        public float? PocetOdpracHodinPoslDenPd { get; set; }
        public float? PracovniDobaPoslDenPd { get; set; }
        public string DuvodPisemnehoVystaveni { get; set; }

        public Hzupn RefAgNavigation { get; set; }
    }
}
