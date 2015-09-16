using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public abstract class WechatPushingEvent : WechatPushingMessage
    {
        public override string MsgType => "event";

        [Node("Event")]
        public abstract string Event { get; }
    }
}