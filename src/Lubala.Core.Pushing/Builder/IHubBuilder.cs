using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    public interface IHubBuilder
    {
        IHubBuilder RegisterMessageType<T>() where T : IPushingMessage;
        IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler);
    }
}
