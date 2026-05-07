using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    public class Version
    {
        private const int major = 7;
        private const int minor = 2;
        private const int fix = 0;
        public static string Current()
        {
            return String.Format("{0:D2}{1:D2}{2:D2}", major, minor, fix);
        }
        public static string Pretty()
        {
            return String.Format("{0}.{1}.{2}", major, minor, fix);
        }
    }
}
