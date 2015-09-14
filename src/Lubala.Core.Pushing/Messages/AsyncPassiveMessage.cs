using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Serialization;
using System.IO;

namespace Lubala.Core.Pushing.Messages
{
	public sealed class AsyncPassiveMessage : PassiveMessage
    {
		internal override Task SerializeTo(Stream targetStream, HubContext context) {
			var encoding = System.Text.Encoding.Unicode;
			var bytes = encoding.GetBytes(string.Empty);

			return targetStream.WriteAsync(bytes, 0, bytes.Length);
		}
    }
}
