using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.Mp.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp
{
    internal class LightweightMessageHandler<TIn> : MPMessageHandler<TIn, MPOutgoingMessage>
        where TIn : MPIncomingMessage
    {
        private readonly Func<TIn, MessageContext, MPOutgoingMessage> _lightweightFunc;
        internal LightweightMessageHandler(Func<TIn, MessageContext, MPOutgoingMessage> lightweightFunc)
        {
            if (lightweightFunc == null)
            {
                throw new ArgumentNullException(nameof(lightweightFunc));
            }

            _lightweightFunc = lightweightFunc;
        }

        protected override MPOutgoingMessage HandleMessage(TIn incomingMessage, MessageContext context)
        {
            return _lightweightFunc(incomingMessage, context);
        }
    }
}
