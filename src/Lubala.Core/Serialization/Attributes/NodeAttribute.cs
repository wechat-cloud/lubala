using System;

namespace Lubala.Core.Serialization.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NodeAttribute : Attribute
    {
        public NodeAttribute(string nodeName)
        {
            if (string.IsNullOrEmpty(nodeName))
            {
                throw new ArgumentNullException(nameof(nodeName));
            }

            NodeName = nodeName;
        }

        public string NodeName { get; private set; }
    }
}