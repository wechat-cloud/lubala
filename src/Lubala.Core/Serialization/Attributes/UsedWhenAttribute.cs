using System;

namespace Lubala.Core.Serialization.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UsedWhenAttribute : Attribute
    {
        public UsedWhenAttribute(SerializationWay way)
        {
            Way = way;
        }

        public SerializationWay Way { get; private set; }
    }
}