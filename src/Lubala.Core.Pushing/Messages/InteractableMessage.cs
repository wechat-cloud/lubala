using System;
using System.Xml.Serialization;

namespace Lubala.Core.Pushing
{
    [Serializable]
    [XmlRoot("xml")]
    public abstract class InteractableMessage
    {
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        public int CreateTime { get; set; }

        [XmlElement("MsgType")]
        public string MsgType { get; set; }
    }
}