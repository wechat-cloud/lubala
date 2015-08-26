using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lubala.Core.Pushing
{
    internal class TypeDetector
    {
        private readonly string _content;
        public TypeDetector(string content)
        {
            _content = content;
        }

        internal TypeIdentity Detecting()
        {
            var xmlDocument = XDocument.Parse(_content);
            var root = xmlDocument.Root;

            var msgTypeElement = root.Element("MsgType");
            var eventTypeElement = root.Element("Event");

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
