using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    public class PassiveMusicMessage : MpPassiveMessage
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

        public override string MsgType => "image";
    }
}