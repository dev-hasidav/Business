using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet.Test
{


    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/response.xsd", IsNullable = false)]
    //public partial class responsePack
    //{

    //    private responsePackResponsePackItem[] responsePackItemField;

    //    private decimal versionField;

    //    private string idField;

    //    private string stateField;

    //    private string programVersionField;

    //    private byte icoField;

    //    private string keyField;

    //    private string noteField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("responsePackItem")]
    //    public responsePackResponsePackItem[] responsePackItem
    //    {
    //        get
    //        {
    //            return this.responsePackItemField;
    //        }
    //        set
    //        {
    //            this.responsePackItemField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public decimal version
    //    {
    //        get
    //        {
    //            return this.versionField;
    //        }
    //        set
    //        {
    //            this.versionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string id
    //    {
    //        get
    //        {
    //            return this.idField;
    //        }
    //        set
    //        {
    //            this.idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string state
    //    {
    //        get
    //        {
    //            return this.stateField;
    //        }
    //        set
    //        {
    //            this.stateField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string programVersion
    //    {
    //        get
    //        {
    //            return this.programVersionField;
    //        }
    //        set
    //        {
    //            this.programVersionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public byte ico
    //    {
    //        get
    //        {
    //            return this.icoField;
    //        }
    //        set
    //        {
    //            this.icoField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string key
    //    {
    //        get
    //        {
    //            return this.keyField;
    //        }
    //        set
    //        {
    //            this.keyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string note
    //    {
    //        get
    //        {
    //            return this.noteField;
    //        }
    //        set
    //        {
    //            this.noteField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
    //public partial class responsePackResponsePackItem
    //{

    //    private voucherResponse voucherResponseField;

    //    private invoiceResponse invoiceResponseField;

    //    private decimal versionField;

    //    private string idField;

    //    private string stateField;

    //    private string noteField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //    public voucherResponse voucherResponse
    //    {
    //        get
    //        {
    //            return this.voucherResponseField;
    //        }
    //        set
    //        {
    //            this.voucherResponseField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //    public invoiceResponse invoiceResponse
    //    {
    //        get
    //        {
    //            return this.invoiceResponseField;
    //        }
    //        set
    //        {
    //            this.invoiceResponseField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public decimal version
    //    {
    //        get
    //        {
    //            return this.versionField;
    //        }
    //        set
    //        {
    //            this.versionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string id
    //    {
    //        get
    //        {
    //            return this.idField;
    //        }
    //        set
    //        {
    //            this.idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string state
    //    {
    //        get
    //        {
    //            return this.stateField;
    //        }
    //        set
    //        {
    //            this.stateField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string note
    //    {
    //        get
    //        {
    //            return this.noteField;
    //        }
    //        set
    //        {
    //            this.noteField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IsNullable = false)]
    //public partial class voucherResponse
    //{

    //    private importDetailsDetail[] importDetailsField;

    //    private producedDetails producedDetailsField;

    //    private decimal versionField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("detail", IsNullable = false)]
    //    public importDetailsDetail[] importDetails
    //    {
    //        get
    //        {
    //            return this.importDetailsField;
    //        }
    //        set
    //        {
    //            this.importDetailsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //    public producedDetails producedDetails
    //    {
    //        get
    //        {
    //            return this.producedDetailsField;
    //        }
    //        set
    //        {
    //            this.producedDetailsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public decimal version
    //    {
    //        get
    //        {
    //            return this.versionField;
    //        }
    //        set
    //        {
    //            this.versionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string state
    //    {
    //        get
    //        {
    //            return this.stateField;
    //        }
    //        set
    //        {
    //            this.stateField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //public partial class importDetailsDetail
    //{

    //    private string stateField;

    //    private ushort errnoField;

    //    private string noteField;

    //    private string xPathField;

    //    private string valueRequestedField;

    //    private string valueProducedField;

    //    /// <remarks/>
    //    public string state
    //    {
    //        get
    //        {
    //            return this.stateField;
    //        }
    //        set
    //        {
    //            this.stateField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public ushort errno
    //    {
    //        get
    //        {
    //            return this.errnoField;
    //        }
    //        set
    //        {
    //            this.errnoField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string note
    //    {
    //        get
    //        {
    //            return this.noteField;
    //        }
    //        set
    //        {
    //            this.noteField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string XPath
    //    {
    //        get
    //        {
    //            return this.xPathField;
    //        }
    //        set
    //        {
    //            this.xPathField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string valueRequested
    //    {
    //        get
    //        {
    //            return this.valueRequestedField;
    //        }
    //        set
    //        {
    //            this.valueRequestedField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string valueProduced
    //    {
    //        get
    //        {
    //            return this.valueProducedField;
    //        }
    //        set
    //        {
    //            this.valueProducedField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd", IsNullable = false)]
    //public partial class producedDetails
    //{

    //    private ushort idField;

    //    private string numberField;

    //    private string actionTypeField;

    //    /// <remarks/>
    //    public ushort id
    //    {
    //        get
    //        {
    //            return this.idField;
    //        }
    //        set
    //        {
    //            this.idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string number
    //    {
    //        get
    //        {
    //            return this.numberField;
    //        }
    //        set
    //        {
    //            this.numberField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string actionType
    //    {
    //        get
    //        {
    //            return this.actionTypeField;
    //        }
    //        set
    //        {
    //            this.actionTypeField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    //public partial class invoiceResponse
    //{

    //    private importDetailsDetail[] importDetailsField;

    //    private producedDetails producedDetailsField;

    //    private decimal versionField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("detail", IsNullable = false)]
    //    public importDetailsDetail[] importDetails
    //    {
    //        get
    //        {
    //            return this.importDetailsField;
    //        }
    //        set
    //        {
    //            this.importDetailsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //    public producedDetails producedDetails
    //    {
    //        get
    //        {
    //            return this.producedDetailsField;
    //        }
    //        set
    //        {
    //            this.producedDetailsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public decimal version
    //    {
    //        get
    //        {
    //            return this.versionField;
    //        }
    //        set
    //        {
    //            this.versionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute()]
    //    public string state
    //    {
    //        get
    //        {
    //            return this.stateField;
    //        }
    //        set
    //        {
    //            this.stateField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/documentresponse.xsd", IsNullable = false)]
    //public partial class importDetails
    //{

    //    private importDetailsDetail[] detailField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("detail")]
    //    public importDetailsDetail[] detail
    //    {
    //        get
    //        {
    //            return this.detailField;
    //        }
    //        set
    //        {
    //            this.detailField = value;
    //        }
    //    }
    //}






}
