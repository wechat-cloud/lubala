using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PureMusicMessage : MpOutgoingMessage
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("MusicUrl")]
        public string MusicUrl { get; set; }

        [XmlElement("HighQualityMusicUrl")]
        public string HighQualityMusicUrl { get; set; }

        [XmlElement("ThumbMediaId")]
        public string ThumbMediaId { get; set; }
    }
}