namespace Lubala.Core.HttpGateway
{
    internal class RequestParam
    {
        private RequestParam(string key, string value)
        {
            Key = key;
            Value = value;
        }

        internal string Key { get; }
        internal string Value { get; }

        public static RequestParam Create(string key, string value)
        {
            return new RequestParam(key, value);
        }
    }
}