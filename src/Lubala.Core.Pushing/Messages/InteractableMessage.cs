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

        [XmlElement("CreateTime", typeof (int))]
        public int CreateTime { get; set; }

        [XmlElement("MsgType")]
        public abstract string MsgType { get; }
    }
}