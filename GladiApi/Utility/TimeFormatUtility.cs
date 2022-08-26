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
                vals[i] = ZeroPad(vals[i].Trim());
            return string.Join(',', vals);
        }

        private static string ZeroPad(string str)
        {
            if (str.Length == 1) return $"0{str}";
            return str;
        }
    }
}
