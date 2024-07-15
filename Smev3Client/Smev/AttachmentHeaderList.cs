/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
public partial class AttachmentHeaderListAttachmentHeader
{

    private string contentIdField;

    private string mimeTypeField;

    private string signaturePKCS7Field;

    /// <remarks/>
    public string contentId
    {
        get
        {
            return this.contentIdField;
        }
        set
        {
            this.contentIdField = value;
        }
    }

    /// <remarks/>
    public string MimeType
    {
        get
        {
            return this.mimeTypeField;
        }
        set
        {
            this.mimeTypeField = value;
        }
    }

    /// <remarks/>
    public string SignaturePKCS7
    {
        get
        {
            return this.signaturePKCS7Field;
        }
        set
        {
            this.signaturePKCS7Field = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2", IsNullable = false)]
public partial class AttachmentHeaderList
{

    private AttachmentHeaderListAttachmentHeader[] attachmentHeaderField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AttachmentHeader")]
    public AttachmentHeaderListAttachmentHeader[] AttachmentHeader
    {
        get
        {
            return this.attachmentHeaderField;
        }
        set
        {
            this.attachmentHeaderField = value;
        }
    }
}

