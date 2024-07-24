namespace Base64Content
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/basic/1.2")]
    public partial class AttachmentContentListAttachmentContent
    {

        private string idField;

        private string contentField;

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
        public string Content
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
}

