using System.IO;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing.Messages
{
    public sealed class AsyncPassiveMessage : IPassiveMessage
    {
        public Task SerializeTo(Stream targetStream, HubContext context)
        {
            var encoding = System.Text.Encoding.Unicode;
            var bytes = encoding.GetBytes(string.Empty);

            return targetStream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}