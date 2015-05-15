using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Messages;

namespace Lubala.Dispatchers
{
    public interface IMessageTypeRecognizer
    {
        MessageType Recognize(Stream bodyStream);
    }
}
