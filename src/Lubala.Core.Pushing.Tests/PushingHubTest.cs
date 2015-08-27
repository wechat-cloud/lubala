using System;
using System.IO;
using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Resolvers;
using Lubala.Core.Serialization;
using Moq;
using Xunit;

namespace Lubala.Core.Pushing.Tests
{
    public class PushingHubTest
    {
        private readonly string testXml = @"
<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
</xml>";

        [Fact]
        public void TestInterpreting()
        {
            var moqChannel = new Mock<ILubalaChannel>();
            moqChannel.SetupGet(c => c.Resolver).Returns(TypeResolver.Resolver);

            var builder = new HubBuilder(moqChannel.Object);

            var serializerMoq = new Mock<IXmlSerializer>();
            serializerMoq.Setup(x => x.Serialize(It.IsAny<object>(), It.IsAny<Stream>()));

            var moqPassive = new Mock<IPassiveMessage>();
            moqPassive
                .Setup(x => x.Serialize(serializerMoq.Object))
                .Returns("success");
            var handler = new Mock<IMessageHandler>();
            handler
                .Setup(x => x.HandleMessage(It.IsAny<IPushingMessage>(), It.IsAny<MessageContext>()))
                .Returns(moqPassive.Object);

            builder.RegisterMessageType<TestTextMessage>();
            builder.RegisterMessageHandler(typeof (TestTextMessage), handler.Object);

            var ph = builder.BuildPushingHub();

            using (var t = StringStream.Create(testXml))
            {
                using (var fakeTargetStream = new MemoryStream())
                {
                    ph.Interpreting(t.Stream, fakeTargetStream, null);

                    fakeTargetStream.Position = 0;
                    using (var reader = new StreamReader(fakeTargetStream))
                    {
                        var result = reader.ReadToEnd();
                        Assert.Equal(result, "");
                    }
                    moqPassive.Verify(x => x.Serialize(It.IsAny<IXmlSerializer>()), Times.Never);
                }
            }
        }

        [Fact]
        public void TestInterpretingWithHandler()
        {
            var moqChannel = new Mock<ILubalaChannel>();
            moqChannel.SetupGet(c => c.Resolver).Returns(TypeResolver.Resolver);

            var builder = new HubBuilder(moqChannel.Object);

            var serializerMoq = new Mock<IXmlSerializer>();
            serializerMoq.Setup(x => x.Serialize(It.IsAny<object>(), It.IsAny<Stream>()));

            var moqPassive = new Mock<IPassiveMessage>();
            moqPassive
                .Setup(x => x.Serialize(serializerMoq.Object))
                .Returns("success");

            builder.RegisterMessageType<TestTextMessage>();
            builder.RegisterMessageHandler(typeof (TestTextMessage), new TestTextHandler());

            var ph = builder.BuildPushingHub();

            using (var t = StringStream.Create(testXml))
            {
                using (var fakeTargetStream = new MemoryStream())
                {
                    ph.Interpreting(t.Stream, fakeTargetStream, null);

                    fakeTargetStream.Position = 0;
                    using (var reader = new StreamReader(fakeTargetStream))
                    {
                        var result = reader.ReadToEnd();
                        Assert.Equal(result, "");
                    }
                    moqPassive.Verify(x => x.Serialize(It.IsAny<IXmlSerializer>()), Times.Never);
                }
            }
        }
    }

    [Serializable]
    [MsgType("text")]
    [XmlRoot("xml")]
    public class TestTextMessage : IPushingMessage
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

    public class TestTextHandler : IMessageHandler
    {
        public IPassiveMessage HandleMessage(IPushingMessage incomingMessage, MessageContext context)
        {
            Assert.Equal(context.SupportPassiveMessage, false);
            Assert.Equal(context.TypeIdentity.MsgType, "text");
            Assert.Equal(context.TypeIdentity.EventType, null);
            Assert.NotNull(context.Raw);
            Assert.NotNull(incomingMessage);

            return null;
        }
    }
}