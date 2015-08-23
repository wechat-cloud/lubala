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
        private HubContext _hubContext;
        internal PushingHub(HubContext hubContext)
        {
            if (hubContext == null)
            {
                throw new ArgumentNullException(nameof(hubContext));
            }

            _hubContext = hubContext;
        }

        public IReadOnlyCollection<EventProcessor> EventProcessors { get; private set; }
        public IReadOnlyCollection<IMessageHandler> MessageHandlers { get; private set; }

		public void Interpreting(Stream sourceStream, Stream targetStream, EncodingOption encodingOption = null)
        {

            // TODO: pick up one event processor.
            EventProcessor processor = null;
            if (processor == null)
            {
                // TODO: write empty string.
            }

            // var incomingMessage = processor.MessageParser.ParseMessage(sourceStream, _hubContext);

            // var incomingMessageType = incomingMessage.GetType();

            // TODO: pick up one message handler.
            // IMessageHandler handler = null;
            // var result = handler.HandleMessage(incomingMessage);

            // TODO: write result into target stream.
            throw new NotImplementedException();
        }
    }
}
