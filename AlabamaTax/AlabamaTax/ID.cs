using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class ID
    {
        /// <summary>
        /// New unique identifier suitable for use as TransmissionID.
        /// </summary>
        /// <returns></returns>
        public static string New()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 30);
        }
    }
}
