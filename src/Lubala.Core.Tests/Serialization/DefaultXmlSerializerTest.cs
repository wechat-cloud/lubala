using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lubala.Core.Serialization;
using Xunit;

namespace Lubala.Core.Tests.Serialization
{
    public class DefaultXmlSerializerTest
    {
        [Fact]
        public void TestSerializePureTextMessage()
        {
            var serializer = new DefaultXmlSerializer();
            var message = new TestTextMessage
            {
                Content = "hello",
                CreateTime = 11223,
                FromUserName = "Lu",
                ToUserName = "Rongkai"
            };

            using (var stream = new MemoryStream())
            {
                serializer.Serialize(message, stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    Debug.WriteLine(result);
                }
            }
        }

        [Fact]
        public void TestDeserializePureTextMessage()
        {
            var xml =
                @"<xml><ToUserName>Rongkai</ToUserName><FromUserName>Lu</FromUserName><CreateTime>11223</CreateTime><Content>hello</Content></xml>";

            var serializer = new DefaultXmlSerializer();

            TestTextMessage message;

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(xml);
                    writer.Flush();
                    stream.Position = 0;
                    var xmlDoc = XDocument.Load(stream);
                    message = serializer.Deserialize<TestTextMessage>(xmlDoc);
                }
            }

            Assert.Equal(message.Content, "hello");
            Assert.Equal(message.ToUserName, "Rongkai");
            Assert.Equal(message.FromUserName, "Lu");
            Assert.Equal(message.CreateTime, 11223);
        }
    }

    [Serializable]
    [XmlRoot("xml")]
    public class TestTextMessage
    {
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        public int CreateTime { get; set; }

        [XmlElement("MsgType")]
        public string MsgType { get; set; }

        [XmlElement("CreateTime", typeof (long))]
        public long MsgId { get; }

        [XmlElement("Content")]
        public string Content { get; set; }
    }
}