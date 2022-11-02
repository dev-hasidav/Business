using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkzVc
    {
        public SkzVc()
        {
            SkzVchst = new HashSet<SkzVchst>();
            SkzVcpoh = new HashSet<SkzVcpoh>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public string Vcislo { get; set; }
        public double? StavVc { get; set; }
        public string Ids { get; set; }
        public string Nazev { get; set; }
        public int? RefStruct { get; set; }
        public int? RelSkzVc { get; set; }
        public DateTime? DatExp { get; set; }
        public double? Reklam { get; set; }
        public double? Servis { get; set; }
        public string Pozn { get; set; }
        public bool MPohoda { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Skz RefAgNavigation { get; set; }
        public ICollection<SkzVchst> SkzVchst { get; set; }
        public ICollection<SkzVcpoh> SkzVcpoh { get; set; }
    }
}
