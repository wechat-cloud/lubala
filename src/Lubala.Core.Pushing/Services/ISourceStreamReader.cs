using System.IO;
using System.Xml.Linq;

namespace Lubala.Core.Pushing.Services
{
    public interface ISourceStreamReader
    {
        XDocument ReadAsXml(Stream sourceStream);
    }
}
