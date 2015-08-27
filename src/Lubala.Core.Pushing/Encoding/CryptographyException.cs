using System;

namespace Lubala.Core.Pushing.Encoding
{
    internal class CryptographyException : Exception
    {
        public CryptographyException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; private set; }
    }
}