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

            MessageHandlers = _hubContext.GetMessageHandlers();
        }

        public IReadOnlyDictionary<Type, IMessageHandler> MessageHandlers { get; private set; }

        public string Interpreting(string content, EncodingOption encodingOption = null)
        {
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
