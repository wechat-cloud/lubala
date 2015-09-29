using System;
using System.IO;
using System.Xml.Linq;

namespace Lubala.Core.Serialization
{
    public interface IXmlSerializer
    {
        void Serialize<T>(T obj, Stream targetStream);

        T Deserialize<T>(XDocument xml);
        object Deserialize(XDocument xml, Type type);
    }
}