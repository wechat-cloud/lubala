using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing
{
    internal class HubContext
    {
        internal HubContext()
        {
            MessageTypes = new Dictionary<string, Type>();
            MessageHandlers = new Dictionary<Type, IMessageHandler>();
        }

        public ILubalaChannel Channel { get; internal set; }

        public IDictionary<string, Type> MessageTypes { get; }
        public IDictionary<Type, IMessageHandler> MessageHandlers { get; }
        
        public IReadOnlyDictionary<Type, IMessageHandler> GetMessageHandlers()
        {
            return new ReadOnlyDictionary<Type, IMessageHandler>(MessageHandlers);
        }
    }
}