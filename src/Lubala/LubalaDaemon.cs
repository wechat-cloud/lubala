using System;

namespace Lubala
{
	public class LubalaDaemon
	{
		private DaemonSetting _setting;
		public LubalaDaemon( DaemonSetting setting)
		{
			_setting = setting;
		}

		public virtual async void ExecuteOn(HostContext hostContext){

		}
	}
}

