using System.Security.Cryptography;
using System.Text;

namespace Lubala.Core.Cryptographic
{
    internal class DefaultSha1Hasher : ISha1Hasher
    {
        public string HashString(string source)
        {
            var sha1Algorithm = SHA1.Create();
            var bytes = sha1Algorithm.ComputeHash(Encoding.UTF8.GetBytes(source));

            var sb = new StringBuilder();
            foreach (var theByte in bytes)
            {
                sb.AppendFormat("{0:x2}", theByte);
            }

            return sb.ToString();
        }
    }
}