using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    [Serializable]
    public abstract class InteractableMessage
    {
        public string ToUserName { get; protected set; }
        public string FromUserName { get; protected set; }
        public int CreateTime { get; protected set; }
        public string MsgType { get; protected set; }
    }
}
