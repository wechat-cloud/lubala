using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
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