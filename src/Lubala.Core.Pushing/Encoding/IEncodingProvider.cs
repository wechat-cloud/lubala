using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lubala.Core.Pushing.Encoding
{
    public interface IEncodingProvider
    {
        string EncryptMessage(string message, CryptographyContext context);
        XDocument DecryptMessage(XDocument xml, CryptographyContext context);
    }
}
