using System.IO;
using Lubala.Messages;

namespace Lubala.Dispatchers.Transforms
{
    public interface IMessageTypeRecognizer
    {
        MessageType Recognize(Stream bodyStream);
    }
}
