using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [MsgType("voice")]
    public class RawVoiceMessage : WechatPushingMessage, IAcceptPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("Format")]
        public string Format { get; set; }

        public override string MsgType => "voice";
    }
}