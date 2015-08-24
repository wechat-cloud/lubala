using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
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