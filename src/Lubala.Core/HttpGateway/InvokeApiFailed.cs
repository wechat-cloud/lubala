namespace Lubala.Core.HttpGateway
{
    internal sealed class InvokeApiFailed
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }

        public bool IsFailed()
        {
            return errcode != null || errmsg != null;
        }
    }
}