using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class PureImageMessage : MPOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}