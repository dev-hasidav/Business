using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SKasaSkzButton
    {
        public SKasaSkzButton()
        {
            SKasaSkzButtonPol = new HashSet<SKasaSkzButtonPol>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefKasa { get; set; }
        public int? RefSkzButton { get; set; }
        public int? UsrOrder { get; set; }
        public int? Poradi { get; set; }
        public string Ids { get; set; }
        public int? ButtonColor { get; set; }
        public int? TextColor { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }

        public Kasa RefKasaNavigation { get; set; }
        public ICollection<SKasaSkzButtonPol> SKasaSkzButtonPol { get; set; }
    }
}
