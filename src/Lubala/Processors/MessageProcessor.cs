using System;
using Lubala.Messages;

namespace Lubala.Processors
{
    internal abstract class MessageProcessor
    {
        public MessageProcessor(ProcessorContext processorContext)
        {
            
        }

        internal MessageBase Process()
        {
            throw new NotImplementedException();
        }
    }
}