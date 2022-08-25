using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    /// <summary>
    /// Thrown when a document query fails for the given selector
    /// </summary>
    internal class HtmlElementNotFoundException: Exception
    {
        public HtmlElementNotFoundException(string? msg): base(msg) { }
    }
}
