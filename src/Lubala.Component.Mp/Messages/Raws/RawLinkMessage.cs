using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("link")]
    public class RawLinkMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        [Node("Url")]
        public string Url { get; set; }

        public override string MsgType => "link";
    }
}