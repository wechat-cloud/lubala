using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("image")]
    public class RawImageMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("PicUrl")]
        public string PictureUrl { get; set; }

        [Node("MediaId")]
        public string MediaId { get; set; }

        public override string MsgType => "image";
    }
}