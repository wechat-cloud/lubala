using Lubala.Processors;

namespace Lubala.Dispatchers
{
    internal interface IDispatcher
    {
        IMessageProcessor Dispatching(KernelContext wechatContext);
    }
}