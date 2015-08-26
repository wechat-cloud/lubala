using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lubala.Core.Pushing.Attributes;
using Lubala.Core.Pushing.Messages;
using Moq;
using Xunit;

namespace Lubala.Core.Pushing.Tests
{
    public class PushingHubTest
    {
        private string testXml = @"
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

            var moqPassive = new Mock<IPassiveMessage>();
            moqPassive
                .Setup(x => x.Serialize())
                .Returns("success");
            var handler = new Mock<IMessageHandler>();
            handler
                .Setup(x => x.HandleMessage(It.IsAny<IPushingMessage>(), It.IsAny<MessageContext>()))
                .Returns(moqPassive.Object);

            builder.RegisterMessageType<TestTextMessage>();
            builder.RegisterMessageHandler(typeof (TestTextMessage), handler.Object);

            var ph = builder.BuildPushingHub();

            var result = ph.Interpreting(testXml);

            Assert.Equal(result, "");
            moqPassive.Verify(x => x.Serialize(), Times.Never);
        }

        [Fact]
        public void TestInterpretingWithHandler()
        {
            var moqChannel = new Mock<ILubalaChannel>();
            moqChannel.SetupGet(c => c.Resolver).Returns(TypeResolver.Resolver);

            var builder = new HubBuilder(moqChannel.Object);

            var moqPassive = new Mock<IPassiveMessage>();
            moqPassive
                .Setup(x => x.Serialize())
                .Returns("success");
            
            builder.RegisterMessageType<TestTextMessage>();
            builder.RegisterMessageHandler(typeof(TestTextMessage), new TestTextHandler());

            var ph = builder.BuildPushingHub();

            var result = ph.Interpreting(testXml);

            Assert.Equal(result, "");
            moqPassive.Verify(x => x.Serialize(), Times.Never);
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
        [XmlElement("CreateTime", typeof(long))]
        public long MsgId { get; }
        [XmlElement("Content")]
        public string Content { get; set; }
    }

    public class TestTextHandler : IMessageHandler
    {
        public IPassiveMessage HandleMessage(IPushingMessage incomingMessage, MessageContext context)
        {
            Assert.Equal(context.SupportPassiveMessage, false);
            Assert.Equal(context.MsgType, "text");
            Assert.Equal(context.EventType, null);
            Assert.NotNull(context.Raw);
            Assert.NotNull(incomingMessage);

            return null;
        }
    }
}
