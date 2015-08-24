using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class RawImageMessage : MPIncomingMessage
    {
        [XmlElement("PicUrl")]
        public string PictureUrl { get; set; }

        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}