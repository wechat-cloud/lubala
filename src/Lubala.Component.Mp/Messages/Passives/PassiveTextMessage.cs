using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    public class PassiveTextMessage : MpPassiveMessage
    {
        [Node("Content")]
        public string Content { get; set; }

        public override string MsgType => "text";
    }
}