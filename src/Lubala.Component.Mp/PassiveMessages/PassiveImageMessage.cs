using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveImageMessage : WechatPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        protected override string MsgType => "image";
    }
}