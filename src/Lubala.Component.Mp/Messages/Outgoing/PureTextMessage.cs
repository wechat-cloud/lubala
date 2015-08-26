using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PureTextMessage : MpOutgoingMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }
    }
}