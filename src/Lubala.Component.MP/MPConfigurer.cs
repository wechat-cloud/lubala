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