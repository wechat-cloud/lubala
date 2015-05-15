using System;
using System.IO;
using System.Xml.Linq;
using Lubala.Messages;

namespace Lubala.Dispatchers.Transforms
{
    internal class DefaultXmlMessageTypeRecognizer : IMessageTypeRecognizer
    {
        private const string MsgTypeNodeName = "MsgType";
        private IMessageTypeMapper _messageTypeMapper;

        internal DefaultXmlMessageTypeRecognizer(IMessageTypeMapper messageTypeMapper)
        {
            _messageTypeMapper = messageTypeMapper;
        }

        public MessageType Recognize(Stream bodyStream)
        {
            var document = XDocument.Load(bodyStream);
            var xmlNode = document.Root;

            if (xmlNode == null)
            {
                throw new InvalidOperationException("body xml format incorrect.");
            }

            var msgTypeNode = xmlNode.Element(MsgTypeNodeName);

            if (msgTypeNode == null)
            {
                throw new InvalidOperationException("cannot found MsgType node.");
            }

            var msgTypeText = msgTypeNode.Value;

            var msgType = _messageTypeMapper.Map(msgTypeText);
            return msgType;
        }
    }
}