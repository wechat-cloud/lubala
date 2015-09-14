using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [MsgType("shortvideo")]
    public class RawShortVideoMessage : WechatPushingMessage, IAcceptPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string MsgType => "shortvideo";
    }
}