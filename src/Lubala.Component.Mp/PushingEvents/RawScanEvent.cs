using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [EventType("SCAN")]
    public class RawScanEvent : WechatPushingEvent
    {
        [Node("EventKey")]
        public string EventKey { get; set; }

        [Node("Ticket")]
        public string Ticket { get; set; }

        public override string Event => "SCAN";
    }
}