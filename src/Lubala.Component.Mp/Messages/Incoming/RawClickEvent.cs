using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [EventType("CLICK")]
    public class RawClickEvent : InteractableEvent
    {
        [XmlElement("EventKey")]
        public string EventKey { get; set; }
    }
}