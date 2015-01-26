using System;

namespace Lubala
{
	public class HostContext
	{
		public HostContext()
		{
		}

		public IRequest Request {
			get;
			private set;
		}

		public IResponse Response{
			get;
			private set;
		}
	}
}

