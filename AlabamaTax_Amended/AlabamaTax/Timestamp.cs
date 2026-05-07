using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class Timestamp
    {
        public static DateTime Now
        {
            get
            {
                DateTime now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, DateTimeKind.Local);
            }
        }
    }
}
