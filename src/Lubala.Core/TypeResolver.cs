using System;
using Lubala.Core.Serialization;

namespace Lubala.Core
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
            Resolver.Register<IXmlSerializer, DefaultXmlSerializer>();
        }
    }
}