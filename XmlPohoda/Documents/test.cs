﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.7.2558.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/test.xsd")]
[System.Xml.Serialization.XmlRootAttribute("responsePackItem", Namespace="http://tempuri.org/test.xsd", IsNullable=false)]
public partial class responsePackItemType {
    
    private object itemField;
    
    private ItemChoiceType itemElementNameField;
    
    private string versionField;
    
    private string idField;
    
    private string stateField;
    
    private string noteField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("addressbookResponse", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("invoiceResponse", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("orderResponse", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("printResponse", typeof(object))]
    [System.Xml.Serialization.XmlElementAttribute("voucherResponse", typeof(object))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public object Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType ItemElementName {
        get {
            return this.itemElementNameField;
        }
        set {
            this.itemElementNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string state {
        get {
            return this.stateField;
        }
        set {
            this.stateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string note {
        get {
            return this.noteField;
        }
        set {
            this.noteField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/test.xsd", IncludeInSchema=false)]
public enum ItemChoiceType {
    
    /// <remarks/>
    addressbookResponse,
    
    /// <remarks/>
    invoiceResponse,
    
    /// <remarks/>
    orderResponse,
    
    /// <remarks/>
    printResponse,
    
    /// <remarks/>
    voucherResponse,
}