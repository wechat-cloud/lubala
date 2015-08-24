﻿using System;
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
    [EventCode("video")]
    internal class VideoMessageParser : MessageParser<RawVideoMessage>
    {
        protected override RawVideoMessage ParseCore(Stream sourceStream, HubContext context)
        {
            throw new NotImplementedException();
        }
    }
}
