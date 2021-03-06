﻿using System;
using Lubala.Core;
using Lubala.Dispatchers;
using Lubala.Handlers;
using Lubala.Messages;

namespace Lubala
{
    public class LubalaKernel : ILubalaKernel
    {
        private readonly HandlerCollection _handlerCollection = new HandlerCollection();

        static LubalaKernel()
        {
            var moduleLoader = KernelService.TypeResolver.Resolve<ILubalaModuleLoader>();
            moduleLoader.LoadAllModules();
        }

        public LubalaKernel(IKernelSettingProvider kernelSettingProvider)
        {
            if (kernelSettingProvider == null)
            {
                throw new ArgumentNullException("kernelSettingProvider");
            }

            var setting = kernelSettingProvider.CreateSetting();
            InitializeKernel(setting);
        }

        public LubalaKernel(KernelSetting setting)
        {
            InitializeKernel(setting);
        }

        private void InitializeKernel(KernelSetting setting)
        {
            TypeResolver = KernelService.TypeResolver;
            Setting = setting;
        }

        public ITypeResolver TypeResolver { get; private set; }
        public KernelSetting Setting { get; private set; }

        public void RegisterHandler(IMessageHandler messageHandler)
        {
            _handlerCollection.Add(messageHandler);
        }

        public TService GetService<TService>() where TService : ILubalaService
        {
            var service = TypeResolver.Resolve<TService>();
            service.SetupContext(null);
            throw new NotImplementedException();
        }

        public MessageBase VerifyAvailability(IWechatContext wechatContext)
        {
            throw new NotImplementedException();
        }

        public MessageBase Hanlde(IWechatContext wechatContext)
        {
            if (wechatContext == null)
            {
                throw new ArgumentNullException("wechatContext");
            }

            var kernelContext = new KernelContext(wechatContext, Setting, _handlerCollection);

            var dispatcher = TypeResolver.Resolve<IDispatcher>();
            var handler = dispatcher.Dispatching(kernelContext);
            return handler.Process();
        }
    }
}