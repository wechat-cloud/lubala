using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lubala.Core.Pushing.Messages
{
    public abstract class InteactableEvent : InteractableMessage, IPushingMessage
    {
        public override sealed string MsgType => "event";

        [XmlElement("Event")]
        public abstract string Event { get; }
    }
}
