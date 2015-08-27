using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages
{
    [EventType("unsubscribe")]
    public class RawUnsubscribeEvent : PushingEvent
    {
        public override string Event => "unsubscribe";
    }
}