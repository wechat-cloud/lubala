using System;
using System.IO;
using System.Xml.Linq;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization;

namespace Lubala.Core.Pushing
{
    internal class PushingEngine : IPushingEngine
    {
        private readonly ISourceStreamReader _sourceStreamReader;
        private readonly ITypeDetector _typeDetector;
        private readonly IXmlSerializer _xmlSerializer;

        public PushingEngine(
            ISourceStreamReader sourceStreamReader,
            ITypeDetector typeDetector,
            IXmlSerializer xmlSerializer)
        {
            _sourceStreamReader = sourceStreamReader;
            _typeDetector = typeDetector;
            _xmlSerializer = xmlSerializer;
        }

        public IPassiveMessage ProducePassiveMessage(Stream sourceStream, HubContext context)
        {
            var rawXml = _sourceStreamReader.ReadAsXml(sourceStream);
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

        private MessageContext BuideMessageContext(HubContext context, TypeIdentity typeIdentity, XDocument rawXml, IPushingMessage message)
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