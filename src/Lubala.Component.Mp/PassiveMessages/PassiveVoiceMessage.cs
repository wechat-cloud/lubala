using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveVoiceMessage : WechatPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        protected override string MsgType => "voice";
    }
}