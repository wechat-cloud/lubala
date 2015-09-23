using System;
using System.Text;
using System.Threading.Tasks;
using Debugger = System.Diagnostics.Debug;

namespace Lubala.Core.Logs
{
    internal class DebugLogger : ILogger
    {
        public Task Debug(string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Debug", messageOrFormat, propertyValues);
        }

        public Task Debug(Exception exception, string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Debug", exception, messageOrFormat, propertyValues);
        }

        public Task Info(string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Info", messageOrFormat, propertyValues);
        }

        public Task Info(Exception exception, string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Info", exception, messageOrFormat, propertyValues);
        }

        public Task Error(string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Error", messageOrFormat, propertyValues);
        }

        public Task Error(Exception exception, string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Error", exception, messageOrFormat, propertyValues);
        }

        public Task Fatal(string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Fatal", messageOrFormat, propertyValues);
        }

        public Task Fatal(Exception exception, string messageOrFormat, params string[] propertyValues)
        {
            return WriteMessage("Fatal", exception, messageOrFormat, propertyValues);
        }

        private Task WriteMessage(string level, string messageOrFormat, params string[] propertyValues)
        {
            var raw = messageOrFormat.FormatWith(propertyValues);
            var message = "[{0}]{1}: {2}".FormatWith(level, NowDateTime(), raw);

            return Task.Factory.StartNew(() => { Debugger.WriteLine(message); });
        }

        private Task WriteMessage(string level, Exception exception, string messageOrFormat,
            params string[] propertyValues)
        {
            var raw = messageOrFormat.FormatWith(propertyValues);
            var message = "[{0}]{1}: {2}".FormatWith(level, NowDateTime(), raw);

            var exceptionMessage = FormatException(exception, level);

            return Task.Factory.StartNew(() =>
            {
                Debugger.WriteLine(message);
                Debugger.WriteLine(exceptionMessage);
            });
        }

        private string NowDateTime()
        {
            var now = DateTime.Now;
            return now.ToString("yyyy-MM-dd hh:mm:ss fff");
        }

        private string FormatException(Exception exception, string level)
        {
            var sb = new StringBuilder();

            var exceptionMessage = exception.Message;
            var exceptionStackTrace = exception.StackTrace;

            sb.AppendLine("[{0}]-> {1}".FormatWith(level, exceptionMessage));
            sb.AppendLine(exceptionStackTrace);

            return sb.ToString();
        }
    }
}