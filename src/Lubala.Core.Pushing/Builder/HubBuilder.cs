using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    internal sealed class HubBuilder : IHubBuilder
    {
        public IHubBuilder RegisterEventProcessor(EventProcessor eventProcessor)
        {
            throw new NotImplementedException();
        }

        public IHubBuilder RegisterMessageHandler(Type MessageType, IMessageHandler messageHandler)
        {
            throw new NotImplementedException();
        }
    }
}
