using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.Mp.Messages;
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
            var pureTextMessage = new PureTextMessage
            {
                Content = "hello",
                CreateTime = 11223,
                FromUserName = "Lu",
                ToUserName = "Rongkai"
            };

            using (var stream = new MemoryStream())
            {
                serializer.Serialize(pureTextMessage, stream);
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
            var xml = @"<xml><ToUserName>Rongkai</ToUserName><FromUserName>Lu</FromUserName><CreateTime>11223</CreateTime><Content>hello</Content></xml>";

            var serializer = new DefaultXmlSerializer();

            PureTextMessage message;
            using (var stream = new MemoryStream())
            {
                using(var writer = new StreamWriter(stream))
                {
                    writer.WriteLine(xml);
                    writer.Flush();
                    stream.Position = 0;
                    message = serializer.Deserialize<PureTextMessage>(stream);
                }
            }

            Assert.Equal(message.Content, "hello");
            Assert.Equal(message.ToUserName, "Rongkai");
            Assert.Equal(message.FromUserName, "Lu");
            Assert.Equal(message.CreateTime, 11223);
        }
    }
}
