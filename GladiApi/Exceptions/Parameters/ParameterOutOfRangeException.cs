using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    /// <summary>
    /// Thrown when a method parameter exceeds allowed bounds
    /// </summary>
    public class ParameterOutOfRangeException : Exception
    {
        public ParameterOutOfRangeException(string msg) : base(msg) { }
    }
}
