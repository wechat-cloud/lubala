using System;
using Lubala.Core.Logs;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
	public static class PushingExtension
    {
	    public static IPushingHub CreatePushingHub(this ILubalaChannel channel, Action<IHubBuilder> configurer)
	    {
	        Log.Logger.Debug("creating pushing hub.");
            var builder = new HubBuilder(channel);
		    configurer(builder);

		    var pushingHub = builder.BuildPushingHub();
            Log.Logger.Debug("created pushing hub.");
            return pushingHub;
        }
	}
}

