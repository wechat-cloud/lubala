using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("text")]
    public class RawTextMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}