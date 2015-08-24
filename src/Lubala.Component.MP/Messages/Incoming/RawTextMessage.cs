using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP.Messages
{
    [EventCode("image")]
    [XmlRoot("xml")]
    public class RawTextMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}