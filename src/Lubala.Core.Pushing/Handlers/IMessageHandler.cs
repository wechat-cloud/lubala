using System;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    public interface IMessageHandler
    {
        IPassiveMessage HandleMessage(WechatPushingMessage incomingMessage, MessageContext context);
    }
}

