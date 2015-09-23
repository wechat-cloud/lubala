using System;
using Lubala.Core.Logs;
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
                    Log.Logger.Debug("imcoming message support passive message.");
                    var wechatPassive = (WechatPassiveMessage) passive;
                    wechatPassive.BridgeTo(incomingMessage);
                    Log.Logger.Debug("passive message bind to incoming message.");

                    return passive;
                }
            }
            catch (Exception exp)
            {
                Log.Logger.Fatal(exp, "execute message handler failed.");
                throw;
            }

            return new AsyncPassiveMessage();
        }
    }
}