using System;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core
{
	public class WechatToken
	{
		public string AccessToken{ get; internal set; }

		public int ExpiresIn{ get; internal set; }

		[Ignore]
		internal DateTimeOffset TokenCreatedDateTime{ get; set; }

		[Ignore]
		public DateTimeOffset ExpiredDateTime { get { return TokenCreatedDateTime.AddSeconds(ExpiresIn); } }
	}
}

