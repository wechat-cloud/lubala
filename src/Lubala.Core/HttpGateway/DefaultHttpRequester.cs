using Lubala.Core.Logs;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Lubala.Core.HttpGateway
{
    internal class DefaultHttpRequester : IHttpRequester
    {
        private const string BaseUrl = "https://api.weixin.qq.com";
        private static readonly string UserAgentString = GetUserAgentString();

        private readonly IRestClient _client;

        public DefaultHttpRequester()
        {
            var client = new RestClient(BaseUrl) {UserAgent = UserAgentString};
            _client = client;
        }

        public T Execute<T>(string resource, ApiContext context) where T : new()
        {
            var request = CreateRestRequest(resource, context);
            var response = _client.Get(request);

            var deserializer = new JsonDeserializer();

            var failedTest = deserializer.Deserialize<InvokeApiFailed>(response);
            if (failedTest.IsFailed())
            {
                Log.Logger.Error("requesting resource error. errorcode: {0}, errormsg: {1}",
                    failedTest.errcode,
                    failedTest.errmsg);
                throw new ApiInvokeException(failedTest.errcode, failedTest.errmsg);
            }

            return deserializer.Deserialize<T>(response);
        }

        private static string GetUserAgentString()
        {
            var version = typeof (ILubalaChannel).Assembly.GetName().Version.ToString();
            return $"Lubala SDK v{version}";
        }

        private IRestRequest CreateRestRequest(string resource, ApiContext context)
        {
            var request = new RestRequest(resource);
            foreach (var param in context.Params)
            {
                request.AddParameter(param.Key, param.Value);
            }

            return request;
        }
    }
}