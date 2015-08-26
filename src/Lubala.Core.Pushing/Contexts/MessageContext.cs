using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    public sealed class MessageContext
    {
        public ILubalaChannel Channel { get; internal set; }

        public string Raw { get; internal set; }
        public string MsgType { get; internal set; }
        public string EventType { get; internal set; }
        public bool SupportPassiveMessage { get; internal set; }
    }
}
