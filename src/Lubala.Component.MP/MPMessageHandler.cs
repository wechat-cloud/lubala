using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP.Messages;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.MP
{
    public abstract class MPMessageHandler : IMessageHandler
    {
        internal abstract Type IncomingMessageType { get; }
        public abstract IPassiveMessage HandleMessage(IPushingMessage incomingMessage);
    }

    public abstract class MPMessageHandler<TIn, TOut> : MPMessageHandler
        where TIn : MPIncomingMessage
        where TOut : MPOutgoingMessage
    {
        internal override Type IncomingMessageType => typeof (TIn);

        protected abstract TOut HandleMessage(TIn incomingMessage);

        public sealed override IPassiveMessage HandleMessage(IPushingMessage incomingMessage)
        {
            var typedMessage = incomingMessage as TIn;
            if (typedMessage != null)
            {
                return HandleMessage(typedMessage);
            }

            throw new InvalidCastException("incomingMessage doesn't match required message type.");
        }
    }
}
