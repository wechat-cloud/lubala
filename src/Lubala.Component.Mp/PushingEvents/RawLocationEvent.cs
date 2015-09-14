using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [EventType("LOCATION")]
    public class RawLocationEvent : WechatPushingEvent
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