using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd", IsNullable = false)]
    public partial class ImportDetails
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("detail")]
        public List<Detail> detail { get; set; }
    }
}
