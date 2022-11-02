using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class EmailsTmpl
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public int? RefAg { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressCc { get; set; }
        public string EmailAddressBc { get; set; }
        public string Subject { get; set; }
        public string Stext { get; set; }
        public string Attachments { get; set; }
        public int? Priority { get; set; }
        public bool ReturnReceipt { get; set; }
        public bool DisposNotif { get; set; }
        public DateTime? Datum { get; set; }
        public string Creator { get; set; }
    }
}
