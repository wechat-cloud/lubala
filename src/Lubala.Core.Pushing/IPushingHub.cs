using System;
using System.Collections.Generic;
using System.IO;

namespace Lubala.Core.Pushing
{
	public interface IPushingHub
	{
	    bool Verify(string timestamp, string nonce, string signature);
	    string Interpreting(string content, EncodingOption encodingOption = null);
	}
}

