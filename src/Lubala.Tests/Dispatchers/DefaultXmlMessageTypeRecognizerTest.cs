using System;
using System.IO;
using System.Xml;
using Lubala.Dispatchers;
using Lubala.Dispatchers.Transforms;
using Lubala.Messages;
using Xunit;

namespace Lubala.Tests.Dispatchers
{
    public class DefaultXmlMessageTypeRecognizerTest
    {
        [Fact]
        public void ParseEmptyStreamTest()
        {
            var recognizer = new DefaultXmlMessageTypeRecognizer(new FackMessageTypeMapper());
            
            Assert.Throws(typeof(XmlException), () =>
            {
                using (var stream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine();
                        writer.Flush();
                        stream.Position = 0;

                        var result = recognizer.Recognize(stream);
                    }
                }
            });
        }

        [Fact]
        public void ParseTypeTest()
        {
            var recognizer = new DefaultXmlMessageTypeRecognizer(new FackMessageTypeMapper());

            Assert.DoesNotThrow(() =>
            {
                using (var stream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("<xml><MsgType>text</MsgType></xml>");
                        writer.Flush();
                        stream.Position = 0;

                        var result = recognizer.Recognize(stream);
                    }
                }
            });
        }

        private class FackMessageTypeMapper : IMessageTypeMapper
        {
            public MessageType Map(string msgTypeText)
            {
                return MessageType.Text;
            }
        }
    }
}