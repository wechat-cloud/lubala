namespace Lubala.Core.HttpGateway
{
    internal interface IHttpRequester
    {
        T Execute<T>(string resource, ApiContext context) where T : new();
    }
}