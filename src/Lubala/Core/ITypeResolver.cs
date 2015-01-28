using System;

namespace Lubala
{
	public interface ITypeResolver
	{
		T Resolve<T>();
		object Resolve(Type type);
	}
}

