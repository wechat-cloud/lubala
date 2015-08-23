using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing;

namespace Lubala.Pushing
{
    public static class PushingHubExtension
    {
        public static HubBuilder EnablePushingForMP(this HubBuilder hubBuilder)
        {
            // TODO: register default mp handlers.
            return hubBuilder;
        }
    }
}
