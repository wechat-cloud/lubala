using System;
using System.IO;
using Lubala.Core.Pushing;
using Lubala.Core.Serialization;
using Lubala.Core;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpPassiveMessage : XmlPassiveMessage
    {
        [Node("ToUserName")]
        protected string ToUserName { get; set; }

        [Node("FromUserName")]
        protected string FromUserName { get; set; }

        [Node("CreateTime")]
        protected long CreateTime { get; set; }

        [Node("MsgType")]
        protected abstract string MsgType { get; }

        internal void ReplyTo(MpRawMessage rawMessage)
		{
			this.FromUserName = rawMessage.ToUserName;
			this.ToUserName = rawMessage.FromUserName;
			this.CreateTime = DateTimeOffset.UtcNow.DateTimeToEpoch();
		}
	}
}

