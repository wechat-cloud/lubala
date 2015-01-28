using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Lubala
{
	public interface IWechatResponse
	{
		IDictionary<string, string> Headers { get; }
		void SetStatusCode(HttpStatusCode statusCode);
		void Write(string content);
		void WriteLine(string content);

		void WriteTo(Stream stream);
	}
}

