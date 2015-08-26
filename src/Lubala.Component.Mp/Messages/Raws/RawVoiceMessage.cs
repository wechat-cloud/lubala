using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("voice")]
    public class RawVoiceMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("Format")]
        public string Format { get; set; }

        public override string MsgType => "voice";
    }
}