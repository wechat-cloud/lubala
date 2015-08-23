using System;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
	public static class PushingExtension
	{
		public static IPushingHub CreatePushingHub(this ILubalaChannel channel, Action<HubBuilder> hubBuilder)
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

            throw new NotImplementedException();
		}
	}
}

