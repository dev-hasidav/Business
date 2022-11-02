using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd", IsNullable = false)]
    public partial class ListAddressBook
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("addressbook")]
        public List<Addressbook> addressbook { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime dateTimeStamp { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime dateValidFrom { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public enumState state { get; set; }
    }
}
