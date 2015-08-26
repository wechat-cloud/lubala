using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lubala.Core.Serialization;
using Lubala.Core.Serialization.Attributes;
using Xunit;

namespace Lubala.Core.Tests.Serialization
{
    public class DefaultXmlSerializerTest
    {
        [Fact]
        public void TestSerializePureTextMessage()
        {
            var serializer = new WechatXmlSerializer();
            var message = new TestTextMessage
            {
                Content = "hello",
                CreateTime = 11223,
                FromUserName = "<Lu>",
                ToUserName = "Rongkai",
                Subs = new Sub[]
                {
                    new Sub(), new Sub(), 
                }
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
                @"<xml>
  <ToUserName>Rongkai</ToUserName>
  <FromUserName>&lt;Lu&gt;</FromUserName>
  <CreateTime>11223</CreateTime>
  <MsgType>text</MsgType>
  <MsgId>11223</MsgId>
  <Content>hello</Content>
  <ssss>
    <dd>
      <X>8/26/2015 11:56:06 PM</X>
    </dd>
    <dd>
      <X>8/26/2015 11:56:06 PM</X>
    </dd>
  </ssss>
</xml>";

            var serializer = new WechatXmlSerializer();

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
            Assert.Equal(message.FromUserName, "<Lu>");
            Assert.Equal(message.CreateTime, 11223);
        }
    }
    
    public class TestTextMessage
    {
        [Node("ToUserName")]
        public string ToUserName { get; set; }

        [Node("FromUserName")]
        public string FromUserName { get; set; }

        [Node("CreateTime")]
        public int CreateTime { get; set; }

        [Node("MsgType")]
        public string MsgType => "text";

        [Node("MsgId")]
        public long MsgId => 11223;

        [Node("Content")]
        public string Content { get; set; }

        [Array("ssss")]
        [ArrayItem("dd", typeof(Sub))]
        public Sub[] Subs { get; set; }
    }

    public class Sub
    {
        public string X => DateTime.Now.ToString();
    }
}