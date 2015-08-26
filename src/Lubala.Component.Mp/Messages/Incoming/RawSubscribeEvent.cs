using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [EventType("subscribe")]
    public class RawSubscribeEvent : InteractableEvent
    {
        [XmlElement("EventKey")]
        public string EventKey { get; set; }

        [XmlElement("Ticket")]
        public string Ticket { get; set; }
    }
}