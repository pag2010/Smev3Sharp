using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using Smev3Client.Xml;

namespace Smev3Client.Smev
{
    /// <summary>
    /// Сообщение запроса
    /// </summary>
    public class RequestMessage<T> : IXmlSerializable where T : new()
    {
        public Request<T> Request { get; set; }

        public AttachmentContentList AttachmentContentList { get; set; }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadElementSubtreeContent(
                "RequestMessage", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                (respReader) =>
                {
                    var request = new Request<T>();

                    request.ReadXml(respReader);

                    Request = request;

                    // AttachmentContentList
                    var serializer = new XmlSerializer(typeof(AttachmentContentList));
                    AttachmentContentList = (AttachmentContentList)serializer.Deserialize(reader);

                    // SMEVSignature
                    respReader.ReadElementIfItCurrentOrRequired(
                        "SMEVSignature", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: false,
                        (r) => r.Skip());
                });
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
