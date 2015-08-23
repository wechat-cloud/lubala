using System;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
	public static class PushingExtension
	{
		public static IPushingHub CreatePushingHub(this ILubalaChannel channel, Action<HubBuilder> hubBuilder)
        {
			throw new NotImplementedException();
		}
	}
}

