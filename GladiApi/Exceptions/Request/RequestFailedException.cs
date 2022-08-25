using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    /// <summary>
    /// This exception gets thrown when a Http request returns with a non-2xx status code.
    /// </summary>
    public class RequestFailedException : Exception
    {
        public RequestFailedException(string? message) : base(message)
        {
        }
    }
}
