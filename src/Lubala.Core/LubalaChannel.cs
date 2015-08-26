using System;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
	internal class LubalaChannel : ILubalaChannel
	{
		internal LubalaChannel(ITokenSource tokenSource)
		{
		    Resolver = TypeResolver.Resolver;
		}

	    public ITypeResolver Resolver { get; private set; }
	    public WechatToken Token { get; }
	}
}

