using System;
using Lubala.Core.Token;

namespace Lubala.Core
{
	public class LubalaChannelFactory
	{
		static LubalaChannelFactory() {
			// init resolver here.
		}

		public ILubalaChannel CreateDefaultChannel() {
			throw new NotImplementedException();
		}

		public ILubalaChannel CreateChannelWith(string apiKey, string apiSecret) {
			throw new NotImplementedException();
		}

		public ILubalaChannel CreateChannelWith(ITokenSource tokenSource) {
			throw new NotImplementedException();
		}
	}
}

