using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MessageType("image")]
    [XmlRoot("xml")]
    public class RawTextMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}