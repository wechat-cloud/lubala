using Lubala.Messages;

namespace Lubala
{
    public interface ILubalaKernel
    {
        KernelSetting Setting { get; }
        void RegisterHandler(IMessageHandler messageHandler);
        MessageBase ExecuteOn(IWechatContext wechatContext);
    }
}