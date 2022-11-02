using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    public partial class Detail
    {
        /// <remarks/>
        public enumState state { get; set; }

        /// <remarks/>
        public int errno { get; set; }

        /// <remarks/>
        public string note { get; set; }

        /// <remarks/>
        public string XPath { get; set; }

        /// <remarks/>
        public string valueRequested { get; set; }

        /// <remarks/>
        public string valueProduced { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, №: {1}, note: {2}{3}{4}{5}{6}{7}{8}",
                state, errno, note,
                string.IsNullOrWhiteSpace(XPath) ? "" : ", XPath: ", XPath,
                string.IsNullOrWhiteSpace(valueProduced) ? "" : ", valueProduced: ,", valueProduced,
                string.IsNullOrWhiteSpace(valueRequested) ? "" : ", valueRequested: ", valueRequested);
        }
    }
}
