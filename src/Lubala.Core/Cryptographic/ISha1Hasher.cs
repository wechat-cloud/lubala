using System.Text;

namespace Lubala.Core.Cryptographic
{
    public interface ISha1Hasher
    {
        string HashString(string source, Encoding encoding = null);
    }
}