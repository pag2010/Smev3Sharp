using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Base64Content;
using Smev3Client.Xml;

namespace Smev3Client.Smev
{
    public class SenderProvidedResponseData<T> :
        IXmlSerializable where T : new()
    {
        public string Id { get; set; }

        public Guid MessageID { get; set; }

        public string To { get; set; }

        public RequestRejected[] RequestRejectionResons { get; set; }

        public RequestStatus Status { get; set; }

        public AsyncProcessingStatus ProcessingStatus { get; set; }

        /// <summary>
        /// Содержательная часть ответа, XML-документ.
        /// </summary>
        public MessagePrimaryContent<T> MessagePrimaryContent { get; set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public MessagePrimaryContent<T> Content { get; private set; }

        public AttachmentHeaderList AttachmentHeaderList { get; set; }
        public AttachmentContentList AttachmentContentList { get; set; }

        public SenderProvidedResponseData()
        {
        }

        public SenderProvidedResponseData(
            Guid messageId,
            string to,
            string xmlElementId,
            List<Attachment> attachments,
            MessagePrimaryContent<T> content)
        {
            MessageID = messageId;

            Content = content
                ?? throw new ArgumentNullException(nameof(content));

            To = to;

            Id = xmlElementId;


            var attachmentHeaderList = new AttachmentHeaderList();
            attachmentHeaderList.AttachmentHeader = attachments.Select(a =>
                 new AttachmentHeaderListAttachmentHeader()
                 {
                     contentId = a.Name,
                     MimeType = a.MimeType,
                     SignaturePKCS7 = Convert.ToBase64String(a.SignatureData)
                 }).ToArray();

            var attachmentContentList = new AttachmentContentList();
            attachmentContentList.AttachmentContent = attachments.Select(a =>
                new AttachmentContentListAttachmentContent()
                {
                    Id = a.Name,
                    Content = Convert.ToBase64String(a.Data)
                }).ToArray();

            AttachmentHeaderList = attachmentHeaderList;
            AttachmentContentList = attachmentContentList;
        }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadElementSubtreeContent(
                "SenderProvidedResponseData", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                (respReader) =>
                {
                    respReader.ReadElementIfItCurrentOrRequired(
                        "MessageID", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                        (r) => MessageID = Guid.Parse(r.ReadElementContentAsString()));

                    respReader.ReadElementIfItCurrentOrRequired(
                        "To", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                        (r) => r.Skip());

                    respReader.ReadElementIfItCurrentOrRequired(
                        "MessagePrimaryContent", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_BASIC_1_2, required: false,
                        (r) =>
                        {
                            var msgPrimaryContent = new MessagePrimaryContent<T>();

                            msgPrimaryContent.ReadXml(r);

                            MessagePrimaryContent = msgPrimaryContent;
                        });

                    respReader.ReadElementIfItCurrentOrRequired(
                        "PersonalSignature", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) =>
                        {
                            r.Skip();
                        });

                    respReader.ReadElementIfItCurrentOrRequired(
                        "AttachmentHeaderList", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) =>
                        {
                            r.Skip();
                        });

                    respReader.ReadElementIfItCurrentOrRequired(
                        "RefAttachmentHeaderList", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) =>
                        {
                            r.Skip();
                        });

                    respReader.ReadElementIfItCurrentOrRequired(
                        "AsyncProcessingStatus", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) =>
                        {
                            var status = new AsyncProcessingStatus();
                            status.ReadXml(r);
                            ProcessingStatus = status;
                        });
                    respReader.ReadElementIfItCurrentOrRequired("RequestRejected", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false, r =>
                    {
                        var requestRejectedList = new List<RequestRejected>();
                        while (reader.IsStartElement("RequestRejected", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2))
                        {
                            var requestRejected = new RequestRejected();
                            requestRejected.ReadXml(r);
                            requestRejectedList.Add(requestRejected);
                        }
                        RequestRejectionResons = requestRejectedList.ToArray();
                    });
                });
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SenderProvidedResponseData", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2);

            writer.WriteAttributeString("Id", Id);

            writer.WriteElementString("MessageID", MessageID.ToString());
            writer.WriteElementString("To", To.ToString());

            Content.WriteXml(writer);

            if (AttachmentHeaderList.AttachmentHeader.Any())
            {
                var serializer = new XmlSerializer(typeof(AttachmentHeaderList));
                serializer.Serialize(writer, AttachmentHeaderList);
            }

            writer.WriteEndElement();

            if (AttachmentContentList.AttachmentContent.Any())
            {
                var serializer2 = new XmlSerializer(typeof(AttachmentContentList));
                serializer2.Serialize(writer, AttachmentContentList);
            }
        }

        #endregion
    }
}
