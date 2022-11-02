using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    public partial class ShipToAddress
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified { get; set; }

        /// <remarks/>
        public string company { get; set; }

        /// <remarks/>
        public string name { get; set; }

        /// <remarks/>
        public string city { get; set; }

        /// <remarks/>
        public string street { get; set; }

        /// <remarks/>
        public bool defaultShipAddress { get; set; }

        /// <remarks/>
        public string zip { get; set; }

        /// <remarks/>
        public Ids country { get; set; } = new Ids();

        /// <remarks/>
        public string phone { get; set; }

        /// <remarks/>
        public string email { get; set; }
    }
}
