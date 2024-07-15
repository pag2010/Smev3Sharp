/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
public partial class AttachmentContentListAttachmentContent
{

    private string idField;

    private AttachmentContentListAttachmentContentContent contentField;

    /// <remarks/>
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public AttachmentContentListAttachmentContentContent Content
    {
        get
        {
            return this.contentField;
        }
        set
        {
            this.contentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
public partial class AttachmentContentListAttachmentContentContent
{

    private Include includeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2004/08/xop/include")]
    public Include Include
    {
        get
        {
            return this.includeField;
        }
        set
        {
            this.includeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2004/08/xop/include")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2004/08/xop/include", IsNullable = false)]
public partial class Include
{

    private string hrefField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string href
    {
        get
        {
            return this.hrefField;
        }
        set
        {
            this.hrefField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2", IsNullable = false)]
public partial class AttachmentContentList
{

    private AttachmentContentListAttachmentContent[] attachmentContentField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AttachmentContent")]
    public AttachmentContentListAttachmentContent[] AttachmentContent
    {
        get
        {
            return this.attachmentContentField;
        }
        set
        {
            this.attachmentContentField = value;
        }
    }
}

