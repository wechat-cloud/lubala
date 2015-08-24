﻿using System;
using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Component.MP.Messages
{
	public abstract class MPIncomingMessage : InteractableMessage, IPushingMessage, IDuplicateCheckable
    {
        [XmlElement("CreateTime", typeof(long))]
        public long MsgId { get; }
	}
}

