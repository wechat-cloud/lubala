using System;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
	public interface ILubalaChannel
	{
        ITypeResolver Resolver { get; }
	    WechatToken Token { get; }
        string AppId { get; }
	}
}

