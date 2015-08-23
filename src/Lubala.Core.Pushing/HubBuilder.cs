using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    public sealed class HubBuilder
    {
        public HubBuilder RegisterEventProcessor(EventProcessor eventProcessor)
        {
            throw new NotImplementedException();
        }

        public HubBuilder RegisterMessageHandler(Type MessageType, IMessageHandler messageHandler)
        {
            throw new NotImplementedException();
        }
    }
}
