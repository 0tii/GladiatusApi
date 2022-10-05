using System.Text;

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

        /// <summary>
        /// Decodes a base64 string. Assumes the string is valid base64.
        /// </summary>
        /// <returns>the decoded string</returns>
        public static string FromBase64(this string str)
        {
            byte[] data = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(data);
        }
        
        public static string ToBase64(this string str)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static bool IsValidBase64(this string str)
        {
            Span<byte> buffer = new Span<byte>(new byte[str.Length]);
            return Convert.TryFromBase64String(str, buffer, out int bytesParsed);
        }
    }
}
