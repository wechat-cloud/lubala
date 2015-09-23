using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core.Logs
{
    public interface ILogger
    {
        Task Debug(string messageOrFormat, params string[] propertyValues);
        Task Debug(Exception exception, string messageOrFormat, params string[] propertyValues);

        Task Info(string messageOrFormat, params string[] propertyValues);
        Task Info(Exception exception, string messageOrFormat, params string[] propertyValues);

        Task Error(string messageOrFormat, params string[] propertyValues);
        Task Error(Exception exception, string messageOrFormat, params string[] propertyValues);

        Task Fatal(string messageOrFormat, params string[] propertyValues);
        Task Fatal(Exception exception, string messageOrFormat, params string[] propertyValues);
    }
}
