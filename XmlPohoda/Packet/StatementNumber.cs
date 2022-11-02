using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    public partial class StatementNumber
    {
        /// <remarks/>
        public int statementNumber { get; set; }

        /// <remarks/>
        public int numberMovement { get; set; }
    }
}
