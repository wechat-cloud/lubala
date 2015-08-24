using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP.Messages;

namespace Lubala.Component.MP
{
    internal class LightweightMessageHandler<TIn> : MPMessageHandler<TIn, MPOutgoingMessage>
        where TIn : MPIncomingMessage
    {
        private readonly Func<TIn, MPOutgoingMessage> _lightweightFunc;
        internal LightweightMessageHandler(Func<TIn, MPOutgoingMessage> lightweightFunc)
        {
            if (lightweightFunc == null)
            {
                throw new ArgumentNullException(nameof(lightweightFunc));
            }

            _lightweightFunc = lightweightFunc;
        }
        public override MPOutgoingMessage HandleMessage(TIn incomingMessage)
        {
            return _lightweightFunc(incomingMessage);
        }
    }
}
