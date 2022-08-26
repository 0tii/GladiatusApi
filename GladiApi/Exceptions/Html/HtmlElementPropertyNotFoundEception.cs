using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    /// <summary>
    /// Thrown when an element property query fails for a given selector
    /// </summary>
    internal class HtmlAttributeNotFoundException : Exception
    {
        public HtmlAttributeNotFoundException(string? message) : base(message)
        {
        }
    }
}
