using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    public class PassiveVideoMessage : MpPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        [Node("Title")]
        public string Title { get; set; }

        [Node("Description")]
        public string Description { get; set; }

        protected override string MsgType => "video";
    }
}