using System;

namespace Lubala.Core.Serialization.Attributes
{
    public class ArrayItemAttribute : Attribute
    {
        public ArrayItemAttribute(string itemName, Type itemType)
        {
            ItemName = itemName;
            ItemType = itemType;
        }

        public string ItemName { get; private set; }
        public Type ItemType { get; private set; }
    }
}