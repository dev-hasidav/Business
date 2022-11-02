using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkCs
    {
        public SkCs()
        {
            SkCspol = new HashSet<SkCspol>();
            Skz = new HashSet<Skz>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Stext { get; set; }
        public bool PrepSlv { get; set; }
        public bool PrepVceny { get; set; }
        public bool PrepZpc { get; set; }
        public bool PrepNak { get; set; }
        public bool ZmenSknePrep { get; set; }
        public int? RelAfterMr { get; set; }
        public int? RelCenyVyr { get; set; }
        public bool OceneniVyrNc { get; set; }
        public bool UpravNc { get; set; }
        public int? RelTpZkrNc { get; set; }
        public bool SdphNc { get; set; }
        public int? RefCm { get; set; }
        public bool DenEur { get; set; }
        public int? CmMnoz { get; set; }
        public double? CmKurs { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SkCspol> SkCspol { get; set; }
        public ICollection<Skz> Skz { get; set; }
    }
}
