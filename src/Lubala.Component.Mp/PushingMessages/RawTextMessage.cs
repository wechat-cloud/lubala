using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [MsgType("text")]
    public class RawTextMessage : WechatPushingMessage, IAcceptPassiveMessage
    {
        [Node("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}