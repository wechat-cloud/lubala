using System;
using Lubala.Core.Pushing;
using Lubala.Core.Pushing.Messages;
using Moq;
using Xunit;

namespace Lubala.Component.Mp.Tests
{
    public class MpConfigTest
    {
        [Fact]
        public void TestMessageHandlerSetupCorrectly()
        {
            var moq = new Mock<IHubBuilder>();
            var config = new MpConfigurer(moq.Object);

            var moqMessageHandler = new Mock<MPMessageHandler<RawImageMessage, PassiveTextMessage>>();
            config.RegisterMessageHandler(moqMessageHandler.Object);
            moq.Verify(x => x.RegisterMessageHandler(It.IsAny<Type>(), It.IsAny<IMessageHandler>()), Times.Exactly(1));

            config.RegisterMessageHandler<RawImageMessage>((image, context) => new PassiveTextMessage());
            moq.Verify(x => x.RegisterMessageHandler(It.IsAny<Type>(), It.IsAny<IMessageHandler>()), Times.Exactly(2));
        }
    }
}