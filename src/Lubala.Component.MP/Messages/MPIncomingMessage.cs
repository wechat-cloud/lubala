using System;
using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
	public abstract class MPIncomingMessage : InteractableMessage, IDuplicateCheckable
    {
        [XmlElement("CreateTime", typeof(long))]
        public long MsgId { get; }
	}
}

