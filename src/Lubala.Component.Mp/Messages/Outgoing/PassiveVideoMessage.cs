using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PassiveVideoMessage : MpOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }
}