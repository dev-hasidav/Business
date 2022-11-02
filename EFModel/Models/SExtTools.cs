using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class SExtTools
    {
        public SExtTools()
        {
            SExtToolsLog = new HashSet<SExtToolsLog>();
        }

        public int Id { get; set; }
        public bool Sel { get; set; }
        public string Ids { get; set; }
        public string Popis { get; set; }
        public int? RefAgEt { get; set; }
        public string Command { get; set; }
        public string Parameters { get; set; }
        public string Directory { get; set; }
        public bool PromtForParam { get; set; }
        public bool Wait { get; set; }
        public bool Hide { get; set; }
        public bool KillTool { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public string Pozn { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public int NullCheckIds { get; set; }

        public ICollection<SExtToolsLog> SExtToolsLog { get; set; }
    }
}
