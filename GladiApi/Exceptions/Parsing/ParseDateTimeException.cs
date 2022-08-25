using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    public class ParseDateTimeException : Exception
    {
        public ParseDateTimeException(string? message) : base(message)
        {
        }
    }
}
