using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
