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
        IHubBuilder UseEncoding(string signature, string serverToken, bool compatible = true);
        IHubBuilder RegisterMessageType<T>() where T : WechatPushingMessage;
        IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler);
    }
}
