using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lubala.Core.Pushing
{
    public class HubContext
    {
        public HubContext()
        {
            EventProcessors = new List<EventProcessor>();
            MessageHandlers = new Dictionary<Type, IMessageHandler>();
        }

        public ILubalaChannel Channel { get; internal set; }

        internal IList<EventProcessor> EventProcessors { get; }
        internal IDictionary<Type, IMessageHandler> MessageHandlers { get; }

        public IReadOnlyCollection<EventProcessor> GetEventProcessors()
        {
            return new ReadOnlyCollection<EventProcessor>(EventProcessors);
        }

        public IReadOnlyDictionary<Type, IMessageHandler> GetMessageHandlers()
        {
            return new ReadOnlyDictionary<Type, IMessageHandler>(MessageHandlers);
        }
    }
}