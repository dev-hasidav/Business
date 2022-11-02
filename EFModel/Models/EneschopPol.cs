using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class EneschopPol
    {
        public EneschopPol()
        {
            EneschopPobyt = new HashSet<EneschopPobyt>();
            EneschopVychazky = new HashSet<EneschopVychazky>();
        }

        public int Id { get; set; }
        public int? RefAg { get; set; }
        public string Verze { get; set; }
        public int? RelTpNotif { get; set; }
        public string Idnotifikace { get; set; }
        public string CisloRozhod { get; set; }
        public string IdPripadu { get; set; }
        public string Zmena { get; set; }
        public string PoznNotif { get; set; }
        public DateTime? DatVznikNotif { get; set; }
        public bool IsPlatny { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime? DatNar { get; set; }
        public string RodCisl { get; set; }
        public string CizCisPojSp { get; set; }
        public int? RelDruhZ { get; set; }
        public string KodDruhZ { get; set; }
        public string NazevDruhZ { get; set; }
        public string VarSym { get; set; }
        public string Ico { get; set; }
        public bool PracUraz { get; set; }
        public bool JinaOs { get; set; }
        public bool AlkOmamn { get; set; }
        public DateTime? NeschopOd { get; set; }
        public DateTime? NeschopK { get; set; }
        public DateTime? NeschopDo { get; set; }
        public string JmenoLekare { get; set; }
        public string NazevPzs { get; set; }
        public string UliceLekar { get; set; }
        public string Cplekar { get; set; }
        public string Colekar { get; set; }
        public string ObecLekar { get; set; }
        public string Psclekar { get; set; }
        public string KodStatuLekar { get; set; }

        public Eneschop RefAgNavigation { get; set; }
        public ICollection<EneschopPobyt> EneschopPobyt { get; set; }
        public ICollection<EneschopVychazky> EneschopVychazky { get; set; }
    }
}
