using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class TSkmvpol
    {
        public TSkmvpol()
        {
            TSkmvlist = new HashSet<TSkmvlist>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public int? RefSkz { get; set; }
        public int? RefPol { get; set; }
        public int? RelAgId { get; set; }
        public string Stext { get; set; }
        public string Kod { get; set; }
        public string Vcislo { get; set; }
        public string Pozn { get; set; }
        public int? SkzVc { get; set; }
        public double? Mnozstvi { get; set; }
        public decimal? KcJedn { get; set; }
        public decimal? Kc { get; set; }
        public double? Prenes { get; set; }
        public double? PrenesBfr { get; set; }
        public decimal? VncpohV { get; set; }
        public DateTime? DatExp { get; set; }
        public string Aucet { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int? OrderFld { get; set; }

        public TSkmv RefAgNavigation { get; set; }
        public ICollection<TSkmvlist> TSkmvlist { get; set; }
    }
}
