using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MessageType("image")]
    [XmlRoot("xml")]
    public class RawShortVideoMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string MsgType => "shortvideo";
    }
}