using System;
using System.Security.Cryptography;
using System.Text;

namespace Lubala.Core.Cryptographic
{
    internal class DefaultSha1Hasher : ISha1Hasher
    {
        public string HashString(string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var sha1Algorithm = SHA1.Create();
            var bytes = sha1Algorithm.ComputeHash(encoding.GetBytes(source));

            var final = BitConverter.ToString(bytes).Replace("-", "");

            return final.ToLower();
        }
    }
}