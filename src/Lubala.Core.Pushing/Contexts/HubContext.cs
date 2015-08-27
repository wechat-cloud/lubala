using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Resolvers;

namespace Lubala.Core.Pushing
{
    internal class HubContext
    {
        internal HubContext()
        {
            MessageTypes = new Dictionary<TypeIdentity, Type>();
            MessageHandlers = new Dictionary<Type, IMessageHandler>();
        }

        public ILubalaChannel Channel { get; internal set; }

        public IDictionary<TypeIdentity, Type> MessageTypes { get; }
        public IDictionary<Type, IMessageHandler> MessageHandlers { get; }
        public ITypeResolver Resolver { get; internal set; }
        public EncodingMode EncodingMode { get; internal set; } = EncodingMode.Plain;
        internal string EncodingSignature { get; set; }

        public IReadOnlyDictionary<TypeIdentity, Type> GetMessageTypes()
        {
            return new ReadOnlyDictionary<TypeIdentity, Type>(MessageTypes);
        }

        public IReadOnlyDictionary<Type, IMessageHandler> GetMessageHandlers()
        {
            return new ReadOnlyDictionary<Type, IMessageHandler>(MessageHandlers);
        }
    }
}