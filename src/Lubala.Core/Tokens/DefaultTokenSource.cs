using System;
using System.Collections.Generic;

namespace Lubala.Core.Tokens
{
    public class DefaultTokenSource : ITokenSource
    {
        private static IDictionary<string, WechatToken> _tokens = new Dictionary<string, WechatToken>();
        private static object _locker = new object();
        public WechatToken RetrieveToken(string appId, string appSecret, ILubalaChannel channel)
        {
            lock (_locker)
            {
                WechatToken token;
                if (_tokens.TryGetValue(appId, out token))
                {
                    if (token.ExpiredDateTime < DateTimeOffset.UtcNow)
                    {
                        token = RetrieveTokenRemotly(appId, appSecret, channel);
                        _tokens[appId] = token;
                    }
                }
                else
                {
                    token = RetrieveTokenRemotly(appId, appSecret, channel);
                    _tokens.Add(appId, token);
                }

                return token;
            }
        }

        private WechatToken RetrieveTokenRemotly(string appId, string appSecret, ILubalaChannel channel)
        {
            var token = channel.Request<Token>("/cgi-bin/token", context =>
            {
                context
                    .DisableAutoToken()
                    .AddParam("grant_type", "client_credential")
                    .AddParam("appid", appId)
                    .AddParam("secret", appSecret);
            });

            return new WechatToken(token, DateTimeOffset.UtcNow);
        }
    }
}