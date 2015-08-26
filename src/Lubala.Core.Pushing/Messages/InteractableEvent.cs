using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lubala.Core.Pushing.Messages
{
    public abstract class InteractableEvent : InteractableMessage, IPushingMessage
    {
        [XmlElement("Event")]
        public string Event { get; set; }
    }
}
