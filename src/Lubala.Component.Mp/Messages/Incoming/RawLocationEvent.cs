using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [MessageType("event", EventType = "LOCATION")]
    public class RawLocationEvent : InteactableEvent
    {
        public override string Event => "LOCATION";

        [XmlElement("Latitude")]
        public double Latitude { get; set; }

        [XmlElement("Longitude")]
        public double Longitude { get; set; }

        [XmlElement("Precision")]
        public double Precision { get; set; }
    }
}