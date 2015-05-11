using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lubala.Samples.Mvc.Controllers
{
    public class WechatController : Controller
    {
        private LubalaKernel _kernel;
        public WechatController()
        {
            var setting = new KernelSetting("appId", "appSecret");
            _kernel = new LubalaKernel(setting);
        }

        [HttpGet]
        public ActionResult LubalaGet()
        {
            // var wechatContext = this.GetWechatContext();
            // IWechatContext context = null;
            // var result = _kernel.VerifyAvailability(wechatContext);
            // return new WechatActionResult(result);
            return Content("something right");
        }

        [HttpPost]
        public ActionResult LubalaPost()
        {
            // var wechatContext = this.GetWechatContext();
            // IWechatContext context = null;
            // var result = _kernel.Hanlde(wechatContext);
            // return new WechatActionResult(result);
            return Content("something right");
        }
    }
}