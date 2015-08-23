using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    internal class PushingHub : IPushingHub
    {
        internal PushingHub(HubContext hubContext)
        {
            if (hubContext == null)
            {
                throw new ArgumentNullException(nameof(hubContext));
            }
            
        }

        internal IReadOnlyCollection<IEventProcessor> EventProcessors { get; private set; }
        internal IReadOnlyCollection<IMessageHandler> MessageHandlers { get; private set; }

        public void Interpreting(Stream sourceStream, Stream targetStream)
        {
            throw new NotImplementedException();
        }
    }
}
