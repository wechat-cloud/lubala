using Lubala.Core.Pushing.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [EventType("unsubscribe")]
    public class RawUnsubscribeEvent : WechatPushingEvent
    {
        public override string Event => "unsubscribe";
    }
}