using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lubala.Core.Pushing
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

            return new TypeIdentity
            {
                MsgType = msgType,
                EventType = eventType
            };
        }
    }
}
