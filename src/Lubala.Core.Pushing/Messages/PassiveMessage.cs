using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Serialization;
using System.IO;

namespace Lubala.Core.Pushing
{
	public abstract class PassiveMessage
	{
		internal virtual Task SerializeTo(Stream targetStream, HubContext context) {
			var xmlSerializer = context.Resolver.Resolve<IXmlSerializer>();
			return Task.Factory.StartNew(() => xmlSerializer.Serialize(this, targetStream));
		}
	}
}
