using System;
using System.Collections.Generic;
using System.IO;

namespace Lubala.Core.Pushing
{
	public interface IPushingHub
	{
	    void Interpreting(Stream sourceStream, Stream targetStream, EncodingOption encodingOption = null);

        IReadOnlyCollection<EventProcessor> EventProcessors { get; }
        IReadOnlyDictionary<Type, IMessageHandler> MessageHandlers { get; }
    }
}

