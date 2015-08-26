using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PassiveTextMessage : MpOutgoingMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }
    }
}