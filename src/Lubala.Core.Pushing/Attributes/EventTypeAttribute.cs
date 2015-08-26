using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class EventTypeAttribute : MsgTypeAttribute
    {
        public EventTypeAttribute(string eventType) : base("event")
        {
            EventType = eventType;
        }

        public string EventType { get; private set; }
    }
}
