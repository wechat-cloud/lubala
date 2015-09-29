using System;

namespace Lubala.Core.Serialization.Attributes
{
    public class ArrayAttribute : Attribute
    {
        public ArrayAttribute(string arrayName)
        {
            ArrayName = arrayName;
        }

        public string ArrayName { get; private set; }
    }
}