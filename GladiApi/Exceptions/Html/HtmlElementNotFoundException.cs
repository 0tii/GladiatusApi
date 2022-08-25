using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi.Exceptions
{
    internal class HtmlElementNotFoundException: Exception
    {
        public HtmlElementNotFoundException(string? msg): base(msg) { }
    }
}
