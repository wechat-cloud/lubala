using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lubala.Messages;

namespace Lubala.Dispatchers
{
    public interface IMessageTypeMapper
    {
        MessageType Map(string msgTypeText);
    }
}
