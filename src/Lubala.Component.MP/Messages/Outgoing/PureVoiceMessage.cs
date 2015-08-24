using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class PureVoiceMessage : MPOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "voice";
    }
}