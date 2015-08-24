using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class RawVideoMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string MsgType => "video";
    }
}