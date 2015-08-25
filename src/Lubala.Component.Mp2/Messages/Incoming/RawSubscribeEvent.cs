using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [MessageType("event", EventType = "subscribe")]
    public class RawSubscribeEvent : InteactableEvent
    {
        public override string Event => "subscribe";

        [XmlElement("EventKey")]
        public string EventKey { get; set; }

        [XmlElement("Ticket")]
        public string Ticket { get; set; }
    }
}