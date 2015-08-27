using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [EventType("LOCATION")]
    public class RawLocationEvent : PushingEvent
    {
        [Node("Latitude")]
        public double Latitude { get; set; }

        [Node("Longitude")]
        public double Longitude { get; set; }

        [Node("Precision")]
        public double Precision { get; set; }

        public override string Event => "LOCATION";
    }
}