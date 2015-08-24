using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class RawTextMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}