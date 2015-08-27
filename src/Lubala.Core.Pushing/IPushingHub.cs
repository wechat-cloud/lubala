using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lubala.Core.Pushing
{
	public interface IPushingHub
	{
        IReadOnlyDictionary<Type, IMessageHandler> MessageHandlers { get; }
        ILubalaChannel Channel { get; }
	    EncodingMode EncodingMode { get; }

	    bool Verify(string timestamp, string nonce, string signature);
        void Interpreting(Stream sourceStream, Stream targetStream, IDictionary<string, string> payloads);
        Task InterpretingAsync(Stream sourceStream, Stream targetStream, IDictionary<string, string> payloads);
    }
}

