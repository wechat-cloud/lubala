using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    internal interface IPushingEngine
    {
        Task<IPassiveMessage> ProducePassiveMessage(Stream sourceStream, HubContext context, IDictionary<string, string> payloads);
    }
}