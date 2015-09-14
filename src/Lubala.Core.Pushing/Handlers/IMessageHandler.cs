using System;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    public interface IMessageHandler
    {
        PassiveMessage HandleMessage(PushingMessage incomingMessage, MessageContext context);
    }
}

