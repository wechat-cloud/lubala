using System;
using System.Reflection;
using Lubala.Component.MP.Messages;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP
{
    public sealed class MPConfigurer
    {
        private readonly IHubBuilder _hubBuilder;

        internal MPConfigurer(IHubBuilder hubBuilder)
        {
            _hubBuilder = hubBuilder;
            RegisterDefaultTypes();
        }

        private void RegisterDefaultTypes()
        {
            _hubBuilder.RegisterMessageType<RawImageMessage>();
            _hubBuilder.RegisterMessageType<RawLinkMessage>();
            _hubBuilder.RegisterMessageType<RawLocationMessage>();
            _hubBuilder.RegisterMessageType<RawShortVideoMessage>();
            _hubBuilder.RegisterMessageType<RawTextMessage>();
            _hubBuilder.RegisterMessageType<RawVideoMessage>();
            _hubBuilder.RegisterMessageType<RawVoiceMessage>();
        }

        public MPConfigurer RegisterMessageHandler(MPMessageHandler handler)
        {
            var incomingMessageType = handler.IncomingMessageType;
            _hubBuilder.RegisterMessageHandler(incomingMessageType, handler);
            return this;
        }

        public MPConfigurer RegisterMessageHandler<TIn>(Func<TIn, MessageContext, MPOutgoingMessage> lightweightFunc)
            where TIn : MPIncomingMessage
        {
            var handler = new LightweightMessageHandler<TIn>(lightweightFunc);
            return RegisterMessageHandler(handler);
        }
    }
}