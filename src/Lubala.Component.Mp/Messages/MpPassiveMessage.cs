using System;
using Lubala.Core.Pushing;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpPassiveMessage : PushingMessage, IPassiveMessage
	{
	    public string Serialize()
	    {
	        throw new NotImplementedException();
	    }
	}
}

