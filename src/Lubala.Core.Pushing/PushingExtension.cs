using System;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
	public static class PushingExtension
    {
	    public static IPushingHub CreatePushingHub(this ILubalaChannel channel, Action<IHubBuilder> configurer)
        {
            var builder = new HubBuilder(channel);
		    configurer(builder);

		    var pushingHub = builder.BuildPushingHub();
		    return pushingHub;
        }
	}
}

