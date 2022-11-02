using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Eneschop
    {
        public Eneschop()
        {
            EneschopPol = new HashSet<EneschopPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string CisloRozhod { get; set; }
        public int? RefZam { get; set; }
        public int? RelStavEnes { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime? DatNar { get; set; }
        public string RodCisl { get; set; }
        public string CizCisPojSp { get; set; }
        public int? RelDruhZ { get; set; }
        public string Ico { get; set; }
        public string VarSym { get; set; }
        public bool PracUraz { get; set; }
        public bool JinaOs { get; set; }
        public bool AlkOmamn { get; set; }
        public DateTime? NeschopOd { get; set; }
        public DateTime? NeschopK { get; set; }
        public DateTime? NeschopDo { get; set; }
        public string PoznNotif { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Stext { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckCisloRozhod { get; set; }

        public Zam RefZamNavigation { get; set; }
        public ICollection<EneschopPol> EneschopPol { get; set; }
    }
}
