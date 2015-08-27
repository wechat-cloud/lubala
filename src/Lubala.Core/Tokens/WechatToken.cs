using System;

namespace Lubala.Core.Tokens
{
    public class WechatToken
    {
        private readonly Token _token;

        public WechatToken(Token token, DateTimeOffset createdDate)
        {
            _token = token;
            CreatedDateTime = createdDate;
        }

        public string TokenValue => _token.access_token;

        public DateTimeOffset CreatedDateTime { get; }
        public DateTimeOffset ExpiredDateTime => CreatedDateTime.AddSeconds(_token.expires_in);
    }
}