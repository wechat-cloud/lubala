using System.Collections.Generic;

namespace Lubala.Core.HttpGateway
{
    public sealed class ApiContext
    {
        public ApiContext()
        {
            Params = new List<RequestParameter>();
        }

        internal IList<RequestParameter> Params { get; set; }
        internal bool AutoToken { get; set; } = true;

        public ApiContext AddParam(string key, string value)
        {
            Params.Add(new RequestParameter(key, value));
            return this;
        }

        public ApiContext DisableAutoToken()
        {
            AutoToken = false;
            return this;
        }
    }
}