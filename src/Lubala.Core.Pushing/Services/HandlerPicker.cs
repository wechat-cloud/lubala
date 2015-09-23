using System;
using System.Collections.Generic;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing.Services
{
    internal class HandlerPicker
    {
        private IReadOnlyDictionary<Type, IMessageHandler> _handlers;

        public HandlerPicker(IReadOnlyDictionary<Type, IMessageHandler> handlers)
        {
            _handlers = handlers;
        }

        public IMessageHandler Picking(WechatPushingMessage message)
        {
            var trueType = message.GetType();
            if (_handlers.ContainsKey(trueType))
            {
                return _handlers[trueType];
            }

            return null;
        }
    }
}
