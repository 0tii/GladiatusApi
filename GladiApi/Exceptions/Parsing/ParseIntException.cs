using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    public class ParseIntException : Exception
    {
        public ParseIntException(string? message) : base(message)
        {
        }
    }
}
