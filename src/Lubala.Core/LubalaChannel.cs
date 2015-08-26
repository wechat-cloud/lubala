using System;
using Lubala.Core.Token;

namespace Lubala.Core
{
	internal class LubalaChannel : ILubalaChannel
	{
		internal LubalaChannel(ITokenSource tokenSource)
		{
		    Resolver = TypeResolver.Resolver;
		}

	    public ITypeResolver Resolver { get; private set; }
	}
}

