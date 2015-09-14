using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public class PassiveMusicMessage : WechatPassiveMessage
    {
        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        [Node("MusicUrl")]
        public string MusicUrl { get; set; }

        [Node("HighQualityMusicUrl")]
        public string HighQualityMusicUrl { get; set; }

        [Node("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        protected override string MsgType => "image";
    }
}