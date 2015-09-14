using System;
using System.IO;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
	public abstract class XmlPassiveMessage : IPassiveMessage
	{
        public Task SerializeTo(Stream targetStream, HubContext context)
        {
            var xmlSerializer = context.Resolver.Resolve<IXmlSerializer>();
            return Task.Factory.StartNew(() => xmlSerializer.Serialize(this, targetStream));
        }
    }
}