using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lubala.Core.Serialization
{
    internal class DefaultXmlSerializer : IXmlSerializer
    {
        public void Serialize<T>(T obj, Stream targetStream)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, xmlSettings))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    serializer.Serialize(writer, obj, ns);
                }

                stream.Position = 0;
                stream.WriteTo(targetStream);
            }
        }

        public T Deserialize<T>(Stream source)
        {
            var serializer = new XmlSerializer(typeof(T));
            var result = serializer.Deserialize(source);
            return (T) result;
        }
    }
}
