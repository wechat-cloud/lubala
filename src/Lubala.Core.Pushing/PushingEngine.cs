using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization;
using System.Threading.Tasks;
using Lubala.Core.Logs;
using Lubala.Core.Pushing.Crypography;
using Lubala.Core.Pushing.Extensions;
using Lubala.Core.Pushing.Services;

namespace Lubala.Core.Pushing
{
    internal class PushingEngine : IPushingEngine
    {
        private readonly IEncodingProvider _encodingProvider;
        private readonly ISourceStreamReader _sourceStreamReader;
        private readonly ITypeDetector _typeDetector;
        private readonly IXmlSerializer _xmlSerializer;

        public PushingEngine(
            ISourceStreamReader sourceStreamReader,
            IEncodingProvider encodingProvider,
            ITypeDetector typeDetector,
            IXmlSerializer xmlSerializer)
        {
            _sourceStreamReader = sourceStreamReader;
            _encodingProvider = encodingProvider;
            _typeDetector = typeDetector;
            _xmlSerializer = xmlSerializer;
        }

		public Task<IPassiveMessage> ProducePassiveMessage(Stream sourceStream, HubContext context,
            IDictionary<string, string> payloads)
        {
            var rawXml = _sourceStreamReader.ReadAsXml(sourceStream);
		    Log.Logger.Info("raw message:\n{0}", rawXml.ToStringWithDeclaration());

            CryptographyContext cryptographyContext = null;
            if (IsEncodingEnabled(context))
            {
                Log.Logger.Debug("decrypting message.");
                cryptographyContext = BuildCryptographyContext(context, payloads);
                rawXml = _encodingProvider.DecryptMessage(rawXml, cryptographyContext);
                Log.Logger.Debug("decrypting message done.");
            }

            Log.Logger.Debug("processing message.");
            var result = ProducePassiveMessageCore(rawXml, context, payloads);
		    Log.Logger.Info("result message:\n{0}", result.Format(context));
            Log.Logger.Debug("processing message done.");

            if (IsEncodingEnabled(context))
            {
                Log.Logger.Debug("encrypting message.");
                result = _encodingProvider.EncryptMessage(result, cryptographyContext);
                Log.Logger.Info("encrypted result message:\n{0}", result.Format(context));
                Log.Logger.Debug("encrypting message done.");
            }

			return Task.FromResult(result);
        }

        private bool IsEncodingEnabled(HubContext context)
        {
            return context.EncodingMode == EncodingMode.Compatible || context.EncodingMode == EncodingMode.Secure;
        }

        private CryptographyContext BuildCryptographyContext(HubContext context, IDictionary<string, string> payloads)
        {
            string msgSignature;
            string msgTimestamp;
            string msgNonce;
            if (payloads.TryGetValue("msg_signature", out msgSignature) &&
                payloads.TryGetValue("timestamp", out msgTimestamp) &&
                payloads.TryGetValue("nonce", out msgNonce))
            {
                var cryptographyContext = new CryptographyContext
                {
                    ServerToken = context.ServerToken,
                    AppId = context.Channel.AppId,
                    EncodingAesKey = context.EncodingAesKey,
                    MsgSignature = msgSignature,
                    MsgTimestamp = msgTimestamp,
                    MsgNonce = msgNonce,
					HubContext = context
                };
                return cryptographyContext;
            }

            throw new InvalidOperationException("missing necessary key/value.");
        }
        
        private IPassiveMessage ProducePassiveMessageCore(XDocument rawXml, HubContext context, IDictionary<string, string> payloads)
        {
            var typeIdentity = _typeDetector.Detecting(rawXml);

            var typePicker = new TypePicker(context.GetMessageTypes());
            var targetType = typePicker.Picking(typeIdentity);

            if (targetType == null)
            {
                Log.Logger.Debug("unrecognized message type. system doesn't register this type: {0}");
                return new AsyncPassiveMessage();
            }

            var message = (WechatPushingMessage) _xmlSerializer.Deserialize(rawXml, targetType);

            var handlerPicker = new HandlerPicker(context.GetMessageHandlers());
            var handler = handlerPicker.Picking(message);

            if (handler == null)
            {
                Log.Logger.Debug("cannot find proper message handler.");
                return new AsyncPassiveMessage();
            }

            var messageContext = BuideMessageContext(context, typeIdentity, rawXml, message);

            var safeHandler = new SafeMessageHandler(handler);

            return safeHandler.HandleMessage(message, messageContext);
        }

        private MessageContext BuideMessageContext(HubContext context, TypeIdentity typeIdentity, XDocument rawXml, WechatPushingMessage message)
        {
            var supportPassiveMessage = message is IAcceptPassiveMessage;
            return new MessageContext
            {
                Channel = context.Channel,
                TypeIdentity = typeIdentity,
                Raw = rawXml.ToString(),
                SupportPassiveMessage = supportPassiveMessage
            };
        }
    }
}