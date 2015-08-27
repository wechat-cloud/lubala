using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Serialization;

namespace Lubala.Core.Pushing.Messages
{
    public sealed class AsyncPassiveMessage : IPassiveMessage
    {
        public string Serialize(IXmlSerializer xmlSerializer)
        {
            return string.Empty;
        }
    }
}
