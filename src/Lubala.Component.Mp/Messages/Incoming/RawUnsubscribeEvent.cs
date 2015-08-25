using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [MessageType("event", EventType = "unsubscribe")]
    public class RawUnsubscribeEvent : InteactableEvent
    {
        public override string Event => "unsubscribe";
    }
}