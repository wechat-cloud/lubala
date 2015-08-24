﻿using System.Xml.Serialization;

namespace Lubala.Component.MP.Messages
{
    [XmlRoot("xml")]
    public class RawLocationMessage : MPIncomingMessage
    {
        [XmlElement("Location_X")]
        public double LocationX { get; set; }

        [XmlElement("Location_Y")]
        public double LocationY { get; set; }

        [XmlElement("Scale")]
        public string Scale { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }

        public override string MsgType => "location";
    }
}