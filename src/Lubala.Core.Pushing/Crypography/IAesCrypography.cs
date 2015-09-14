namespace Lubala.Core.Pushing.Crypography
{
    internal interface IAesCrypography
    {
        string AesDecrypting(string raw, string encodingAesKey, ref string appid);
        string AesEncrypting(string raw, string encodingAesKey, string appid);
    }
}