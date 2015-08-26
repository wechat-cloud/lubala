using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lubala.Core.Pushing.Tests
{
    public class TypeIdentityTest
    {
        [Fact]
        public void TestEqual()
        {
            var a = new TypeIdentity {MsgType = "a", EventType = null};
            var b = new TypeIdentity { MsgType = "a", EventType = null };

            Assert.Equal(a, b);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        [Fact]
        public void TestNotEqual()
        {
            var a = new TypeIdentity { MsgType = "a", EventType = "" };
            var b = new TypeIdentity { MsgType = "a", EventType = null };

            Assert.NotEqual(a, b);
            Assert.NotEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}
