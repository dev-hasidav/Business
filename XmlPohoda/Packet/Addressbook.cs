using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
    public partial class Addressbook
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        public AddressBookHeader addressbookHeader { get; set; } = new AddressBookHeader();

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
        [System.Xml.Serialization.XmlArrayItemAttribute("accountItem", IsNullable = false)]
        public List<AccountItem> addressbookAccount { get; set; } = new List<AccountItem>();

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version { get; set; } = "2.0";
    }
}
