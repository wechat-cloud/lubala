using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages.Incoming
{
    [XmlRoot("xml")]
    [EventType("unsubscribe")]
    public class RawUnsubscribeEvent : InteractableEvent
    {
    }
}