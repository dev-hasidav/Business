using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SkSt
    {
        public SkSt()
        {
            Skz = new HashSet<Skz>();
        }

        public int Id { get; set; }
        public int? UsrOrder { get; set; }
        public bool Sel { get; set; }
        public int? RefSklad { get; set; }
        public string Vetev1 { get; set; }
        public string Vetev2 { get; set; }
        public string Vetev3 { get; set; }
        public string Vetev4 { get; set; }
        public string Vetev5 { get; set; }
        public string Vetev6 { get; set; }
        public string Vetev7 { get; set; }
        public string Stext { get; set; }
        public int? RelNomIo { get; set; }
        public string IoOdd { get; set; }
        public bool OnDynTab { get; set; }
        public string Pozn { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public SSklad RefSkladNavigation { get; set; }
        public ICollection<Skz> Skz { get; set; }
    }
}
