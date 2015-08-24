using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
    public interface IHubBuilder
    {
        IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler);
    }
}
