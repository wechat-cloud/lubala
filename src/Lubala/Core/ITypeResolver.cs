using System;

namespace Lubala
{
	public interface ITypeResolver
	{
		T Resolve<T>();
		object Resolve(Type type);
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void Replace<TInterface, TImplementation>() where TImplementation : TInterface;
	}
}

