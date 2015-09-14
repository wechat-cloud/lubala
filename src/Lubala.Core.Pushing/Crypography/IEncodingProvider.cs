using System.Xml.Linq;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing.Crypography
{
    public interface IEncodingProvider
    {
		IPassiveMessage EncryptMessage(IPassiveMessage message, CryptographyContext context);
        XDocument DecryptMessage(XDocument xml, CryptographyContext context);
    }
}
