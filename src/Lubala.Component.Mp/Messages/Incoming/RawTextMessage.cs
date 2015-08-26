using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("text")]
    [XmlRoot("xml")]
    public class RawTextMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Content")]
        public string Content { get; set; }
    }
}