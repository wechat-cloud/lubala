using System;

namespace Lubala.Core.Serialization.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class IgnoreAttribute : Attribute
	{
	}
}

