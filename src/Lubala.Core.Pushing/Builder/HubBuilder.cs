using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    internal sealed class HubBuilder : IHubBuilder
    {
        private readonly HubContext _context;
        public HubBuilder(ILubalaChannel channel)
        {
            _context = new HubContext {Channel = channel};
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
