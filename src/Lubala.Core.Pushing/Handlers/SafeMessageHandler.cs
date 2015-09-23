using System;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    internal class SafeMessageHandler : IMessageHandler
    {
        private readonly IMessageHandler _innerHandler;

        public SafeMessageHandler(IMessageHandler innerHandler)
        {
            _innerHandler = innerHandler;
        }

        public IPassiveMessage HandleMessage(WechatPushingMessage incomingMessage, MessageContext context)
        {
            try
            {
                var passive = _innerHandler.HandleMessage(incomingMessage, context);

                if (context.SupportPassiveMessage && passive is WechatPassiveMessage)
                {
                    var wechatPassive = (WechatPassiveMessage) passive;
                    wechatPassive.BridgeTo(incomingMessage);

                    return passive;
                }
            }
            catch (Exception exp)
            {
                // TODO: log
            }

            return new AsyncPassiveMessage();
        }
    }
}