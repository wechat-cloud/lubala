using System.Xml.Serialization;

namespace Lubala.Component.Mp.Messages
{
    [XmlRoot("xml")]
    public class PureVideoMessage : MpOutgoingMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        public override string MsgType => "video";
    }
}