using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using Smev3Client.Xml;

namespace Smev3Client.Smev
{
    /// <summary>
    /// Запрос
    /// </summary>
    /// <typeparam name="T">Тип запроса</typeparam>
    public class Request<T> :
        IXmlSerializable where T : new()
    {
        public SenderProvidedRequestData<T> SenderProvidedRequestData { get; set; }

        public MessageMetadata MessageMetadata { get; set; }

        public string ReplyTo { get; set; }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadElementSubtreeContent(
                "Request", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                (requestReader) =>
                {
                    var senderProvidedRequestData = new SenderProvidedRequestData<T>();

                    senderProvidedRequestData.ReadXml(requestReader);

                    var messageMetadata = new MessageMetadata();

                    messageMetadata.ReadXml(requestReader);

                    requestReader.ReadElementIfItCurrentOrRequired("ReplyTo", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, true, (r) => ReplyTo = r.ReadElementContentAsString());

                    MessageMetadata = messageMetadata;
                    SenderProvidedRequestData = senderProvidedRequestData;
                });
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
