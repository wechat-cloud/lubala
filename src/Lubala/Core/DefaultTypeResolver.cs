using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lubala.Core
{
    internal class DefaultTypeResolver : ITypeResolver
    {
        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }


        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            throw new NotImplementedException();
        }

        public void Replace<TInterface, TImplementation>() where TImplementation : TInterface
        {
            throw new NotImplementedException();
        }
    }
}
