using System;
using System.Collections.Generic;
using Lubala.Messages;
using Lubala.Processors;

namespace Lubala.Dispatchers
{
    internal class DefaultDispatcher : IDispatcher
    {
        //private static IDictionary<MessageType, MessageProcessor> 
        private IMessageTypeRecognizer _messageTypeRecognizer;

        internal DefaultDispatcher(IMessageTypeRecognizer messageTypeRecognizer)
        {
            _messageTypeRecognizer = messageTypeRecognizer;
        }

        public MessageProcessor Dispatching(KernelContext wechatContext)
        {
            throw new NotImplementedException();
        }
    }
}