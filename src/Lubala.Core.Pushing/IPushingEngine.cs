using System.Collections.Generic;
using System.IO;

namespace Lubala.Core.Pushing
{
    internal interface IPushingEngine
    {
        string ProducePassiveMessage(Stream sourceStream, HubContext context, IDictionary<string, string> payloads);
    }
}