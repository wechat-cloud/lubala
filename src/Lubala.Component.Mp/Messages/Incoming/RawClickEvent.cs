using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [MessageType("event", EventType = "CLICK")]
    public class RawClickEvent : InteactableEvent
    {
        public override string Event => "CLICK";

        [XmlElement("EventKey")]
        public string EventKey { get; set; }
    }
}