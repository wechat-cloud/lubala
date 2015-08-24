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
    [EventCode("location")]
    internal class LocationMessageParser : MessageParser<RawLocationMessage>
    {
        protected override RawLocationMessage ParseCore(Stream sourceStream, HubContext context)
        {
            throw new NotImplementedException();
        }
    }
}