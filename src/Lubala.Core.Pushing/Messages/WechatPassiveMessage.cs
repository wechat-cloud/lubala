using System;
using System.IO;
using Lubala.Core.Pushing;
using Lubala.Core.Serialization;
using Lubala.Core;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
	public abstract class WechatPassiveMessage : XmlPassiveMessage
    {
        [Node("ToUserName")]
        internal string ToUserName { get; set; }

        [Node("FromUserName")]
        internal string FromUserName { get; set; }

        [Node("CreateTime")]
        internal long CreateTime { get; set; }

        [Node("MsgType")]
        protected abstract string MsgType { get; }

        internal void BridgeTo(WechatPushingMessage rawMessage)
        {
            this.FromUserName = rawMessage.ToUserName;
            this.ToUserName = rawMessage.FromUserName;
            this.CreateTime = DateTimeOffset.UtcNow.DateTimeToEpoch();
        }
    }
}

