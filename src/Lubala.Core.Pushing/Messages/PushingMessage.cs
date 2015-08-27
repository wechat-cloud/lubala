using System;
using System.Xml.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing
{
    public abstract class PushingMessage
    {
        [Node("ToUserName")]
        public string ToUserName { get; protected set; }

        [Node("FromUserName")]
        public string FromUserName { get; protected set; }

        [Node("CreateTime")]
        public long CreateTime { get; protected set; }

        [Node("MsgType")]
        public abstract string MsgType { get; }

        protected void BridgeTo(PushingMessage target)
        {
            target.FromUserName = ToUserName;
            target.ToUserName = FromUserName;
            target.CreateTime = DateTimeOffset.UtcNow.DateTimeToEpoch();
        }
    }
}