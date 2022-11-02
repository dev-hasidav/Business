using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    /// <summary>
    /// PartnerIdentity  -  contractDescPartnerIdentity
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    public partial class PartnerIdentity
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        public int id { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        public Address address { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
        public ShipToAddress shipToAddress { get; set; }
    }
}
