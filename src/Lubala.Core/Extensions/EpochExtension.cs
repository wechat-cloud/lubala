using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubala.Core
{
    public static class EpochExtension
    {
        private static DateTimeOffset _unixBegin = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        public static long DateTimeToEpoch(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.Ticks - _unixBegin.Ticks;
        }

        public static DateTimeOffset EpochToDateTime(this long diff)
        {
            return _unixBegin.AddTicks(diff);
        }
    }
}
