using System;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp
{
    internal class LightweightMessageHandler<TIn> : MpMessageHandler<TIn, WechatPassiveMessage>
        where TIn : WechatPushingMessage
    {
        private readonly Func<TIn, MessageContext, WechatPassiveMessage> _lightweightFunc;

        internal LightweightMessageHandler(Func<TIn, MessageContext, WechatPassiveMessage> lightweightFunc)
        {
            if (lightweightFunc == null)
            {
                throw new ArgumentNullException(nameof(lightweightFunc));
            }

            _lightweightFunc = lightweightFunc;
        }

        protected override WechatPassiveMessage HandleMessage(TIn incomingMessage, MessageContext context)
        {
            return _lightweightFunc(incomingMessage, context);
        }
    }
}