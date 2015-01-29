using System;

namespace Lubala
{
	public abstract class MessageHandlerBase : MessageHandler
	{
		public abstract void HandleCore(IWechatContext context);
	}
}

