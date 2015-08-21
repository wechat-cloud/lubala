using System;

namespace Lubala
{
	public class SignLoad
	{
		internal SignLoad(string signature, long timestamp, string nonce)
		{

			Signature = signature;
			Timestamp = timestamp;
			Nonce = nonce;
		}

		public string Signature { get; private set; }

		public long Timestamp { get; private set; }

		public string Nonce { get; private set; }

		//public string Echostr { get; private set; }

		public bool ValidateSignature() {
			throw new NotImplementedException();
		}
	}
}

