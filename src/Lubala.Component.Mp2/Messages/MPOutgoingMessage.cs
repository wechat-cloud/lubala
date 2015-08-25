using System;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MPOutgoingMessage : InteractableMessage, IPassiveMessage
	{
	    public string Serialize()
	    {
	        throw new NotImplementedException();
	    }
	}
}

