using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Pohoda.Xml.Packet.Test
{


    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    // <remarks>responsePack</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/response.xsd", IsNullable = false)]
    //public partial class responsePack
    //{

    //    private responsePackResponsePackItem[] responsePackItemField;

    //    private decimal versionField;

    //    private byte idField;

    //    private string stateField;

    //    private string programVersionField;

    //    private byte icoField;

    //    private string keyField;

    //    private string noteField;

    //    /// <remarks/>
    //    //[System.Xml.Serialization.XmlElementAttribute("responsePackItem")]
    //    //public responsePackResponsePackItem[] responsePackItem
    //    //{
    //    //    get
    //    //    {
    //    //        return this.responsePackItemField;
    //    //    }
    //    //    set
    //    //    {
    //    //        this.responsePackItemField = value;
    //    //    }
    //    //}

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
    //    public byte id
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

    /// <remarks>responsePackResponsePackItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/response.xsd")]
    //public partial class responsePackResponsePackItem
    //{

    //    private listAddressBook listAddressBookField;

    //    private listContract listContractField;

    //    private listBank listBankField;

    //    private listVoucher listVoucherField;

    //    private listInvoice listInvoiceField;

    //    private decimal versionField;

    //    private string idField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
    //    public listAddressBook listAddressBook
    //    {
    //        get
    //        {
    //            return this.listAddressBookField;
    //        }
    //        set
    //        {
    //            this.listAddressBookField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_contract.xsd")]
    //    public listContract listContract
    //    {
    //        get
    //        {
    //            return this.listContractField;
    //        }
    //        set
    //        {
    //            this.listContractField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //    public listBank listBank
    //    {
    //        get
    //        {
    //            return this.listBankField;
    //        }
    //        set
    //        {
    //            this.listBankField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //    public listVoucher listVoucher
    //    {
    //        get
    //        {
    //            return this.listVoucherField;
    //        }
    //        set
    //        {
    //            this.listVoucherField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //    public listInvoice listInvoice
    //    {
    //        get
    //        {
    //            return this.listInvoiceField;
    //        }
    //        set
    //        {
    //            this.listInvoiceField = value;
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
    //}

    /// <remarks>listAddressBook</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd", IsNullable = false)]
    //public partial class listAddressBook
    //{

    //    private listAddressBookAddressbook[] addressbookField;

    //    private decimal versionField;

    //    private System.DateTime dateTimeStampField;

    //    private System.DateTime dateValidFromField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("addressbook")]
    //    public listAddressBookAddressbook[] addressbook
    //    {
    //        get
    //        {
    //            return this.addressbookField;
    //        }
    //        set
    //        {
    //            this.addressbookField = value;
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
    //    public System.DateTime dateTimeStamp
    //    {
    //        get
    //        {
    //            return this.dateTimeStampField;
    //        }
    //        set
    //        {
    //            this.dateTimeStampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    //    public System.DateTime dateValidFrom
    //    {
    //        get
    //        {
    //            return this.dateValidFromField;
    //        }
    //        set
    //        {
    //            this.dateValidFromField = value;
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

    /// <remarks>listAddressBookAddressbook</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_addBook.xsd")]
    //public partial class listAddressBookAddressbook
    //{

    //    private addressbookHeader addressbookHeaderField;

    //    private addressbookAccountAccountItem[] addressbookAccountField;

    //    private decimal versionField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //    public addressbookHeader addressbookHeader
    //    {
    //        get
    //        {
    //            return this.addressbookHeaderField;
    //        }
    //        set
    //        {
    //            this.addressbookHeaderField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("accountItem", IsNullable = false)]
    //    public addressbookAccountAccountItem[] addressbookAccount
    //    {
    //        get
    //        {
    //            return this.addressbookAccountField;
    //        }
    //        set
    //        {
    //            this.addressbookAccountField = value;
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
    //}

    /// <remarks>AddressBookHeader</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IsNullable = false)]
    //public partial class AddressBookHeader
    //{

    //    private object[] itemsField;

    //    private ItemsChoiceType1[] itemsElementNameField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("accountForInvoicing", typeof(addressbookHeaderAccountForInvoicing))]
    //    [System.Xml.Serialization.XmlElementAttribute("accountingReceivedInvoice", typeof(addressbookHeaderAccountingReceivedInvoice))]
    //    [System.Xml.Serialization.XmlElementAttribute("activity", typeof(addressbookHeaderActivity))]
    //    [System.Xml.Serialization.XmlElementAttribute("adGroup", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("adKey", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("centre", typeof(addressbookHeaderCentre))]
    //    [System.Xml.Serialization.XmlElementAttribute("classificationVATReceivedInvoice", typeof(addressbookHeaderClassificationVATReceivedInvoice))]
    //    [System.Xml.Serialization.XmlElementAttribute("email", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("fax", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("id", typeof(ushort))]
    //    [System.Xml.Serialization.XmlElementAttribute("identity", typeof(addressbookHeaderIdentity))]
    //    [System.Xml.Serialization.XmlElementAttribute("markRecord", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("mobil", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("note", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("number", typeof(addressbookHeaderNumber))]
    //    [System.Xml.Serialization.XmlElementAttribute("p1", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("p2", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("p3", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("p4", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("p5", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("p6", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("paymentType", typeof(addressbookHeaderPaymentType))]
    //    [System.Xml.Serialization.XmlElementAttribute("phone", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("priceIDS", typeof(object))]
    //    [System.Xml.Serialization.XmlElementAttribute("region", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("turnover", typeof(byte))]
    //    [System.Xml.Serialization.XmlElementAttribute("web", typeof(string))]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public object[] Items
    //    {
    //        get
    //        {
    //            return this.itemsField;
    //        }
    //        set
    //        {
    //            this.itemsField = value;
    //        }
    //    }

    // <remarks>responsePack</remarks>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType1[] ItemsElementName
    //    {
    //        get
    //        {
    //            return this.itemsElementNameField;
    //        }
    //        set
    //        {
    //            this.itemsElementNameField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderAccountForInvoicing</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderAccountForInvoicing
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string accountNoField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountNo
    //    {
    //        get
    //        {
    //            return this.accountNoField;
    //        }
    //        set
    //        {
    //            this.accountNoField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderAccountingReceivedInvoice</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderAccountingReceivedInvoice
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>Activity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class Activity
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderCentre</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderCentre
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderClassificationVATReceivedInvoice</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderClassificationVATReceivedInvoice
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderIdentity
    //{

    //    private address addressField;

    //    private shipToAddress shipToAddressField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public shipToAddress shipToAddress
    //    {
    //        get
    //        {
    //            return this.shipToAddressField;
    //        }
    //        set
    //        {
    //            this.shipToAddressField = value;
    //        }
    //    }
    //}

    /// <remarks>address</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class address
    //{

    //    private object[] itemsField;

    //    private ItemsChoiceType[] itemsElementNameField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("city", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("company", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("country", typeof(addressCountry))]
    //    [System.Xml.Serialization.XmlElementAttribute("dic", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("division", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("email", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("fax", typeof(long))]
    //    [System.Xml.Serialization.XmlElementAttribute("ico", typeof(uint))]
    //    [System.Xml.Serialization.XmlElementAttribute("mobilPhone", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("number", typeof(ushort))]
    //    [System.Xml.Serialization.XmlElementAttribute("phone", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("street", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("surname", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("www", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("zip", typeof(string))]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public object[] Items
    //    {
    //        get
    //        {
    //            return this.itemsField;
    //        }
    //        set
    //        {
    //            this.itemsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType[] ItemsElementName
    //    {
    //        get
    //        {
    //            return this.itemsElementNameField;
    //        }
    //        set
    //        {
    //            this.itemsElementNameField = value;
    //        }
    //    }
    //}

    /// <remarks>addressCountry</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //public partial class addressCountry
    //{

    //    private byte idField;

    //    private string idsField;

    //    /// <remarks/>
    //    public byte id
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
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>ItemsChoiceType</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IncludeInSchema = false)]
    //public enum ItemsChoiceType
    //{

    //    /// <remarks/>
    //    city,

    //    /// <remarks/>
    //    company,

    //    /// <remarks/>
    //    country,

    //    /// <remarks/>
    //    dic,

    //    /// <remarks/>
    //    division,

    //    /// <remarks/>
    //    email,

    //    /// <remarks/>
    //    fax,

    //    /// <remarks/>
    //    ico,

    //    /// <remarks/>
    //    mobilPhone,

    //    /// <remarks/>
    //    name,

    //    /// <remarks/>
    //    number,

    //    /// <remarks/>
    //    phone,

    //    /// <remarks/>
    //    street,

    //    /// <remarks/>
    //    surname,

    //    /// <remarks/>
    //    www,

    //    /// <remarks/>
    //    zip,
    //}

    /// <remarks>shipToAddress</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class shipToAddress
    //{

    //    private byte idField;

    //    private bool idFieldSpecified;

    //    private string companyField;

    //    private object nameField;

    //    private string cityField;

    //    private string streetField;

    //    private bool defaultShipAddressField;

    //    private bool defaultShipAddressFieldSpecified;

    //    private string zipField;

    //    private shipToAddressCountry countryField;

    //    private object phoneField;

    //    private object emailField;

    //    /// <remarks/>
    //    public byte id
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string company
    //    {
    //        get
    //        {
    //            return this.companyField;
    //        }
    //        set
    //        {
    //            this.companyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public object name
    //    {
    //        get
    //        {
    //            return this.nameField;
    //        }
    //        set
    //        {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string city
    //    {
    //        get
    //        {
    //            return this.cityField;
    //        }
    //        set
    //        {
    //            this.cityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string street
    //    {
    //        get
    //        {
    //            return this.streetField;
    //        }
    //        set
    //        {
    //            this.streetField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool defaultShipAddress
    //    {
    //        get
    //        {
    //            return this.defaultShipAddressField;
    //        }
    //        set
    //        {
    //            this.defaultShipAddressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool defaultShipAddressSpecified
    //    {
    //        get
    //        {
    //            return this.defaultShipAddressFieldSpecified;
    //        }
    //        set
    //        {
    //            this.defaultShipAddressFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string zip
    //    {
    //        get
    //        {
    //            return this.zipField;
    //        }
    //        set
    //        {
    //            this.zipField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public shipToAddressCountry country
    //    {
    //        get
    //        {
    //            return this.countryField;
    //        }
    //        set
    //        {
    //            this.countryField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public object phone
    //    {
    //        get
    //        {
    //            return this.phoneField;
    //        }
    //        set
    //        {
    //            this.phoneField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public object email
    //    {
    //        get
    //        {
    //            return this.emailField;
    //        }
    //        set
    //        {
    //            this.emailField = value;
    //        }
    //    }
    //}

    /// <remarks>shipToAddressCountry</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //public partial class shipToAddressCountry
    //{

    //    private sbyte idField;

    //    private object idsField;

    //    /// <remarks/>
    //    public sbyte id
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
    //    public object ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderNumber</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderNumber
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private string idsField;

    //    private string numberRequestedField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string numberRequested
    //    {
    //        get
    //        {
    //            return this.numberRequestedField;
    //        }
    //        set
    //        {
    //            this.numberRequestedField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookHeaderPaymentType</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookHeaderPaymentType
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string paymentTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string paymentType
    //    {
    //        get
    //        {
    //            return this.paymentTypeField;
    //        }
    //        set
    //        {
    //            this.paymentTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>ItemsChoiceType1</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IncludeInSchema = false)]
    //public enum ItemsChoiceType1
    //{

    //    /// <remarks/>
    //    accountForInvoicing,

    //    /// <remarks/>
    //    accountingReceivedInvoice,

    //    /// <remarks/>
    //    activity,

    //    /// <remarks/>
    //    adGroup,

    //    /// <remarks/>
    //    adKey,

    //    /// <remarks/>
    //    centre,

    //    /// <remarks/>
    //    classificationVATReceivedInvoice,

    //    /// <remarks/>
    //    email,

    //    /// <remarks/>
    //    fax,

    //    /// <remarks/>
    //    id,

    //    /// <remarks/>
    //    identity,

    //    /// <remarks/>
    //    markRecord,

    //    /// <remarks/>
    //    mobil,

    //    /// <remarks/>
    //    note,

    //    /// <remarks/>
    //    number,

    //    /// <remarks/>
    //    p1,

    //    /// <remarks/>
    //    p2,

    //    /// <remarks/>
    //    p3,

    //    /// <remarks/>
    //    p4,

    //    /// <remarks/>
    //    p5,

    //    /// <remarks/>
    //    p6,

    //    /// <remarks/>
    //    paymentType,

    //    /// <remarks/>
    //    phone,

    //    /// <remarks/>
    //    priceIDS,

    //    /// <remarks/>
    //    region,

    //    /// <remarks/>
    //    turnover,

    //    /// <remarks/>
    //    web,
    //}

    /// <remarks>addressbookAccountAccountItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //public partial class addressbookAccountAccountItem
    //{

    //    private ushort idField;

    //    private string accountNumberField;

    //    private object symSpecField;

    //    private string bankCodeField;

    //    private bool defaultAccountField;

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
    //    public string accountNumber
    //    {
    //        get
    //        {
    //            return this.accountNumberField;
    //        }
    //        set
    //        {
    //            this.accountNumberField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public object symSpec
    //    {
    //        get
    //        {
    //            return this.symSpecField;
    //        }
    //        set
    //        {
    //            this.symSpecField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string bankCode
    //    {
    //        get
    //        {
    //            return this.bankCodeField;
    //        }
    //        set
    //        {
    //            this.bankCodeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool defaultAccount
    //    {
    //        get
    //        {
    //            return this.defaultAccountField;
    //        }
    //        set
    //        {
    //            this.defaultAccountField = value;
    //        }
    //    }
    //}

    /// <remarks>listContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_contract.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list_contract.xsd", IsNullable = false)]
    //public partial class listContract
    //{

    //    private listContractContract[] contractField;

    //    private decimal versionField;

    //    private System.DateTime dateTimeStampField;

    //    private System.DateTime dateValidFromField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("contract")]
    //    public listContractContract[] contract
    //    {
    //        get
    //        {
    //            return this.contractField;
    //        }
    //        set
    //        {
    //            this.contractField = value;
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
    //    public System.DateTime dateTimeStamp
    //    {
    //        get
    //        {
    //            return this.dateTimeStampField;
    //        }
    //        set
    //        {
    //            this.dateTimeStampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    //    public System.DateTime dateValidFrom
    //    {
    //        get
    //        {
    //            return this.dateValidFromField;
    //        }
    //        set
    //        {
    //            this.dateValidFromField = value;
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

    /// <remarks>listContractContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list_contract.xsd")]
    //public partial class listContractContract
    //{

    //    private contractDesc contractDescField;

    //    private decimal versionField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    //    public contractDesc contractDesc
    //    {
    //        get
    //        {
    //            return this.contractDescField;
    //        }
    //        set
    //        {
    //            this.contractDescField = value;
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
    //}

    /// <remarks>contractDesc</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd", IsNullable = false)]
    //public partial class contractDesc
    //{

    //    private ushort idField;

    //    private contractDescNumber numberField;

    //    private System.DateTime datePlanStartField;

    //    private bool datePlanStartFieldSpecified;

    //    private System.DateTime dateStartField;

    //    private bool dateStartFieldSpecified;

    //    private System.DateTime dateDeliveryField;

    //    private bool dateDeliveryFieldSpecified;

    //    private string textField;

    //    private contractDescPartnerIdentity partnerIdentityField;

    //    private contractDescResponsiblePerson responsiblePersonField;

    //    private string contractStateField;

    //    private string ost1Field;

    //    private string ost2Field;

    //    private bool markRecordField;

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
    //    public contractDescNumber number
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
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    //    public System.DateTime datePlanStart
    //    {
    //        get
    //        {
    //            return this.datePlanStartField;
    //        }
    //        set
    //        {
    //            this.datePlanStartField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool datePlanStartSpecified
    //    {
    //        get
    //        {
    //            return this.datePlanStartFieldSpecified;
    //        }
    //        set
    //        {
    //            this.datePlanStartFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    //    public System.DateTime dateStart
    //    {
    //        get
    //        {
    //            return this.dateStartField;
    //        }
    //        set
    //        {
    //            this.dateStartField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool dateStartSpecified
    //    {
    //        get
    //        {
    //            return this.dateStartFieldSpecified;
    //        }
    //        set
    //        {
    //            this.dateStartFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    //    public System.DateTime dateDelivery
    //    {
    //        get
    //        {
    //            return this.dateDeliveryField;
    //        }
    //        set
    //        {
    //            this.dateDeliveryField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool dateDeliverySpecified
    //    {
    //        get
    //        {
    //            return this.dateDeliveryFieldSpecified;
    //        }
    //        set
    //        {
    //            this.dateDeliveryFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string text
    //    {
    //        get
    //        {
    //            return this.textField;
    //        }
    //        set
    //        {
    //            this.textField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public contractDescPartnerIdentity partnerIdentity
    //    {
    //        get
    //        {
    //            return this.partnerIdentityField;
    //        }
    //        set
    //        {
    //            this.partnerIdentityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public contractDescResponsiblePerson responsiblePerson
    //    {
    //        get
    //        {
    //            return this.responsiblePersonField;
    //        }
    //        set
    //        {
    //            this.responsiblePersonField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string contractState
    //    {
    //        get
    //        {
    //            return this.contractStateField;
    //        }
    //        set
    //        {
    //            this.contractStateField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ost1
    //    {
    //        get
    //        {
    //            return this.ost1Field;
    //        }
    //        set
    //        {
    //            this.ost1Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ost2
    //    {
    //        get
    //        {
    //            return this.ost2Field;
    //        }
    //        set
    //        {
    //            this.ost2Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool markRecord
    //    {
    //        get
    //        {
    //            return this.markRecordField;
    //        }
    //        set
    //        {
    //            this.markRecordField = value;
    //        }
    //    }
    //}

    /// <remarks>contractDescNumber</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    //public partial class contractDescNumber
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private string idsField;

    //    private string numberRequestedField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string numberRequested
    //    {
    //        get
    //        {
    //            return this.numberRequestedField;
    //        }
    //        set
    //        {
    //            this.numberRequestedField = value;
    //        }
    //    }
    //}

    /// <remarks>contractDescPartnerIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    //public partial class contractDescPartnerIdentity
    //{

    //    private ushort idField;

    //    private Address addressField;

    //    private ShipToAddress shipToAddressField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ShipToAddress shipToAddress
    //    {
    //        get
    //        {
    //            return this.shipToAddressField;
    //        }
    //        set
    //        {
    //            this.shipToAddressField = value;
    //        }
    //    }
    //}

    /// <remarks>contractDescResponsiblePerson</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/contract.xsd")]
    //public partial class contractDescResponsiblePerson
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>listBank</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd", IsNullable = false)]
    //public partial class listBank
    //{

    //    private listBankBank[] bankField;

    //    private decimal versionField;

    //    private System.DateTime dateTimeStampField;

    //    private System.DateTime dateValidFromField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("bank")]
    //    public listBankBank[] bank
    //    {
    //        get
    //        {
    //            return this.bankField;
    //        }
    //        set
    //        {
    //            this.bankField = value;
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
    //    public System.DateTime dateTimeStamp
    //    {
    //        get
    //        {
    //            return this.dateTimeStampField;
    //        }
    //        set
    //        {
    //            this.dateTimeStampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    //    public System.DateTime dateValidFrom
    //    {
    //        get
    //        {
    //            return this.dateValidFromField;
    //        }
    //        set
    //        {
    //            this.dateValidFromField = value;
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

    /// <remarks>listBankBank</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //public partial class listBankBank
    //{

    //    private bankHeader bankHeaderField;

    //    private bankDetailBankItem[] bankDetailField;

    //    private bankSummary bankSummaryField;

    //    private decimal versionField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //    public bankHeader bankHeader
    //    {
    //        get
    //        {
    //            return this.bankHeaderField;
    //        }
    //        set
    //        {
    //            this.bankHeaderField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("bankItem", IsNullable = false)]
    //    public bankDetailBankItem[] bankDetail
    //    {
    //        get
    //        {
    //            return this.bankDetailField;
    //        }
    //        set
    //        {
    //            this.bankDetailField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //    public bankSummary bankSummary
    //    {
    //        get
    //        {
    //            return this.bankSummaryField;
    //        }
    //        set
    //        {
    //            this.bankSummaryField = value;
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
    //}

    /// <remarks>bankHeader</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    //public partial class bankHeader
    //{

    //    private ushort idField;

    //    private string bankTypeField;

    //    private bankHeaderAccount accountField;

    //    private string numberField;

    //    private bankHeaderStatementNumber statementNumberField;

    //    private ulong symVarField;

    //    private bool symVarFieldSpecified;

    //    private System.DateTime dateStatementField;

    //    private System.DateTime datePaymentField;

    //    private bankHeaderAccounting accountingField;

    //    private string textField;

    //    private bankHeaderPartnerIdentity partnerIdentityField;

    //    private bankHeaderMyIdentity myIdentityField;

    //    private bankHeaderPaymentAccount paymentAccountField;

    //    private ushort symConstField;

    //    private bool symConstFieldSpecified;

    //    private ulong symSpecField;

    //    private bool symSpecFieldSpecified;

    //    private bankHeaderCentre centreField;

    //    private bankHeaderActivity activityField;

    //    private bankHeaderContract contractField;

    //    private string symParField;

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
    //    public string bankType
    //    {
    //        get
    //        {
    //            return this.bankTypeField;
    //        }
    //        set
    //        {
    //            this.bankTypeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderAccount account
    //    {
    //        get
    //        {
    //            return this.accountField;
    //        }
    //        set
    //        {
    //            this.accountField = value;
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
    //    public bankHeaderStatementNumber statementNumber
    //    {
    //        get
    //        {
    //            return this.statementNumberField;
    //        }
    //        set
    //        {
    //            this.statementNumberField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public ulong symVar
    //    {
    //        get
    //        {
    //            return this.symVarField;
    //        }
    //        set
    //        {
    //            this.symVarField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool symVarSpecified
    //    {
    //        get
    //        {
    //            return this.symVarFieldSpecified;
    //        }
    //        set
    //        {
    //            this.symVarFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    //    public System.DateTime dateStatement
    //    {
    //        get
    //        {
    //            return this.dateStatementField;
    //        }
    //        set
    //        {
    //            this.dateStatementField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    //    public System.DateTime datePayment
    //    {
    //        get
    //        {
    //            return this.datePaymentField;
    //        }
    //        set
    //        {
    //            this.datePaymentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderAccounting accounting
    //    {
    //        get
    //        {
    //            return this.accountingField;
    //        }
    //        set
    //        {
    //            this.accountingField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string text
    //    {
    //        get
    //        {
    //            return this.textField;
    //        }
    //        set
    //        {
    //            this.textField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderPartnerIdentity partnerIdentity
    //    {
    //        get
    //        {
    //            return this.partnerIdentityField;
    //        }
    //        set
    //        {
    //            this.partnerIdentityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderMyIdentity myIdentity
    //    {
    //        get
    //        {
    //            return this.myIdentityField;
    //        }
    //        set
    //        {
    //            this.myIdentityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderPaymentAccount paymentAccount
    //    {
    //        get
    //        {
    //            return this.paymentAccountField;
    //        }
    //        set
    //        {
    //            this.paymentAccountField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public ushort symConst
    //    {
    //        get
    //        {
    //            return this.symConstField;
    //        }
    //        set
    //        {
    //            this.symConstField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool symConstSpecified
    //    {
    //        get
    //        {
    //            return this.symConstFieldSpecified;
    //        }
    //        set
    //        {
    //            this.symConstFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public ulong symSpec
    //    {
    //        get
    //        {
    //            return this.symSpecField;
    //        }
    //        set
    //        {
    //            this.symSpecField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool symSpecSpecified
    //    {
    //        get
    //        {
    //            return this.symSpecFieldSpecified;
    //        }
    //        set
    //        {
    //            this.symSpecFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderCentre centre
    //    {
    //        get
    //        {
    //            return this.centreField;
    //        }
    //        set
    //        {
    //            this.centreField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderActivity activity
    //    {
    //        get
    //        {
    //            return this.activityField;
    //        }
    //        set
    //        {
    //            this.activityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankHeaderContract contract
    //    {
    //        get
    //        {
    //            return this.contractField;
    //        }
    //        set
    //        {
    //            this.contractField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string symPar
    //    {
    //        get
    //        {
    //            return this.symParField;
    //        }
    //        set
    //        {
    //            this.symParField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderAccount</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderAccount
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderStatementNumber</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderStatementNumber
    //{

    //    private byte statementNumberField;

    //    private byte numberMovementField;

    //    /// <remarks/>
    //    public byte statementNumber
    //    {
    //        get
    //        {
    //            return this.statementNumberField;
    //        }
    //        set
    //        {
    //            this.statementNumberField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public byte numberMovement
    //    {
    //        get
    //        {
    //            return this.numberMovementField;
    //        }
    //        set
    //        {
    //            this.numberMovementField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string accountingTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountingType
    //    {
    //        get
    //        {
    //            return this.accountingTypeField;
    //        }
    //        set
    //        {
    //            this.accountingTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderPartnerIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderPartnerIdentity
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private Address addressField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderMyIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderMyIdentity
    //{

    //    private Address addressField;

    //    private establishment establishmentField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public establishment establishment
    //    {
    //        get
    //        {
    //            return this.establishmentField;
    //        }
    //        set
    //        {
    //            this.establishmentField = value;
    //        }
    //    }
    //}

    /// <remarks>establishment</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class establishment
    //{

    //    private string companyField;

    //    private string cityField;

    //    private string streetField;

    //    private string zipField;

    //    /// <remarks/>
    //    public string company
    //    {
    //        get
    //        {
    //            return this.companyField;
    //        }
    //        set
    //        {
    //            this.companyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string city
    //    {
    //        get
    //        {
    //            return this.cityField;
    //        }
    //        set
    //        {
    //            this.cityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string street
    //    {
    //        get
    //        {
    //            return this.streetField;
    //        }
    //        set
    //        {
    //            this.streetField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string zip
    //    {
    //        get
    //        {
    //            return this.zipField;
    //        }
    //        set
    //        {
    //            this.zipField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderPaymentAccount</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderPaymentAccount
    //{

    //    private string accountNoField;

    //    private ushort bankCodeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountNo
    //    {
    //        get
    //        {
    //            return this.accountNoField;
    //        }
    //        set
    //        {
    //            this.accountNoField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort bankCode
    //    {
    //        get
    //        {
    //            return this.bankCodeField;
    //        }
    //        set
    //        {
    //            this.bankCodeField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderCentre</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderCentre
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderActivity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderActivity
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>bankHeaderContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankHeaderContract
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>bankDetailBankItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankDetailBankItem
    //{

    //    private string textField;

    //    private bankDetailBankItemHomeCurrency homeCurrencyField;

    //    private bankDetailBankItemForeignCurrency foreignCurrencyField;

    //    private string symParField;

    //    private bankDetailBankItemAccounting accountingField;

    //    /// <remarks/>
    //    public string text
    //    {
    //        get
    //        {
    //            return this.textField;
    //        }
    //        set
    //        {
    //            this.textField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankDetailBankItemHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankDetailBankItemForeignCurrency foreignCurrency
    //    {
    //        get
    //        {
    //            return this.foreignCurrencyField;
    //        }
    //        set
    //        {
    //            this.foreignCurrencyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string symPar
    //    {
    //        get
    //        {
    //            return this.symParField;
    //        }
    //        set
    //        {
    //            this.symParField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankDetailBankItemAccounting accounting
    //    {
    //        get
    //        {
    //            return this.accountingField;
    //        }
    //        set
    //        {
    //            this.accountingField = value;
    //        }
    //    }
    //}

    /// <remarks>bankDetailBankItemHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankDetailBankItemHomeCurrency
    //{

    //    private decimal unitPriceField;

    //    /// <remarks/>
    //    public decimal unitPrice
    //    {
    //        get
    //        {
    //            return this.unitPriceField;
    //        }
    //        set
    //        {
    //            this.unitPriceField = value;
    //        }
    //    }
    //}

    /// <remarks>bankDetailBankItemForeignCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankDetailBankItemForeignCurrency
    //{

    //    private byte unitPriceField;

    //    /// <remarks/>
    //    public byte unitPrice
    //    {
    //        get
    //        {
    //            return this.unitPriceField;
    //        }
    //        set
    //        {
    //            this.unitPriceField = value;
    //        }
    //    }
    //}

    /// <remarks>bankDetailBankItemAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankDetailBankItemAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>bankSummary</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    //public partial class bankSummary
    //{

    //    private string roundingDocumentField;

    //    private string roundingVATField;

    //    private bankSummaryHomeCurrency homeCurrencyField;

    //    /// <remarks/>
    //    public string roundingDocument
    //    {
    //        get
    //        {
    //            return this.roundingDocumentField;
    //        }
    //        set
    //        {
    //            this.roundingDocumentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string roundingVAT
    //    {
    //        get
    //        {
    //            return this.roundingVATField;
    //        }
    //        set
    //        {
    //            this.roundingVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bankSummaryHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
    //        }
    //    }
    //}

    /// <remarks>bankSummaryHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //public partial class bankSummaryHomeCurrency
    //{

    //    private decimal priceNoneField;

    //    private ushort priceLowField;

    //    private byte priceLowVATField;

    //    private ushort priceLowSumField;

    //    private decimal priceHighField;

    //    private decimal priceHighVATField;

    //    private decimal priceHighSumField;

    //    private byte price3Field;

    //    private byte price3VATField;

    //    private byte price3SumField;

    //    private round roundField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceNone
    //    {
    //        get
    //        {
    //            return this.priceNoneField;
    //        }
    //        set
    //        {
    //            this.priceNoneField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLow
    //    {
    //        get
    //        {
    //            return this.priceLowField;
    //        }
    //        set
    //        {
    //            this.priceLowField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte priceLowVAT
    //    {
    //        get
    //        {
    //            return this.priceLowVATField;
    //        }
    //        set
    //        {
    //            this.priceLowVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLowSum
    //    {
    //        get
    //        {
    //            return this.priceLowSumField;
    //        }
    //        set
    //        {
    //            this.priceLowSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHigh
    //    {
    //        get
    //        {
    //            return this.priceHighField;
    //        }
    //        set
    //        {
    //            this.priceHighField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighVAT
    //    {
    //        get
    //        {
    //            return this.priceHighVATField;
    //        }
    //        set
    //        {
    //            this.priceHighVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighSum
    //    {
    //        get
    //        {
    //            return this.priceHighSumField;
    //        }
    //        set
    //        {
    //            this.priceHighSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3
    //    {
    //        get
    //        {
    //            return this.price3Field;
    //        }
    //        set
    //        {
    //            this.price3Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3VAT
    //    {
    //        get
    //        {
    //            return this.price3VATField;
    //        }
    //        set
    //        {
    //            this.price3VATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3Sum
    //    {
    //        get
    //        {
    //            return this.price3SumField;
    //        }
    //        set
    //        {
    //            this.price3SumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public round round
    //    {
    //        get
    //        {
    //            return this.roundField;
    //        }
    //        set
    //        {
    //            this.roundField = value;
    //        }
    //    }
    //}

    /// <remarks>round</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class round
    //{

    //    private decimal priceRoundField;

    //    /// <remarks/>
    //    public decimal priceRound
    //    {
    //        get
    //        {
    //            return this.priceRoundField;
    //        }
    //        set
    //        {
    //            this.priceRoundField = value;
    //        }
    //    }
    //}

    /// <remarks>listVoucher</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd", IsNullable = false)]
    //public partial class listVoucher
    //{

    //    private listVoucherVoucher[] voucherField;

    //    private decimal versionField;

    //    private System.DateTime dateTimeStampField;

    //    private System.DateTime dateValidFromField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("voucher")]
    //    public listVoucherVoucher[] voucher
    //    {
    //        get
    //        {
    //            return this.voucherField;
    //        }
    //        set
    //        {
    //            this.voucherField = value;
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
    //    public System.DateTime dateTimeStamp
    //    {
    //        get
    //        {
    //            return this.dateTimeStampField;
    //        }
    //        set
    //        {
    //            this.dateTimeStampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    //    public System.DateTime dateValidFrom
    //    {
    //        get
    //        {
    //            return this.dateValidFromField;
    //        }
    //        set
    //        {
    //            this.dateValidFromField = value;
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

    /// <remarks>listVoucherVoucher</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //public partial class listVoucherVoucher
    //{

    //    private voucherHeader voucherHeaderField;

    //    private voucherDetailVoucherItem[] voucherDetailField;

    //    private voucherSummary voucherSummaryField;

    //    private EET eETField;

    //    private decimal versionField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //    public voucherHeader voucherHeader
    //    {
    //        get
    //        {
    //            return this.voucherHeaderField;
    //        }
    //        set
    //        {
    //            this.voucherHeaderField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("voucherItem", IsNullable = false)]
    //    public voucherDetailVoucherItem[] voucherDetail
    //    {
    //        get
    //        {
    //            return this.voucherDetailField;
    //        }
    //        set
    //        {
    //            this.voucherDetailField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //    public voucherSummary voucherSummary
    //    {
    //        get
    //        {
    //            return this.voucherSummaryField;
    //        }
    //        set
    //        {
    //            this.voucherSummaryField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //    public EET EET
    //    {
    //        get
    //        {
    //            return this.eETField;
    //        }
    //        set
    //        {
    //            this.eETField = value;
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
    //}

    /// <remarks>voucherHeader</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IsNullable = false)]
    //public partial class voucherHeader
    //{

    //    private object[] itemsField;

    //    private ItemsChoiceType2[] itemsElementNameField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("accounting", typeof(voucherHeaderAccounting))]
    //    [System.Xml.Serialization.XmlElementAttribute("activity", typeof(voucherHeaderActivity))]
    //    [System.Xml.Serialization.XmlElementAttribute("cashAccount", typeof(voucherHeaderCashAccount))]
    //    [System.Xml.Serialization.XmlElementAttribute("centre", typeof(voucherHeaderCentre))]
    //    [System.Xml.Serialization.XmlElementAttribute("classificationVAT", typeof(voucherHeaderClassificationVAT))]
    //    [System.Xml.Serialization.XmlElementAttribute("contract", typeof(voucherHeaderContract))]
    //    [System.Xml.Serialization.XmlElementAttribute("date", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("datePayment", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("dateTax", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("id", typeof(ushort))]
    //    [System.Xml.Serialization.XmlElementAttribute("markRecord", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("myIdentity", typeof(voucherHeaderMyIdentity))]
    //    [System.Xml.Serialization.XmlElementAttribute("number", typeof(voucherHeaderNumber))]
    //    [System.Xml.Serialization.XmlElementAttribute("originalDocument", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("partnerIdentity", typeof(voucherHeaderPartnerIdentity))]
    //    [System.Xml.Serialization.XmlElementAttribute("symPar", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("voucherType", typeof(string))]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public object[] Items
    //    {
    //        get
    //        {
    //            return this.itemsField;
    //        }
    //        set
    //        {
    //            this.itemsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType2[] ItemsElementName
    //    {
    //        get
    //        {
    //            return this.itemsElementNameField;
    //        }
    //        set
    //        {
    //            this.itemsElementNameField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string accountingTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountingType
    //    {
    //        get
    //        {
    //            return this.accountingTypeField;
    //        }
    //        set
    //        {
    //            this.accountingTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderActivity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderActivity
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderCashAccount</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderCashAccount
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderCentre</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderCentre
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderClassificationVAT</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderClassificationVAT
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string classificationVATTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string classificationVATType
    //    {
    //        get
    //        {
    //            return this.classificationVATTypeField;
    //        }
    //        set
    //        {
    //            this.classificationVATTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderContract
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderMyIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderMyIdentity
    //{

    //    private Address addressField;

    //    private Establishment establishmentField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Establishment establishment
    //    {
    //        get
    //        {
    //            return this.establishmentField;
    //        }
    //        set
    //        {
    //            this.establishmentField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderNumber</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderNumber
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string numberRequestedField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string numberRequested
    //    {
    //        get
    //        {
    //            return this.numberRequestedField;
    //        }
    //        set
    //        {
    //            this.numberRequestedField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherHeaderPartnerIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherHeaderPartnerIdentity
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private Address addressField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }
    //}

    /// <remarks>ItemsChoiceType2</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IncludeInSchema = false)]
    //public enum ItemsChoiceType2
    //{

    //    /// <remarks/>
    //    accounting,

    //    /// <remarks/>
    //    activity,

    //    /// <remarks/>
    //    cashAccount,

    //    /// <remarks/>
    //    centre,

    //    /// <remarks/>
    //    classificationVAT,

    //    /// <remarks/>
    //    contract,

    //    /// <remarks/>
    //    date,

    //    /// <remarks/>
    //    datePayment,

    //    /// <remarks/>
    //    dateTax,

    //    /// <remarks/>
    //    id,

    //    /// <remarks/>
    //    markRecord,

    //    /// <remarks/>
    //    myIdentity,

    //    /// <remarks/>
    //    number,

    //    /// <remarks/>
    //    originalDocument,

    //    /// <remarks/>
    //    partnerIdentity,

    //    /// <remarks/>
    //    symPar,

    //    /// <remarks/>
    //    text,

    //    /// <remarks/>
    //    voucherType,
    //}

    /// <remarks>voucherDetailVoucherItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherDetailVoucherItem
    //{

    //    private string textField;

    //    private decimal quantityField;

    //    private decimal coefficientField;

    //    private bool coefficientFieldSpecified;

    //    private bool payVATField;

    //    private string rateVATField;

    //    private decimal discountPercentageField;

    //    private voucherDetailVoucherItemHomeCurrency homeCurrencyField;

    //    private ulong symParField;

    //    private bool symParFieldSpecified;

    //    private string noteField;

    //    private voucherDetailVoucherItemAccounting accountingField;

    //    private voucherDetailVoucherItemClassificationVAT classificationVATField;

    //    private voucherDetailVoucherItemContract contractField;

    //    /// <remarks/>
    //    public string text
    //    {
    //        get
    //        {
    //            return this.textField;
    //        }
    //        set
    //        {
    //            this.textField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal quantity
    //    {
    //        get
    //        {
    //            return this.quantityField;
    //        }
    //        set
    //        {
    //            this.quantityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal coefficient
    //    {
    //        get
    //        {
    //            return this.coefficientField;
    //        }
    //        set
    //        {
    //            this.coefficientField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool coefficientSpecified
    //    {
    //        get
    //        {
    //            return this.coefficientFieldSpecified;
    //        }
    //        set
    //        {
    //            this.coefficientFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool payVAT
    //    {
    //        get
    //        {
    //            return this.payVATField;
    //        }
    //        set
    //        {
    //            this.payVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string rateVAT
    //    {
    //        get
    //        {
    //            return this.rateVATField;
    //        }
    //        set
    //        {
    //            this.rateVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal discountPercentage
    //    {
    //        get
    //        {
    //            return this.discountPercentageField;
    //        }
    //        set
    //        {
    //            this.discountPercentageField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public voucherDetailVoucherItemHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public ulong symPar
    //    {
    //        get
    //        {
    //            return this.symParField;
    //        }
    //        set
    //        {
    //            this.symParField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool symParSpecified
    //    {
    //        get
    //        {
    //            return this.symParFieldSpecified;
    //        }
    //        set
    //        {
    //            this.symParFieldSpecified = value;
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
    //    public voucherDetailVoucherItemAccounting accounting
    //    {
    //        get
    //        {
    //            return this.accountingField;
    //        }
    //        set
    //        {
    //            this.accountingField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public voucherDetailVoucherItemClassificationVAT classificationVAT
    //    {
    //        get
    //        {
    //            return this.classificationVATField;
    //        }
    //        set
    //        {
    //            this.classificationVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public voucherDetailVoucherItemContract contract
    //    {
    //        get
    //        {
    //            return this.contractField;
    //        }
    //        set
    //        {
    //            this.contractField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherDetailVoucherItemHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherDetailVoucherItemHomeCurrency
    //{

    //    private decimal unitPriceField;

    //    private decimal priceField;

    //    private decimal priceVATField;

    //    private decimal priceSumField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal unitPrice
    //    {
    //        get
    //        {
    //            return this.unitPriceField;
    //        }
    //        set
    //        {
    //            this.unitPriceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal price
    //    {
    //        get
    //        {
    //            return this.priceField;
    //        }
    //        set
    //        {
    //            this.priceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceVAT
    //    {
    //        get
    //        {
    //            return this.priceVATField;
    //        }
    //        set
    //        {
    //            this.priceVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceSum
    //    {
    //        get
    //        {
    //            return this.priceSumField;
    //        }
    //        set
    //        {
    //            this.priceSumField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherDetailVoucherItemAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherDetailVoucherItemAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherDetailVoucherItemClassificationVAT</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherDetailVoucherItemClassificationVAT
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string classificationVATTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string classificationVATType
    //    {
    //        get
    //        {
    //            return this.classificationVATTypeField;
    //        }
    //        set
    //        {
    //            this.classificationVATTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherDetailVoucherItemContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherDetailVoucherItemContract
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherSummary</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IsNullable = false)]
    //public partial class voucherSummary
    //{

    //    private string roundingDocumentField;

    //    private string roundingVATField;

    //    private bool calculateVATField;

    //    private bool calculateVATFieldSpecified;

    //    private string typeCalculateVATInclusivePriceField;

    //    private voucherSummaryHomeCurrency homeCurrencyField;

    //    /// <remarks/>
    //    public string roundingDocument
    //    {
    //        get
    //        {
    //            return this.roundingDocumentField;
    //        }
    //        set
    //        {
    //            this.roundingDocumentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string roundingVAT
    //    {
    //        get
    //        {
    //            return this.roundingVATField;
    //        }
    //        set
    //        {
    //            this.roundingVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool calculateVAT
    //    {
    //        get
    //        {
    //            return this.calculateVATField;
    //        }
    //        set
    //        {
    //            this.calculateVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool calculateVATSpecified
    //    {
    //        get
    //        {
    //            return this.calculateVATFieldSpecified;
    //        }
    //        set
    //        {
    //            this.calculateVATFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string typeCalculateVATInclusivePrice
    //    {
    //        get
    //        {
    //            return this.typeCalculateVATInclusivePriceField;
    //        }
    //        set
    //        {
    //            this.typeCalculateVATInclusivePriceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public voucherSummaryHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherSummaryHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //public partial class voucherSummaryHomeCurrency
    //{

    //    private decimal priceNoneField;

    //    private ushort priceLowField;

    //    private byte priceLowVATField;

    //    private ushort priceLowSumField;

    //    private decimal priceHighField;

    //    private decimal priceHighVATField;

    //    private decimal priceHighSumField;

    //    private byte price3Field;

    //    private byte price3VATField;

    //    private byte price3SumField;

    //    private Round roundField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceNone
    //    {
    //        get
    //        {
    //            return this.priceNoneField;
    //        }
    //        set
    //        {
    //            this.priceNoneField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLow
    //    {
    //        get
    //        {
    //            return this.priceLowField;
    //        }
    //        set
    //        {
    //            this.priceLowField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte priceLowVAT
    //    {
    //        get
    //        {
    //            return this.priceLowVATField;
    //        }
    //        set
    //        {
    //            this.priceLowVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLowSum
    //    {
    //        get
    //        {
    //            return this.priceLowSumField;
    //        }
    //        set
    //        {
    //            this.priceLowSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHigh
    //    {
    //        get
    //        {
    //            return this.priceHighField;
    //        }
    //        set
    //        {
    //            this.priceHighField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighVAT
    //    {
    //        get
    //        {
    //            return this.priceHighVATField;
    //        }
    //        set
    //        {
    //            this.priceHighVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighSum
    //    {
    //        get
    //        {
    //            return this.priceHighSumField;
    //        }
    //        set
    //        {
    //            this.priceHighSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3
    //    {
    //        get
    //        {
    //            return this.price3Field;
    //        }
    //        set
    //        {
    //            this.price3Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3VAT
    //    {
    //        get
    //        {
    //            return this.price3VATField;
    //        }
    //        set
    //        {
    //            this.price3VATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3Sum
    //    {
    //        get
    //        {
    //            return this.price3SumField;
    //        }
    //        set
    //        {
    //            this.price3SumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Round round
    //    {
    //        get
    //        {
    //            return this.roundField;
    //        }
    //        set
    //        {
    //            this.roundField = value;
    //        }
    //    }
    //}

    /// <remarks>EET</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IsNullable = false)]
    //public partial class EET
    //{

    //    private string stateEETField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string stateEET
    //    {
    //        get
    //        {
    //            return this.stateEETField;
    //        }
    //        set
    //        {
    //            this.stateEETField = value;
    //        }
    //    }
    //}

    /// <remarks>listInvoice</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/list.xsd", IsNullable = false)]
    //public partial class listInvoice
    //{

    //    private listInvoiceInvoice[] invoiceField;

    //    private decimal versionField;

    //    private System.DateTime dateTimeStampField;

    //    private System.DateTime dateValidFromField;

    //    private string stateField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("invoice")]
    //    public listInvoiceInvoice[] invoice
    //    {
    //        get
    //        {
    //            return this.invoiceField;
    //        }
    //        set
    //        {
    //            this.invoiceField = value;
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
    //    public System.DateTime dateTimeStamp
    //    {
    //        get
    //        {
    //            return this.dateTimeStampField;
    //        }
    //        set
    //        {
    //            this.dateTimeStampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    //    public System.DateTime dateValidFrom
    //    {
    //        get
    //        {
    //            return this.dateValidFromField;
    //        }
    //        set
    //        {
    //            this.dateValidFromField = value;
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

    /// <remarks>listInvoiceInvoice</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/list.xsd")]
    //public partial class listInvoiceInvoice
    //{

    //    private invoiceHeader invoiceHeaderField;

    //    private invoiceDetailInvoiceItem[] invoiceDetailField;

    //    private invoiceSummary invoiceSummaryField;

    //    private EET1 eETField;

    //    private decimal versionField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //    public invoiceHeader invoiceHeader
    //    {
    //        get
    //        {
    //            return this.invoiceHeaderField;
    //        }
    //        set
    //        {
    //            this.invoiceHeaderField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //    [System.Xml.Serialization.XmlArrayItemAttribute("invoiceItem", IsNullable = false)]
    //    public invoiceDetailInvoiceItem[] invoiceDetail
    //    {
    //        get
    //        {
    //            return this.invoiceDetailField;
    //        }
    //        set
    //        {
    //            this.invoiceDetailField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //    public invoiceSummary invoiceSummary
    //    {
    //        get
    //        {
    //            return this.invoiceSummaryField;
    //        }
    //        set
    //        {
    //            this.invoiceSummaryField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //    public EET1 EET
    //    {
    //        get
    //        {
    //            return this.eETField;
    //        }
    //        set
    //        {
    //            this.eETField = value;
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
    //}

    /// <remarks>invoiceHeader</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    //public partial class invoiceHeader
    //{

    //    private object[] itemsField;

    //    private ItemsChoiceType3[] itemsElementNameField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("account", typeof(invoiceHeaderAccount))]
    //    [System.Xml.Serialization.XmlElementAttribute("accounting", typeof(invoiceHeaderAccounting))]
    //    [System.Xml.Serialization.XmlElementAttribute("activity", typeof(invoiceHeaderActivity))]
    //    [System.Xml.Serialization.XmlElementAttribute("centre", typeof(invoiceHeaderCentre))]
    //    [System.Xml.Serialization.XmlElementAttribute("classificationVAT", typeof(invoiceHeaderClassificationVAT))]
    //    [System.Xml.Serialization.XmlElementAttribute("contract", typeof(invoiceHeaderContract))]
    //    [System.Xml.Serialization.XmlElementAttribute("date", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("dateAccounting", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("dateDue", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("dateOrder", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("dateTax", typeof(System.DateTime), DataType = "date")]
    //    [System.Xml.Serialization.XmlElementAttribute("extId", typeof(invoiceHeaderExtId))]
    //    [System.Xml.Serialization.XmlElementAttribute("id", typeof(ushort))]
    //    [System.Xml.Serialization.XmlElementAttribute("intNote", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("invoiceType", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("liquidation", typeof(invoiceHeaderLiquidation))]
    //    [System.Xml.Serialization.XmlElementAttribute("markRecord", typeof(bool))]
    //    [System.Xml.Serialization.XmlElementAttribute("myIdentity", typeof(invoiceHeaderMyIdentity))]
    //    [System.Xml.Serialization.XmlElementAttribute("note", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("number", typeof(invoiceHeaderNumber))]
    //    [System.Xml.Serialization.XmlElementAttribute("numberOrder", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("partnerIdentity", typeof(invoiceHeaderPartnerIdentity))]
    //    [System.Xml.Serialization.XmlElementAttribute("paymentType", typeof(invoiceHeaderPaymentType))]
    //    [System.Xml.Serialization.XmlElementAttribute("storno", typeof(string))]
    //    [System.Xml.Serialization.XmlElementAttribute("symConst", typeof(ushort))]
    //    [System.Xml.Serialization.XmlElementAttribute("symPar", typeof(uint))]
    //    [System.Xml.Serialization.XmlElementAttribute("symVar", typeof(uint))]
    //    [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
    //    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    //    public object[] Items
    //    {
    //        get
    //        {
    //            return this.itemsField;
    //        }
    //        set
    //        {
    //            this.itemsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public ItemsChoiceType3[] ItemsElementName
    //    {
    //        get
    //        {
    //            return this.itemsElementNameField;
    //        }
    //        set
    //        {
    //            this.itemsElementNameField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderAccount</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderAccount
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string accountNoField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountNo
    //    {
    //        get
    //        {
    //            return this.accountNoField;
    //        }
    //        set
    //        {
    //            this.accountNoField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string accountingTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string accountingType
    //    {
    //        get
    //        {
    //            return this.accountingTypeField;
    //        }
    //        set
    //        {
    //            this.accountingTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderActivity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderActivity
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderCentre</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderCentre
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderClassificationVAT</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderClassificationVAT
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderContract
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderExtId</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderExtId
    //{

    //    private string idsField;

    //    private string exSystemNameField;

    //    private string exSystemTextField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string exSystemName
    //    {
    //        get
    //        {
    //            return this.exSystemNameField;
    //        }
    //        set
    //        {
    //            this.exSystemNameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string exSystemText
    //    {
    //        get
    //        {
    //            return this.exSystemTextField;
    //        }
    //        set
    //        {
    //            this.exSystemTextField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderLiquidation</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderLiquidation
    //{

    //    private System.DateTime dateField;

    //    private bool dateFieldSpecified;

    //    private uint amountHomeField;

    //    private bool amountHomeFieldSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", DataType = "date")]
    //    public System.DateTime date
    //    {
    //        get
    //        {
    //            return this.dateField;
    //        }
    //        set
    //        {
    //            this.dateField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool dateSpecified
    //    {
    //        get
    //        {
    //            return this.dateFieldSpecified;
    //        }
    //        set
    //        {
    //            this.dateFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public uint amountHome
    //    {
    //        get
    //        {
    //            return this.amountHomeField;
    //        }
    //        set
    //        {
    //            this.amountHomeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool amountHomeSpecified
    //    {
    //        get
    //        {
    //            return this.amountHomeFieldSpecified;
    //        }
    //        set
    //        {
    //            this.amountHomeFieldSpecified = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderMyIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderMyIdentity
    //{

    //    private Address addressField;

    //    private Establishment establishmentField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Establishment establishment
    //    {
    //        get
    //        {
    //            return this.establishmentField;
    //        }
    //        set
    //        {
    //            this.establishmentField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderNumber</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderNumber
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private string idsField;

    //    private string numberRequestedField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string numberRequested
    //    {
    //        get
    //        {
    //            return this.numberRequestedField;
    //        }
    //        set
    //        {
    //            this.numberRequestedField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderPartnerIdentity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderPartnerIdentity
    //{

    //    private ushort idField;

    //    private Address addressField;

    //    private ShipToAddress shipToAddressField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Address address
    //    {
    //        get
    //        {
    //            return this.addressField;
    //        }
    //        set
    //        {
    //            this.addressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ShipToAddress shipToAddress
    //    {
    //        get
    //        {
    //            return this.shipToAddressField;
    //        }
    //        set
    //        {
    //            this.shipToAddressField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceHeaderPaymentType</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceHeaderPaymentType
    //{

    //    private ushort idField;

    //    private string idsField;

    //    private string paymentTypeField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string paymentType
    //    {
    //        get
    //        {
    //            return this.paymentTypeField;
    //        }
    //        set
    //        {
    //            this.paymentTypeField = value;
    //        }
    //    }
    //}

    /// <remarks>ItemsChoiceType3</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IncludeInSchema = false)]
    //public enum ItemsChoiceType3
    //{

    //    /// <remarks/>
    //    account,

    //    /// <remarks/>
    //    accounting,

    //    /// <remarks/>
    //    activity,

    //    /// <remarks/>
    //    centre,

    //    /// <remarks/>
    //    classificationVAT,

    //    /// <remarks/>
    //    contract,

    //    /// <remarks/>
    //    date,

    //    /// <remarks/>
    //    dateAccounting,

    //    /// <remarks/>
    //    dateDue,

    //    /// <remarks/>
    //    dateOrder,

    //    /// <remarks/>
    //    dateTax,

    //    /// <remarks/>
    //    extId,

    //    /// <remarks/>
    //    id,

    //    /// <remarks/>
    //    intNote,

    //    /// <remarks/>
    //    invoiceType,

    //    /// <remarks/>
    //    liquidation,

    //    /// <remarks/>
    //    markRecord,

    //    /// <remarks/>
    //    myIdentity,

    //    /// <remarks/>
    //    note,

    //    /// <remarks/>
    //    number,

    //    /// <remarks/>
    //    numberOrder,

    //    /// <remarks/>
    //    partnerIdentity,

    //    /// <remarks/>
    //    paymentType,

    //    /// <remarks/>
    //    storno,

    //    /// <remarks/>
    //    symConst,

    //    /// <remarks/>
    //    symPar,

    //    /// <remarks/>
    //    symVar,

    //    /// <remarks/>
    //    text,
    //}

    /// <remarks>invoiceDetailInvoiceItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItem
    //{

    //    private ushort idField;

    //    private string textField;

    //    private decimal quantityField;

    //    private string unitField;

    //    private decimal coefficientField;

    //    private bool payVATField;

    //    private string rateVATField;

    //    private decimal discountPercentageField;

    //    private invoiceDetailInvoiceItemHomeCurrency homeCurrencyField;

    //    private string noteField;

    //    private string codeField;

    //    private invoiceDetailInvoiceItemStockItem stockItemField;

    //    private invoiceDetailInvoiceItemForeignCurrency foreignCurrencyField;

    //    private invoiceDetailInvoiceItemAccounting accountingField;

    //    private invoiceDetailInvoiceItemClassificationVAT classificationVATField;

    //    private bool pDPField;

    //    private invoiceDetailInvoiceItemCentre centreField;

    //    private invoiceDetailInvoiceItemActivity activityField;

    //    private invoiceDetailInvoiceItemContract contractField;

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
    //    public string text
    //    {
    //        get
    //        {
    //            return this.textField;
    //        }
    //        set
    //        {
    //            this.textField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal quantity
    //    {
    //        get
    //        {
    //            return this.quantityField;
    //        }
    //        set
    //        {
    //            this.quantityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string unit
    //    {
    //        get
    //        {
    //            return this.unitField;
    //        }
    //        set
    //        {
    //            this.unitField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal coefficient
    //    {
    //        get
    //        {
    //            return this.coefficientField;
    //        }
    //        set
    //        {
    //            this.coefficientField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool payVAT
    //    {
    //        get
    //        {
    //            return this.payVATField;
    //        }
    //        set
    //        {
    //            this.payVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string rateVAT
    //    {
    //        get
    //        {
    //            return this.rateVATField;
    //        }
    //        set
    //        {
    //            this.rateVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public decimal discountPercentage
    //    {
    //        get
    //        {
    //            return this.discountPercentageField;
    //        }
    //        set
    //        {
    //            this.discountPercentageField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
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
    //    public string code
    //    {
    //        get
    //        {
    //            return this.codeField;
    //        }
    //        set
    //        {
    //            this.codeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemStockItem stockItem
    //    {
    //        get
    //        {
    //            return this.stockItemField;
    //        }
    //        set
    //        {
    //            this.stockItemField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemForeignCurrency foreignCurrency
    //    {
    //        get
    //        {
    //            return this.foreignCurrencyField;
    //        }
    //        set
    //        {
    //            this.foreignCurrencyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemAccounting accounting
    //    {
    //        get
    //        {
    //            return this.accountingField;
    //        }
    //        set
    //        {
    //            this.accountingField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemClassificationVAT classificationVAT
    //    {
    //        get
    //        {
    //            return this.classificationVATField;
    //        }
    //        set
    //        {
    //            this.classificationVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool PDP
    //    {
    //        get
    //        {
    //            return this.pDPField;
    //        }
    //        set
    //        {
    //            this.pDPField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemCentre centre
    //    {
    //        get
    //        {
    //            return this.centreField;
    //        }
    //        set
    //        {
    //            this.centreField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemActivity activity
    //    {
    //        get
    //        {
    //            return this.activityField;
    //        }
    //        set
    //        {
    //            this.activityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceDetailInvoiceItemContract contract
    //    {
    //        get
    //        {
    //            return this.contractField;
    //        }
    //        set
    //        {
    //            this.contractField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemHomeCurrency
    //{

    //    private decimal unitPriceField;

    //    private decimal priceField;

    //    private decimal priceVATField;

    //    private decimal priceSumField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal unitPrice
    //    {
    //        get
    //        {
    //            return this.unitPriceField;
    //        }
    //        set
    //        {
    //            this.unitPriceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal price
    //    {
    //        get
    //        {
    //            return this.priceField;
    //        }
    //        set
    //        {
    //            this.priceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceVAT
    //    {
    //        get
    //        {
    //            return this.priceVATField;
    //        }
    //        set
    //        {
    //            this.priceVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceSum
    //    {
    //        get
    //        {
    //            return this.priceSumField;
    //        }
    //        set
    //        {
    //            this.priceSumField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemStockItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemStockItem
    //{

    //    private store storeField;

    //    private stockItem stockItemField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public store store
    //    {
    //        get
    //        {
    //            return this.storeField;
    //        }
    //        set
    //        {
    //            this.storeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public stockItem stockItem
    //    {
    //        get
    //        {
    //            return this.stockItemField;
    //        }
    //        set
    //        {
    //            this.stockItemField = value;
    //        }
    //    }
    //}

    /// <remarks>store</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class store
    //{

    //    private byte idField;

    //    private string idsField;

    //    /// <remarks/>
    //    public byte id
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
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>stockItem</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd", IsNullable = false)]
    //public partial class stockItem
    //{

    //    private ushort idField;

    //    private string idsField;

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
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemForeignCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemForeignCurrency
    //{

    //    private decimal unitPriceField;

    //    private decimal priceField;

    //    private decimal priceVATField;

    //    private decimal priceSumField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal unitPrice
    //    {
    //        get
    //        {
    //            return this.unitPriceField;
    //        }
    //        set
    //        {
    //            this.unitPriceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal price
    //    {
    //        get
    //        {
    //            return this.priceField;
    //        }
    //        set
    //        {
    //            this.priceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceVAT
    //    {
    //        get
    //        {
    //            return this.priceVATField;
    //        }
    //        set
    //        {
    //            this.priceVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceSum
    //    {
    //        get
    //        {
    //            return this.priceSumField;
    //        }
    //        set
    //        {
    //            this.priceSumField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemAccounting</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemAccounting
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemClassificationVAT</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemClassificationVAT
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemCentre</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemCentre
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemActivity</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemActivity
    //{

    //    private ushort idField;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetailInvoiceItemContract</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceDetailInvoiceItemContract
    //{

    //    private ushort idField;

    //    private bool idFieldSpecified;

    //    private string idsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
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
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool idSpecified
    //    {
    //        get
    //        {
    //            return this.idFieldSpecified;
    //        }
    //        set
    //        {
    //            this.idFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string ids
    //    {
    //        get
    //        {
    //            return this.idsField;
    //        }
    //        set
    //        {
    //            this.idsField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceSummary</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    //public partial class invoiceSummary
    //{

    //    private string roundingDocumentField;

    //    private string roundingVATField;

    //    private bool calculateVATField;

    //    private bool calculateVATFieldSpecified;

    //    private string typeCalculateVATInclusivePriceField;

    //    private invoiceSummaryHomeCurrency homeCurrencyField;

    //    /// <remarks/>
    //    public string roundingDocument
    //    {
    //        get
    //        {
    //            return this.roundingDocumentField;
    //        }
    //        set
    //        {
    //            this.roundingDocumentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string roundingVAT
    //    {
    //        get
    //        {
    //            return this.roundingVATField;
    //        }
    //        set
    //        {
    //            this.roundingVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public bool calculateVAT
    //    {
    //        get
    //        {
    //            return this.calculateVATField;
    //        }
    //        set
    //        {
    //            this.calculateVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool calculateVATSpecified
    //    {
    //        get
    //        {
    //            return this.calculateVATFieldSpecified;
    //        }
    //        set
    //        {
    //            this.calculateVATFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string typeCalculateVATInclusivePrice
    //    {
    //        get
    //        {
    //            return this.typeCalculateVATInclusivePriceField;
    //        }
    //        set
    //        {
    //            this.typeCalculateVATInclusivePriceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public invoiceSummaryHomeCurrency homeCurrency
    //    {
    //        get
    //        {
    //            return this.homeCurrencyField;
    //        }
    //        set
    //        {
    //            this.homeCurrencyField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceSummaryHomeCurrency</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //public partial class invoiceSummaryHomeCurrency
    //{

    //    private decimal priceNoneField;

    //    private ushort priceLowField;

    //    private byte priceLowVATField;

    //    private ushort priceLowSumField;

    //    private decimal priceHighField;

    //    private decimal priceHighVATField;

    //    private decimal priceHighSumField;

    //    private byte price3Field;

    //    private byte price3VATField;

    //    private byte price3SumField;

    //    private Round roundField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceNone
    //    {
    //        get
    //        {
    //            return this.priceNoneField;
    //        }
    //        set
    //        {
    //            this.priceNoneField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLow
    //    {
    //        get
    //        {
    //            return this.priceLowField;
    //        }
    //        set
    //        {
    //            this.priceLowField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte priceLowVAT
    //    {
    //        get
    //        {
    //            return this.priceLowVATField;
    //        }
    //        set
    //        {
    //            this.priceLowVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public ushort priceLowSum
    //    {
    //        get
    //        {
    //            return this.priceLowSumField;
    //        }
    //        set
    //        {
    //            this.priceLowSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHigh
    //    {
    //        get
    //        {
    //            return this.priceHighField;
    //        }
    //        set
    //        {
    //            this.priceHighField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighVAT
    //    {
    //        get
    //        {
    //            return this.priceHighVATField;
    //        }
    //        set
    //        {
    //            this.priceHighVATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public decimal priceHighSum
    //    {
    //        get
    //        {
    //            return this.priceHighSumField;
    //        }
    //        set
    //        {
    //            this.priceHighSumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3
    //    {
    //        get
    //        {
    //            return this.price3Field;
    //        }
    //        set
    //        {
    //            this.price3Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3VAT
    //    {
    //        get
    //        {
    //            return this.price3VATField;
    //        }
    //        set
    //        {
    //            this.price3VATField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public byte price3Sum
    //    {
    //        get
    //        {
    //            return this.price3SumField;
    //        }
    //        set
    //        {
    //            this.price3SumField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public Round round
    //    {
    //        get
    //        {
    //            return this.roundField;
    //        }
    //        set
    //        {
    //            this.roundField = value;
    //        }
    //    }
    //}

    /// <remarks>EET1</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute("EET", Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    //public partial class EET
    //{

    //    private string stateEETField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.stormware.cz/schema/version_2/type.xsd")]
    //    public string stateEET
    //    {
    //        get
    //        {
    //            return this.stateEETField;
    //        }
    //        set
    //        {
    //            this.stateEETField = value;
    //        }
    //    }
    //}

    /// <remarks>invoiceDetail</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/invoice.xsd", IsNullable = false)]
    //public partial class invoiceDetail
    //{

    //    private InvoiceItem[] invoiceItemField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("invoiceItem")]
    //    public InvoiceItem[] invoiceItem
    //    {
    //        get
    //        {
    //            return this.invoiceItemField;
    //        }
    //        set
    //        {
    //            this.invoiceItemField = value;
    //        }
    //    }
    //}

    /// <remarks>voucherDetail</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/voucher.xsd", IsNullable = false)]
    //public partial class voucherDetail
    //{

    //    private VoucherItem[] voucherItemField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("voucherItem")]
    //    public VoucherItem[] voucherItem
    //    {
    //        get
    //        {
    //            return this.voucherItemField;
    //        }
    //        set
    //        {
    //            this.voucherItemField = value;
    //        }
    //    }
    //}

    /// <remarks>bankDetail</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/bank.xsd", IsNullable = false)]
    //public partial class bankDetail
    //{

    //    private BankItem[] bankItemField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("bankItem")]
    //    public BankItem[] bankItem
    //    {
    //        get
    //        {
    //            return this.bankItemField;
    //        }
    //        set
    //        {
    //            this.bankItemField = value;
    //        }
    //    }
    //}

    /// <remarks>addressbookAccount</remarks>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.stormware.cz/schema/version_2/addressbook.xsd", IsNullable = false)]
    //public partial class addressbookAccount
    //{

    //    private AccountItem[] accountItemField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("accountItem")]
    //    public AccountItem[] accountItem
    //    {
    //        get
    //        {
    //            return this.accountItemField;
    //        }
    //        set
    //        {
    //            this.accountItemField = value;
    //        }
    //    }
    //}






}
