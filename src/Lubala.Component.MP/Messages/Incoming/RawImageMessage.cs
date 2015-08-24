using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP.Messages
{
    [EventCode("image")]
    [XmlRoot("xml")]
    public class RawImageMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("PicUrl")]
        public string PictureUrl { get; set; }

        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}