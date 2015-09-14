using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
    public abstract class PushingEvent : PushingMessage
    {
        public override string MsgType => "event";

        [Node("Event")]
        public abstract string Event { get; }
    }
}
