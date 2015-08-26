using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PassiveVoiceMessage : MpOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}