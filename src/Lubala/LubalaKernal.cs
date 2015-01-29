using System;

namespace Lubala
{
	public class LubalaKernal
	{
		private KernalSetting _setting;
		public LubalaKernal( KernalSetting setting)
		{
			_setting = setting;
		}

		public virtual async void ExecuteOn(IWechatContext hostContext){
		}
	}
}

