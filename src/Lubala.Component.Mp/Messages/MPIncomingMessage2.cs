using System;
using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpIncomingMessage : InteractableMessage, IPushingMessage, IDuplicateCheckable
    {
        [XmlElement("CreateTime", typeof(long))]
        public long MsgId { get; }
	}
}

