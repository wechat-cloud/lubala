using System;
using System.IO;
using Lubala.Core.Pushing;
using Lubala.Core.Serialization;

namespace Lubala.Component.Mp.Messages
{
	public abstract class MpPassiveMessage : PushingMessage, IPassiveMessage
    {
        public string Serialize(IXmlSerializer xmlSerializer)
	    {
            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(this, stream);
                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
	    }
	}
}

