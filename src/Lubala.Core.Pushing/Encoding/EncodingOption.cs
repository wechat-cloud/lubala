using System;

namespace Lubala.Core.Pushing
{
	public sealed class EncodingOption
	{
		public EncodingOption(EncodingMode encodingMode, string signature) {
			if (encodingMode != EncodingMode.Plain && string.IsNullOrEmpty(signature)) {
				throw new ArgumentException("must specfic signature when encoding mode is Compatible or Secure.", nameof(signature));
			}
		}
	}
}

