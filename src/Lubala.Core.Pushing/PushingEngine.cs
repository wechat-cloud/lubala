﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Lubala.Core.Pushing.Encoding;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization;

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

        public string ProducePassiveMessage(Stream sourceStream, HubContext context,
            IDictionary<string, string> payloads)
        {
            var rawXml = _sourceStreamReader.ReadAsXml(sourceStream);

            CryptographyContext cryptographyContext = null;
            if (IsEncodingEnabled(context))
            {
                cryptographyContext = BuildCryptographyContext(context, payloads);
                rawXml = _encodingProvider.DecryptMessage(rawXml, cryptographyContext);
            }

            var message = ProducePassiveMessageCore(rawXml, context, payloads);
            var result = message.Serialize();

            if (IsEncodingEnabled(context))
            {
                result = _encodingProvider.EncryptMessage(result, cryptographyContext);
            }

            return result;
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
                    Token = context.Channel.Token.TokenValue,
                    AppId = context.Channel.AppId,
                    EncodingAesKey = context.EncodingSignature,
                    MsgSignature = msgSignature,
                    MsgTimestamp = msgTimestamp,
                    MsgNonce = msgNonce
                };
                return cryptographyContext;
            }

            throw new InvalidOperationException("missing necessary key/value.");
        }
        
        private IPassiveMessage ProducePassiveMessageCore(XDocument rawXml, HubContext context,
            IDictionary<string, string> payloads)
        {
            var typeIdentity = _typeDetector.Detecting(rawXml);

            var typePicker = new TypePicker(context.GetMessageTypes());
            var targetType = typePicker.Picking(typeIdentity);

            if (targetType == null)
            {
                return new EmptyPassiveMessage();
            }

            var message = (IPushingMessage) _xmlSerializer.Deserialize(rawXml, targetType);

            var handlerPicker = new HandlerPicker(context.GetMessageHandlers());
            var handler = handlerPicker.Picking(message);

            if (handler == null)
            {
                return new EmptyPassiveMessage();
            }

            var messageContext = BuideMessageContext(context, typeIdentity, rawXml, message);

            var safeHandler = new SafeMessageHandler(handler);

            return safeHandler.HandleMessage(message, messageContext);
        }

        private MessageContext BuideMessageContext(HubContext context, TypeIdentity typeIdentity, XDocument rawXml,
            IPushingMessage message)
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