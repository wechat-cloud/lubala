using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lubala.Core.Resolvers
{
    internal class DefaultTypeResolver : ITypeResolver
    {
        private static readonly IDictionary<Type, Type> InnerTypeDict = new ConcurrentDictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        public object Resolve(Type type)
        {
            return Resolve(type, new Dictionary<Type, object>());
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            var interfaceType = typeof (TInterface);
            if (InnerTypeDict.ContainsKey(interfaceType))
            {
                throw new InvalidOperationException("type already regsitered.");
            }
            InnerTypeDict.Add(interfaceType, typeof (TImplementation));
        }

        public void Replace<TInterface, TImplementation>() where TImplementation : TInterface
        {
            var interfaceType = typeof (TInterface);
            if (InnerTypeDict.ContainsKey(interfaceType))
            {
                InnerTypeDict[interfaceType] = typeof (TImplementation);
            }
        }

        private object Resolve(Type type, IDictionary<Type, object> resolvedInstances)
        {
            Type rootType;
            if (InnerTypeDict.TryGetValue(type, out rootType))
            {
                var constructor = GetDefaultConstructorParames(rootType);
                var targetInstance = ActivateTargetType(constructor, resolvedInstances, rootType);
                return targetInstance;
            }

            throw new InvalidOperationException("type does not registered.");
        }

        private object ActivateTargetType(ConstructorInfo constructor, IDictionary<Type, object> resolvedInstances,
            Type rootType)
        {
            var paramInfos = constructor.GetParameters();
            var paramInstances = new object[paramInfos.Length];
            for (var i = 0; i < paramInfos.Length; i++)
            {
                var paramType = paramInfos[i].ParameterType;

                if (paramType == rootType)
                {
                    throw new InvalidOperationException("target type has circular reference on this dependences.");
                }

                object paramInstance = null;
                if (resolvedInstances.TryGetValue(paramType, out paramInstance))
                {
                    paramInstances[i] = paramInstance;
                }
                else
                {
                    paramInstances[i] = Resolve(paramType, resolvedInstances);
                }
            }
            return constructor.Invoke(paramInstances);
        }

        private ConstructorInfo GetDefaultConstructorParames(Type targetType)
        {
            var constructors = targetType.GetConstructors(
                BindingFlags.CreateInstance |
                BindingFlags.Instance |
                BindingFlags.Default |
                BindingFlags.Public |
                BindingFlags.NonPublic);
            if (constructors.Length > 0)
            {
                return constructors.First();
            }

            throw new InvalidOperationException("no constructor found.");
        }
    }
}