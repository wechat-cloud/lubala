using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [MsgType("image")]
    public class RawImageMessage : WechatPushingMessage, IAcceptPassiveMessage
    {
        [Node("PicUrl")]
        public string PictureUrl { get; set; }

        [Node("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}