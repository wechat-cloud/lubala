using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages
{
    [EventType("CLICK")]
    public class RawClickEvent : PushingEvent
    {
        [XmlElement("EventKey")]
        public string EventKey { get; set; }

        public override string Event => "CLICK";
    }
}