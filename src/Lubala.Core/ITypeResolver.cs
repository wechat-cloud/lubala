using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core
{
    public interface ITypeResolver
    {
        T Resolve<T>();
        object Resolve(Type type);
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void Replace<TInterface, TImplementation>() where TImplementation : TInterface;
    }
}
