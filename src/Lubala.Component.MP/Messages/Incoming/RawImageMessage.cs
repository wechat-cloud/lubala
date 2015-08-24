using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class RawImageMessage : MPIncomingMessage
    {
        [XmlElement("PicUrl")]
        public string PicUrl { get; set; }

        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}