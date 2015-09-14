using System;
using System.IO;
using System.Threading.Tasks;
using Lubala.Core.Serialization;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Pushing
{
	public abstract class XmlPassiveMessage : PassiveMessage
	{
		[Node("ToUserName")]
		internal string ToUserName { get; set; }

		[Node("FromUserName")]
		internal string FromUserName { get; set; }

		[Node("CreateTime")]
		internal long CreateTime { get; set; }

		[Node("MsgType")]
		internal abstract string MsgType { get; }
	}
}