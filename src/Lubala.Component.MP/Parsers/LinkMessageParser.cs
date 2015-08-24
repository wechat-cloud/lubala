using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP.Messages;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP.Parsers
{
    [EventCode("link")]
    internal class LinkMessageParser : MessageParser<RawLinkMessage>
    {
        protected override RawLinkMessage ParseCore(Stream sourceStream, HubContext context)
        {
            throw new NotImplementedException();
        }
    }
}
