using System;
using System.Collections.Generic;
using System.IO;

namespace Lubala.Core.Pushing
{
	public interface IPushingHub
	{
	    string Interpreting(string content, EncodingOption encodingOption = null);
	}
}

