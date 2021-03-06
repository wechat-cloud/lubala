﻿using System;
using System.Reflection;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    internal sealed class HubBuilder : IHubBuilder
    {
        private readonly HubContext _context;

        public HubBuilder(ILubalaChannel channel)
        {
            _context = new HubContext {Channel = channel, Resolver = channel.Resolver};
        }

        public IHubBuilder UseAutoEncoding(string encodingAesKey, string serverToken)
        {
            _context.ServerToken = serverToken;
            _context.EncodingAesKey = encodingAesKey;
            throw new NotImplementedException();
        }

        public IHubBuilder UseEncoding(string encodingAesKey, string serverToken, bool compatible = true)
        {
            _context.EncodingMode = compatible ? EncodingMode.Compatible : EncodingMode.Secure;
            _context.ServerToken = serverToken;
            _context.EncodingAesKey = encodingAesKey;
            return this;
        }

        public IHubBuilder RegisterMessageType<T>() where T : WechatPushingMessage
        {
            var targetType = typeof (T);
            var msgTypeAttribute = targetType.GetCustomAttribute(typeof (MsgTypeAttribute));
            var eventTypeAttribute = targetType.GetCustomAttribute(typeof (EventTypeAttribute));

            if (msgTypeAttribute == null && eventTypeAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{targetType.Name} doesn't setup a valid MsgType/EventType attribute.");
            }

            if (eventTypeAttribute != null)
            {
                var attr = (EventTypeAttribute) eventTypeAttribute;
                var identity = new TypeIdentity {MsgType = attr.MsgType, EventType = attr.EventType};
                _context.MessageTypes.Add(identity, targetType);
            }
            else
            {
                var attr = (MsgTypeAttribute) msgTypeAttribute;
                var identity = new TypeIdentity {MsgType = attr.MsgType, EventType = null};
                _context.MessageTypes.Add(identity, targetType);
            }

            return this;
        }

        public IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler)
        {
            if (messageHandler == null)
            {
                throw new ArgumentNullException(nameof(messageHandler));
            }
            _context.MessageHandlers.Add(messageType, messageHandler);
            return this;
        }

        internal IPushingHub BuildPushingHub()
        {
            return new PushingHub(_context);
        }
    }
}