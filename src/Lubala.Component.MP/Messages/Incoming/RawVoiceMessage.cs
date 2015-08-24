﻿using System.Xml.Serialization;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Attributes;

namespace Lubala.Component.MP.Messages
{
    [EventCode("image")]
    [XmlRoot("xml")]
    public class RawVoiceMessage : MPIncomingMessage, IAcceptPassiveMessage
    {
        [XmlElement("MediaId")]
        public string MediaId { get; set; }

        [XmlElement("Format")]
        public string Format { get; set; }

        public override string MsgType => "voice";
    }
}