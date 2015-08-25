using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.Mp;
using Lubala.Component.Mp.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Pushing
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
