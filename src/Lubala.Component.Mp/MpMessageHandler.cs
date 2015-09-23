using System;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp
{
    public abstract class MpMessageHandler<TIn, TOut> : IMessageHandler
        where TIn : WechatPushingMessage
        where TOut : WechatPassiveMessage
    {
        internal Type IncomingMessageType => typeof (TIn);

        protected abstract TOut HandleMessage(TIn incomingMessage, MessageContext context);

        public IPassiveMessage HandleMessage(WechatPushingMessage incomingMessage, MessageContext context)
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