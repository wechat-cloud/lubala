using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [EventType("subscribe")]
    public class RawSubscribeEvent : WechatPushingEvent
    {
        [Node("EventKey")]
        public string EventKey { get; set; }

        [Node("Ticket")]
        public string Ticket { get; set; }

        public override string Event => "subscribe";
    }
}