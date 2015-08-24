using System;
using System.IO;

namespace Lubala.Core.Pushing
{
    public abstract class MessageParser<TTargetMessage> : IMessageParser
        where TTargetMessage : InteractableMessage
    {

        protected abstract TTargetMessage ParseCore(Stream sourceStream, HubContext context);

        public InteractableMessage ParseMessage(Stream sourceStream, HubContext context)
        {
            return ParseCore(sourceStream, context);
        }
    }
}