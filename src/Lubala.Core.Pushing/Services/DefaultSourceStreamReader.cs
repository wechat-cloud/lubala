using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Lubala.Core.Pushing.Services
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