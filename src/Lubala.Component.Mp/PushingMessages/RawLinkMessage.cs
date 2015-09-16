using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [MsgType("link")]
    public class RawLinkMessage : WechatPushingMessage, IAcceptPassiveMessage
    {
        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        [Node("Url")]
        public string Url { get; set; }

        public override string MsgType => "link";
    }
}