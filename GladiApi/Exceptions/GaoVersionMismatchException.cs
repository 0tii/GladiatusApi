using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    internal class GaoVersionMismatchException : Exception
    {
        public GaoVersionMismatchException(string? msg) : base(msg)
        {
        }
    }
}
