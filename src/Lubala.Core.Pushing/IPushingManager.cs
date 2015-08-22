using System;

namespace Lubala.Core.Pushing
{
	public interface IPushingManager
	{
		IPushingManager RegisterHandler(IMessageHandler handler);
		IPushingManager RegisterHandler<T, R>(Func<T, R> lightweightHandler)
			where T: IncomingMessageBase
			where R: OutgoingMessageBase;
	}
}

