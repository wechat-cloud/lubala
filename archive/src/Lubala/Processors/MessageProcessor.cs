using System;
using Lubala.Messages;

namespace Lubala.Processors
{
    public interface IMessageProcessor
    {
        MessageBase Process();
    }
}