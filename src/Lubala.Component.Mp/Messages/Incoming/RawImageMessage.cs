using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("image")]
    [XmlRoot("xml")]
    public class RawImageMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("PicUrl")]
        public string PictureUrl { get; set; }

        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}