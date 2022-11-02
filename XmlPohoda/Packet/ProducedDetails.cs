using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd", IsNullable = false)]
    public partial class ProducedDetails
    {
        /// <remarks/>
        public int id { get; set; }

        /// <remarks/>
        public string number { get; set; }

        /// <remarks/>
        public EnumActionType actionType { get; set; }
    }
}
