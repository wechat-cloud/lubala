using System;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp
{
    public abstract class MpMessageHandler : IMessageHandler
    {
        internal abstract Type IncomingMessageType { get; }
        public abstract IPassiveMessage HandleMessage(IPushingMessage incomingMessage, MessageContext context);
    }

    public abstract class MPMessageHandler<TIn, TOut> : MpMessageHandler
        where TIn : WechatPushingMessage
        where TOut : WechatPassiveMessage
    {
        internal override Type IncomingMessageType => typeof (TIn);

        protected abstract TOut HandleMessage(TIn incomingMessage, MessageContext context);

        public override sealed IPassiveMessage HandleMessage(IPushingMessage incomingMessage, MessageContext context)
        {
            var typedMessage = incomingMessage as TIn;
            if (typedMessage != null)
            {
                return HandleMessage(typedMessage, context);
            }

            throw new InvalidCastException("incomingMessage doesn't match required message type.");
        }
    }
}