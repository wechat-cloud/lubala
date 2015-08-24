using System;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
	public static class PushingExtension
    {
        //var hub = channel.CreatePushingHub(builder =>
        //{
        //    builder.ConfigureMP(config =>
        //    {
        //        config.RegisterMessageHandler<IncomingTextMessage>(() => { });
        //        config.RegisterMessageHandler<IncomingTextMessage>(() => { });
        //    });

        //    builder.ConfigureUserManagement(config =>
        //    {
        //        config.RegisterMessageHandler<BlaBlaBla>(() => { });
        //    });
        //});

        //hub.Interpreting(Request.Stream, Response.Stream);
        public static IPushingHub CreatePushingHub(this ILubalaChannel channel, Action<IHubBuilder> configurer)
        {
            var builder = new HubBuilder(channel);
		    configurer(builder);

		    var pushingHub = builder.BuildPushingHub();
		    return pushingHub;
        }
	}
}

