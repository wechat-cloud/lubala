using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Lubala.Core.Cryptographic;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing.Encoding
{
    internal class AesEncodingProvider : IEncodingProvider
    {
        private const string EncryptNodeName = "Encrypt";
        private readonly IAesCrypography _aesCrypography;
        private readonly ISha1Hasher _sha1Hasher;

        public AesEncodingProvider(ISha1Hasher sha1Hasher, IAesCrypography aesCrypography)
        {
            _sha1Hasher = sha1Hasher;
            _aesCrypography = aesCrypography;
        }

		public IPassiveMessage EncryptMessage(IPassiveMessage message, CryptographyContext context){
			using (var stream = new MemoryStream()) {
				message.SerializeTo(stream, context.HubContext);
				stream.Position = 0;
				using (var reader = new StreamReader(stream)) {
					var originalMessage = reader.ReadToEnd();
					var encryptedMessage = EncryptMessage(originalMessage, context);
					var signature = GenarateSinature(originalMessage, context);

					return new EncryptedPassiveMessage{ 
						MsgSignature = signature,
						TimeStamp = context.MsgTimestamp,
						Nonce = context.MsgNonce,
						Encrypt = encryptedMessage
					};
				}
			}
		}

		private string EncryptMessage(string rawMessage, CryptographyContext context)
        {
            if (context.EncodingAesKey.Length != 43)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_IllegalAesKey);
            }
            var raw = "";
            try
            {
                raw = _aesCrypography.AesEncrypting(rawMessage, context.EncodingAesKey, context.AppId);
            }
            catch (Exception)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_EncryptAES_Error);
            }

			return raw;
        }

        public XDocument DecryptMessage(XDocument xml, CryptographyContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var encryptElement = xml.Root?.Element(EncryptNodeName);

            if (encryptElement == null)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_ParseXml_Error);
            }

            var encryptContent = encryptElement.Value;

            return DecryptingMessage(encryptContent, context);
        }

        private XmlDocument GenerateXmlDocument(CryptographyContext context, string raw, string signature)
        {
            var xml = new XmlDocument();
            var root = xml.CreateElement("xml");

            var encryptNode = xml.CreateElement(EncryptNodeName);
            encryptNode.InnerText = raw;

            var signatureNode = xml.CreateElement("MsgSignature");
            signatureNode.InnerText = signature;

            var timeStampNode = xml.CreateElement("TimeStamp");
            timeStampNode.InnerText = context.MsgTimestamp;

            var nonceNode = xml.CreateElement("Nonce");
            nonceNode.InnerText = context.MsgNonce;

            root.AppendChild(encryptNode);
            root.AppendChild(signatureNode);
            root.AppendChild(timeStampNode);
            root.AppendChild(nonceNode);

            xml.AppendChild(root);
            return xml;
        }

        private XDocument DecryptingMessage(string encryptContent, CryptographyContext context)
        {
            if (context.EncodingAesKey.Length != 43)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_IllegalAesKey);
            }

            if (!VerifySignature(encryptContent, context))
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_ValidateSignature_Error);
            }

            var messageAppId = "";
            var message = "";

            try
            {
                message = _aesCrypography.AesDecrypting(encryptContent, context.EncodingAesKey, ref messageAppId);
            }
            catch (FormatException)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_DecodeBase64_Error);
            }
            catch (Exception)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_DecryptAES_Error);
            }

            if (messageAppId != context.AppId)
            {
                throw new CryptographyException(CrypographyConstant.WXBizMsgCrypt_ValidateAppid_Error);
            }

            return XDocument.Parse(message);
        }

        private bool VerifySignature(string encryptContent, CryptographyContext context)
        {
            var hash = GenarateSinature(encryptContent, context);
            return hash == context.MsgSignature;
        }

        private string GenarateSinature(string encryptContent, CryptographyContext context)
        {
            var sortList = new SortedSet<string>
            {
                context.Token,
                context.MsgTimestamp,
                context.MsgNonce,
                encryptContent
            };

            var raw = string.Join("", sortList);

            var encoding = System.Text.Encoding.ASCII;
            var hash = _sha1Hasher.HashString(raw, encoding);

            return hash;
        }
    }
}