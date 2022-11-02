using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IsNullable = false)]
    public partial class Account
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("accountItem")]
        public List<AccountItem> accountItem { get; set; }
    }
}
