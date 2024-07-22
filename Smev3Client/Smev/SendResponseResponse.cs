using Smev3Client.Soap;
using System;
using System.Xml.Schema;
using System.Xml;
using Smev3Client.Xml;

namespace Smev3Client.Smev
{
    /// <summary>
    /// Возвращаемое значение метода "Послать запрос": запрос принят.
    /// Если запрос не может быть принят, информация о причине отказа передаётся через SOAP fault, см.WSDL-описание сервиса.
    /// </summary>
    public class SendResponseResponse : ISoapEnvelopeBody
    {
        /// <summary>
        /// Данные о сообщении: ID, присвоенный СМЭВ, дата приёма по часам СМЭВ, результат маршрутизации, etc.
        /// </summary>
        public MessageMetadata MessageMetadata { get; set; }

        public SendResponseResponse() { }

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadElementSubtreeContent(
                "Body", SoapConsts.SOAP_NAMESPACE, required: true,
                (bodyReader) =>
                {
                    bodyReader.ReadElementSubtreeContent(
                        "SendResponseResponse", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                        (r) =>
                        {
                            var messageMetadata = new MessageMetadata();

                            messageMetadata.ReadXml(r);

                            MessageMetadata = messageMetadata;
                        });
                });
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
