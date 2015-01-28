using System;
using System.Collections.Generic;

namespace Lubala
{
	public interface IWechatRequest
	{
		IDictionary<string, string> QueryStrings { get; }
		IDictionary<string, string> Headers { get; }
		string RawBody { get; }
	}
}

