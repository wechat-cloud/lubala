namespace Lubala.Core.Tokens
{
    public interface ITokenSource
    {
        WechatToken RetrieveToken(string appId, string appSecret, ILubalaChannel channel);
    }
}