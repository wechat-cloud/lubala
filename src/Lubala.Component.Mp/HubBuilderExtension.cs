using System;
using Lubala.Component.Mp;

namespace Lubala.Core.Pushing
{
    public static class HubBuilderExtension
    {
        public static IHubBuilder UseMP(this IHubBuilder hubBuilder, Action<MpConfigurer> configurer)
        {
            var mpConfigurer = new MpConfigurer(hubBuilder);
            configurer(mpConfigurer);

            return hubBuilder;
        }
    }
}