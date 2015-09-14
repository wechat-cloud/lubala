using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    public class PassiveImageMessage : MpPassiveMessage
    {
        [Node("MediaId")]
        public string MediaId { get; set; }

        protected override string MsgType => "image";
    }
}