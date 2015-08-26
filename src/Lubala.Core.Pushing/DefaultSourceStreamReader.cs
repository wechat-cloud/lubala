using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Lubala.Core.Pushing;

namespace Lubala.Core
{
    internal class DefaultSourceStreamReader : ISourceStreamReader
    {
        public XDocument ReadAsXml(Stream sourceStream)
        {
            using (var reader = XmlReader.Create(sourceStream))
            {
                return XDocument.Load(reader);
            }
        }
    }
}