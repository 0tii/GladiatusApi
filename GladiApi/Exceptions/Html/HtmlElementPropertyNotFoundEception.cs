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
    internal class HtmlAttributeNotFoundEception : Exception
    {
        public HtmlAttributeNotFoundEception(string? message) : base(message)
        {
        }
    }
}
