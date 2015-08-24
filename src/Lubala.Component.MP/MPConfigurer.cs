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
    public sealed class MPConfigurer
    {
        private IHubBuilder _hubBuilder;
        public MPConfigurer(IHubBuilder hubBuilder)
        {
            _hubBuilder = hubBuilder;

            RegisterDefaultEventProcessors();
        }

        private void RegisterDefaultEventProcessors()
        {
            RegisterEventProcessor(new ImageMessageParser());
            RegisterEventProcessor(new LinkMessageParser());
            RegisterEventProcessor(new LocationMessageParser());
            RegisterEventProcessor(new ShortVideoMessageParser());
            RegisterEventProcessor(new TextMessageParser());
            RegisterEventProcessor(new VideoMessageParser());
            RegisterEventProcessor(new VoiceMessageParser());
        }

        private void RegisterEventProcessor(IMessageParser parser)
        {
            var attr = parser.GetType().GetCustomAttribute(typeof (EventCodeAttribute));
            if (attr == null)
            {
                // TODO: log
                return;
            }

            var eventCodeAttribute = (EventCodeAttribute) attr;
            var processor = new EventProcessor(eventCodeAttribute.EventCode, parser);
            _hubBuilder.RegisterEventProcessor(processor);
        }

        public MPConfigurer RegisterMessageHandler(MPMessageHandler handler)
        {
            var incomingMessageType = handler.IncomingMessageType;
            _hubBuilder.RegisterMessageHandler(incomingMessageType, handler);
            return this;
        }
    }
}
