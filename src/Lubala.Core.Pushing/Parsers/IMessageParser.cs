using System.IO;

namespace Lubala.Core.Pushing
{
    public interface IMessageParser
    {
        InteractableMessage ParseMessage(Stream sourceStream, HubContext context);
    }
}