using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [EventType("SCAN")]
    public class RawScanEvent : InteractableEvent
    {
        [XmlElement("EventKey")]
        public string EventKey { get; set; }

        [XmlElement("Ticket")]
        public string Ticket { get; set; }
    }
}