using System;

namespace Lubala
{
	public class EncodingAesKey
	{
        private string _key;
		public EncodingAesKey(string key)
		{
		    if (string.IsNullOrEmpty(key))
		    {
                throw new ArgumentException("key");
		    }

		    if (key.Length > 43)
		    {
                throw new ArgumentException("key should less than 43 characters.");
		    }

		    _key = key;
		}
	}
}

