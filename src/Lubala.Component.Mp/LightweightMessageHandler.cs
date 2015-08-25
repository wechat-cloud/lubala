using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.Mp.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp
{
    internal class LightweightMessageHandler<TIn> : MPMessageHandler<TIn, MpOutgoingMessage>
        where TIn : MpIncomingMessage
    {
        private readonly Func<TIn, MessageContext, MpOutgoingMessage> _lightweightFunc;
        internal LightweightMessageHandler(Func<TIn, MessageContext, MpOutgoingMessage> lightweightFunc)
        {
            if (lightweightFunc == null)
            {
                throw new ArgumentNullException(nameof(lightweightFunc));
            }

            _lightweightFunc = lightweightFunc;
        }

        protected override MpOutgoingMessage HandleMessage(TIn incomingMessage, MessageContext context)
        {
            return _lightweightFunc(incomingMessage, context);
        }
    }
}
