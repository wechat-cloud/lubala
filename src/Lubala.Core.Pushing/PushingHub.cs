﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization;

namespace Lubala.Core.Pushing
{
    internal class PushingHub : IPushingHub
    {
        private HubContext _hubContext;
        internal PushingHub(HubContext hubContext)
        {
            if (hubContext == null)
            {
                throw new ArgumentNullException(nameof(hubContext));
            }

            _hubContext = hubContext;

            MessageTypes = _hubContext.GetMessageTypes();
            MessageHandlers = _hubContext.GetMessageHandlers();
            Resolver = _hubContext.Resolver;
        }

        internal IReadOnlyDictionary<TypeIdentity, Type> MessageTypes { get; }
        public IReadOnlyDictionary<Type, IMessageHandler> MessageHandlers { get; private set; }
        internal ITypeResolver Resolver { get; private set; }

        public string Interpreting(string content, EncodingOption encodingOption = null)
        {
            var detector = new TypeDetector(content);
            var typeIdentity = detector.Detecting();

            var typePicker = new TypePicker(MessageTypes);
            var targetType = typePicker.Picking(typeIdentity);

            if (targetType == null)
            {
                // TODO: log unrecognized type.
                return "";
            }

            var serializer = Resolver.Resolve<IXmlSerializer>();
            IPushingMessage message = null;

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                    writer.Flush();
                    stream.Position = 0;

                    message = (IPushingMessage)serializer.Deserialize(stream, targetType);
                }
            }

            var handlerPicker = new HandlerPicker(MessageHandlers);
            var handler = handlerPicker.Picking(message);

            if (handler == null)
            {
                // TODO: no handler.
                return "";
            }

            var messageContext = new MessageContext
            {
                Channel = _hubContext.Channel,
                MsgType = typeIdentity.MsgType,
                EventType = typeIdentity.EventType,
                Raw = content,
                SupportPassiveMessage = message is IAcceptPassiveMessage
            };

            try
            {
                var passive = handler.HandleMessage(message, messageContext);

                if (messageContext.SupportPassiveMessage)
                {
                    return passive.Serialize();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception exp)
            {
                // TODO: log
            }
            return "";
        }
    }
}
