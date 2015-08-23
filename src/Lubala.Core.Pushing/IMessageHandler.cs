using System;

namespace Lubala.Core.Pushing
{
    public interface IMessageHandler
    {
        object HandleMessage(object incomingMessage);
    }

    public interface IMessageHandler<in TIn, out TOut> : IMessageHandler
        where TIn : InteractableMessage
        where TOut: IPassiveResponse
    {
        TOut HandleMessage(TIn incomingMessage);
	}
}

