using System;
using System.IO;
using Lubala.Core.Pushing;
using Lubala.Core.Serialization;
using Lubala.Core;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpPassiveMessage : XmlPassiveMessage
	{
		internal void ReplyTo(MpRawMessage rawMessage)
		{
			this.FromUserName = rawMessage.ToUserName;
			this.ToUserName = rawMessage.FromUserName;
			this.CreateTime = DateTimeOffset.UtcNow.DateTimeToEpoch();
		}
	}
}

