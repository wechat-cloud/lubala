using System;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    public interface IHubBuilder
    {
        IHubBuilder UseAutoEncoding(string encodingAesKey, string serverToken);
        IHubBuilder UseEncoding(string encodingAesKey, string serverToken, bool compatible = true);
        IHubBuilder RegisterMessageType<T>() where T : WechatPushingMessage;
        IHubBuilder RegisterMessageHandler(Type messageType, IMessageHandler messageHandler);
    }
}