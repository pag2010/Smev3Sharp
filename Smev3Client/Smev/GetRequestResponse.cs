using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Smev3Client.Soap;
using Smev3Client.Xml;

namespace Smev3Client.Smev
{
    /// <summary>
    /// Ответ, присланный поставщиком данных.
    /// </summary>
    public class GetRequestResponse<T> :
        ISoapEnvelopeBody,
        IXmlSerializable where T : new()
    {
        public RequestMessage<T> RequestMessage { get; private set; }

        public List<byte[]> Attachments { get; private set; } = new List<byte[]>();

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
                        "GetRequestResponse", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2, required: true,
                        (r) =>
                        {
                            var requestMessage = new RequestMessage<T>();
                            if (!r.IsEmptyElement)
                            {
                                requestMessage.ReadXml(reader);
                            }

                            RequestMessage = requestMessage;
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
