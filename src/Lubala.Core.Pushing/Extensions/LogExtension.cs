using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lubala.Core.Pushing.Messages;

namespace Lubala.Core.Pushing.Extensions
{
    internal static class LogExtension
    {
        public static string Format(this IPassiveMessage message, HubContext context)
        {
            using (var stream = new MemoryStream())
            {
                message.SerializeTo(stream, context);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
