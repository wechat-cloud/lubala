using Lubala.Core.Cryptographic;
using Lubala.Core.HttpGateway;
using Lubala.Core.Serialization;
using Lubala.Core.Tokens;

namespace Lubala.Core.Resolvers
{
    public class TypeResolver
    {
        private static ITypeResolver _resolver;

        static TypeResolver()
        {
            Resolver = new DefaultTypeResolver();
        }

        public static ITypeResolver Resolver
        {
            get { return _resolver; }
            set
            {
                _resolver = value;
                RegisterDefaultServices();
            }
        }

        private static void RegisterDefaultServices()
        {
            Resolver.Register<ISha1Hasher, DefaultSha1Hasher>();
            Resolver.Register<IXmlSerializer, WechatXmlSerializer>();
            Resolver.Register<ITokenSource, DefaultTokenSource>();
            Resolver.Register<IHttpRequester, DefaultHttpRequester>();
        }
    }
}