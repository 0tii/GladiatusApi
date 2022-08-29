using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public static class StringExtensions
    {
        public static int ExtractInteger(this string str)
        {
            string result = string.Empty;
            bool readNumber = false;

            foreach (char c in str)
                if (char.IsDigit(c))
                {
                    readNumber = true;
                    result += c;
                }
                else
                    if (readNumber && !char.IsDigit(c))
                    break;

            return int.Parse(result);
        }

        public static int[] ExtractIntegers(this string str)
        {
            bool readingNumber = false;
            string current = string.Empty;
            List<int> result = new();

            foreach(char c in str)
                if (char.IsDigit(c))
                {
                    readingNumber = true;
                    current += c;
                }
                else
                    if (readingNumber && !char.IsDigit(c))
                    {
                        result.Add(int.Parse(current));
                        current = string.Empty;
                        readingNumber = false;
                    }

            return result.ToArray();
        }
    }
}
