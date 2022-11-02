using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    public partial class BankDetail
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("bankItem")]
        public List<BankItem> bankItem { get; set; }
    }
}
