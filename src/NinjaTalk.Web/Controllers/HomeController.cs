using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lubala.Component.Mp;
using Lubala.Component.Mp.Messages;
using Lubala.Core;
using Lubala.Core.Pushing;
using Lubala.Pushing;

namespace NinjaTalk.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILubalaChannel channel = CreateChannel();

        private static ILubalaChannel CreateChannel()
        {
            var factory = new LubalaChannelFactory();
            return factory.CreateChannel(
                "wx140db0edac3db6cf",
                "26937c210b2358ec479db9a7d26768bf");
        }

        [HttpGet]
        public ActionResult Index(string signature, string timestamp, string nonce)
        {
            var hub = channel.CreatePushingHub(builder => { });

            var result = hub.Verify(timestamp, nonce, signature);
            if (result)
            {
                return Content(nonce);
            }
            return new EmptyResult();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(string msg_signature, string timestamp, string nonce)
        {
            var dict = new Dictionary<string, string>
            {
                {"msg_signature", msg_signature},
                {"timestamp", timestamp},
                {"nonce", nonce}
            };

            var hub = channel.CreatePushingHub(builder =>
            {
                builder.UseEncoding("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false);
                builder.UseMP(x => { x.RegisterMessageHandler(new MyHandler()); });
            });

            hub.Interpreting(Request.InputStream, Response.OutputStream, dict);
            return new EmptyResult();
        }
    }

    public class MyHandler : MPMessageHandler<RawImageMessage, PassiveTextMessage>
    {
        protected override PassiveTextMessage HandleMessage(RawImageMessage incomingMessage, MessageContext context)
        {
            var res = new PassiveTextMessage
            {
                Content = "hi"
            };
            incomingMessage.Reply(res);
            return res;
        }
    }
}