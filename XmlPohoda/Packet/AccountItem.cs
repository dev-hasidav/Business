using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    public partial class AccountItem
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        public string accountNumber { get; set; }

        /// <remarks/>
        public string symSpec { get; set; }

        /// <remarks/>
        public string bankCode { get; set; }

        /// <remarks/>
        public bool defaultAccount { get; set; }
    }
}
