using System;
using Lubala.Component.Mp.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp
{
    public sealed class MpConfigurer
    {
        private readonly IHubBuilder _hubBuilder;

        internal MpConfigurer(IHubBuilder hubBuilder)
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

            _hubBuilder.RegisterMessageType<RawClickEvent>();
            _hubBuilder.RegisterMessageType<RawLocationEvent>();
            _hubBuilder.RegisterMessageType<RawScanEvent>();
            _hubBuilder.RegisterMessageType<RawSubscribeEvent>();
            _hubBuilder.RegisterMessageType<RawUnsubscribeEvent>();
        }

        public MpConfigurer RegisterMessageHandler(MpMessageHandler handler)
        {
            var incomingMessageType = handler.IncomingMessageType;
            _hubBuilder.RegisterMessageHandler(incomingMessageType, handler);
            return this;
        }

        public MpConfigurer RegisterMessageHandler<TIn>(Func<TIn, MessageContext, MpPassiveMessage> lightweightFunc)
            where TIn : MpRawMessage
        {
            var handler = new LightweightMessageHandler<TIn>(lightweightFunc);
            return RegisterMessageHandler(handler);
        }
    }
}