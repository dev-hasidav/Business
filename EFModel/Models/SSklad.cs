using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SSklad
    {
        public SSklad()
        {
            SkSt = new HashSet<SkSt>();
            Skz = new HashSet<Skz>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool SkMinus { get; set; }
        public int? RefUsr { get; set; }
        public int? RefPzdJ { get; set; }
        public string AucetM { get; set; }
        public string AucetZ { get; set; }
        public string AucetV { get; set; }
        public string AucetNv { get; set; }
        public string AucetP { get; set; }
        public string AucetZv { get; set; }
        public string AucetVvm { get; set; }
        public bool SynchDleSk { get; set; }
        public bool SynchSk { get; set; }
        public bool SynchNew { get; set; }
        public bool OmezSkladPlu { get; set; }
        public int? DolniMezPlu { get; set; }
        public int? HorniMezPlu { get; set; }
        public bool Reklam { get; set; }
        public string Pozn { get; set; }
        public bool MPhSynchSk { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SkSt> SkSt { get; set; }
        public ICollection<Skz> Skz { get; set; }
    }
}
