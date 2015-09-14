using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveTextMessage : WechatPassiveMessage
    {
        [Node("Content")]
        public string Content { get; set; }

        protected override string MsgType => "text";
    }
}