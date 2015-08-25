using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    internal sealed class HubBuilder : IHubBuilder
    {
        private readonly HubContext _context;
        public HubBuilder(ILubalaChannel channel)
        {
            _context = new HubContext {Channel = channel};
        }

        public IHubBuilder RegisterMessageType<T>() where T : IPushingMessage
        {
            var targetType = typeof (T);
            var eventCodeAttribute = targetType.GetCustomAttribute(typeof (MessageTypeAttribute));
            if (eventCodeAttribute == null)
            {
                throw new InvalidOperationException($"{targetType.Name} doesn't setup EventCode attribute.");
            }

            var eventCode = ((MessageTypeAttribute) eventCodeAttribute).MsgType;

            _context.MessageTypes.Add(eventCode, targetType);
            return this;
        }

        public IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler)
        {
            _context.MessageHandlers.Add(messageType, messageHandler);
            return this;
        }

        internal IPushingHub BuildPushingHub()
        {
            return new PushingHub(_context);
        }
    }
}
