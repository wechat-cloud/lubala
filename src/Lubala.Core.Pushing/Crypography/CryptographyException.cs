using System;

namespace Lubala.Core.Pushing.Crypography
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