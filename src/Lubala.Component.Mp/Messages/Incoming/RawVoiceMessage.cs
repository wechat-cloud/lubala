using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("voice")]
    [XmlRoot("xml")]
    public class RawVoiceMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("Format")]
        public string Format { get; set; }
    }
}