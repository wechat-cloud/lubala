using System.Xml.Linq;

namespace Lubala.Core.Pushing
{
    public interface ITypeDetector
    {
        TypeIdentity Detecting(XDocument xml);
    }
}