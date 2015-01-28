using System;

namespace Lubala
{
	public class LubalaKernal
	{
		private DaemonSetting _setting;
		public LubalaKernal( DaemonSetting setting)
		{
			_setting = setting;
		}

		public virtual async void ExecuteOn(WechatContext hostContext){
		}
	}
}

