using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("location")]
    public class RawLocationMessage : MpRawMessage, IAcceptPassiveMessage
    {
        [Node("Location_X")]
        public double LocationX { get; set; }

        [Node("Location_Y")]
        public double LocationY { get; set; }

        [Node("Scale")]
        public string Scale { get; set; }

        [Node("Label")]
        public string Label { get; set; }

        public override string MsgType => "location";
    }
}