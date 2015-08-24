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

            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using (var writer = XmlWriter.Create(targetStream, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                serializer.Serialize(writer, obj, ns);
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
