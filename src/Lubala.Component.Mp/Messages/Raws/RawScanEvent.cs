﻿using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Component.Mp.Messages
{
    [EventType("SCAN")]
    public class RawScanEvent : PushingEvent
    {
        [Node("EventKey")]
        public string EventKey { get; set; }

        [Node("Ticket")]
        public string Ticket { get; set; }

        public override string Event => "SCAN";
    }
}