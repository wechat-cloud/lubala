using System;

namespace Lubala
{
	public interface IWechatContext
	{
        ILubalaKernel Kernel { get; }

        string RawBody { get; }
    }
}

