using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lubala.Core.Logs;

namespace Lubala.Core.Serialization
{
    internal class DefaultXmlSerializer : IXmlSerializer
    {
        public void Serialize<T>(T obj, Stream targetStream)
        {
            Log.Logger.Debug("serializing message.");
            var serializer = new XmlSerializer(typeof (T));

            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
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
            Log.Logger.Debug("serializing message done.");
        }

        public T Deserialize<T>(XDocument xml)
        {
            return (T) Deserialize(xml, typeof (T));
        }

        public object Deserialize(XDocument xml, Type type)
        {
            using (var reader = xml.CreateReader())
            {
                Log.Logger.Debug("deserializing message.");
                var serializer = new XmlSerializer(type);
                var result = serializer.Deserialize(reader);
                Log.Logger.Debug("deserializing message done.");
                return result;
            }
        }
    }
}