using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public static class BoolExtensions
    {
        public static int ToInt(this bool self) => self ? 1 : 0;
        public static string ToIntString(this bool self) => self ? "1" : "0";
    }
}
