using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.HttpGateway;
using Lubala.Core.Tokens;
using Xunit;

namespace Lubala.Core.Tests.HttpGateway
{
    public class DefaultHttpRequesterTest
    {
        [Fact]
        public void TestRetrieveToken()
        {
            var x = new SecretInformationReader();
            
            var requester = new DefaultHttpRequester();

            var context = new ApiContext();
            context.AddParam("grant_type", "client_credential")
                .AddParam("appid", x.AppId)
                .AddParam("secret", x.AppSecret);
            var result = requester.Execute<Token>("/cgi-bin/token", context);
        }
    }
}
