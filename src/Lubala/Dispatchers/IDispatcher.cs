using Lubala.Processors;

namespace Lubala.Dispatchers
{
    internal interface IDispatcher
    {
        MessageProcessor Dispatching(KernelContext wechatContext);
    }
}