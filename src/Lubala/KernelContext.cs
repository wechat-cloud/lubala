using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Handlers;

namespace Lubala
{
    internal class KernelContext
    {
        internal KernelContext(IWechatContext wechatContext, HandlerCollection handlerCollection)
        {
            if (wechatContext == null)
            {
                throw new ArgumentNullException("wechatContext");
            }
            if (handlerCollection == null)
            {
                throw new ArgumentNullException("handlerCollection");
            }

            WechatContext = wechatContext;
            RawBody = wechatContext.RawBody;
            MessageHandlers = new ReadOnlyCollection<IMessageHandler>(handlerCollection);
        }

        public IWechatContext WechatContext { get; private set; }
        public string RawBody { get; private set; }
        public IReadOnlyCollection<IMessageHandler> MessageHandlers { get; private set; }
    }
}
