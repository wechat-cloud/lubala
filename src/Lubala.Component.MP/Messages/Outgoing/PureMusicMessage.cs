using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class PureMusicMessage : MPOutgoingMessage
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("MusicURL")]
        public string MusicURL { get; set; }

        [XmlElement("HQMusicUrl")]
        public string HQMusicUrl { get; set; }

        [XmlElement("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string MsgType => "music";
    }
}