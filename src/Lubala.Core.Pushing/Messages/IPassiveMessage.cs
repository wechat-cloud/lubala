using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Serialization;
using System.IO;

namespace Lubala.Core.Pushing.Messages
{
	public interface IPassiveMessage
	{
	    Task SerializeTo(Stream targetStream, HubContext context);
	}
}
