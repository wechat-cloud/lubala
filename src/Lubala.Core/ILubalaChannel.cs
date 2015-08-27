using System;
using System.Collections;
using Lubala.Core.Resolvers;
using Lubala.Core.Tokens;

namespace Lubala.Core
{
	public interface ILubalaChannel
	{
        ITypeResolver Resolver { get; }
	    WechatToken Token { get; }
        string AppId { get; }
	    T Request<T>(string resource, Action<ApiContext> action) where T : new();
	}
}

