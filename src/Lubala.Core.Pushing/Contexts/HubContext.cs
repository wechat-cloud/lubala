using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lubala.Core.Pushing
{
    public class HubContext
    {
        public HubContext()
        {
            MessageHandlers = new Dictionary<Type, IMessageHandler>();
        }

        public ILubalaChannel Channel { get; internal set; }

        internal IDictionary<Type, IMessageHandler> MessageHandlers { get; }
        
        public IReadOnlyDictionary<Type, IMessageHandler> GetMessageHandlers()
        {
            return new ReadOnlyDictionary<Type, IMessageHandler>(MessageHandlers);
        }
    }
}