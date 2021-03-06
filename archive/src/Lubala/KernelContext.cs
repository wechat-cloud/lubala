﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Handlers;

namespace Lubala
{
    internal class KernelContext
    {
        private KernelSetting _setting;
        private HandlerCollection _handlerCollection;

        internal KernelContext(IWechatContext wechatContext, KernelSetting setting, HandlerCollection handlerCollection)
        {
            if (wechatContext == null)
            {
                throw new ArgumentNullException("wechatContext");
            }
            if (setting == null)
            {
                throw new ArgumentNullException("setting");
            }
            if (handlerCollection == null)
            {
                throw new ArgumentNullException("handlerCollection");
            }

            WechatContext = wechatContext;
            Setting = setting;
            MessageHandlers = new ReadOnlyCollection<IMessageHandler>(handlerCollection);
            RawBody = wechatContext.RawBody;
        }

        public IWechatContext WechatContext { get; private set; }
        public KernelSetting Setting { get; private set; }
        public IReadOnlyCollection<IMessageHandler> MessageHandlers { get; private set; }
        public string RawBody { get; private set; }
        public Stream BodyStream { get; set; }
    }
}
