using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    [EventType("CLICK")]
    public class RawClickEvent : WechatPushingEvent
    {
        [XmlElement("EventKey")]
        public string EventKey { get; set; }

        public override string Event => "CLICK";
    }
}