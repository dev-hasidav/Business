using System;
using System.Collections.Generic;

namespace EFModel.Models
{
    public partial class Cert
    {
        public int Id { get; set; }
        public string CryptHash { get; set; }
        public byte[] Data { get; set; }
    }
}
