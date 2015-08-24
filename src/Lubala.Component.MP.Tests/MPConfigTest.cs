using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Component.MP.Messages;
using Lubala.Core.Pushing;
using Moq;
using Xunit;

namespace Lubala.Component.MP.Tests
{
    public class MPConfigTest
    {
        [Fact]
        public void TestMessageHandlerSetupCorrectly()
        {
            var moq = new Mock<IHubBuilder>();
            var config = new MPConfigurer(moq.Object);

            var moqMessageHandler = new Mock<MPMessageHandler<RawImageMessage, PureTextMessage>>();
            config.RegisterMessageHandler(moqMessageHandler.Object);
            moq.Verify(x => x.RegisterMessageHandler(It.IsAny<Type>(), It.IsAny<IMessageHandler>()), Times.Exactly(1));

            config.RegisterMessageHandler<RawImageMessage>((image, context) => new PureTextMessage());
            moq.Verify(x => x.RegisterMessageHandler(It.IsAny<Type>(), It.IsAny<IMessageHandler>()), Times.Exactly(2));
        }
    }
}
