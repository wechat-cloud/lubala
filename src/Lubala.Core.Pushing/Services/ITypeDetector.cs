using System.Xml.Linq;

namespace Lubala.Core.Pushing.Services
{
    public interface ITypeDetector
    {
        TypeIdentity Detecting(XDocument xml);
    }
}