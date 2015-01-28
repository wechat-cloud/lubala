using System;

namespace Lubala
{
	public interface IWechatContext
	{
		IWechatRequest Request { get; }
		IWechatResponse Response{ get; }
	}
}

