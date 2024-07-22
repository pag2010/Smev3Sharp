using Smev3Client.Soap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml;

namespace Smev3Client.Smev
{
    public class SendResponseRequest<T> :
        ISoapEnvelopeBody,
        ISmev3Envelope
        where T : new()
    {
        #region members

        private readonly ISmev3XmlSigner _signer;

        private readonly SenderProvidedResponseData<T> _responseData;

        private readonly SoapEnvelope<SendResponseRequest<T>> _soapEnvelope;

        #endregion

        public SendResponseRequest()
        {
        }

        public SendResponseRequest(
            SenderProvidedResponseData<T> responseData,
            ISmev3XmlSigner signer)
        {
            _signer = signer ?? throw new ArgumentNullException(nameof(signer));

            _responseData = responseData ?? throw new ArgumentNullException(nameof(responseData));

            _soapEnvelope = new SoapEnvelope<SendResponseRequest<T>>
            {
                Header = new SoapEnvelopeHeader
                {
                    Action = new SoapAction(nameof(Smev3Methods.SendResponse))
                },
                Body = this
            };
        }

        #region ISmev3Envelope

        public byte[] Get()
        {
            return _soapEnvelope.Serialize();
        }

        #endregion

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SendResponseRequest", Smev3NameSpaces.MESSAGE_EXCHANGE_TYPES_1_2);

            _responseData.WriteXml(writer);

            writer.WriteStartElement("CallerInformationSystemSignature");

            _signer.SignXmlElement(
                    Smev3XmlSerializer.ToXmlElement(_responseData),
                    _responseData.Id)
                .WriteTo(writer);

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        #endregion
    }
}
