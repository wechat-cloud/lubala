using System;

namespace Lubala.Core
{
	public class WechatToken
	{
		public string AccessToken{ get; internal set; }

		public int ExpiresIn{ get; internal set; }
        
		internal DateTimeOffset TokenCreatedDateTime{ get; set; }
        
		public DateTimeOffset ExpiredDateTime { get { return TokenCreatedDateTime.AddSeconds(ExpiresIn); } }
	}
}

