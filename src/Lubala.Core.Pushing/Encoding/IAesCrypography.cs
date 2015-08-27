using System;

namespace Lubala.Core.Pushing.Encoding
{
    internal interface IAesCrypography
    {
        string AesDecrypting(string raw, string encodingAesKey, ref string appid);
        string AesEncrypting(string raw, string encodingAesKey, string appid);
    }
}