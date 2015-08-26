using System.IO;

namespace Lubala.Core.Pushing
{
    internal interface IPushingEngine
    {
        IPassiveMessage ProducePassiveMessage(Stream sourceStream, HubContext context);
    }
}