using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MvcApplication1.Library
{
    public class DateHelper
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly string dateFormat = "dd/MM/yyyy";
        public static Int64 getMillisecondsFromEpoch()
        {
            return (Int64)DateTime.Now.Subtract(epoch).TotalMilliseconds;
        }
        public static DateTime convertToDateTime(Int64 time)
        {
            return epoch.AddMilliseconds(time);
        }
        public static Int64 getMillisecondsFromEpoch(string date)
        {
            DateTime t;
            DateTime.TryParseExact(date, dateFormat, null, DateTimeStyles.None, out t);
            return (Int64)t.Subtract(epoch).TotalMilliseconds;
        }
        
    }
}