using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lubala.Core.Pushing.Tests
{
    public class MessageTypeDetectorTest
    {
        [Fact]
        public void TestTypeParseCorrectly()
        {
            var testXml = @"
<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
</xml>";
            var detector = new TypeDetector(testXml);
            var type = detector.Detecting();

            Assert.Equal(type.MsgType, "text");
            Assert.Equal(type.EventType, null);
        }
    }
}
