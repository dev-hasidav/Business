using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class EmailsSent
    {
        public int Id { get; set; }
        public bool Sel { get; set; }
        public int? RefAg { get; set; }
        public string EmailFrom { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressCc { get; set; }
        public string EmailAddressBc { get; set; }
        public string Subject { get; set; }
        public string Stext { get; set; }
        public string Attachments { get; set; }
        public int? Priority { get; set; }
        public bool ReturnReceipt { get; set; }
        public bool DisposNotif { get; set; }
        public string StatusInfo { get; set; }
        public DateTime? Datum { get; set; }
        public string Oznacil { get; set; }
        public string Ucetni { get; set; }
        public string Creator { get; set; }
        public DateTime? DatCreate { get; set; }
        public DateTime? DatSave { get; set; }
        public string Pozn { get; set; }
    }
}
