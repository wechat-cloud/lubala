using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP.Messages;
using Lubala.Component.MP.Parsers;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP
{
    public sealed class MPConfig
    {
        private HubBuilder _hubBuilder;
        public MPConfig(HubBuilder hubBuilder)
        {
            _hubBuilder = hubBuilder;

            RegisterDefaultEventProcessors();
        }

        private void RegisterDefaultEventProcessors()
        {
            RegisterEventProcessor(new ImageMessageParser());
        }

        private void RegisterEventProcessor(IMessageParser parser)
        {
            var attr = parser.GetType().GetCustomAttribute(typeof (EventCodeAttribute));
            if (attr == null)
            {
                // TODO: log
            }

            var eventCodeAttribute = (EventCodeAttribute) attr;
            var processor = new EventProcessor(eventCodeAttribute.EventCode, parser);
            _hubBuilder.RegisterEventProcessor(processor);
        }

        public MPConfig RegisterMessageHandler<T>(IMessageHandler<T, MPOutgoingMessage> handler) where T: MPIncomingMessage
        {
            _hubBuilder.RegisterMessageHandler(typeof (T), handler);
            return this;
        }
    }
}
