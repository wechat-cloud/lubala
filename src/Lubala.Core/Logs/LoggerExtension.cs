using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Lubala.Core.Logs
{
    public static class LoggerExtension
    {
        public static string FormatWith(this string messageOrFormat, params string[] propertyValues)
        {
            if (propertyValues.Length == 0)
            {
                return messageOrFormat;
            }
            return string.Format(messageOrFormat, propertyValues);
        }

        public static string ToStringWithDeclaration(this XDocument doc)
        {
            if (doc == null)
            {
                throw new ArgumentNullException(nameof(doc));
            }
            var builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                doc.Save(writer);
            }
            return builder.ToString();
        }
    }
}