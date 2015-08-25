using System;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpOutgoingMessage : InteractableMessage, IPassiveMessage
	{
	    public string Serialize()
	    {
	        throw new NotImplementedException();
	    }
	}
}

