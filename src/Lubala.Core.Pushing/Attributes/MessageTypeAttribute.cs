using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MessageTypeAttribute : Attribute
    {
        public MessageTypeAttribute(string msgType)
        {
            if (string.IsNullOrEmpty(msgType))
            {
                throw new ArgumentNullException(nameof(msgType));
            }

            MsgType = msgType;
        }

        public string MsgType { get; private set; }
        public string EventType { get; set; }
    }
}
