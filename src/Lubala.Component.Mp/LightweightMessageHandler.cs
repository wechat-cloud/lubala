using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.Mp.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp
{
    internal class LightweightMessageHandler<TIn> : MPMessageHandler<TIn, MpPassiveMessage>
        where TIn : MpRawMessage
    {
        private readonly Func<TIn, MessageContext, MpPassiveMessage> _lightweightFunc;
        internal LightweightMessageHandler(Func<TIn, MessageContext, MpPassiveMessage> lightweightFunc)
        {
            if (lightweightFunc == null)
            {
                throw new ArgumentNullException(nameof(lightweightFunc));
            }

            _lightweightFunc = lightweightFunc;
        }

        protected override MpPassiveMessage HandleMessage(TIn incomingMessage, MessageContext context)
        {
            return _lightweightFunc(incomingMessage, context);
        }
    }
}
