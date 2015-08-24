﻿using System.Xml.Serialization;
using Lubala.Core.Pushing;

namespace Lubala.Component.MP.Messages
{
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