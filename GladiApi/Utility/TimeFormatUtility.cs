using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public static class TimeFormatUtility
    {
        /// <summary>
        /// makes gladiatus server time string reliably parseable by zero-padding single digit datetime values
        /// </summary>
        public static string PrepareDateString(string dt)
        {
            string[] vals = dt.Split(',');
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = ZeroPadExact(vals[i].Trim(), 2);
            }

            if (vals[^1].Length < 3)
                vals[^1] = ZeroPadExact(vals[^1], 3);

                return string.Join(',', vals);
        }

        private static string ZeroPadExact(string str, int targetLength)
        {
            while (str.Length < targetLength)
                str = $"0{str}";
            return str;
        }
    }
}
