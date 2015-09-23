using System.IO;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Messages
{
    public interface IPassiveMessage
    {
        Task SerializeTo(Stream targetStream, HubContext context);
    }
}