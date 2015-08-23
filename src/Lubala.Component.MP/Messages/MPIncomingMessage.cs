using System;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
	public abstract class MPIncomingMessage : InteractableMessage, IDuplicateCheckable
	{
		
		public double MsgId { get; }
	}
}

