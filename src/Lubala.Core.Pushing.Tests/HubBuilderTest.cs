using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;
using Lubala.Core.Resolvers;
using Moq;
using Xunit;

namespace Lubala.Core.Pushing.Tests
{
    public class HubBuilderTest
    {
        [Fact]
        public void TestRegisterMessageType()
        {
            var moqChannel = new Mock<ILubalaChannel>();
            moqChannel.SetupGet(c => c.Resolver).Returns(TypeResolver.Resolver);

            var builder = new HubBuilder(moqChannel.Object);

            Assert.Throws<InvalidOperationException>(() =>
            {
                builder.RegisterMessageType<FakeMessage>();
            });
        }

        [Fact]
        public void TestRegisterMessageHandler()
        {
            var moqChannel = new Mock<ILubalaChannel>();
            moqChannel.SetupGet(c => c.Resolver).Returns(TypeResolver.Resolver);

            var builder = new HubBuilder(moqChannel.Object);

            Assert.Throws<ArgumentNullException>(() =>
            {
                builder.RegisterMessageHandler(typeof(FakeMessage), null);
            });

            var moqHandler = new Mock<IMessageHandler>();
            builder.RegisterMessageHandler(typeof (FakeMessage), moqHandler.Object);

            builder.BuildPushingHub();
        }
    }

    public class FakeMessage : PushingMessage
    {
        public override string MsgType { get; }
    }
}
