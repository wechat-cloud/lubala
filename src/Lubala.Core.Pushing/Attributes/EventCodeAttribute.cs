using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Attributes
{
    public class EventCodeAttribute : Attribute
    {
        public EventCodeAttribute(string eventCode)
        {
            if (string.IsNullOrEmpty(eventCode))
            {
                throw new ArgumentNullException(nameof(eventCode));
            }

            EventCode = eventCode.ToLowerInvariant();
        }

        public string EventCode { get; private set; }
    }
}
