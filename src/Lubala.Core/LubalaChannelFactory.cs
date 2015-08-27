using System;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
	public class LubalaChannelFactory
	{
		static LubalaChannelFactory() {
			// init resolver here.
		}

		public ILubalaChannel CreateChannel(string apiKey, string apiSecret) {
			var channel = new LubalaChannel(apiKey, apiSecret);
		    return channel;
		}
	}
}

