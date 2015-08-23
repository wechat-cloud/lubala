using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    public sealed class EventProcessor
    {
        public EventProcessor(string eventCode, IMessageParser messageParser)
        {
            if (string.IsNullOrEmpty(eventCode))
            {
            }
            if (messageParser == null)
            {
            }

            EventCode = eventCode;
            MessageParser = messageParser;
        }

        public string EventCode { get; private set; }
        public IMessageParser MessageParser { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var target = (EventProcessor) obj;

            return EventCode.ToLowerInvariant() == target.EventCode.ToLowerInvariant();
        }

        public override int GetHashCode()
        {
            return EventCode.GetHashCode();
        }

        public override string ToString()
        {
            var parser = MessageParser.GetType().FullName;
            return $"{EventCode.ToLowerInvariant()}: {parser}";
        }
    }
}
