using Smev3Client.Xml;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Smev3Client.Smev
{
    /// <summary>
    /// Данные о сообщении
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SenderProvidedRequestData<T> :
        IXmlSerializable where T : new()
    {
        public SenderProvidedRequestData()
        {
        }

        public SenderProvidedRequestData(
            Guid messageId,
            string xmlElementId,
            MessagePrimaryContent<T> content)
        {
            MessageId = messageId;

            Content = content
                ?? throw new ArgumentNullException(nameof(content));

            Id = xmlElementId;
        }

        /// <summary>
        /// Атрибут Id xml элемента
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Ид. сообщения
        /// </summary>
        public Guid MessageId { get; private set; }

        /// <summary>
        /// Ид. транзакции
        /// </summary>
        public string TransactionCode { get; private set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        public MessagePrimaryContent<T> Content { get; private set; }

        /// <summary>
        /// Описание вложений
        /// </summary>
        public AttachmentHeaderList AttachmentHeaderList { get; private set; }

        public bool TestMessage { get; set; }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadElementSubtreeContent(
                 "SenderProvidedRequestData", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                 (r) =>
                 {
                     r.ReadElementIfItCurrentOrRequired(
                        "MessageID", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) => MessageId = Guid.Parse(r.ReadElementContentAsString()));

                     r.ReadElementIfItCurrentOrRequired(
                         "TransactionCode", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                         (requestReader) => TransactionCode = r.ReadElementContentAsString());

                     var msgPrimaryContent = new MessagePrimaryContent<T>();
                     msgPrimaryContent.ReadXml(r);

                     Content = msgPrimaryContent;

                     var serializer = new XmlSerializer(typeof(AttachmentHeaderList));

                     AttachmentHeaderList = (AttachmentHeaderList)serializer.Deserialize(reader);
                 });

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SenderProvidedRequestData", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2);

            writer.WriteAttributeString("Id", Id);

            writer.WriteElementString("MessageID", MessageId.ToString());

            Content.WriteXml(writer);

            if (TestMessage)
            {
                writer.WriteElementString("TestMessage", string.Empty);
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
