using System;

namespace Lubala
{
	public class WechatContext
	{
		public WechatContext()
		{
		}

		public IWechatRequest Request {
			get;
			private set;
		}

		public IWechatResponse Response{
			get;
			private set;
		}
	}
}

