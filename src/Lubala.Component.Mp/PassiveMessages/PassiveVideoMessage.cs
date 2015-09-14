using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveVideoMessage : WechatPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        protected override string MsgType => "video";
    }
}