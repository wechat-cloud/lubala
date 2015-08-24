using System;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
	public abstract class MPOutgoingMessage : InteractableMessage, IPassiveMessage
	{
	    public string Serialize()
	    {
	        throw new NotImplementedException();
	    }
	}
}

