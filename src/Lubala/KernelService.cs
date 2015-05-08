using Lubala.Core;

namespace Lubala
{
    public static class KernelService
    {
        static KernelService()
        {
            RegisterDefaultLubalaServices();
        }

        private static ITypeResolver _typeResolver;
        internal static ITypeResolver TypeResolver {
            get { return _typeResolver ?? new DefaultTypeResolver(); }
            set
            {
                _typeResolver = value;
                RegisterDefaultLubalaServices();
            }
        }
        
        private static void RegisterDefaultLubalaServices()
        {
            TypeResolver.Register<ILubalaModuleLoader, DefaultLubalaModuleLoader>();
            TypeResolver.Register<IKernelSettingProvider, DefaultKernelSettingProvider>();
            TypeResolver.Register<IMessageValidationService, DefaultMessageValidationService>();
        }
    }
}
