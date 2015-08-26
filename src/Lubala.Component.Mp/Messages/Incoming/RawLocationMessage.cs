using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [MsgType("location")]
    [XmlRoot("xml")]
    public class RawLocationMessage : MpIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("Location_X")]
        public double LocationX { get; set; }

        [XmlElement("Location_Y")]
        public double LocationY { get; set; }

        [XmlElement("Scale")]
        public string Scale { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}