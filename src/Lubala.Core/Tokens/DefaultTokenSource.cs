using System;
using System.Collections.Generic;
using Lubala.Core.Logs;

namespace Lubala.Core.Tokens
{
    public class DefaultTokenSource : ITokenSource
    {
        private static readonly IDictionary<string, WechatToken> _tokens = new Dictionary<string, WechatToken>();
        private static readonly object _locker = new object();

        public WechatToken RetrieveToken(string appId, string appSecret, ILubalaChannel channel)
        {
            lock (_locker)
            {
                WechatToken token;
                if (_tokens.TryGetValue(appId, out token))
                {
                    if (token.ExpiredDateTime < DateTimeOffset.UtcNow)
                    {
                        Log.Logger.Info("token expired, retrieving now.");
                        token = RetrieveTokenRemotly(appId, appSecret, channel);
                        _tokens[appId] = token;
                    }
                }
                else
                {
                    Log.Logger.Info("retrieving token from wechat server.");
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