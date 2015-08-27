using System;
using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing
{
    public abstract class PushingMessage
    {
        [Node("ToUserName")]
        public string ToUserName { get; private set; }

        [Node("FromUserName")]
        public string FromUserName { get; private set; }

        [Node("CreateTime")]
        public int CreateTime { get; private set; }

        [Node("MsgType")]
        public abstract string MsgType { get; }
    }
}