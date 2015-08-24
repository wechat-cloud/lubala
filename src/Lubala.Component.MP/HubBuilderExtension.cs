using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP;
using Lubala.Component.MP.Messages;
using Lubala.Core.Pushing;

namespace Lubala.Pushing
{
    public static class HubBuilderExtension
    {
        public static IHubBuilder UseMP(this IHubBuilder hubBuilder, Action<MPConfigurer> configurer)
        {
            var mpConfigurer = new MPConfigurer(hubBuilder);
            configurer(mpConfigurer);

            return hubBuilder;
        }
    }
}
