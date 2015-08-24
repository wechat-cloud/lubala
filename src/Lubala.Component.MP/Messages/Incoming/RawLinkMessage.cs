using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP.Messages
{
    [EventCode("image")]
    [XmlRoot("xml")]
    public class RawLinkMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Url")]
        public string Url { get; set; }

        public override string MsgType => "link";
    }
}