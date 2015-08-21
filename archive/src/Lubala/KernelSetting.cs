using System;

namespace Lubala
{
	public class KernelSetting
    {
	    public KernelSetting(string appId, string appSecret, EncodingMode encodingMode = EncodingMode.Plain, string encodingAesKey = "")
	    {
	        AppId = appId;
	        AppSecret = appSecret;
	        EncodingMode = encodingMode;
	        EncodingAesKey = encodingAesKey;
	    }

        public string AppId { get; private set; }
        public string AppSecret { get; private set; }
        public EncodingMode EncodingMode { get; private set; }
        public string EncodingAesKey { get; private set; }
	}

}

