using System;
using Lubala.Core.HttpGateway;
using Lubala.Core.Resolvers;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
    internal class LubalaChannel : ILubalaChannel
    {
        internal LubalaChannel(string appId, string appSecret)
        {
            Resolver = TypeResolver.Resolver;
            TokenSource = Resolver.Resolve<ITokenSource>();
            HttpRequester = Resolver.Resolve<IHttpRequester>();

            AppId = appId;
            AppSecret = appSecret;
        }

        internal IHttpRequester HttpRequester { get; }
        internal string AppSecret { get; }

        public ITokenSource TokenSource { get; set; }
        public ITypeResolver Resolver { get; }
        public WechatToken Token => TokenSource.RetrieveToken(AppId, AppSecret, this);

        public string AppId { get; }

        public T Request<T>(string resource, Action<ApiContext> action) where T : new()
        {
            var context = new ApiContext();
            action(context);

            if (context.AutoToken)
            {
                context.AddParam("access_token", Token.TokenValue);
            }

            return HttpRequester.Execute<T>(resource, context);
        }
    }
}