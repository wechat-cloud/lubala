using System;

namespace Lubala.Core.HttpGateway
{
    internal sealed class ApiInvokeException : Exception
    {
        public ApiInvokeException(string errcode, string errmsg) : base(errmsg)
        {
            ErrorCode = errcode;
        }

        public string ErrorCode { get; private set; }
    }
}