using System;
using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
	public abstract class WechatPushingMessage : IDuplicateCheckable
    {
        [Node("ToUserName")]
        public string ToUserName { get; protected set; }

        [Node("FromUserName")]
        public string FromUserName { get; protected set; }

        [Node("CreateTime")]
        public long CreateTime { get; protected set; }

        [Node("MsgType")]
        public abstract string MsgType { get; }

        [XmlElement("MsgId", typeof(long))]
        public long MsgId { get; private set; }
    }
}

