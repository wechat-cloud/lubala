using System;
using Lubala.Core.Pushing.Encoding;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing.Messages
{
	internal class EncryptedPassiveMessage : XmlPassiveMessage
	{
		[Node("MsgSignature")]
		public string MsgSignature { get; internal set; }

		[Node("TimeStamp")]
		public string TimeStamp{ get; internal set; }

		[Node("Nonce")]
		public string Nonce{ get; internal set; }

		[Node("Encrypt")]
		public string Encrypt { get; internal set; }
	}
}

