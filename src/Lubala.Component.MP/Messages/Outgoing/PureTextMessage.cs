using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class PureTextMessage : MPOutgoingMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}