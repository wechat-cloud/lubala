using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Serialization
{
    public interface IXmlSerializer
    {
        void Serialize<T>(T obj, Stream targetStream);
        T Deserialize<T>(Stream source);
        object Deserialize(Stream source, Type type);
    }
}
