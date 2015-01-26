using System;

namespace Lubala
{
	public class RequestAuth
	{
		public string Signature {
			get;
			set;
		}

		public long Timestamp {
			get;
			set;
		}

		public string Nonce {
			get;
			set;
		}

		public string Echostr{
			get;
			set;
		}
	}
}

