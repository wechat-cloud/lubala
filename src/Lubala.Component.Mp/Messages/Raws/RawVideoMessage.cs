using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("video")]
    public class RawVideoMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("ThumbMediaId")]
        public string ThumbMediaId { get; set; }

        public override string MsgType => "video";
    }
}