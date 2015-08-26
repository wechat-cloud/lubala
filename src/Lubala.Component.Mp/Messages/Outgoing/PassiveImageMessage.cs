using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PassiveImageMessage : MpOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}