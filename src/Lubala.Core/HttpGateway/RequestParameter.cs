using System;

namespace Lubala.Core.HttpGateway
{
    internal class RequestParameter
    {
        public RequestParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

        internal string Key { get; }
        internal string Value { get; }
    }
}