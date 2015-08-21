using Lubala.Messages;

namespace Lubala.Dispatchers.Transforms
{
    public interface IMessageTypeMapper
    {
        MessageType Map(string msgTypeText);
    }
}
