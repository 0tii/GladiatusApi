using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    /// <summary>
    /// Thrown when an element that was previously present could not be found in the document, probably due to the document structure having been changed.
    /// </summary>
    public class HtmlFormatChangedException : Exception
    {
        public HtmlFormatChangedException(string? msg): base(msg)
        {
        }
    }
}
