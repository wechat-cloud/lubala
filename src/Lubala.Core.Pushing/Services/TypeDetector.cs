using System.Xml.Linq;
using Lubala.Core.Logs;

namespace Lubala.Core.Pushing.Services
{
    internal class TypeDetector : ITypeDetector
    {
        public TypeIdentity Detecting(XDocument xml)
        {
            var root = xml.Root;

            var msgTypeElement = root?.Element("MsgType");
            var eventTypeElement = root?.Element("Event");

            var msgType = msgTypeElement?.Value;
            var eventType = eventTypeElement?.Value;

            Log.Logger.Info("MsgType: {0}, Event: {1}", msgType, eventType);

            return new TypeIdentity
            {
                MsgType = msgType,
                EventType = eventType
            };
        }
    }
}
